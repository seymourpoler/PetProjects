using System;

namespace RedisDotNet
{
    public class Redis : IDisposable, IRedis
    {
        readonly  string _host;
        readonly int _port;
        
        public Redis(string host="localhost", int port=6379)
        {
            _host = host;
            _port = port;
        }

        public void Dispose()
        {
            GC.SuppressFinalize (this);
            throw  new NotImplementedException();
        }

        public void Set<T>(string key, T value)
        {
            Check.IsNull<ArgumentNullException>(key);
            Check.IsNull<ArgumentNullException>(value);
        }
    }
}