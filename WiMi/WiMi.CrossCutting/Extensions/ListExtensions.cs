using System.Collections.Generic;

namespace WiMi.CrossCutting.Extensions
{
	public static class ListExtensions
    {
		public static bool IsEmpty<T>(this List<T> list) where T : class
		{
			const int noElements = 0;
			return list.Count == noElements;
		}

		public static bool IsNotEmpty<T>(this List<T> list) where T : class
        {
            const int noElements = 0;
            return list.Count > noElements;
        }
    }
}
