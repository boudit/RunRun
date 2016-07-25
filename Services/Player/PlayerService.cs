// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayerService.cs" Company="Company">
//   Copyright (c) Company. All rights reserved.
// </copyright>
// <summary>
//   Defines the PlayerService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Services.Player
{
    using System;

    using DalContracts.Entities;
    using DalContracts.Player;

    using ServicesContracts.Player;

    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository playerRepository;

        public PlayerService()
        {
        }

        public Player Get(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}