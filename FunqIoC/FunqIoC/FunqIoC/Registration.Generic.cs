using System;

namespace FunqIoC
{
	public class Registration<TService>:Registration, IRegistration<TService>
	{
		internal Registration (Type serviceType, object factory): base(serviceType, factory)
		{
		}
		
		public INamedReusedOwned InitializedBy (Action<TService> initializer)
		{
			SetInitializer (initializer);
			return this;
		}
	}
}

