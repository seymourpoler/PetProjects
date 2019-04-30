using System;

namespace RedisDotNet
{
    public class RedisException : Exception
    {
        public RedisException(string message) : base(message) { }
    }
}