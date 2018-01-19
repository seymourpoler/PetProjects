using System;
using System.Collections.Generic;

namespace ExtensionMethods
{
    public static class ReadOnlyCollectionExtensions
    {
        public static bool IsEmpty<T>(this IReadOnlyCollection<T> collection)
        {
            if (collection == null)
            {
                return true;
            }
            throw new NotImplementedException();
        }
    }
}