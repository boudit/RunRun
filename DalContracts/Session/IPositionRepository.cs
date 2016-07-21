// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPositionRepository.cs" company="Company">
//   Copyright (c) Company. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace DalContracts.Session
{
    using System;
    using System.Collections.Generic;

    using Entities;

    public interface IPositionRepository
    {
        void AddInSession(Session session, Player player);

        void SetPosition(Guid sessionGuid, Guid playerGuid, Position position);

        IEnumerable<Position> GetPositionsOfOthersInSession(Guid sessionGuid, Guid requesterGuid, uint lastTimeSpent);
    }
}