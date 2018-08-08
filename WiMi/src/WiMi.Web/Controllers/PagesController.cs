using Microsoft.AspNetCore.Mvc;
using System;
using WiMi.Domain;
using WiMi.Domain.Pages.Create;

namespace WiMi.Web.Controllers
{
    public class PagesController : Controller
    {
        readonly IPageCreator pageCreator;

        public PagesController(
            IPageCreator pageCreator)
        {
            this.pageCreator = pageCreator;
        }

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

        // GET: Pages/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromBody]Models.PageCreationRequest request)
        {
            if (request is null)
            {
                return BadRequest(Error.ErrorCodes.RequestCanNotBeNull);
            }
			var result = pageCreator.Create(new PageCreationRequest(title: request.Title, body: request.Body));
			if(result.IsOk)
			{
                return Ok();
			}
            return BadRequest(result.Errors);
        }

        [HttpGet]
        public IActionResult Find()
<<<<<<< HEAD
=======
        {
            throw new NotImplementedException();
        }

        // GET: Pages/Edit/5
        public IActionResult Edit(int id)
>>>>>>> 9cca9fd40531ad0c81c79343c7d8444c72db0e56
        {
            var result = pageCreator.Create(new PageCreationRequest(title: request.Title, body: request.Body));
            if (result.IsOk)
            {
                return Ok();
            }
            return BadRequest(result.Errors);
        }
    }
}