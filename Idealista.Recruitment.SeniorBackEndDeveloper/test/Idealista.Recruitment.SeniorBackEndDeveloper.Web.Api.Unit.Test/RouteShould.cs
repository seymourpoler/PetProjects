using Xunit;
using MyTested.AspNetCore.Mvc;
using Idealista.Recruitment.SeniorBackEndDeveloper.Web.Api.Controllers.Ads;

namespace Idealista.Recruitment.SeniorBackEndDeveloper.Web.Api.Unit.Test
{
    public class RouteShould
    {
        [Fact]
        public void MapToReturnAllAds()
        {
            MyMvc
                .Routing()
                .ShouldMap(request => request
                    .WithLocation("/api/ads/all")
                    .WithUser())
                .To<FindAllAdsController>(c => c.Find());
        }
    }
}
