//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="WebSocketBroadcasterRepository.cs" company="Company">
//    Copyright (c) Eurofins. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------
namespace Host.Communicator
{
    using System;
    using System.Collections.Concurrent;

    using Entities;

    using Shared.Extensions;
    using Shared.Serializers;

    public static class WebSocketBroadcasterRepository
    {
        private static readonly ConcurrentDictionary<Guid, WebSocketBroadcaster> WebSocketList = new ConcurrentDictionary<Guid, WebSocketBroadcaster>();

        public static WebSocketBroadcaster GetFromSession(Guid sessionGuid)
        {
            WebSocketBroadcaster result;

            if (WebSocketList.TryGetValue(sessionGuid, out result))
            {
                return result;
            }

            return null;
        }

        public static WebSocketBroadcaster Create(Session session)
        {
            var result = new WebSocketBroadcaster(session, new BinarySerializer());

            WebSocketList.TryAdd(session.Guid, result);

            return result;
        }

        public static void Remove(Session session)
        {
            WebSocketList.Remove(session.Guid);
        }
    }
}