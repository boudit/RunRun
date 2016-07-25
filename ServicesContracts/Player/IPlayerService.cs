// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPlayerService.cs" Company="Company">
//   Copyright (c) Company. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ServicesContracts.Player
{
    using System;

    using DalContracts.Entities;

    public interface IPlayerService
    {
        Player Get(Guid guid);
    }
}