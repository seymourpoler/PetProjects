using System;

namespace Monad.Optinal
{
	public interface IOptional<T> where T : class
	{
		T Value{get;}
		IOptional<T> Or (T value);
		IOptional<T> Or (Func<T> func);
		T ValueOr (Func<T> func);
		T ValueOrFailure { get;}
		IOptional<T> Where(Func<T, bool> predicate);
		IOptional<TResult> Bind<TResult> (Func<T, TResult> func) where TResult : class;
		IOptional<TResult> Bind<TResult> (Func<T, TResult> some, Func<TResult> none) where TResult : class;
		IOptional<TResult> Bind<TResult> (Func<T, TResult> some, Action none) where TResult : class;
		IOptional<T> Bind (Func<T> func);
		IOptional<TResult> Bind<TResult> (Func<TResult> func) where TResult : class;
		IOptional<T> Bind (Action<T> some, Action none);
		IOptional<T> Bind (Action<T> action);
	}

	public class Optional
	{
		public static IOptional<T> From<T>(T value) where T : class
		{
			if(value == default(T)){
				return new None<T> ();
			}
			return new Some<T> (value);
		}
	}

	public class ValueMissingException : Exception{}
}

