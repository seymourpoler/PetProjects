using System;

namespace Monad.Optinal
{
	public class Some<T> : IOptional<T> where T : class
    {
		private readonly T _value;

		public T Value{
			get{return _value;}
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

		public IOptional<TResult> Bind<TResult>(Func<T, TResult> some, Func< TResult> none) 
			where TResult : class
		{
			return some (_value).ToOptional ();
		}

		public IOptional<TResult> Bind<TResult> (Func<T, TResult> func)
			where TResult : class
		{
			return func (_value).ToOptional ();
		}

		public IOptional<TResult> Bind<TResult>(Func<T, TResult> some, Action none) 
			where TResult : class
		{
			return some (_value).ToOptional ();
		}

		public IOptional<T> Bind (Action<T> some, Action none)
		{
			some (_value);
			return this;
		}

		public IOptional<T> Bind (Action<T> some)
		{
			some (_value);
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
			if(predicate(_value)){
				return this;
			}
			return new None<T> ();
		}
    }
}
