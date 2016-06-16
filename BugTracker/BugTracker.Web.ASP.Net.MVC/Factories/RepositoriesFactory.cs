using BugTracker.Data.MongoDb.Users;
using BugTracker.Data.MongoDb.Bugs;
using BugTracker.Domain.Bugs.Commands.Repositories;
using BugTracker.Domain.Users.Commands.Repositories;


namespace BugTracker.Web.ASP.Net.MVC.Factories
{
	public class RepositoriesFactory
	{
		public static IUserRepository UserRepository(){
			return new UsersStore ();
		}

		public static IBugRepository BugRepository(){
			return new BugsStore ();
		}
	}
}

