using System;
using System.Collections.Generic;
using ExtensionMethods.Object;

namespace ExtensionMethods.ReadOnlyCollection
{
    public static partial class ReadOnlyCollectionExtensions
    {
        public static void ForEach<T>(this IReadOnlyCollection<T> collection, Action<T> action)
        {
            if(collection.IsNull()){return;}
            if(action.IsNull()){return;}

            foreach (var item in collection)
            {
                action(item);
            }
        }
    }
}