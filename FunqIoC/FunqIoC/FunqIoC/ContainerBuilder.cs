using System;
using System.Collections.Generic;

namespace FunqIoC
{
	public class ContainerBuilder
	{
		private List<Registration> _registrations;
		public ContainerBuilder ()
		{
			_registrations = new List<Registration>();
		}
		
		public Container Build ()
		{
			var container = new Container ();
			
			foreach (var registration in _registrations) {
				var key = new ServiceKey (registration.ServiceType, registration.FactoryType);
				key.Name = registration.Name;
				
				var entry = new ServiceEntry ();
				entry.Factory = registration.Factory;
				entry.Scope = registration.Scope;
				entry.Owner = registration.Owner;
				entry.Iniatilizer = registration.Initializer;
				entry.Container = container;
				
				container.Register (key, entry);
			}
			return container;
		}
		
		public Registration<TService> Register<TService> (Func<TService> factory)
		{
			return RegisterImpl<TService, Func<TService>>(factory);
		}
		
		public Registration<TService> Register<TService, TArg> (Func<TArg,TService> factory)
		{
			return RegisterImpl<TService, Func<TArg, TService>> (factory);
		}

		public Registration<TService> Register<TService, TArgOne, TArgTwo> (Func<TArgOne, TArgTwo,TService> factory)
		{
			return RegisterImpl<TService, Func<TArgOne, TArgTwo,TService>> (factory);
		}
		
		private Registration<TService> RegisterImpl<TService, TFunc> (TFunc factory)
		{
			var newRegistration = new Registration<TService> (typeof(TService), factory);
			_registrations.Add (newRegistration);
			return newRegistration;
		}
	}
}

