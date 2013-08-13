using System;

namespace FunqIoC.Test
{
	public class Disposable: IFoo, IDisposable
	{
		public bool IsDisposed {
			get;
			set;
		}
		
		public void Dispose ()
		{
			IsDisposed = true;
		}
	}
}

