using Xunit;

namespace RedisDotNet.Integration.Test
{
    public class Redis_should
    {
        IRedis redis;

        public Redis_should()
        {
            redis = RedisFactory.Create();
        }

        [Fact]
        public void set_value()
        {
            redis.Set("foo", "bar");
        }
    }
}