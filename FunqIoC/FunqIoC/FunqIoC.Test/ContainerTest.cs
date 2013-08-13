using System;
using NUnit.Framework;

namespace FunqIoC.Test
{
	[TestFixture()]
	public class ContainerTest
	{		
		[Test()]
		public void ShouldReturnObject ()
		{
			var builder = new ContainerBuilder ();
			builder.Register<IBar> (() => new Bar ());
			var container = builder.Build();
			
			var bar = container.Resolve<IBar> ();
			
			Assert.IsNotNull (bar);
			Assert.IsTrue (bar is IBar);
		}
		
		[Test()]
		public void ShouldReturnObjectWithInjectedParameter ()
		{
			var builder = new ContainerBuilder ();
			builder.Register<IBar, string> ((s) => new Bar (s));
			var container = builder.Build();
			
			var bar = container.Resolve<IBar, string> ("foo");
			
			Assert.AreEqual ("foo", bar.ArgOne);
		}

		
		[Test()]
		public void ShouldReturnObjectWithTwoInjectedParameters ()
		{
			var builder = new ContainerBuilder ();
			
			builder.Register<IBar, string, bool> ((s, b) => new Bar (s, b));
			var container = builder.Build ();
			
			var bar = container.Resolve<IBar, string, bool> ("foo", false);
			
			Assert.AreEqual ("foo", bar.ArgOne);
			Assert.AreEqual (false, bar.ArgTwo);
		}
		
		[Test()]
		public void ShouldReturnObjectWithInjectedParameterAndWithOutParameters ()
		{
			var builder = new ContainerBuilder ();
			
			builder.Register<IBar, string> ((s) => new Bar (s));
			builder.Register<IBar> (() => new Bar ());
			var container = builder.Build ();
			
			var barOne = container.Resolve<IBar> ();
			var barTwo = container.Resolve<IBar, string> ("foo");
			
			Assert.IsNotNull (barTwo);
			Assert.IsNotNull (barOne);
			Assert.AreEqual ("foo", barTwo.ArgOne);
		}
		
		[Test()]
		public void ShouldReturnObjectWithParameters ()
		{
			var builder = new ContainerBuilder ();
			
			builder.Register<IBar> (() => new Bar ());
			builder.Register<IFoo, IBar> ((b) => new Foo (b));
			var container = builder.Build ();
			
			var foo = container.Resolve<IFoo, IBar> (new Bar ()) as Foo; 
			
			Assert.IsNotNull (foo);
			Assert.IsTrue (foo is IFoo);
			Assert.IsTrue (foo.Bar is IBar);
		}
		
		[Test()]
		public void ShouldReturnResolvedNames ()
		{
			var builder = new ContainerBuilder ();
			
			builder.Register<IBar> (() => new Bar ("a")).Named ("a");
			builder.Register<IBar> (() => new Bar ("b")).Named ("b");
			var container = builder.Build ();
			
			var a = container.ResolveNamed<IBar> ("a") as Bar; 
			var b = container.ResolveNamed<IBar> ("b") as Bar; 
			
			Assert.AreEqual ("a", a.ArgOne);
			Assert.AreEqual ("b", b.ArgOne);
		}
		
		[Test()]
		public void ShouldReturnResolvedNamesWithOutOrderRegistration ()
		{
			var builder = new ContainerBuilder ();
			
			builder.Register<IBar> (() => new Bar ("noname"));
			builder.Register<IBar> (() => new Bar ("a")).Named ("a");
			builder.Register<IBar> (() => new Bar ("b")).Named ("b");
			var container = builder.Build ();
			
			var a = container.ResolveNamed<IBar> ("a") as Bar; 
			var b = container.ResolveNamed<IBar> ("b") as Bar; 
			var c = container.Resolve<IBar> () as Bar;
			
			Assert.AreEqual ("a", a.ArgOne);
			Assert.AreEqual ("b", b.ArgOne);
			Assert.AreEqual ("noname", c.ArgOne);
		}
	
