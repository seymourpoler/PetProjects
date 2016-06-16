using System;
using System.Web.Mvc;

namespace BugTracker.Web.ASP.Net.MVC
{
	public class BugTrackerVirtualPathProviderViewEngine: VirtualPathProviderViewEngine
	{
		public BugTrackerVirtualPathProviderViewEngine()
		{
			ViewLocationFormats = new[]
			{
				"~/{1}/Views/{0}",
				"~{1}/Views/{0}",
				"{1}/Views/{0}"
			};
		}

		protected override IView CreatePartialView (ControllerContext controllerContext, string partialPath)
		{
			var physicalpath = controllerContext.HttpContext.Server.MapPath(partialPath);
			return new BugTrackerView(physicalpath);
		}

		protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
		{
			var physicalpath = controllerContext.HttpContext.Server.MapPath(viewPath);
			return new BugTrackerView(physicalpath);
		}

	}
}

