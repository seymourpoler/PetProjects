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
            redis.Set("foo", "bar");
        }
        
        [Fact]
        public void clean_all_keys()
        {
            redis.Set("keyOne", "bar");
            redis.Set("keyTwo", "bar");
            redis.Set("keyThree", "bar");
            redis.Set("keyFour", "bar");
            
            redis.FlushAll();
        }
    }
}