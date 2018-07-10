using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WiMi.Web.Controllers
{
    public class PagesController : Controller
    {
        // GET: Pages
        public ActionResult Index()
        {
            return View();
        }

        // GET: Pages/Create
        public ActionResult New()
        {
            return View();
        }

        // GET: Pages/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
    }
}