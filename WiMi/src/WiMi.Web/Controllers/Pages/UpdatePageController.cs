using Microsoft.AspNetCore.Mvc;
using System;
using WiMi.Domain.Pages.Find;

namespace WiMi.Web.Controllers.Pages
{
    public class UpdatePageController : Controller
    {
        readonly IPageFinder pageFinder;

        public UpdatePageController(IPageFinder pageFinder)
        {
            this.pageFinder = pageFinder;
        }

        public IActionResult Edit(Guid id)
        {
            var page = pageFinder.FindBy(id);
            return View("~/Views/Pages/Edit.cshtml", page);
        }
    }
}