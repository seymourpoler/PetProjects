using System;

namespace Monad.Optinal
{
	public class None<T> : IOptional<T> where T : class
    {
		public T Value
		{ 
			get { return default(T); } 
		}

		public T ValueOrFailure
		{
			get{throw new ValueMissingException ();}
		}

		public T ValueOr (Func<T> func)
		{
			return func ();
		}

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

		public IOptional<TResult> Bind<TResult> (Func<TResult> some, Func<TResult> none) 
			where TResult : class
		{
			var value = none ();
			return new Some<TResult> (value);
		}

		public IOptional<T> Bind (Func<T> func)
		{
			return new Some<T> (func());
		}

		public IOptional<T> Bind (Func<T> some, Func<T> none){
			var value = none ();
			return new Some<T> (value);
		}

		public IOptional<TResult> Bind<TResult> (Func<TResult> func) 
			where TResult : class
		{
			var value = func ();
			return new Some<TResult> (value);
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

		public IOptional<T> Bind (Func<T> some, Action none){
			none ();
			return this;
		}

		public IOptional<TResult> Bind<TResult> (Func<TResult> some, Action none) 
			where TResult: class
		{
			none ();
			return new None<TResult> ();
		}

		public IOptional<T> Bind (Action<T> some, Func<T> none)
		{
			var value = none ();
			return new Some<T> (value);
		}

		public IOptional<T> Bind (Action<T> some, Action none)
		{
			none ();
			return this;
		}

		public IOptional<T> Bind (Action<T> action)
		{
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
