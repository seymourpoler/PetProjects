using System;

namespace FunqIoC.Test
{
	public class Foo : IFoo
	{
		public IBar Bar{ get; set; }
		
		public Foo(){}
		
		public  Foo (IBar bar)
		{
			this.Bar = bar;
		}
	}
}

