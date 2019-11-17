using System;
using System.Collections.Generic;

namespace Idealista.Recruitment.SeniorBackEndDeveloper.Repository.EntityFramework.InMemory.Ads.Models
{
    public class Ad
    {
        public int Id { get; set; }
        private string Typology { get; set; }
        private string Description { get; set; }
        private List<string> PictureUrls { get; set; }
        private int HouseSize { get; set; }
        private int GardenSize { get; set; }
        private int Score { get; set; }
        private DateTime IrrelevantSince { get; set; }
    }
}