		[Test()]
		public void ShouldReturnResolutionExceptionResolveNotRegisterService ()
		{
			var builder = new ContainerBuilder ();
			var container = builder.Build ();
			try {
				IFoo foo = container.Resolve<IFoo> ();
				foo.ToString ();
				Assert.Fail ("shold raise a resolution expcetion");
			} catch (ResolutionException) {
			}
		}
		
		[Test()]
		public void ShouldReturnNullWhenNotRegisteredService ()
		{
			var builder = new ContainerBuilder ();
			var container = builder.Build ();
			IFoo foo = container.TryResolve<IFoo> ();
			Assert.IsNull (foo);
		}
		
		[Test()]
		public void ShouldReturnObjectWhenNotRegisteredServiceWithArguments ()
		{
			var builder = new ContainerBuilder ();
			builder.Register<IBar> (() => new Bar ()).ReusedWithIn (ReuseScope.Container);
			var container = builder.Build ();
			
			IBar barOne = container.Resolve<IBar> () as IBar;
			IBar barTwo = container.Resolve<IBar> () as IBar;
			
			Assert.IsNotNull (barOne);
			Assert.IsNotNull (barTwo);
			Assert.AreSame(barOne, barTwo);
		}
		
		[Test()]
		public void ShouldReturnAnInstanceIsReusedWithContainer ()
		{
			var builder = new ContainerBuilder ();
			builder.Register<IBar, string> ((s) => new Bar (s));
			var container = builder.Build ();
			IBar bar = container.TryResolve<IBar, string> ("bar") as IBar;
			Assert.AreEqual ("bar", bar.ArgOne);
		}
	
		[Test()]
		public void ShouldReturnRegisteredOnParentResolvesOnChildContainer ()
		{
			var builder = new ContainerBuilder ();
			builder.Register<IFoo> (() => new Foo ());
			var container = builder.Build ();
			
			var child = container.CreateChildContainer ();
			var foo = child.Resolve<IFoo> ();
			
			Assert.IsNotNull (foo);
		}

		[Test()]
		public void HierarcyScopedInstanceIsReusedOnTheSameContainer ()
		{
			var builder = new ContainerBuilder ();
			builder.Register<IFoo> (() => new Foo ()).ReusedWithIn (ReuseScope.Hierarchy);
			var container = builder.Build ();
			
			
			var fooOne = container.Resolve<IFoo> ();
			var fooTwo = container.Resolve<IFoo> ();
			
			Assert.AreSame (fooOne, fooTwo);
		}
		
		[Test()]
		public void HierarcyScopedInstanceIsReusedOnTheChildContainer ()
		{
			var builder = new ContainerBuilder ();
			builder.Register<IFoo> (() => new Foo ()).ReusedWithIn (ReuseScope.Hierarchy);
			var parent = builder.Build ();
			var child = parent.CreateChildContainer ();
			
			
			var fooOne = parent.Resolve<IFoo> ();
			var fooTwo = child.Resolve<IFoo> ();
			
			Assert.AreSame (fooOne, fooTwo);
		}

		[Test()]
		public void ContainerScopedInstanceIsNotReusedOnTheChildContainer ()
		{
			var builder = new ContainerBuilder ();
			builder.Register<IFoo> (() => new Foo ()).ReusedWithIn (ReuseScope.Container);
			var parent = builder.Build ();
			var child = parent.CreateChildContainer ();
			
			var fooTwo = child.Resolve<IFoo> ();
			var fooOne = parent.Resolve<IFoo> ();
			
			Assert.AreNotSame (fooOne, fooTwo);
		}
		
		[Test()]
		public void ContainerOwnedNoneReusedInstanceAreDisposed ()
		{
			var builder = new ContainerBuilder ();
			builder.Register<IFoo> (() => new Disposable ())
				.ReusedWithIn (ReuseScope.None)
				.OwnedBy (Owner.Container);
			
			var container = builder.Build ();
						
			var foo = container.Resolve<IFoo> () as Disposable;
			container.Dispose ();
			
			Assert.IsTrue (foo.IsDisposed);
		}
		
