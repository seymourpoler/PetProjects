using System.Collections.Generic;

namespace Idealista.Recruitment.SeniorBackEndDeveloper.Domain.Ads
{
    public interface IFindAllAdsRepository
    {
        IReadOnlyCollection<Models.Ad> Find();
    }
}
