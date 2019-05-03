namespace RedisDotNet.Commands
{
    public class FlushAll : BaseCommand
    {
        public FlushAll(string host, int port) : base(host, port)
        {
        }
    }
}