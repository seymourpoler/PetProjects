using System;
using System.Linq;
using System.Collections.Generic;

namespace ReadOnlyList
{
	public static class ReadOnlyListExtensions
	{
		public static ReadOnlyList<TResult> Select<T, TResult>(this ReadOnlyList<T> list, Func<T, TResult> function) 
			where TResult : class, new()
			where T : class
		{
			var result = new List<TResult> ();
			list.ForEach (x => result.Add (function (x)));
			return new ReadOnlyList<TResult> (result);
		}

		public static ReadOnlyList<T> OrderAscendingBy<T, TKey>(this ReadOnlyList<T> list, Func<T, TKey> ordering)
			where TKey : class
			where T : class
		{
			var result = new List<T>();
			list.ForEach(x => result.Add(x));
			return new ReadOnlyList<T>(
				items: result.OrderBy(ordering));
		}

		public static ReadOnlyList<T> OrderDescendingBy<T, TKey>(this ReadOnlyList<T> list, Func<T, TKey> ordering)
			where TKey : class
			where T : class
		{
			var result = new List<T>();
			list.ForEach(x => result.Add(x));
			return new ReadOnlyList<T>(
				items: result.OrderByDescending(ordering));
		}
	
	}
}

