using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace BugTracker.Web.ASP.Net.MVC
{
	public class BugTrackerControllerFactory : DefaultControllerFactory
	{
		public virtual IController CreateController(RequestContext requestContext, string controllerName)
		{
			throw new NotImplementedException ();
		}

		public override void ReleaseController(IController controller)
		{
			IDisposable dispose = controller as IDisposable;
			if (dispose != null)
			{
				dispose.Dispose();
			}
		}
	}
}

