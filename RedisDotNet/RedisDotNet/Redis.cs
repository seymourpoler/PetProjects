using System;
using System.Text;
using RedisDotNet.Commands;

namespace RedisDotNet
{
    public class Redis : IRedis, IDisposable
    {
        string _host;
        int _port;
        
        public Redis(string host = "localhost", int port = 6379)
        {
            _host = host;
            _port = port;
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

            using (var command = new Set(host: _host, port: _port))
            {
                command.Execute(key, value);
            }
        }

        public void FlushAll()
        {
            using (var command = new FlushAll(host: _host, port: _port))
            {
                command.Execute();
            }
        }

        public void Remove(string key)
        {
            Check.IsNullOrWhiteSpace<ArgumentNullException>(key);
            
            using (var command = new Remove(host: _host, port: _port))
            {
                command.Execute(key);
            }
        }

        public bool ContainsKey(string key)
        {
            Check.IsNullOrWhiteSpace<ArgumentNullException>(key);
            
            using (var command = new ContainsKey(host: _host, port: _port))
            {
               var result =  command.Execute(key);
               return result;
            }
        }
    }
}