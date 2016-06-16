using System;
using System.Web;
using BugTracker.Web.ASP.Net.MVC.Session;
using BugTracker.Web.ASP.Net.MVC.Session.Models;
using BugTracker.CrossCutting.JsonSerializer;

namespace BugTracker.Web.ASP.Net.MVC.Session.Services
{
	public interface ISessionService
	{
		void SetSession(Models.Session session);
		Models.Session GetCurrentSession ();
		string GetTokenFromCurrentSession();
		void SetCurrentSessionFromToken (string sessionToken);
		bool IsAnonymous ();
	}

	public class SessionService : ISessionService
	{
		private readonly IJsonSerializer serializer;

		public SessionService (IJsonSerializer serializer)
		{
			this.serializer = serializer;
		}

		public void SetSession(Models.Session session)
		{
			HttpContext.Current.Items[Constants.Session] = session;
			SetCurrentSessionFromToken (
				GetTokenFromCurrentSession ());
		}

		public Models.Session GetCurrentSession()
		{
			var result = HttpContext.Current.Items [Constants.Session] as Models.Session;
			if (result != null) {
				return result;
			}
			var cookies = HttpContext.Current.Request.Cookies.Get (Constants.Session);
			if (cookies == null) {
				return GetCurrentSessionFromToken (String.Empty);
			}
			return GetCurrentSessionFromToken(cookies.Value);
		}

		public bool IsAnonymous ()
		{
			return GetCurrentSession () == null;
		}

		public string GetTokenFromCurrentSession()
		{
			return serializer.Serialize (
				GetCurrentSession());
		}
			
		public void SetCurrentSessionFromToken (string sessionToken)
		{
			var request = HttpContext.Current.Request;
			var response = HttpContext.Current.Response;
			var cookie = response.Cookies.Get(Constants.Session);
			if (cookie != null)
			{
				cookie.Path = request.ApplicationPath;
				cookie.Value = sessionToken;
				cookie.Expires = DateTime.UtcNow.AddHours(20);
				response.Cookies.Set(cookie);
			}
		}

		private Models.Session GetCurrentSessionFromToken(string token)
		{
			return serializer.Deserialize<Models.Session> (token);
		}
	}
}

