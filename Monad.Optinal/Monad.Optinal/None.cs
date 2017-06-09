using System;

namespace Monad.Optinal
{
	public class None<T> : IOptional<T> where T : class
    {

        public static None<T> From(T value)
        {
            if (default(T) == value)
            {
                return new None<T>();
            }
            throw new ArgumentNullException();
        }

		public IOptional<T> Bind(Action some, Action none)
		{
			none ();
			return this;
		}
    }
}
