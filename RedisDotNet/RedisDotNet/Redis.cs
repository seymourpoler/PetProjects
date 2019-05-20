using System;
using System.Text;
using RedisDotNet.Commands;

namespace RedisDotNet
{
    public class Redis : IRedis, IDisposable
    {
        readonly string _host;
        readonly int _port;
        
        public Redis(string host = "localhost", int port = 6379)
        {
            _host = host;
            _port = port;
        }

        public void Set(string key, string value)
        {
            Set(key: key, value: Encoding.UTF8.GetBytes(value));
        }
        
        public void Set(string key, string value, int expireInSeconds)
        {
            Set(key: key, value: Encoding.UTF8.GetBytes(value));

            Check.If<ArgumentException>(() => expireInSeconds < 0);
            using (var command = new Expire(host: _host, port: _port))
            {
                const int perSecond = 1000;
                command.Execute(key: key, timeInSeconds: expireInSeconds * perSecond);
            }
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

        public void Rename(string oldKey, string newKey)
        {
            Check.IsNullOrWhiteSpace<ArgumentNullException>(oldKey);
            Check.IsNullOrWhiteSpace<ArgumentNullException>(newKey);
            
            using (var command = new Rename(host: _host, port: _port))
            {
                command.Execute(oldKey: oldKey, newKey: newKey);
            }
        }

        public string Get(string key)
        {
            Check.IsNullOrWhiteSpace<ArgumentNullException>(key);
            
            using (var command = new Get(host: _host, port: _port))
            {
                var result = command.Execute(key);
                return result;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize (this);
        }
    }
}