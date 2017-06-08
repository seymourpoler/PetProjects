﻿using System;

namespace Monad.Optinal
{
	public static class NoneExtensions
	{
		public static IOptional<TResult> Bind<T, TResult>(this None<T> @this, Func<T, TResult> some, Func<T, TResult> none) 
			where TResult : class, new()
			where T : class
		{
			return none(null).ToOptional();
		}
	}
}
