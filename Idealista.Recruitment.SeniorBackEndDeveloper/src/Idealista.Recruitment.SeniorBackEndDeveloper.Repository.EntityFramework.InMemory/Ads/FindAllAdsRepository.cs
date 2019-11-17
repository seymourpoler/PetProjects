using System.Collections.Generic;
using System.Linq;
using Idealista.Recruitment.SeniorBackEndDeveloper.Domain.Ads;
using Idealista.Recruitment.SeniorBackEndDeveloper.Domain.Ads.Models;

namespace Idealista.Recruitment.SeniorBackEndDeveloper.Repository.EntityFramework.InMemory.Ads
{
    public class FindAllAdsRepository : IFindAllAdsRepository
    {
        private readonly DataBaseContext _dataBaseContext;

        public FindAllAdsRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public IReadOnlyCollection<Ad> Find()
        {
            var ads = _dataBaseContext.Ads.ToList();
            
            
            
            throw new System.NotImplementedException();
        }

        private IReadOnlyCollection<Ad> Build(IReadOnlyCollection<Models.Ad> ads)
        {
            foreach (var ad in ads)
            {
                
            }
        }

        private Ad Build(Models.Ad ad)
        {
            var result = new Ad(
                id: ad.Id,
                ty);
        }

        private IReadOnlyCollection<Picture> Build(List<int> pictureIds)
        {
            var result = new List<Picture>();
            
            foreach (var pictureId in pictureIds)
            {
                var picture = _dataBaseContext.Pictures.FirstOrDefault(x => x.Id == pictureId);
                if (picture != null)
                {
                    result.Add(new Picture(
                        id: picture.Id,
                        url: picture.Url,
                        quality: Build(picture.Quality)));
                }
            }

            return result.AsReadOnly();

            PictureQuality Build(string quality)
            {
                if (quality == "HD")
                {
                    return PictureQuality.High;
                }

                return PictureQuality.Standard;
            }
        }
    }
}