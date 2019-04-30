using System;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace RedisDotNet
{
    public class ConnectedSocket : IDisposable
    {
        readonly Socket _socket;
        BufferedStream _buffer;

        //For tests
        public ConnectedSocket()
        {
            
        }
        public ConnectedSocket(string host, int port)
        {
            _socket =  new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.NoDelay = true;
            _socket.SendTimeout = -1;
            _socket.Connect(host: host, port: port);
            const int bufferSize = 16 * 1024;
            _buffer = new BufferedStream (stream: new NetworkStream (_socket), bufferSize: bufferSize);
        }

        public virtual void Send(string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            Send(bytes);
        }
        
        public virtual void Send(byte[] values)
        {
            _socket.Send(values);
            
            //TODO: refactor --> extract
            const int error = -1;
            if (error == _buffer.ReadByte())
            {
                throw new RedisException("No more data");   
            }
            
            var stringBuilder = new StringBuilder ();
            int c;
            while ((c = _buffer.ReadByte ()) != error){
                if (c == '\r')
                    continue;
                if (c == '\n')
                    break;
                stringBuilder.Append ((char) c);
            }

            var line = stringBuilder.ToString();
            if (line.First() == '-')
            {
                var message = line;
                if (line.StartsWith("ERR "))
                {
                    message = line.Substring(4);
                }
                throw new RedisException(message);
            }
        }

        public void Dispose()
        {
            if (_socket != null)
            {
                _socket.Close();
                _socket.Dispose();
            }

            if (_buffer != null)
            {
                _buffer.Close();
                _buffer.Dispose();
            }
        }
    }
}