using BugTracker.Web.ASP.Net.MVC.Login.Controllers;
using BugTracker.Web.ASP.Net.MVC.Bugs.Controllers;
using BugTracker.Web.ASP.Net.MVC.SignUp.Controllers;
using System;
using System.Collections.Generic;
using System.Web.Mvc;


namespace BugTracker.Web.ASP.Net.MVC.Factories
{
	public class ControllerFactoryResolver: IDependencyResolver
	{
		public object GetService(Type serviceType)
		{
			if (serviceType == typeof(LoginController))
				return ControllersFactory.LoginController();
			if (serviceType == typeof(SignUpController))
				return ControllersFactory.SignUpController();
			if (serviceType == typeof(BugsController))
				return ControllersFactory.BugController();
			return null;
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			return new List<object>();
		}
	}
}

