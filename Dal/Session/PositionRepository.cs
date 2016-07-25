// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PositionRepository.cs" Company="Company">
//   Copyright (c) Company. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Dal.Session
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DalContracts.Entities;
    using DalContracts.Session;

    public class PositionRepository : IPositionRepository
    {
        public void AddInSession(Session session, Player player)
        {
            session.Players.Add(player);
        }

        public void SetPosition(Guid sessionGuid, Guid playerGuid, Position position)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Position> GetPositionsOfOthersInSession(Guid sessionGuid, Guid requesterGuid, uint lastTimeSpent)
        {
            throw new NotImplementedException();
        }
    }
}