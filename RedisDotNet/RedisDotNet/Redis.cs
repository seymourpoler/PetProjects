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
                    keys: key, 
                    values: Encoding.UTF8.GetBytes(value));
                
                socket.Send(Encoding.UTF8.GetBytes(dataToBeSent));
                socket.Send(Encoding.UTF8.GetBytes(value));
                socket.Send(new[] {(byte) '\r', (byte) '\n'});
            }
        }

        static string BuildDataToBeSent(byte [] values,  params object [] keys)
        {
            string resp = "*" + (1 + keys.Length + 1).ToString () + "\r\n";
            resp += "$3\r\nSET\r\n";
            foreach (object arg in keys) {
                string argStr = arg.ToString ();
                int argStrLength = Encoding.UTF8.GetByteCount(argStr);
                resp += "$" + argStrLength + "\r\n" + argStr + "\r\n";
            }
            resp +=	"$" + values.Length + "\r\n";
            return resp;
        }
    }
}