// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISessionService.cs" company="Company">
//   Copyright (c) Company. All rights reserved.
// </copyright>
// <summary>
//   Defines the ISessionService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServicesContracts.Session
{
    using System;

    using Entities;

    public interface ISessionService
    {
        Session Create(Player player);

        void Delete(Session session);

        Session Get(Guid guid);

        void AddInSession(Session session, Guid playerGuid);
    }
}