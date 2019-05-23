using System;
using System.IO;
using System.Net.Sockets;

namespace RedisDotNet
{
    public interface IConnectedSocket
    {
        string Send(string command);
    }
    
    public class ConnectedSocket : IConnectedSocket
    {
        protected Socket _socket;
        protected BufferedStream _buffer;
        
        
        public ConnectedSocket(string host, int port)
        {
            _socket =  new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.NoDelay = true;
            _socket.SendTimeout = -1;
            _socket.Connect(host: host, port: port);
            const int bufferSize = 16 * 1024;
            _buffer = new BufferedStream (stream: new NetworkStream (_socket), bufferSize: bufferSize);
        }

        public string Send(string command)
        {
            throw new NotImplementedException();
        }
    }
}