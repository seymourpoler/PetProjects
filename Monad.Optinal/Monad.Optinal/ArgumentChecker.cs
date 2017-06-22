using System;

namespace Monad.Optinal
{
	public static class ArgumentChecker
	{
		public static void CheckNull<T>(T argument) where T : class
		{
			if (argument == null)
			{
				throw new ArgumentNullException(typeof(T).ToString());
			}
		}
	}
}

