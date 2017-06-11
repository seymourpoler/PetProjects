using System;

namespace Monad.Optinal
{
	public static class SomeExtensions
	{
		public static IOptional<TResult> Bind<T, TResult>(this Some<T> @this, Func<T, TResult> some, Action none) 
			where TResult : class, new()
			where T : class
		{
			return some (@this.Value).ToOptional();
		}
	}
}
