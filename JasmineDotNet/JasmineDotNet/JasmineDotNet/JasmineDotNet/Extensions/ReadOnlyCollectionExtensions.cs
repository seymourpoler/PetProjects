using System;
using System.Collections.ObjectModel;

namespace JasmineDotNet.Extensions
{
    public static class ReadOnlyCollectionExtensions
    {
        public static T Second<T>(this ReadOnlyCollection<T> collection)
        {
            const int minimumNumberOfElements = 2;
            const int secondPosition = 1;
            if (collection.Count < minimumNumberOfElements)
            {
                throw  new ArgumentOutOfRangeException();
            }

            return collection[secondPosition];
        }
    }
}