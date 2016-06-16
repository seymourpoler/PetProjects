using System;
using System.Web;
using System.Web.Mvc;
using BugTracker.CrossCutting.JsonSerializer;
using BugTracker.Web.ASP.Net.MVC.Session.Models;
using BugTracker.Web.ASP.Net.MVC.Session.Services;

namespace BugTracker.Web.ASP.Net.MVC.Session.ActionFilters
{
	public class RequiredSession: AuthorizeAttribute
	{
		private ISessionService sessionService;

		public RequiredSession(){
			sessionService = new SessionService (new JsonSerializer());
		}

		protected override bool AuthorizeCore(HttpContextBase httpContext)
		{
			return !sessionService.IsAnonymous();
		}
	}
}

