using System;
using System.Web.Mvc;

namespace BugTracker.Web.ASP.Net.MVC.SignUp.Controllers
{
	public partial class SignUpController : Controller
	{
		[HttpGet]
		public ActionResult Index()
		{
			return View("Index.cshtml");
		}
	}
}

