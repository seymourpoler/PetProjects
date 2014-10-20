using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using TodoList.Console.Infrastructure.CrossCutting.Configuration;

namespace TodoList.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var url = Configuration.Url;
            using (WebApp.Start<StartUp>(new StartOptions { AppStartup = url }))
            {
                System.Console.Write("server listening at: " + url);
                System.Console.ReadKey();
            }
        }
    }
}
