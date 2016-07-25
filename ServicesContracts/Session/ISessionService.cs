// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISessionService.cs" Company="Company">
//   Copyright (c) Company. All rights reserved.
// </copyright>
// <summary>
//   Defines the ISessionService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServicesContracts.Session
{
    using System;

    using DalContracts.Entities;

    public interface ISessionService
    {
        Session Create();

        void Delete(Session session);

        Session Get(Guid guid);

        void AddInSession(Session session, Guid playerGuid);
    }
}