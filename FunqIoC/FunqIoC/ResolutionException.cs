using System;

namespace FunqIoC
{
	public class ResolutionException : Exception
	{
		public ResolutionException ()
		{
		}
		
		public ResolutionException (string message):base(message)
		{
		}
	}
}

