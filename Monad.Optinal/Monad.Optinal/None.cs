using System;

namespace Monad.Optinal
{
	public class None<T> : IOptional<T> where T : class
    {
		public T Value{ get { return null; } }
		
        public static None<T> From(T value)
        {
            if (default(T) == value)
            {
                return new None<T>();
            }
            throw new ArgumentNullException();
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
