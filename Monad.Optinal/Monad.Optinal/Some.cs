using System;

namespace Monad.Optinal
{
	public class Some<T> : IOptional<T> where T : class
    {
		private readonly T _value;

		public T Value
		{
			get{return _value;}
		}

		public T ValueOrFailure 
		{
			get{return _value;}
		}

		public T ValueOr (Func<T> func)
		{
			return _value;
		}

        public Some(T value)
        {
            _value = value;
        }

        public static Some<T> From(T value)
        {
            if(default (T) == value)
            {
                throw new ArgumentNullException();
            }
            return new Some<T>(value);
        }

		public IOptional<T> Bind (Func<T> func)
		{
			ArgumentChecker.CheckNull (func);
			return func ().ToOptional ();
		}

		public IOptional<T> Bind (Func<T> some, Func<T> none){
			return some ().ToOptional ();
		}

		public IOptional<TResult> Bind<TResult> (Func<TResult> function) 
			where TResult : class
		{
			ArgumentChecker.CheckNull (function);
			return function ().ToOptional ();
		}

		public IOptional<TResult> Bind<TResult> (Func<TResult> functionSome, Func<TResult> none) 
			where TResult : class
		{
			ArgumentChecker.CheckNull (functionSome);
			return functionSome ().ToOptional();
		}

		public IOptional<TResult> Bind<TResult>(Func<T, TResult> some, Func< TResult> none) 
			where TResult : class
		{
			ArgumentChecker.CheckNull (none);
			return some (_value).ToOptional ();
		}

		public IOptional<TResult> Bind<TResult> (Func<T, TResult> func)
			where TResult : class
		{
			ArgumentChecker.CheckNull (func);
			return func (_value).ToOptional ();
		}

		public IOptional<TResult> Bind<TResult> (Func<T, TResult> some, Action none) 
			where TResult : class
		{
			return some (_value).ToOptional();
		}

		public IOptional<T> Bind (Func<T> some, Action none){
			return some ().ToOptional();
		}

		public IOptional<TResult> Bind<TResult> (Func<TResult> some, Action none) 
			where TResult: class
		{
			return some ().ToOptional ();
		}

		public IOptional<T> Bind (Action<T> some, Func<T> none)
		{
			some (_value);
			return this;
		}

		public IOptional<T> Bind (Action<T> some, Action none)
		{
			some (_value);
			return this;
		}

		public IOptional<T> Bind (Action<T> action)
		{
			action (_value);
			return this;
		}

		public IOptional<T> Or(T value)
		{
			return this;
		}

		public IOptional<T> Or (Func<T> func)
		{
			return this;
		}

		public IOptional<T> Where (Func<T, bool> predicate)
		{
			ArgumentChecker.CheckNull (predicate);
			if(predicate(_value)){
				return this;
			}
			return new None<T> ();
		}
	}
}
