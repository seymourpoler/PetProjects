using System.Collections.Generic;
using System.Linq;

namespace Idealista.Recruitment.SeniorBackEndDeveloper.Domain.Ads.Models
{
    public class Ad
    {
        public int Id { get; }
        public IReadOnlyCollection<Picture> Pictures { get; }
        public string Description { get; }
        public AdTypology Typology { get; }
        public int HouseSize { get; }
        public int HouseGarden { get; }

        public bool IsCompleted
        {
            get
            {
                var hasPictures = Pictures != null && Pictures.Any();

                return HasDescription() &&
                    hasPictures &&
                    HasSize();
            }
        }

        public Ad(
            int id,
            AdTypology typology,
            IReadOnlyCollection<Picture> pictures = null,
            string description = "",
            int houseSize = 0,
            int houseGarden = 0)
        {
            Id = id;
            Pictures = pictures;
            Description = description;
            Typology = typology;
            HouseSize = houseSize;
            HouseGarden = houseGarden;
        }      

        private bool HasDescription()
        {
            if(Typology == AdTypology.Garage)
            {
                return true;
            }
            return !string.IsNullOrWhiteSpace(Description);
        }

        private bool HasSize()
        {
            if (Typology == AdTypology.Chalet)
            {
                return HouseSize > 0 &&
                    HouseGarden > 0;
            }
            return HouseSize > 0;
        }
    }
}
