using System;
using System.Collections.ObjectModel;

namespace JasmineDotNet.Extensions
{
    public static class ReadOnlyCollectionExtensions
    {
        public static T Second<T>(this ReadOnlyCollection<T> collection)
        {
            const int minimumNumberOfElements = 2;
            if (collection.Count < minimumNumberOfElements)
            {
                throw  new ArgumentOutOfRangeException();
            }
            throw new NotImplementedException();
        }
    }
}