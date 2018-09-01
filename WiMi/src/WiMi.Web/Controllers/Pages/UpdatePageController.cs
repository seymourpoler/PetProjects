using Microsoft.AspNetCore.Mvc;

namespace WiMi.Web.Controllers.Pages
{
    public class UpdatePageController : Controller
    {
        public IActionResult Edit()
        {
            return View("~/Views/Pages/Edit.cshtml");
        }
    }
}