﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SessionService.cs" Company="Company">
//   Copyright (c) Company. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Services.Session
{
    using System;
    using System.Diagnostics.Contracts;

    using Dal.Session;

    using DalContracts;
    using DalContracts.Entities;
    using DalContracts.Session;

    using Services.Player;

    using ServicesContracts.Player;
    using ServicesContracts.Session;

    public class SessionService : ISessionService
    {
        private readonly ISessionRepository sessionRepository;

        private readonly IPlayerService playerService;

        private readonly IUnitOfWork unitOfWork;

        public SessionService()
            : this(new SessionRepository(), new PlayerService(), new UnitOfWork())
        {
        }

        public SessionService(ISessionRepository sessionRepository, IPlayerService playerService, IUnitOfWork unitOfWork)
        {
            this.sessionRepository = sessionRepository;
            this.playerService = playerService;
            this.unitOfWork = unitOfWork;
        }

        public Session Create()
        {
            var result = new Session(Guid.NewGuid());
            
            this.sessionRepository.Add(result);

            this.unitOfWork.Save();

            return result;
        }

        public void Delete(Session session)
        {
            Contract.Requires(session != null);

            this.sessionRepository.Remove(session);

            this.unitOfWork.Save();
        }

        public Session Get(Guid guid)
        {
            Contract.Requires(guid != Guid.Empty);

            return this.sessionRepository.Get(guid);
        }

        public void AddInSession(Session session, Guid playerGuid)
        {
            throw new NotImplementedException();
        }
    }
}