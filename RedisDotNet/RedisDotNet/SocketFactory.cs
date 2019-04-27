using System.Net.Sockets;

namespace RedisDotNet
{
    public static class SocketFactory
    {
        public static ConnectedSocket Create(string host, int port)
        {
            var socket = new ConnectedSocket(host: host, port: port);
            return socket;
        }
    }
}