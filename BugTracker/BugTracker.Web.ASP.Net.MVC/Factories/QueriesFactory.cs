using BugTracker.Data.MongoDb.Bugs;
using BugTracker.Domain.Bugs.Queries;
using System;

namespace BugTracker.Web.ASP.Net.MVC.Factories
{
	public class QueriesFactory
	{
		public static IFindBugsByUserEmail FindBugsByUserEmail(){
			return new BugsStore ();
		}
	}
}

