using System;
using Microsoft.AspNetCore.Mvc;
using WiMi.Web.Models;

namespace WiMi.Web.Controllers
{
    public class PagesController : Controller
    {
        // GET: Pages
        public IActionResult Index()
        {
            return View();
        }

        // GET: Pages/New
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromBody]PageCreationRequest request)
        {
            if (request is null)
            {
                return BadRequest("request can not be null");
            }
            throw new NotImplementedException();
        }

        // GET: Pages/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }
    }
}