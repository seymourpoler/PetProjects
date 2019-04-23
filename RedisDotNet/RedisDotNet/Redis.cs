using System;
using System.Text;

namespace RedisDotNet
{
    public class Redis : IDisposable, IRedis
    {
        readonly  string _host;
        readonly int _port;

        public Redis(
            string host = "localhost", 
            int port = 6379)
        {
            _host = host;
            _port = port;
        }

        public void Dispose()
        {
            GC.SuppressFinalize (this);
            throw  new NotImplementedException();
        }

        public void Set(string key, string value)
        {
            Check.IsNull<ArgumentNullException>(key);
            Check.IsNull<ArgumentNullException>(value);

            using (var socket = SocketFactory.Create(host: _host, port: _port))
            {
                var dataToBeSent = BuildDataToBeSent(
                    key: key, 
                    values: Encoding.UTF8.GetBytes(value));
                
                socket.Send(Encoding.UTF8.GetBytes(dataToBeSent));
                socket.Send(Encoding.UTF8.GetBytes(value));
                socket.Send(new[] {(byte) '\r', (byte) '\n'});
            }
        }
        
        static string BuildDataToBeSent(string key, byte [] values)
        {
            var resp = "*3\r\n";
            resp += "$3\r\nSET\r\n";
            
            resp += "$" + Encoding.UTF8.GetByteCount(key) + "\r\n" + key + "\r\n";
            
            resp +=	"$" + values.Length + "\r\n";
            return resp;
        }
    }
}