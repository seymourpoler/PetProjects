using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult InternalServerError()
        {
            return View();
        }

        public IActionResult Forbidden()
        {
            return View();
        }
    }
}
