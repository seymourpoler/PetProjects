using System.Collections.Generic;
using ExtensionMethods.Object;

namespace ExtensionMethods.ReadOnlyCollection
{
    public static partial class ReadOnlyCollectionExtensions
    {
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