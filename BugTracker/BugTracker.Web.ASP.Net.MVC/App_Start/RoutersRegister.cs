using System.Web.Mvc;
using System.Web.Routing;

namespace BugTracker.Web.ASP.Net.MVC.App_Start
{
	public class RoutersRegister
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name:"ShowLogin",
				url: "login",
				defaults: new { controller = "Login", action = "Index" }
			);

			routes.MapRoute(
				name:"Login",
				url: "api/login",
				defaults: new { controller = "Login", action = "Login" }
			);

			routes.MapRoute(
				name:"ShowSignUp",
				url: "signup",
				defaults: new { controller = "SignUp", action = "Index" }
			);

			routes.MapRoute(
				name:"SignUp",
				url: "api/signup",
				defaults: new { controller = "SignUp", action = "SignUp" }
			);

			routes.MapRoute(
				name:"ShowBugs",
				url: "bugs",
				defaults: new { controller = "Bugs", action = "Index" }
			);

			routes.MapRoute(
				name:"GetBugsByUser",
				url: "api/me/bugs",
				defaults: new { controller = "Bugs", action = "GetBugsByUser" }
			);

			routes.MapRoute(
				name:"CreateNewBug",
				url: "api/me/create/bug",
				defaults: new { controller = "Bugs", action = "CreateNewBug"}
			);

			routes.MapRoute(
				name:"DeleteBug",
				url: "api/me/remove/bug",
				defaults: new { controller = "Bugs", action = "RemoveBug"}
			);

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}

