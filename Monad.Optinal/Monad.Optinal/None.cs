using System;

namespace Monad.Optinal
{
	public class None<T> : IOptional<T> where T : class
    {

		public T Value{ get { return default(T); } }
		
        public static None<T> From(T value)
        {
            if (default(T) == value)
            {
                return new None<T>();
            }
            throw new ArgumentNullException();
        }

		public IOptional<TResult> Bind<TResult> (Func<T, TResult> func) 
			where TResult : class
		{
			return new None<TResult> ();
		}

		public IOptional<TResult> Bind<TResult>(Func<T, TResult> some, Func<TResult> none) 
			where TResult : class
		{
			return none().ToOptional();
		}

		public IOptional<TResult> Bind<TResult>(Func<T, TResult> some, Action none) 
			where TResult : class
		{
			none ();
			return new None<TResult> ();
		}

		public IOptional<T> Bind (Action<T> some, Action none)
		{
			none ();
			return this;
		}

		public IOptional<T> Or(T value)
		{
			return value.ToOptional<T> ();
		}

		public IOptional<T> Or (Func<T> func)
		{
			return func ().ToOptional ();
		}

		public IOptional<T> Where (Func<T, bool> predicate)
		{
			return this;
		}
    }
}
