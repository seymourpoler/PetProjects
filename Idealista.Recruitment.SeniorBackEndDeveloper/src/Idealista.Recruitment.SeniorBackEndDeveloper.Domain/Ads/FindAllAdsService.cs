using System.Collections.Generic;
using Idealista.Recruitment.SeniorBackEndDeveloper.Domain.Ads.Models;

namespace Idealista.Recruitment.SeniorBackEndDeveloper.Domain.Ads
{
    public interface IFindAllAdsService
    {
        IReadOnlyCollection<Ad> Find();
    }

    public class FindAllAdsService : IFindAllAdsService
    {
        private readonly IFindAllAdsRepository _findAllAdsRepository;

        public FindAllAdsService(IFindAllAdsRepository findAllAdsRepository)
        {
            _findAllAdsRepository = findAllAdsRepository;
        }

        public IReadOnlyCollection<Ad> Find()
        {
            var ads = _findAllAdsRepository.Find();
            return ads;
        }
    }
}
