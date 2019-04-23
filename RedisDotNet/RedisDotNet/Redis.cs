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
            
            Set(key: key, value: Encoding.UTF8.GetBytes(value));
        }

        public void Set(string key, byte[] value)
        {
            Check.IsNull<ArgumentNullException>(key);
            Check.IsNull<ArgumentNullException>(value);
            
            using (var socket = SocketFactory.Create(host: _host, port: _port))
            {
                var dataToBeSent = BuildDataToBeSent(key: key, values: value);
                
                socket.Send(dataToBeSent);
                socket.Send(value);
                socket.Send(new[] {(byte) '\r', (byte) '\n'});
            }
        }
        
        static byte[] BuildDataToBeSent(string key, byte [] values)
        {
            var result = new StringBuilder();
            result.Append("*3\r\n");
            result.Append("$3\r\nSET\r\n");
            result.Append("$").Append(Encoding.UTF8.GetByteCount(key)).Append("\r\n");
            result.Append(key).Append("\r\n");
            result.Append("$").Append(values.Length).Append("\r\n");
            
            return Encoding.UTF8.GetBytes(result.ToString());
        }
    }
}