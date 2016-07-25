// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LinkFactory.cs" Company="Company">
//   Copyright (c) Company. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Shared.Links
{
    using System;

    public class LinkFactory
    {
        private const string EntityGetLink = "{0}/{1}";

        public ILink Create(string controllerName, Guid entityGuid)
        {
            return new Link { GetUri = string.Format(EntityGetLink, controllerName, entityGuid) };
        }
    }
}