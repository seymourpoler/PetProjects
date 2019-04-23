namespace RedisDotNet
{
    public static class RedisFactory
    {
        public static IRedis Create (
            string host = "localhost", 
            int port = 6379)
        {
            var sockectSender = new SocketSender(host: host, port: port);
            var redis = new Redis(sockectSender);
            return redis;
        }
    }
}