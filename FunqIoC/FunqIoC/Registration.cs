using System;

namespace FunqIoC
{
	public abstract class Registration : IRegistration
	{
		internal Type ServiceType {
			get;
			private set;
		}
		internal Type FactoryType {
			get;
			private set;
		}
		internal object Factory {
			get;
			private set;
		}
		
		internal string Name {
			get;
			private set;
		}
		
		internal ReuseScope Scope {
			get; 
			private set;
		}
	
		internal Owner Owner {
			get;
			private set;
		}
		
		
		internal object Initializer {
			get;
			private set;
		}
		
		internal Registration (Type serviceType, object factory)
		{
			ServiceType = serviceType;
			FactoryType = factory.GetType ();
			Factory = factory;
		}
		
		public IReusedOwned Named (string name)
		{
			this.Name = name;
			return this;
		}
		
		public IOwned ReusedWithIn (ReuseScope scope)
		{
			this.Scope = scope;
			return this;
		}
		
		public void OwnedBy (Owner owner)
		{
			this.Owner = owner;
			
		}
		
		protected void SetInitializer (object initializer)
		{
			this.Initializer = initializer;
		}
	}
} 

