// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPlayerService.cs" company="Company">
//   Copyright (c) Company. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ServicesContracts.Player
{
    using System;

    using Entities;

    public interface IPlayerService
    {
        Player Get(Guid guid);
    }
}