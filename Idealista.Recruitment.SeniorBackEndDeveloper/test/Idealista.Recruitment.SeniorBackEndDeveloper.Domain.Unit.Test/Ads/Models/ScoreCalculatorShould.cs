using Idealista.Recruitment.SeniorBackEndDeveloper.Domain.Ads.Models;
using Shouldly;
using Xunit;

namespace Idealista.Recruitment.SeniorBackEndDeveloper.Domain.Unit.Test.Ads.Models
{
    public class ScoreCalculatorShould
    {
        [Fact]
        public void ReturnMinusTenPointsWhenHasNullPictures()
        {
            var calculator = new ScoreAdCalculator();
            var ad = new Ad(
                typology: AdTypology.Flat,
                pictures: null);

            var score = calculator.Calculate(ad);

            score.ShouldBe(-10);
        }

        [Fact]
        public void ReturnMinusTenPointsWhenHasNoPictures()
        {
            var calculator = new ScoreAdCalculator();
            var ad = new Ad(
                typology: AdTypology.Flat,
                pictures: new string[] { });

            var score = calculator.Calculate(ad);

            score.ShouldBe(-10);
        }

        [Fact]
        public void ReturnTwelvePointssWhenHasHighDefinitionPicture()
        {
            var calculator = new ScoreAdCalculator();
            var ad = new Ad(
                typology: AdTypology.Flat,
                pictures: new[] { "photo_HD.jpg" });

            var score = calculator.Calculate(ad);

            score.ShouldBe(20);
        }

        [Fact]
        public void ReturnTenPointsWhenHasPicture()
        {
            var calculator = new ScoreAdCalculator();
            var ad = new Ad(
                typology: AdTypology.Flat,
                pictures: new[] { "photo.jpg" });

            var score = calculator.Calculate(ad);

            score.ShouldBe(10);
        }

        [Fact]
        public void ReturnThirtyPointsWhenHasNormalPictureAndHighDefinitionPicture()
        {
            var calculator = new ScoreAdCalculator();
            var ad = new Ad(
                typology: AdTypology.Flat,
                pictures: new[] { "photo.jpg", "photo_HD.jpg" });

            var score = calculator.Calculate(ad);

            score.ShouldBe(30);
        }

        [Fact]
        public void ReturnFifteenPointWhenHasPictureAndDescription()
        {
            var calculator = new ScoreAdCalculator();
            var ad = new Ad(
                typology: AdTypology.Flat,
                pictures: new[] { "photo.jpg" },
                description: "a description");

            var score = calculator.Calculate(ad);

            score.ShouldBe(15);
        }

        [Fact]
        public void ReturnTwentyFivePointsWhenIsAFlatAndDescriptionHasMoreOrEqualsTewntyCharactersAndMinusOrEqualsFourtyNineCharacters()
        {
            var calculator = new ScoreAdCalculator();
            var ad = new Ad(
                typology: AdTypology.Flat,
                pictures: new[] { "photo.jpg" },
                description: "Este piso es una ganga, compra, COMPRA!!!!");

            var score = calculator.Calculate(ad);

            score.ShouldBe(25);
        }

        [Fact]
        public void ReturnThirtyFivePointsWhenIsAFlatAndDescriptionHasMoreOrEqualFiftyCharacters()
        {
            var calculator = new ScoreAdCalculator();
            var ad = new Ad(
                typology: AdTypology.Flat,
                pictures: new[] { "photo.jpg" },
                description: "Este piso es una ganga. No deje pasar la oportunidad y adquiera este piso, compra, COMPRA!!!!");

            var score = calculator.Calculate(ad);

            score.ShouldBe(45);
        }

        [Fact]
        public void ReturnThirtyFivePointsWhenIsAChaletAndDescriptionHasMoreThanFiftyCharacters()
        {
            var calculator = new ScoreAdCalculator();
            var ad = new Ad(
                typology: AdTypology.Chalet,
                pictures: new[] { "photo.jpg" },
                description: "Este chalet es una ganga. No deje pasar la oportunidad y adquiera este chalets, compra, COMPRA!!!!");

            var score = calculator.Calculate(ad);

            score.ShouldBe(35);
        }

        [Fact]
        public void ReturnTwentyPointsWhenHasLuminosoWordInDescription()
        {
            var calculator = new ScoreAdCalculator();
            var ad = new Ad(
                typology: AdTypology.Chalet,
                pictures: new[] { "photo.jpg" },
                description: "Este chalet es Luminoso");

            var score = calculator.Calculate(ad);

            score.ShouldBe(20);
        }

        [Fact]
        public void ReturnTwentyPointsWhenHasNuevoWordInDescription()
        {
            var calculator = new ScoreAdCalculator();
            var ad = new Ad(
                typology: AdTypology.Flat,
                pictures: new[] { "photo.jpg" },
                description: "Nuevo piso");

            var score = calculator.Calculate(ad);

            score.ShouldBe(20);
        }

        [Fact]
        public void ReturnTwentyPointsWhenHasCéntricoWordInDescription()
        {
            var calculator = new ScoreAdCalculator();
            var ad = new Ad(
                typology: AdTypology.Chalet,
                pictures: new[] { "photo.jpg" },
                description: "Se vende un Céntrico chalet");

            var score = calculator.Calculate(ad);

            score.ShouldBe(20);
        }

        [Fact]
        public void ReturnTwentyPointsWhenHasReformadoWordInDescription()
        {
            var calculator = new ScoreAdCalculator();
            var ad = new Ad(
                typology: AdTypology.Flat,
                pictures: new[] { "photo.jpg" },
                description: "Un piso Reformado");

            var score = calculator.Calculate(ad);

            score.ShouldBe(20);
        }

        [Fact]
        public void ReturnTwentyPointsWhenHasÁticoWordInDescription()
        {
            var calculator = new ScoreAdCalculator();
            var ad = new Ad(
                typology: AdTypology.Flat,
                pictures: new[] { "photo.jpg" },
                description: "Se vende Ático");

            var score = calculator.Calculate(ad);

            score.ShouldBe(20);
        }

        [Fact]
        public void ReturnFiftyFivePointForCompletedFlatAd()
        {
            var calculator = new ScoreAdCalculator();
            var ad = new Ad(
                typology: AdTypology.Flat,
                pictures: new[] { "photo.jpg" },
                description: "Se vende piso",
                houseSize: 120);

            var score = calculator.Calculate(ad);

            score.ShouldBe(55);
        }

        [Fact]
        public void ReturnFiftyFivePointForCompletedChaletAd()
        {
            var calculator = new ScoreAdCalculator();
            var ad = new Ad(
                typology: AdTypology.Chalet,
                pictures: new[] { "photo.jpg" },
                description: "Se vende piso",
                houseSize: 120,
                houseGarden: 9);

            var score = calculator.Calculate(ad);

            score.ShouldBe(55);
        }

        [Fact]
        public void ReturnFiftyPointForCompletedGarageAd()
        {
            var calculator = new ScoreAdCalculator();
            var ad = new Ad(
                typology: AdTypology.Garage,
                pictures: new[] { "photo.jpg" },
                description: string.Empty,
                houseSize: 10);

            var score = calculator.Calculate(ad);

            score.ShouldBe(50);
        }

    }
}
