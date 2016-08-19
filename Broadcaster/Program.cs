//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Program.cs" company="Eurofins">
//    Copyright (c) Eurofins. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------
namespace Broadcaster
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var broadcaster = new BroadcastServer();

            broadcaster.StartSocket();

            while (true)
            {
            }
        }
    }
}