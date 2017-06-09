using System;

namespace Monad.Optinal
{
	public interface IOptional<T> where T : class
	{
		T Value{get;}
		IOptional<T> Bind (Action<T> some, Action none);
		IOptional<T> Or (T value);
		IOptional<T> Or (Func<T> func);
		IOptional<T> Where(Func<T, bool> predicate);
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
}

