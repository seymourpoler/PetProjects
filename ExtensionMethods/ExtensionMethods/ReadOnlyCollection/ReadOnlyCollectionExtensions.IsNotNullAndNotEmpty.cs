using System.Collections.Generic;
using ExtensionMethods.Object;

namespace ExtensionMethods.ReadOnlyCollection
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