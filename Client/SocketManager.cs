//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="SocketManager.cs" company="Company">
//    Copyright (c) Company. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------
namespace Client
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    public class SocketManager
    {
        private Socket socket;

        // private const string Url = "10.33.192.135";

        private const int PortNumber = 4243;

        public void StartSocket(string server)
        {
            this.socket = GetConnectedSocket(server, PortNumber);
            
            this.ListenToIncomingData();
        }

        public void SendDataToServer(string dataToSend)
        {
            var bytesToSend = Encoding.ASCII.GetBytes(dataToSend);

            this.socket.Send(bytesToSend);
        }

        private static Socket GetConnectedSocket(string server, int port)
        {
            Socket result = null;

            // Get host related information.
            var hostEntry = Dns.GetHostEntry(server);

            // Loop through the AddressList to obtain the supported AddressFamily. This is to avoid
            // an exception that occurs when the host IP Address is not compatible with the address family
            // (typical in the IPv6 case).
            foreach (var address in hostEntry.AddressList)
            {
                var ipe = new IPEndPoint(address, port);
                var tempSocket = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    tempSocket.Connect(ipe);

                    if (tempSocket.Connected)
                    {
                        result = tempSocket;
                        break;
                    }
                }
                catch
                {
                }
            }

            return result;
        }

        private void ListenToIncomingData()
        {
            var bytes = new byte[256];

            var receiveEvent = new SocketAsyncEventArgs();
            receiveEvent.Completed += this.AcceptReceive;
            receiveEvent.SetBuffer(bytes, 0, 256);

            if (!this.socket.ReceiveAsync(receiveEvent))
            {
                this.AcceptReceive(this.socket, receiveEvent);
            }
        }

        private void AcceptReceive(object sender, SocketAsyncEventArgs e)
        {
            var dataReceived = Encoding.ASCII.GetString(e.Buffer, e.Offset, e.Count);

            Console.WriteLine("Received: " + dataReceived);

            this.ListenToIncomingData();
        }
    }
}