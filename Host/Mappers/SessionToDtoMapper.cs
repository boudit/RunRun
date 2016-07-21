// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SessionToDtoMapper.cs" company="Company">
//   Copyright (c) Company. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Host.Mappers
{
    using System.Diagnostics.Contracts;

    using Dto.Entities;

    using Entities;

    using Shared.Mappers;

    public class SessionToDtoMapper : IMapper<Session, SessionDto>
    {
        public SessionDto Map(Session source)
        {
            Contract.Requires(source != null);

            return new SessionDto();
        }
    }
}