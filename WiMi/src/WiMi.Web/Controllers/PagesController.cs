﻿using Microsoft.AspNetCore.Mvc;
using WiMi.Domain;
using WiMi.Domain.Pages.Create;

namespace WiMi.Web.Controllers
{
    public class PagesController : Controller
    {
        readonly IPageCreator pageCreator;
        readonly HttpActionResultBuilder httpActionResultBuilder;

        public PagesController(
            IPageCreator pageCreator, 
            HttpActionResultBuilder httpActionResultBuilder)
        {
            this.pageCreator = pageCreator;
            this.httpActionResultBuilder = httpActionResultBuilder;
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

        [HttpPost]
        public IActionResult Create([FromBody]Models.PageCreationRequest request)
        {
            if (request is null)
            {
                //return  httpActionResultBuilder.Build(
                //    httpStatuscode: HttpStatusCode.BadRequest, 
                //    entity: nameof(Error.ErrorCodes.RequestCanNotBeNull));
                return BadRequest(Error.ErrorCodes.RequestCanNotBeNull);
            }
			var result = pageCreator.Create(new PageCreationRequest(title: request.Title, body: request.Body));
			if(result.IsOk)
			{
                //return httpActionResultBuilder.Build(httpStatuscode: HttpStatusCode.OK);
                return Ok();
			}
            //return httpActionResultBuilder.Build(
            //	httpStatuscode: HttpStatusCode.BadRequest,
            //	entity: result.Errors);
            return BadRequest(result.Errors);
        }

        // GET: Pages/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }
    }
}