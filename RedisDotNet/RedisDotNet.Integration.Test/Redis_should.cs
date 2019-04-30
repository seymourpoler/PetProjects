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

        [Fact]
        public void remove_key()
        {
            const string key = "foo";
            redis.Set(key, "bar");
            redis.Remove(key);
        }

        [Fact]
        public void flush_all()
        {
            redis.Set("oneKey", "oneValue");
            redis.Set("twoKey", "twoValue");
            redis.FlushAll();
        }
    }
}