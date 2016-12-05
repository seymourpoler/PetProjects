using System.Collections.Generic;

namespace Infrestructura.Extensions
{
    public static class IReadOnlyCollectionExtensions
    {
        public static bool IsEmpty<T>(this IReadOnlyCollection<T> collection) where T :class
        {
            return collection.Count == 0;
        }
    }
}
