using System.Collections.Generic;

namespace ExtensionMethods
{
    public static partial class ReadOnlyCollectionExtensions
    {
        public static bool IsNullOrEmpty<T>(this IReadOnlyCollection<T> collection)
        {
            return collection.IsNull() ||
                   collection.IsEmpty();
        }
    }
}