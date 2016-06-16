
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BugTracker.Web.ASP.Net.MVC.App_Start;
using BugTracker.Web.ASP.Net.MVC.Factories;

namespace BugTracker.Web.ASP.Net.MVC
{
	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterGlobalFilters (GlobalFilterCollection filters)
		{
			filters.Add (new HandleErrorAttribute ());
		}

		protected void Application_Start ()
		{
			AreaRegistration.RegisterAllAreas ();
			RegisterGlobalFilters (GlobalFilters.Filters);
			RoutersRegister.RegisterRoutes (RouteTable.Routes);
			DependencyResolver.SetResolver(new ControllerFactoryResolver());

			ViewEngines.Engines.Clear();
			ViewEngines.Engines.Add(new BugTrackerVirtualPathProviderViewEngine());
		}
	}
}
