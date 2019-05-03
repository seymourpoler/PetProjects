using System;
using System.Text;

namespace RedisDotNet
{
    public class Redis : IRedis, IDisposable
    {
        readonly ConnectedSocketFactory _connectedSocketFactory;

        public Redis(ConnectedSocketFactory connectedSocketFactory)
        {
            _connectedSocketFactory = connectedSocketFactory;
        }

        public void Dispose()
        {
            GC.SuppressFinalize (this);
        }

        public void Set(string key, string value)
        {
            Set(key: key, value: Encoding.UTF8.GetBytes(value));
        }

        public void Set(string key, byte[] value)
        {
            Check.IsNullOrWhiteSpace<ArgumentNullException>(key);
            Check.IsNullOrEmpty<byte, ArgumentNullException>(value);

            using (var socket = _connectedSocketFactory.Create())
            {
                var dataToBeSent = BuildDataToBeSent(key: key, values: value);
                socket.Send(dataToBeSent);
                socket.Send(value);
                socket.Send(new[] {(byte) '\r', (byte) '\n'});
            }
        }

        static string BuildDataToBeSent(string key, byte [] values)
        {
            var result = new StringBuilder();
            result.Append("*3\r\n");
            result.Append("$3\r\nSET\r\n");
            result.Append("$").Append(Encoding.UTF8.GetByteCount(key)).Append("\r\n");
            result.Append(key).Append("\r\n");
            result.Append("$").Append(values.Length).Append("\r\n");

            return result.ToString();
        }

        public void FlushAll()
        {
            using (var socket = _connectedSocketFactory.Create())
            {
                var dataToBeSent = new StringBuilder("*1\r\n");
                dataToBeSent.Append("$8\r\nFLUSHALL\r\n");
                socket.Send(dataToBeSent.ToString());
            }
        }

        public void Remove(string key)
        {
            using (var socket = _connectedSocketFactory.Create())
            {
                var dataToBeSent = new StringBuilder("*2\r\n");
                dataToBeSent.Append("$3\r\nDEL\r\n");
                dataToBeSent.Append("$");
                dataToBeSent.Append(key.Length);
                dataToBeSent.Append("\r\n");
                dataToBeSent.Append(key);
                dataToBeSent.Append("\r\n");
                socket.Send(dataToBeSent.ToString());
            }
        }

        public void ContainsKey(string key)
        {
            using (var socket = _connectedSocketFactory.Create())
            {
                var dataToBeSent = new StringBuilder("*2\r\n");
                dataToBeSent.Append("$6\r\nEXISTS\r\n");
                dataToBeSent.Append("$");
                dataToBeSent.Append(key.Length);
                dataToBeSent.Append("\r\n");
                dataToBeSent.Append(key);
                dataToBeSent.Append("\r\n");
                socket.Send(dataToBeSent.ToString());
            }
        }
    }
}