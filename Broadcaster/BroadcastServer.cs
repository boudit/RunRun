//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="BroadcastServer.cs" company="Company">
//    Copyright (c) Company. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------
namespace Broadcaster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    public class BroadcastServer
    {
        private TcpListener tcpListener;

        private Socket socketListener;

        private const int PortNumber = 4243;
        
        private readonly List<Client> connectedClients;

        public BroadcastServer()
        {
            this.connectedClients = new List<Client>();
        }

        public void StartSocket()
        {
            this.socketListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
            this.socketListener.Bind(new IPEndPoint(IPAddress.Any, PortNumber));
            this.socketListener.Listen(100);

            this.ListenToIncomingConnection();
        }
        
        private void ListenToIncomingConnection()
        {
            var acceptEvent = new SocketAsyncEventArgs();
            acceptEvent.Completed += this.AcceptCallback;

            if (!this.socketListener.AcceptAsync(acceptEvent))
            {
                this.AcceptCallback(this.socketListener, acceptEvent);
            }
        }

        public void AcceptCallback(object sender, SocketAsyncEventArgs acceptEvent)
        {
            Console.WriteLine("New Connection");

            try
            {
                var clientSocket = acceptEvent.AcceptSocket;

                if (clientSocket != null)
                {
                    var newClient = new Client(clientSocket);
                    newClient.OtherClients.AddRange(this.connectedClients);

                    this.connectedClients.ForEach(cl => cl.OtherClients.Add(newClient));
                    this.connectedClients.Add(newClient);
                }
            }
            catch
            {
                // handle any exceptions here;
            }
            finally
            {
                acceptEvent.AcceptSocket = null; // to enable reuse
            }

            this.ListenToIncomingConnection();
        }

        //public void StartTcp()
        //{
        //    try
        //    {
        //        this.tcpListener = new TcpListener(this.GetLocalIpAddress(), PortNumber);

        //        this.tcpListener.Start();

        //        while (true)
        //        {
        //            Console.Write("Waiting for a connection... ");

        //            // Perform a blocking call to accept requests.
        //            // You could also user server.AcceptSocket() here.
        //            var client = this.tcpListener.AcceptTcpClientAsync().Result;

        //            this.connectedTcpClients.Add(client);

        //            this.ProcessNewClient(client);
        //        }
        //    }
        //    catch (SocketException e)
        //    {
        //        Console.WriteLine("SocketException: {0}", e);
        //    }
        //    finally
        //    {
        //        // Stop listening for new clients.
        //        this.tcpListener.Stop();
        //    }
        //}

        //private void ProcessNewClient(TcpClient client)
        //{
        //    var bytes = new byte[256];
        //    string data = null;

        //    // Get a stream object for reading and writing
        //    var stream = client.GetStream();

        //    int i;

        //    // Loop to receive all the data sent by the client.
        //    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
        //    {
        //        // Translate data bytes to a ASCII string.
        //        data = Encoding.ASCII.GetString(bytes, 0, i);
        //        Console.WriteLine("Received: {0}", data);

        //        // Process the data sent by the client.
        //        data = data.ToUpper();

        //        var msg = Encoding.ASCII.GetBytes(data);

        //        // Send back a response.
        //        stream.Write(msg, 0, msg.Length);
        //        Console.WriteLine("Sent: {0}", data);
        //    }


        //    // Shutdown and end connection
        //    client.Dispose();
        //}

        private IPAddress GetLocalIpAddress()
        {
            var hostName = Dns.GetHostName();
            return Dns.GetHostAddressesAsync(hostName).Result[1];

            //return IPAddress.Parse("127.0.0.1");
        }
    }
}