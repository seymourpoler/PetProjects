using Microsoft.AspNetCore.Mvc;
using WiMi.Domain;
using WiMi.Domain.Pages.Create;

namespace WiMi.Web.Controllers.Pages
{
	public class CreatePageController : Controller
    {
        readonly IPageCreator pageCreator;

		public CreatePageController(
            IPageCreator pageCreator)
        {
            this.pageCreator = pageCreator;
        }

        // GET: Pages/New
        public IActionResult New()
        {
			return View("~/Views/Pages/New.cshtml");
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
	}
}