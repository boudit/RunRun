// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebSocketCommunicator.cs" company="company">
//   
// </copyright>
// <summary>
//   The web socket communicator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Host.Communicator
{
    using System;
    using System.Net.WebSockets;
    using System.Threading;
    using System.Threading.Tasks;

    using Entities;

    /// <summary>
    /// The web socket communicator.
    /// </summary>
    public class WebSocketCommunicator : IDisposable
    {
        private readonly WebSocket webSocket;

        public WebSocketCommunicator(WebSocketContext webSocketContext)
        {
            this.webSocket = webSocketContext.WebSocket;
        }

        public Player Player { get; set; }

        public Task<WebSocketReceiveResult> ReceiveAsync(ArraySegment<byte> buffer, CancellationToken cancellationToken)
        {
            return this.webSocket.ReceiveAsync(buffer, cancellationToken);
        }

        public Task SendAsync(ArraySegment<byte> buffer, WebSocketMessageType messageType, bool endOfMessage, CancellationToken cancellationToken)
        {
            return this.webSocket.SendAsync(buffer, messageType, endOfMessage, cancellationToken);
        }

        public Task CloseAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken)
        {
            return this.webSocket.CloseAsync(closeStatus, statusDescription, cancellationToken);
        }

        public bool IsListening()
        {
            return this.webSocket.State == WebSocketState.Open;
        }

        public void Dispose()
        {
            this.webSocket.Dispose();
        }
    }
}