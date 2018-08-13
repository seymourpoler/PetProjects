using Microsoft.AspNetCore.Mvc;
using WiMi.Domain.Pages.Find;

namespace WiMi.Web.Controllers.Pages
{
	public class FindPagesController : Controller
    {
		readonly IPageFinder pageFinder;

		public FindPagesController(IPageFinder pageFinder)
		{
			this.pageFinder = pageFinder;
		}

        public IActionResult Index()
        {
			return View("~/Views/Pages/Index.cshtml");
        }

		[HttpGet]
		public IActionResult Find()
		{
			var pages = pageFinder.Find();
			return Ok(pages);
		}
	}
}
