using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Hello(string name)
        {
            return View("Hello", new ViewModel { Name = name });
        }
    }

    public class ViewModel
    {
        public string Name { get; set; }
    }
}
