using System;
using System.Text;
using RedisDotNet.Commands;

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

            using (var command = new Set(host: "localhost", port: 6379))
            {
                command.Execute(key, value);
            }
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
            using (var command = new Remove(host: "localhost", port: 6379))
            {
                command.Execute(key);
            }
        }

        public bool ContainsKey(string key)
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
                var result = socket.Send(dataToBeSent.ToString());
                const int success = 1;
                return success == result;

            }
        }
    }
}