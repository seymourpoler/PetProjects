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
    }
}
