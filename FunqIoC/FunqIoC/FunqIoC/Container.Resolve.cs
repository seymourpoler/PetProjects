using System;

namespace FunqIoC
{
	public partial class Container
	{
		/* Sin refactorizar
		public TService Resolve<TService> ()
		{
			var key = new ServiceKey (typeof(TService), typeof(Func<TService>));
			Func<TService> factory = (Func<TService>)factories [key];
			return factory.Invoke ();
		}
		
		public TService Resolve<TService, TArg> (TArg argOne)
		{
			var key = new ServiceKey (typeof(TService), typeof(Func<TArg,TService>));
			Func<TArg, TService> factory = (Func<TArg,TService>)factories [key];
			return factory.Invoke (argOne);
		}
		
		public TService Resolve<TService, TArgOne, TArgTwo> (TArgOne argOne, TArgTwo argTwo)
		{
			var key = new ServiceKey (typeof(TService), typeof(Func<TArgOne, TArgTwo,TService>));
			Func<TArgOne, TArgTwo ,TService> factory = (Func<TArgOne, TArgTwo,TService>)factories [key];
			return factory.Invoke (argOne, argTwo);
		}
		*/
		
		/* Refactorizado */
			
		public TService Resolve<TService> ()
		{
			return ResolveImpl<TService, Func<TService>> (null,(factory) => factory (), true);
		}
		
		public TService Resolve<TService, TArg> (TArg argOne)
		{
			return ResolveImpl<TService, Func<TArg, TService>> (null, (factory) => factory (argOne), true);
		}
		
		public TService Resolve<TService, TArgOne, TArgTwo> (TArgOne argOne, TArgTwo argTwo)
		{
			return ResolveImpl<TService, Func<TArgOne, TArgTwo, TService>> (null, (factory) => factory (argOne, argTwo), true);
		}
		
		public TService ResolveNamed<TService> (string name)
		{
			return ResolveImpl<TService, Func<TService>> (name,(factory) => factory (), true);
		}
		
		public TService TryResolve<TService> ()
		{
			return ResolveImpl<TService, Func<TService>> (null, (factory) => factory (), false);
		}
		
		public TService TryResolve<TService, TArg> (TArg argOne)
		{
			return ResolveImpl<TService, Func<TArg, TService>> (null, (factory) => factory (argOne), false);
		}
		
		private TService ResolveImpl<TService, TFunc> (string name, Func<TFunc, TService> invoker, bool throwIfMissing)
		{
			var key = new ServiceKey (typeof(TService), typeof(TFunc));
			key.Name = name;
			var entry = GetEntry (key);
			
			if (entry != null) {
				if (entry.Instance == null) {
					switch (entry.Scope) {
					case ReuseScope.Hierarchy:
						if (entry.Container != this) {
							return entry.Container.ResolveImpl<TService, TFunc> (name, invoker, throwIfMissing);
						}
						else if (entry.Instance == null) {
							entry.Instance = CreateInstance<TService, TFunc> (entry, invoker);
						}
						return (TService)entry.Instance;
					case ReuseScope.Container:
						ServiceEntry containerEntry;
						if (entry.Container != this) {
							containerEntry = entry.CloneFor (this);
							this.Register (key, containerEntry);
						} else {
							containerEntry = entry;
						}
					
						if (containerEntry.Instance == null) {
							containerEntry.Instance = CreateInstance<TService, TFunc> (containerEntry, invoker);
						}
						return (TService)containerEntry.Instance;
					case ReuseScope.None:
						return CreateInstance<TService, TFunc> (entry, invoker);
					default:
						throw new ResolutionException ("Unkown scope");
					}
				} else {
					return (TService)entry.Instance;
				}
			}
			
			if (throwIfMissing) {
				throw new ResolutionException ();
			} else {
				return default(TService);
			}	
		}
		
		private TService CreateInstance<TService, TFunc> (ServiceEntry entry, Func<TFunc, TService> invoker)
		{
			TService instance = invoker ((TFunc)entry.Factory);
			
			if (entry.Owner == Owner.Container && instance is IDisposable) {
				disposables.Push (new WeakReference (instance));
			}
			
			if (entry.Iniatilizer != null) {
				((Action<TService>)entry.Iniatilizer).Invoke (instance);
			}
			
			
			return instance;
		}
		
		private ServiceEntry GetEntry (ServiceKey key)
		{
			ServiceEntry entry;
			
			services.TryGetValue (key, out entry);
			
			if (entry == null && parentContainer != null) {
				return parentContainer.GetEntry (key);
			}
			
			/*
			if (parentContainer != null) {
				return parentContainer.GetEntry (key);
			} else {
				services.TryGetValue (key, out entry);
			}
			*/			
			return entry;
		}
	}
}

