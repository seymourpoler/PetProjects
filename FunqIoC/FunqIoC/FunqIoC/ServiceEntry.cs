using System;

namespace FunqIoC
{
	internal class ServiceEntry
	{
		public object Factory {
			get;
			set;
		}
		public object Instance {
			get;
			set;
		}
		
		public ReuseScope Scope {
			get;
			set;
		}
		
		public Container Container {
			get;
			set;
		}
		
		public Owner Owner {
			get;
			set;
		}
		
		public object Iniatilizer {
			get;
			set;
		}
		 
		public ServiceEntry CloneFor (Container newContainer)
		{
			var result = new ServiceEntry ();
			result.Factory = this.Factory;
			result.Scope = this.Scope;
			result.Owner = this.Owner;
			result.Container = newContainer;
			result.Iniatilizer = this.Iniatilizer;
			return result;
		}
		
		public ServiceEntry ()
		{
		}
	}
}

