using Idealista.Recruitment.SeniorBackEndDeveloper.Domain.Ads;
using Microsoft.AspNetCore.Mvc;

namespace Idealista.Recruitment.SeniorBackEndDeveloper.Web.Api.Controllers.Ads
{
    public class FindAllAdsController : Controller
    {
        private readonly IFindAllAdsService _findAllAdsService;

        public FindAllAdsController(IFindAllAdsService findAllAdsService)
        {
            _findAllAdsService = findAllAdsService;
        }

        [HttpGet("api/ads/all")]
        public IActionResult Find()
        {
            var ads = _findAllAdsService.Find();
            return Ok(ads);
        }
    }
}
