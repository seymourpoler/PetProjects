using System.Collections.Generic;

namespace Idealista.Recruitment.SeniorBackEndDeveloper.Domain.Ads.Models
{
    public class ScoreAdCalculator
    {
        public int Calculate(Ad ad)
        {
            var score = 0;
            score = score + CalculateScoreOfPictures(ad.Pictures);
            score = score + CalculateScoreOfDescription(ad.Typology, ad.Description);
            if(ad.IsCompleted)
            {
                score = score + 40; 
            }
            return score;
        }

        private int CalculateScoreOfPictures(IReadOnlyCollection<string> pictureUrls)
        {
            var score = 0;
            const int scoreOfNoPictures = -10;
            var isNullOrEmpty = (pictureUrls is null) || (pictureUrls.Count == 0);
            if(isNullOrEmpty)
            {
                return scoreOfNoPictures;
            }
            const int scoreOfHihgDefinitionPicture = 20;
            const int scoreOfPicture = 10;
            foreach(var picture in pictureUrls)
            {
                var isInHighDefinition = picture.Contains("HD");
                if (isInHighDefinition)
                {
                    score = score + scoreOfHihgDefinitionPicture;
                    break;
                }
                score = score + scoreOfPicture;
            }
            return score;
        }

        private int CalculateScoreOfDescription(AdTypology adTypology, string description)
        {
            const int scoreOfNoDescription = 0;
            if(string.IsNullOrWhiteSpace(description))
            {
                return scoreOfNoDescription;
            }
            const int scoreOfDescription = 5;
            var score = scoreOfDescription;

            score = score + CalculateScoreOfKeyWords(description);

            if (adTypology == AdTypology.Flat)
            {
                score = score + CalculateScoreOfFlatDescription(description);
            }
            if(adTypology == AdTypology.Chalet)
            {
                score = score + CalculateScoreOfChaletDescription(description);
            }
            return score;
        }

        private int CalculateScoreOfKeyWords(string description)
        {
            const int scoreOfKeyWord = 5;
            var score = 0;
            if (description.Contains("Luminoso"))
            {
                score = score + scoreOfKeyWord;
            }
            if (description.Contains("Nuevo"))
            {
                score = score + scoreOfKeyWord;
            }
            if (description.Contains("Céntrico"))
            {
                score = score + scoreOfKeyWord;
            }
            if (description.Contains("Reformado"))
            {
                score = score + scoreOfKeyWord;
            }
            if (description.Contains("Ático"))
            {
                score = score + scoreOfKeyWord;
            }
            return score;
        }

        private int CalculateScoreOfFlatDescription(string description)
        {
            var hasMediumLengthDescription = (description.Length >= 20) && (description.Length <= 49);
            if (hasMediumLengthDescription)
            {
                return 10;
            }
            var hasBigLengthDescription = description.Length > 50;
            if (hasBigLengthDescription)
            {
                return 30;
            }
            return 0;
        }
    
        private int CalculateScoreOfChaletDescription(string description)
        {
            if(description.Length > 50)
            {
                return 20;
            }
            return 0;
        }
    }
}
