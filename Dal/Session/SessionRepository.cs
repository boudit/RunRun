// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SessionRepository.cs" Company="Company">
//   Copyright (c) Company. All rights reserved.
// </copyright>
// <summary>
//   Defines the SessionRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Dal.Session
{
    using System;
    using System.Collections.Concurrent;

    using DalContracts.Entities;
    using DalContracts.Session;

    using Shared.Extensions;

    public class SessionRepository : ISessionRepository
    {
        private readonly ConcurrentDictionary<Guid, Session> sessions;

        public SessionRepository()
        {
            this.sessions = new ConcurrentDictionary<Guid, Session>();
        }

        public void Add(Session session)
        {
            this.sessions.TryAdd(session.Guid, session);
        }

        public void Remove(Session session)
        {
            this.sessions.Remove(session.Guid);
        }

        public Session Get(Guid guid)
        {
            Session result;

            if (!this.sessions.TryGetValue(guid, out result))
            {
                return null;
            }

            return result;
        }
    }
}