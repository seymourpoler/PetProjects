using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            const int port = 5000;
            var server = new Server(new Logger());
            Console.CancelKeyPress += delegate
            {
                Console.WriteLine("Stopping server");
                server.Stop();
            };
            Console.WriteLine($"Local server started at localhost:{port} CTRL + C for stopping");
            server.Start(port);
        }
    }
}
