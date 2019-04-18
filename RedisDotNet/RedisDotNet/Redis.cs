using System;
using System.Text;

namespace RedisDotNet
{
    public class Redis : IDisposable, IRedis
    {
        readonly  string _host;
        readonly int _port;

        public Redis(
            string host="localhost", 
            int port=6379)
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
                var dataToBeSent = BuildDataToBeSent(key, value);

                socket.Send(dataToBeSent);
                socket.Send(new byte[] {(byte) '\r', (byte) '\n'});
            }
        }

        static byte[] BuildDataToBeSent(string key, string value)
        {
            var data = new StringBuilder();
            data.Append( $"*{1 + key.Length + 1).ToString ()}\r\n");
            data.Append("${\"SET\".Length}\r\nSET\r\n");
            data.Append("${Encoding.UTF8.GetByteCount(key)}\r\n{key}\r\n");
            data.Append("${value.Length}\r\n");
            var result = Encoding.UTF8.GetBytes(data.ToString());
            return result;
        }
    }
}