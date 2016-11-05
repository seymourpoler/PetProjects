using Microsoft.AspNetCore.Mvc;

namespace TuduManayer.UserInterface.AspNetCore.Mvc.Login.Controllers
{
    public class LoginController :  Controller
    {
        public IActionResult Index()
        {
            return View("~/Login/Views/Index.cshtml");
        }
    }
}
