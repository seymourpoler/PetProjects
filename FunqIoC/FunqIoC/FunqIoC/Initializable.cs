using System;

namespace FunqIoC
{
	public class Initializable : IInitializable
	{
		public int InitializeCalls {
			get;
			set;
		}
		
		public Initializable ()
		{
		}
		
		public void Initialize ()
		{
			InitializeCalls ++;
		}
	}
}

