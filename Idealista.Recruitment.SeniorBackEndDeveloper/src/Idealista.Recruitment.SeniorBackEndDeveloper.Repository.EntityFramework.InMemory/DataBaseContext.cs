using Microsoft.EntityFrameworkCore;

namespace Idealista.Recruitment.SeniorBackEndDeveloper.Repository.EntityFramework.InMemory
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        { }
        
        public DbSet<Ads.Models.Ad> Ads { get; set; }
        public DbSet<Ads.Models.Picture> Pictures { get; set; }
    }
}