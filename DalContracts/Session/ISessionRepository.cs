// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISessionRepository.cs" company="Company">
//   Copyright (c) Company. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace DalContracts.Session
{
    using System;

    using Entities;

    public interface ISessionRepository
    {
        void Add(Session session);

        void Remove(Session session);

        Session Get(Guid guid);
    }
}