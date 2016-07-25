// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Session.cs" Company="Company">
//   Copyright (c) Company. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Entities
{
    using System;
    using System.Collections.Generic;

    public class Session
    {
        public Session(Guid guid)
        {
            this.Players = new List<Player>();
            this.Guid = guid;
        }

        public Guid Guid { get; private set; }

        public IList<Player> Players { get; private set; }
    }
}