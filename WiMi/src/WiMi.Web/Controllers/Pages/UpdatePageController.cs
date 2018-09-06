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
            var viewModel = FindPageViewModelBy(id);
            return View("~/Views/Pages/Edit.cshtml", viewModel);
        }

        Models.UpdatePageViewModel FindPageViewModelBy(Guid id)
        {
            var page = pageFinder.FindBy(id);
            var result = new Models.UpdatePageViewModel
            {
                Id = page.Id.ToString(),
                Title = page.Title,
                Body = page.Body
            };
            return result;
        }
    }
}