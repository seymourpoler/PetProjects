using System;
using System.Net;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using WiMi.Domain;
using WiMi.Domain.Pages;

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

        [System.Web.Http.HttpPost]
        public IHttpActionResult Create([System.Web.Http.FromBody]Models.PageCreationRequest request)
        {
            if (request is null)
            {
                return  httpActionResultBuilder.Build(
                    httpStatuscode: HttpStatusCode.BadRequest, 
                    entity: nameof(Error.ErrorCodes.RequestCanNotBeNull));
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