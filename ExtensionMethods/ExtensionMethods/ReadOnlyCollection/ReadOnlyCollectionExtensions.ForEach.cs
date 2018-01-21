using System;
using System.Collections.Generic;

namespace ExtensionMethods.ReadOnlyCollection
{
    public static partial class ReadOnlyCollectionExtensions
    {
        public static void ForEach<T>(this IReadOnlyCollection<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
        }
    }
}