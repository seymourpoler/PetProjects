using System;

namespace FunqIoC
{
	public class ServiceKey
	{
		public Type ServiceType {
			get;
			private set;
		}
		
		public Type FactoryType {
			get;
			private set;
		}
		
		public string Name {
			get;
			set;
		}
		
		public ServiceKey (Type serviceType, Type factoryTpe)
		{
			this.ServiceType = serviceType;
			this.FactoryType = factoryTpe;
		}
		
		public override bool Equals (object key)
		{
			if (key == null) {
				return false;
			}
			
			if (this.GetType () != key.GetType ()) {
				return false;
			}			
			var serviceKey = key as ServiceKey;
			
			if (Object.ReferenceEquals (this, serviceKey)) {
				return true;
			}
			
			return serviceKey.ServiceType == this.ServiceType && 
				serviceKey.FactoryType == this.FactoryType &&
				serviceKey.Name == this.Name;		
		}
		
		public override int GetHashCode ()
		{
			int hash = ServiceType.GetHashCode () ^ FactoryType.GetHashCode ();
			if (!string.IsNullOrEmpty (this.Name)) {
				hash ^= Name.GetHashCode ();
			}
			return hash;
		}
	}
}

