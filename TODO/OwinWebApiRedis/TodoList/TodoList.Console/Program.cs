using Microsoft.Owin;
using Microsoft.Owin.Hosting;

namespace TodoList.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var port = 5000;
            using (WebApp.Start<StartUp>(new StartOptions { Port = port }))
            {
                System.Console.Write("server listening at: " + port);
                System.Console.ReadKey();
            }
        }
    }
}
