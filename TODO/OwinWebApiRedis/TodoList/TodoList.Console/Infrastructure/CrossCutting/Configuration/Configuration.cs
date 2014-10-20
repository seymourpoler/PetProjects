using System.Configuration;

namespace TodoList.Console.Infrastructure.CrossCutting.Configuration
{
    public static class Configuration
    {
        public static string Url {
            get { return ConfigurationManager.AppSettings["Url"]; }
        }
    }
}
