// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SessionToDtoMapper.cs" Company="Company">
//   Copyright (c) Company. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Host.Mappers
{
    using System.Diagnostics.Contracts;

    using DalContracts.Entities;

    using Dto.Entities;
    
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