// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBinarySerializer.cs" company="Company">
//   Copyright (c) Company. All rights reserved.
// </copyright>
// <summary>
//   Defines the IBinarySerializer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Shared.Serializers
{
    public interface IBinarySerializer
    {
        byte[] Serialize(object obj);

        object Deserialize(byte[] arrBytes);

        T Deserialize<T>(byte[] arrBytes) where T : class;
    }
}