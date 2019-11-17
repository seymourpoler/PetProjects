namespace Idealista.Recruitment.SeniorBackEndDeveloper.Domain.Ads.Models
{
    public class Picture
    {
        public int Id { get; }
        public string Url { get; }
        public PictureQuality Quality { get; }
        
        public Picture(int id, string url, PictureQuality quality)
        {
            Id = id;
            Url = url;
            Quality = quality;
        }
    }
}