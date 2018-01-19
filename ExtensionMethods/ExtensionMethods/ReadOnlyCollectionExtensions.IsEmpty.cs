using System.Collections.Generic;

namespace ExtensionMethods
{
    public static partial class ReadOnlyCollectionExtensions
    {
        public static bool IsEmpty<T>(this IReadOnlyCollection<T> collection)
        {
            const int noElements = 0;
            if (collection == null)
            {
                return true;
            }

            return collection.Count == noElements;
        }
    }
}