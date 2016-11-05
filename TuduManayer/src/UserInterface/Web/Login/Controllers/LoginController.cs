using Microsoft.AspNetCore.Mvc;

namespace Web.Login.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View("Index.cshtml");
        }
    }
}
