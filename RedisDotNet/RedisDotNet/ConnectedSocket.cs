using System;
using System.Net.Sockets;
using System.Text;

namespace RedisDotNet
{
    public class ConnectedSocket : IDisposable
    {
        readonly Socket _socket;

        public ConnectedSocket(string host, int port)
        {
            _socket =  new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.NoDelay = true;
            _socket.SendTimeout = -1;
            _socket.Connect(host: host, port: port);
        }

        public virtual void Send(string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            Send(bytes);
        }
        
        public virtual void Send(byte[] values)
        {
            _socket.Send(values);
        }

        public void Dispose()
        {
            if (_socket is null)
            {
                return;
            }
            _socket.Close();
            _socket.Dispose();
        }
    }
}