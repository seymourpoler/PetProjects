using Microsoft.AspNetCore.Mvc;

namespace TuduManayer.UserInterface.AspNetCore.Mvc.Login.Controllers
{
    public partial class LoginController :  Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
