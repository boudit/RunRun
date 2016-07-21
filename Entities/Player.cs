// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Player.cs" company="Company">
//   Copyright (c) Company. All rights reserved.
// </copyright>
// <summary>
//   The player.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Entities
{
    using System;

    /// <summary>
    /// The player.
    /// </summary>
    public class Player
    {
        public Guid Guid { get; set; }

        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            var player = obj as Player;
            if (player == null)
            {
                return false;
            }

            return this.Guid.Equals(player.Guid);
        }

        public override int GetHashCode()
        {
            return this.Guid.GetHashCode();
        }
    }
}