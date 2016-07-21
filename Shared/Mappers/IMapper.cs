// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMapper.cs" company="Company">
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