using System.Collections.Generic;

namespace ExtensionMethods
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