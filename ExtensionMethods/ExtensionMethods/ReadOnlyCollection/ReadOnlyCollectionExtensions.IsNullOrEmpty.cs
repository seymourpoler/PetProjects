using System.Collections.Generic;
using ExtensionMethods.Object;

namespace ExtensionMethods.ReadOnlyCollection
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