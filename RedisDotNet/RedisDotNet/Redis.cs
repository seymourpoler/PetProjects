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
            using (var command = new FlushAll(host: "localhost", port: 6379))
            {
                command.Execute();
            }
        }

        public void Remove(string key)
        {
            Check.IsNullOrWhiteSpace<ArgumentNullException>(key);
            
            using (var command = new Remove(host: "localhost", port: 6379))
            {
                command.Execute(key);
            }
        }

        public bool ContainsKey(string key)
        {
            Check.IsNullOrWhiteSpace<ArgumentNullException>(key);
            
            using (var command = new ContainsKey(host: "localhost", port: 6379))
            {
               var result =  command.Execute(key);
               return result;
            }
        }
    }
}