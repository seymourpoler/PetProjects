using System.Collections.Generic;

namespace WiMi.CrossCutting
{
    public static class ReadOnlyListExtensions
    {
        public static bool IsEmpty<T>(this IReadOnlyList<T> list) where T : class
        {
            const int noElements = 0;
            return list.Count == noElements;
        }
    }
}
