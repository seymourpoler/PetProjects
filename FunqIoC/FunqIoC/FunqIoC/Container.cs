
using System;
using System.Collections.Generic;

namespace FunqIoC
{
	public partial class Container : IDisposable
	{
		Dictionary<ServiceKey, ServiceEntry> services = new Dictionary<ServiceKey, ServiceEntry> ();
		Stack<WeakReference> disposables = new Stack<WeakReference>();
		Stack<Container> childContainers = new Stack<Container>();
		
		protected Container parentContainer;
		
		internal Container (Container parentContainer)
		{
			this.parentContainer = parentContainer;
		}
			
		public Container ()
		{
		}
		
		public Container CreateChildContainer ()
		{
			var newChildContainer = new Container (this);
			childContainers.Push (newChildContainer);
			return newChildContainer;
		}
		
		public void Dispose ()
		{
			while (disposables.Count > 0) {
				var wr = disposables.Pop ();
				var disposable = (IDisposable)wr.Target;
				if (wr.IsAlive) {
					disposable.Dispose ();
				}
			}
			
			while (childContainers.Count > 0) {
				childContainers.Pop ().Dispose ();
			}
		}
	}
}

