using System.Net.Sockets;

namespace RedisDotNet
{
    public static class SocketFactory
    {
        public static Socket Create(string host, int port)
        {
            var result = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            result.NoDelay = true;
            result.SendTimeout = -1;
            result.Connect(host: host, port: port);
            
            return result;
        }
    }
}