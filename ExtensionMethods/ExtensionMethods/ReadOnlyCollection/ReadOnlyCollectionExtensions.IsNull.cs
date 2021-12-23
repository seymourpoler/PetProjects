using System.Collections.Generic;

namespace ExtensionMethods.ReadOnlyCollection
{
    public partial class ReadOnlyCollectionExtensions
    {
        public static bool IsNull<T>(this IReadOnlyCollection<T> collection)
        {
            return collection is null;
        }
    }
}