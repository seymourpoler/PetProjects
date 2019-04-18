using Xunit;

namespace RedisDotNet.Unit.Test
{
    public class Redis_should
    {
        IRedis redis;

        public Redis_should()
        {
            redis = new Redis();
        }

        [Fact]
        public void set_value()
        {
            redis.Set("1", "value");
        }
    }
}