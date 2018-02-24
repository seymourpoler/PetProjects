using Microsoft.Extensions.Configuration;
using System.IO;

namespace Gambon.SqlServer
{
    public class AppConfiguration
    {
        private readonly IConfiguration configuration;

        public AppConfiguration()
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public string ConnectionString
        {
            get
            {
                return configuration.GetConnectionString("Gambon");
            }
        }
    }
}