		[Test()]
		public void ContainerOwnedAndContainerReusedInstanceAreDisposed ()
		{
			var builder = new ContainerBuilder ();
			builder.Register<IFoo> (() => new Disposable ())
				.ReusedWithIn (ReuseScope.Container)
				.OwnedBy (Owner.Container);
			
			var container = builder.Build ();
						
			var foo = container.Resolve<IFoo> () as Disposable;
			container.Dispose ();
			
			Assert.IsTrue (foo.IsDisposed);
		}
		
		[Test()]
		public void ContainerOwnedAndHierarchyReusedInstanceAreDisposed ()
		{
			var builder = new ContainerBuilder ();
			builder.Register<IFoo> (() => new Disposable ())
				.ReusedWithIn (ReuseScope.Hierarchy)
				.OwnedBy (Owner.Container);
			
			var container = builder.Build ();
						
			var foo = container.Resolve<IFoo> () as Disposable;
			container.Dispose ();
			
			Assert.IsTrue (foo.IsDisposed);
		}
		
		[Test()]
		public void ContainerOwnedNoneReusedInstanceAreDisposedNotKeptAlive ()
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
			
			Assert.IsTrue (wr.IsAlive);
			//Assert.IsFalse (wr.IsAlive);
		}
	
		[Test()]
		public void ChildContainerInstanceWithParentRegistrationIsDisposed ()
		{
			var builder = new ContainerBuilder ();
			builder.Register<IFoo> (() => new Disposable ())
				.ReusedWithIn (ReuseScope.Hierarchy)
				.OwnedBy (Owner.Container);
			
			var parent = builder.Build ();
			var child = parent.CreateChildContainer ();
						
			var foo = child.Resolve<IFoo> () as Disposable;
			child.Dispose ();
			
			Assert.IsFalse (foo.IsDisposed);
		}
	
		[Test()]
		public void DisposingParentContainerDisposingChildContainerInstance ()
		{
			var builder = new ContainerBuilder ();
			builder.Register<IFoo> (() => new Disposable ())
				.ReusedWithIn (ReuseScope.None)
				.OwnedBy (Owner.Container);
			
			var parent = builder.Build ();
			var child = parent.CreateChildContainer ();
						
			var foo = child.Resolve<IFoo> () as Disposable;
			parent.Dispose ();
			
			Assert.IsTrue (foo.IsDisposed);
		}
		
		[Test()]
		public void DisposingContainerDoesNotDisposeExternalOwnerInstances ()
		{
			var builder = new ContainerBuilder ();
			builder.Register<IFoo> (() => new Disposable ())
				.ReusedWithIn (ReuseScope.Hierarchy)
				.OwnedBy (Owner.External);
			
			var container = builder.Build ();
						
			var foo = container.Resolve<IFoo> () as Disposable;
			container.Dispose ();
			
			Assert.IsFalse (foo.IsDisposed);
		}
		
		[Test()]
		public void FluentAPI ()
		{
			var builder = new ContainerBuilder ();
			
			builder.Register<IFoo> (() => new Foo ())
				.Named ("foo")
				.ReusedWithIn (ReuseScope.None)
				.OwnedBy (Owner.External);
			
		}
		
		[Test()]
		public void InitializableIsCalledWhenInstanceIsCreated ()
		{
			var builder = new ContainerBuilder ();
			
			builder.Register<IInitializable> (() => new Initializable ())
				.InitializedBy ((i) => i.Initialize ())
				.ReusedWithIn (ReuseScope.Container);
			
			
			var container = builder.Build ();
			var iOne = container.Resolve<IInitializable> () as Initializable;
			var iTwo = container.Resolve<IInitializable> () as Initializable;	
			
			Assert.AreSame (iOne, iTwo);
			Assert.AreEqual (1, iOne.InitializeCalls);
		}
	}
}

