using System;

namespace RedisDotNet.Commands
{
    public class Expire : BaseCommand
    {
        public Expire(string host, int port) 
            : base(host, port) { }

        public void Execute(string key, int timeInSeconds)
        {
            throw new NotImplementedException();
        }
    }
}