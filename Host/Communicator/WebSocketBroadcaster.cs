// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebSocketBroadcaster.cs" Company="">
//   
// </copyright>
// <summary>
//   The communicator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Host.Communicator
{
    using System;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Net;
    using System.Net.WebSockets;
    using System.Threading;
    using System.Threading.Tasks;

    using DalContracts.Entities;

    using Dto.Response;
    using Dto.Send;
    
    using Shared.Serializers;

    /// <summary>
    /// The communicator.
    /// </summary>
    public class WebSocketBroadcaster
    {
        private readonly Session session;

        private readonly IBinarySerializer serializer;

        private readonly ConcurrentDictionary<Guid, WebSocketCommunicator> webSocketList;

        public WebSocketBroadcaster(Session session, IBinarySerializer serializer)
        {
            this.session = session;
            this.serializer = serializer;
            this.webSocketList = new ConcurrentDictionary<Guid, WebSocketCommunicator>();
        }

        public async void StartListeningToIncomingRequests()
        {
            var listener = new HttpListener();
            listener.Prefixes.Add(this.FormatSessionUri());
            listener.Start();

            while (true)
            {
                var listenerContext = await listener.GetContextAsync();

                if (listenerContext.Request.IsWebSocketRequest)
                {
                    this.ProcessIncomingRequest(listenerContext);
                }
                else
                {
                    listenerContext.Response.StatusCode = 400;
                    listenerContext.Response.Close();
                }
            }
        }

        private async Task ProcessIncomingRequest(HttpListenerContext listenerContext)
        {
            try
            {
                var webSocketContext = await listenerContext.AcceptWebSocketAsync(null);

                var communicator = new WebSocketCommunicator(webSocketContext);

                Player player = null;
                var playerGuid = await this.ListenToIncomingPlayerGuid(communicator);
                if (playerGuid != Guid.Empty)
                {
                    player = this.session.Players.FirstOrDefault(p => p.Guid == playerGuid);
                }

                if (player == null)
                {
                    communicator.CloseAsync(WebSocketCloseStatus.NormalClosure, "No player found", CancellationToken.None).Start();
                    return;
                }

                communicator.Player = player;

                this.webSocketList.TryAdd(playerGuid, communicator);

                this.StartListeningToIncomingMessages(communicator).Start();
            }
            catch (Exception)
            {
                listenerContext.Response.StatusCode = 500;
                listenerContext.Response.Close();
            }
        }

        private async Task StartListeningToIncomingMessages(WebSocketCommunicator communicator)
        {
            try
            {
                var receiveBuffer = new byte[1024];

                while (communicator.IsListening())
                {
                    // * `WebSocketReceiveResult.MessageType` - What type of data was received and written to the provided buffer. Was it binary, utf8, or a close message?                
                    // * `WebSocketReceiveResult.Count` - How many bytes were read?                
                    // * `WebSocketReceiveResult.EndOfMessage` - Have we finished reading the data for this message or is there more coming?
                    var receiveResult = await communicator.ReceiveAsync(new ArraySegment<byte>(receiveBuffer), CancellationToken.None);

                    if (receiveResult.MessageType == WebSocketMessageType.Close)
                    {
                        await communicator.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                    }
                    else
                    {
                        this.SendToOthers(communicator, receiveBuffer, receiveResult);
                    }
                }
            }
            finally
            {
                this.webSocketList.TryRemove(communicator.Player.Guid, out communicator);
                communicator.Dispose();
            }
        }

        private async Task<Guid> ListenToIncomingPlayerGuid(WebSocketCommunicator communicator)
        {
            var buffer = this.serializer.Serialize(new GetPlayerGuidRequestDto());

            await communicator.SendAsync(
                    new ArraySegment<byte>(buffer),
                    WebSocketMessageType.Binary,
                    false,
                    CancellationToken.None);

            buffer = new byte[64];
            await communicator.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            var response = this.serializer.Deserialize<GetPlayerGuidResponseDto>(buffer);

            return response?.Guid ?? Guid.Empty;
        }

        private void SendToOthers(WebSocketCommunicator source, byte[] buffer, WebSocketReceiveResult result)
        {
            var dataToSend = new ArraySegment<byte>(buffer, 0, result.Count);

            foreach (var webSocketDestination in this.webSocketList)
            {
                if (source.Player.Guid != webSocketDestination.Key)
                {
                    webSocketDestination.Value.SendAsync(
                        dataToSend,
                        result.MessageType,
                        result.EndOfMessage,
                        CancellationToken.None);
                }
            }
        }

        private string FormatSessionUri()
        {
            return $"http://localhost:4242/{this.session.Guid}/";
        }
    }
}