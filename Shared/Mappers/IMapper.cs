// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMapper.cs" Company="Company">
//   Copyright (c) Company. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Shared.Mappers
{
    public interface IMapper<in TInput, out TOutput>
    {
        TOutput Map(TInput source);
    }
}