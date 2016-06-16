using System.Web.Mvc;

namespace BugTracker.Web.ASP.Net.MVC.Login.Controllers
{
	public partial class LoginController : Controller
	{
		[HttpGet]
		public ActionResult Index()
		{
			return View("Index.cshtml");
		}
	}
}

