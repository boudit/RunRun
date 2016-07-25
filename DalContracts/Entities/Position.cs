// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Position.cs" Company="Company">
//   Copyright (c) Company. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace DalContracts.Entities
{
    public struct Position
    {
        public Position(uint timeSpent, int x, int y)
            : this()
        {
            this.TimeSpent = timeSpent;
            this.X = x;
            this.Y = y;
        }

        public uint TimeSpent { get; private set; }

        public int X { get; private set; }

        public int Y { get; private set; }
    }
}