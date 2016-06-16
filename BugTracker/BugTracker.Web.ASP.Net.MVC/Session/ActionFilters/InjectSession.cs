using System;
using System.Web.Mvc;
using BugTracker.CrossCutting.JsonSerializer;
using BugTracker.Web.ASP.Net.MVC.Session.Services;

namespace BugTracker.Web.ASP.Net.MVC
{
	public class InjectSession : ActionFilterAttribute
	{
		private string token;
		private ISessionService sessionService;

		public InjectSession()
		{
			sessionService = new SessionService(new JsonSerializer());
		}

		public override void OnActionExecuted (ActionExecutedContext filterContext)
		{
			token = sessionService.GetTokenFromCurrentSession ();
		}

		public override void OnActionExecuting (ActionExecutingContext filterContext)
		{
			sessionService.SetCurrentSessionFromToken (token);
		}
	}
}

