using BugTracker.Web.ASP.Net.MVC.Bugs.Controllers;
using BugTracker.Web.ASP.Net.MVC.Login.Controllers;
using BugTracker.Web.ASP.Net.MVC.SignUp.Controllers;

namespace BugTracker.Web.ASP.Net.MVC.Factories
{
	public class ControllersFactory
	{
		public static LoginController LoginController()
		{
			return new LoginController (
				sessionService: ServicesFactory.SessionService (),
				validateLoginUser: CommandsFactory.ValidateLoginUser ());
		}

		public static SignUpController SignUpController(){
			return new SignUpController (
				createUser: CommandsFactory.CreateUser(),
				sessionService: ServicesFactory.SessionService());
		}

		public static BugsController BugController()
		{
			return new BugsController (
				sessionService: ServicesFactory.SessionService(),
				findByUserEmail: QueriesFactory.FindBugsByUserEmail (),
				createNewBug: CommandsFactory.CreateNewBug(),
				removeBug: CommandsFactory.RemoveBug());
		}
	}
}

