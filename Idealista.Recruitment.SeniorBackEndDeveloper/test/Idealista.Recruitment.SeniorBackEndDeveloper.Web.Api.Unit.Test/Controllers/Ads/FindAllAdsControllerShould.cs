using Idealista.Recruitment.SeniorBackEndDeveloper.Domain.Ads;
using Idealista.Recruitment.SeniorBackEndDeveloper.Web.Api.Controllers.Ads;
using Moq;
using Xunit;

namespace Idealista.Recruitment.SeniorBackEndDeveloper.Web.Api.Unit.Test.Controllers.Ads
{
    public class FindAllAdsControllerShould
    {
        [Fact]
        public void ReturnAllAds()
        {
            var findAllAdsService = new Mock<IFindAllAdsService>();
            var controller = new FindAllAdsController(findAllAdsService.Object);

             controller.Find();

            findAllAdsService
                .Verify(x => x.Find());
        }
    }
}
