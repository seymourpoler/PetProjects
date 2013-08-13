
using System;
using System.Collections.Generic;

namespace FunqIoC
{
	public partial class Container
	{
		/*
		public Registration Register<TService> (Func<TService> factory)
		{
			return RegisterImpl<TService, Func<TService>>(factory);
		}
		
		public Registration Register<TService, TArg> (Func<TArg,TService> factory)
		{
			return RegisterImpl<TService, Func<TArg, TService>> (factory);
		}

		public Registration Register<TService, TArgOne, TArgTwo> (Func<TArgOne, TArgTwo,TService> factory)
		{
			return RegisterImpl<TService, Func<TArgOne, TArgTwo,TService>> (factory);
		}
		
		private Registration RegisterImpl<TService, TFunc> (TFunc factory)
		{
			var key = new ServiceKey (typeof(TService), typeof(TFunc));
			factories.Add (key, factory);
			
			return new Registration (this, typeof(TService), factory);
		}
		
		internal void ReName (string newName, Type serviceType, object factory)
		{
			var key = new ServiceKey (serviceType, factory.GetType ());
			factories.Remove (key);
			key.Name = newName;
			factories.Add (key, factory);
		}
		*/
		
		internal void Register (ServiceKey serviceKey, ServiceEntry entry)
		{
			services.Add(serviceKey, entry);
		}
	}
}

