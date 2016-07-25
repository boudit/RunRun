// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BinarySerializer.cs" Company="Company">
//   Copyright (c) Company. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Shared.Serializers
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    public class BinarySerializer : IBinarySerializer
    {
        public byte[] Serialize(object obj)
        {
            if (obj == null)
            {
                return null;
            }

            byte[] result;
            var formatter = new BinaryFormatter();

            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, obj);
                result = stream.ToArray();
            }

            return result;
        }

        public object Deserialize(byte[] arrBytes)
        {
            return this.Deserialize<object>(arrBytes);
        }

        public T Deserialize<T>(byte[] arrBytes) where T : class 
        {
            T result;

            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();

                stream.Write(arrBytes, 0, arrBytes.Length);
                stream.Seek(0, SeekOrigin.Begin);
                result = formatter.Deserialize(stream) as T;
            }

            return result;
        }
    }
}