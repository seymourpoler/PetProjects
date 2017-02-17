using System;
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
	}
}

