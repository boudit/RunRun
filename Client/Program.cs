using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;

    class Program
    {
        private System.Net.Sockets.Socket socketListener;

        public static void Main(String[] args)
        {
            //RunClientTcp();
            var host = Dns.GetHostName();

            var sender = new SocketManager();
            sender.StartSocket(host);
            
            long index = 0;
            while (true)
            {
                Thread.Sleep(30);
                sender.SendDataToServer((index++).ToString());
            }
        }
        
        private static void RunClientTcp()
        {
            try
            {
                TcpClient client = new TcpClient("10.33.193.38", 4243);

                NetworkStream ns = client.GetStream();

                Guid id = Guid.NewGuid();
                Console.WriteLine("I am : " + id.ToString());

                while (true)
                {
                    Console.WriteLine("Sending: Hello From " + id.ToString());
                    SendMessage(ns, "Hello From " + id.ToString());

                    byte[] bytes = new byte[1024];
                    int bytesRead = ns.Read(bytes, 0, bytes.Length);

                    Console.WriteLine("Receiving: " + Encoding.ASCII.GetString(bytes, 0, bytesRead));
                }

                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.Read();
        }

        private static void SendMessage(NetworkStream stream, string message)
        {
            var msg = System.Text.Encoding.ASCII.GetBytes(message);
            
            stream.Write(msg, 0, msg.Length);
        }
    }
}
