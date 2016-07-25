// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConcurrentDictionaryExtensions.cs" Company="Company">
//   Copyright (c) Company. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Shared.Extensions
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    public static class ConcurrentDictionaryExtensions
    {
        public static bool Remove<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> self, TKey key)
        {
            return ((IDictionary<TKey, TValue>)self).Remove(key);
        }
    }
}