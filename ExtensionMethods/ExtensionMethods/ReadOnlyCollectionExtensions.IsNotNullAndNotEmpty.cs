using System.Collections.Generic;

namespace ExtensionMethods
{
    public static partial class ReadOnlyCollectionExtensions
    {
        public static bool IsNotNullAndNotEmpty<T>(this IReadOnlyCollection<T> collection)
        {
            return collection.IsNotNull() &&
                   collection.IsNotEmpty();
        }
    }
}