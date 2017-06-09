using System;

namespace Monad.Optinal
{
	public interface IOptional<T> where T : class
	{
		IOptional<T> Bind (Action some, Action none);
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

