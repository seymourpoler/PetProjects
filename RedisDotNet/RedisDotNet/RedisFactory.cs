namespace RedisDotNet
{
    public static class RedisFactory
    {
        public static IRedis Create (
            string host = "localhost", 
            int port = 6379)
        {

            var redis = new Redis(new ConnectedSocketFactory(host: host, port: port));
            return redis;
        }
    }
}