using System;
using FunqIoC;

namespace FunqIoC.Console
{
	public class MainClass
	{
		public static void Main (string[] args)
		{
			//ShouldReturnObjectWhenNotRegisteredServiceWithArgumentsTest ();
			//ShouldReturnRegisteredOnParentResolvesOnChildContainerTest ();
			//ContainerScopedInstanceIsNotReusedOnTheChildContainerTest ();
			//ContainerOwnedNoneReusedInstanceAreDisposedNotKeptAliveTest ();
		}
		
		private static void ShouldReturnObjectWhenNotRegisteredServiceWithArgumentsTest ()
		{
			ContainerBuilder builder = new ContainerBuilder ();
			builder.Register<IBar> (() => new Bar ()).ReusedWithIn (ReuseScope.Container);
			var container = builder.Build ();
			
			IBar barOne = container.Resolve<IBar> () as IBar;
			IBar barTwo = container.Resolve<IBar> () as IBar;
		}
		
		private static void ShouldReturnRegisteredOnParentResolvesOnChildContainerTest ()
		{
			var builder = new ContainerBuilder ();
			builder.Register<IFoo> (() => new Foo ());
			var container = builder.Build ();
			
			var child = container.CreateChildContainer ();
			var foo = child.Resolve<IFoo> ();
		}
		
		public static void ContainerScopedInstanceIsNotReusedOnTheChildContainerTest ()
		{
			var builder = new ContainerBuilder ();
			builder.Register<IFoo> (() => new Foo ()).ReusedWithIn (ReuseScope.Container);
			var parent = builder.Build ();
			var child = parent.CreateChildContainer ();
			
			var fooOne = parent.Resolve<IFoo> ();
			var fooTwo = child.Resolve<IFoo> ();
			
			//Assert.AreNotSame (fooOne, fooTwo);
		}
		
		public static void ContainerOwnedNoneReusedInstanceAreDisposedNotKeptAliveTest ()
		{
			var builder = new ContainerBuilder ();
			builder.Register<IFoo> (() => new Disposable ())
				.ReusedWithIn (ReuseScope.None)
				.OwnedBy (Owner.Container);
			
			var container = builder.Build ();
						
			var foo = container.Resolve<IFoo> () as Disposable;
			var wr = new WeakReference (foo);
			
			foo = null;
			GC.Collect ();
			
			var pp = wr.IsAlive;
		}
	}
}
