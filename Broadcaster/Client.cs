//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Client.cs" company="Company">
//    Copyright (c) Company. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------
namespace Broadcaster
{
    using System.Collections.Generic;
    using System.Net.Sockets;
    using System.Text;

    public class Client
    {
        private readonly Socket clientSocket;

        private readonly List<Client> otherClients;

        public Client(Socket clientSocket)
        {
            this.clientSocket = clientSocket;
            this.otherClients = new List<Client>();

            this.ListenToIncomingData();
        }

        public List<Client> OtherClients
        {
            get
            {
                return otherClients;
            }
        }

        private void ListenToIncomingData()
        {
            var bytes = new byte[256];

            var receiveEvent = new SocketAsyncEventArgs();
            receiveEvent.Completed += this.AcceptReceive;
            receiveEvent.SetBuffer(bytes, 0, 256);

            if (!this.clientSocket.ReceiveAsync(receiveEvent))
            {
                this.AcceptReceive(this.clientSocket, receiveEvent);
            }
        }

        private void AcceptReceive(object sender, SocketAsyncEventArgs e)
        {
            var dataReceived = Encoding.ASCII.GetString(e.Buffer, e.Offset, e.Count);
            
            this.SendDataToOtherClients(dataReceived);

            this.ListenToIncomingData();
        }

        private void SendDataToOtherClients(string dataToSend)
        {
            var bytesToSend = Encoding.ASCII.GetBytes(dataToSend.ToUpper());

            this.OtherClients.ForEach(cl => cl.clientSocket.Send(bytesToSend));
        }
    }
}