using BugTracker.CrossCutting.JsonSerializer;
using BugTracker.Data.MongoDb.Users;
using BugTracker.Data.MongoDb.Bugs;
using BugTracker.Domain.Bugs.Queries;
using BugTracker.Web.ASP.Net.MVC.Session.Services;
using System;

namespace BugTracker.Web.ASP.Net.MVC.Factories
{
	public class ServicesFactory
	{
		public static ISessionService SessionService()
		{
			return new SessionService (new JsonSerializer());
		}
	}
}

