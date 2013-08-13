using System;

namespace FunqIoC.Test
{
	public class Bar:IBar
	{
		public string ArgOne {
			get;
			set;
		}

		public bool ArgTwo {
			get;
			set;
		}

		public Bar ()
		{
		}
		
		public Bar (string argOne)
		{
			this.ArgOne = argOne;
		}
		
		public Bar (string argOne, bool argTwo)
		{
			this.ArgOne = argOne;
			this.ArgTwo = argTwo;
		}
	}
}

