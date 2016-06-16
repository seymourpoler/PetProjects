using System;
using System.Web.Mvc;
using BugTracker.Web.ASP.Net.MVC.Session.ActionFilters;

namespace BugTracker.Web.ASP.Net.MVC.Bugs.Controllers
{
	[RequiredSession]
	public partial class BugsController: Controller
	{
		public ActionResult Index()
		{
			return View("Index.cshtml");
		}
	}
}

