using System;
using System.ComponentModel;

namespace FunqIoC
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IRegistration:IFluentInterface, INamedReusedOwned{}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IRegistration<TService>:IFluentInterface, IRegistration, IInitialized<TService>{}
	
	[EditorBrowsable(EditorBrowsableState.Never)]	
	public interface INamedReusedOwned:IFluentInterface, INamed, IReusedOwned
	{}
	
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IReusedOwned: IReused, IOwned, IFluentInterface{}
	
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IInitialized<TService>:IFluentInterface
	{
		INamedReusedOwned InitializedBy (Action<TService> initializar);
	}
	
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface INamed:IFluentInterface
	{
		IReusedOwned Named (string name);
	}
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IReused:IFluentInterface
	{
		IOwned ReusedWithIn(ReuseScope scope);
	}
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IOwned:IFluentInterface
	{
		void OwnedBy(Owner owner);
	}
}

