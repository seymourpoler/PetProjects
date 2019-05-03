using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace RedisDotNet.Commands
{
    public class BaseCommand : IDisposable
    {
        protected const int fail = -1;
        protected const string success = "OK";
        
        protected Socket _socket;
        protected BufferedStream _buffer;

        public BaseCommand(string host, int port)
        {
            _socket =  new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.NoDelay = true;
            _socket.SendTimeout = -1;
            _socket.Connect(host: host, port: port);
            const int bufferSize = 16 * 1024;
            _buffer = new BufferedStream (stream: new NetworkStream (_socket), bufferSize: bufferSize);
        }

        protected string ReadLine ()
        {
            StringBuilder result = new StringBuilder ();
            int currentReadByte;
		
            while ((currentReadByte = _buffer.ReadByte ()) != -1){
                if (currentReadByte == '\r')
                    continue;
                if (currentReadByte == '\n')
                    break;
                result.Append ((char) currentReadByte);
            }
            return result.ToString ();
        }
        
        public void Dispose()
        {
            if (_buffer != null)
            {
                _buffer.Close();
                _buffer.Dispose();
            }
            
            if (_socket != null)
            {
                _socket.Close();
                _socket.Dispose();
            }
        }
    }
}