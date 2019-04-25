using System.Net.Sockets;

namespace RedisDotNet
{
    public static class SocketFactory
    {
        public static Socket Create(string host, int port)
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.NoDelay = true;
            socket.SendTimeout = -1;
            socket.Connect(host: host, port: port);
            
            return socket;
        }
    }
}