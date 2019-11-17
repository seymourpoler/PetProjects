using Idealista.Recruitment.SeniorBackEndDeveloper.Domain.Ads;
using Moq;
using Xunit;

namespace Idealista.Recruitment.SeniorBackEndDeveloper.Domain.Unit.Test.Ads
{
    public class FindAllAdsServiceShould
    {
        [Fact]
        public void ReturnAllAds()
        {
            var repository = new Mock<IFindAllAdsRepository>();
            var service = new FindAllAdsService(repository.Object);

            var ads = service.Find();

            repository
                .Verify(x => x.Find());
        }
    }
}
