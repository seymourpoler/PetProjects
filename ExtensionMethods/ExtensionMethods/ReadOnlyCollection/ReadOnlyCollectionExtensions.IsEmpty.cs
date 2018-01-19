using System.Collections.Generic;
using ExtensionMethods.Object;

namespace ExtensionMethods.ReadOnlyCollection
{
    public static partial class ReadOnlyCollectionExtensions
    {
        public static bool IsEmpty<T>(this IReadOnlyCollection<T> collection)
        {
            if (collection.IsNull())
            {
                return true;
            }

            return collection.Count == noElements;
        }
    }
}