// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayerService.cs" company="Company">
//   Copyright (c) Company. All rights reserved.
// </copyright>
// <summary>
//   Defines the PlayerService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Services.Player
{
    using System;
    using System.Collections.Concurrent;

    using DalContracts.Player;

    using Entities;

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