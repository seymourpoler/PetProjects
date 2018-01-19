using System;
using System.Collections.Generic;

namespace ExtensionMethods
{
    public static partial class ReadOnlyCollectionExtensions
    {
        const int noElements = 0;
        public static bool IsEmpty<T>(this IReadOnlyCollection<T> collection)
        {
            if (collection.IsNull())
            {
                return true;
            }

            return collection.Count == noElements;
        }
        
        public static bool IsNotEmpty<T>(this IReadOnlyCollection<T> collection)
        {
            if (collection.IsNull())
            {
                return false;
            }

            return collection.Count > noElements;
        }
    }
}