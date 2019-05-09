using System;
using Shouldly;
using Xunit;

namespace RedisDotNet.Integration.Test
{
    public class Redis_should : IDisposable
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

        [Fact]
        public void return_true_when_contains_key()
        {
            redis.Set("oneKey", "oneValue");

            var result = redis.ContainsKey("oneKey");

            result.ShouldBeTrue();
        }
        
        [Fact]
        public void return_false_when_contains_key()
        {
            var result = redis.ContainsKey("missing-Key");

            result.ShouldBeFalse();
        }

        [Fact]
        public void rename()
        {
            redis.Set("foo", "bar");
            redis.Rename("foo", "fhoo");
        }

        [Fact]
        public void get()
        {
            redis.Set("foo", "bar");
            
            var result = redis.Get("foo");
            
            result.ShouldBe("bar");
        }

        [Fact]
        public void expireInSeconds()
        {
            redis.Set(key:"foo", value:"bar", expireInSeconds: 30);
        }
        
        public void Dispose()
        {
            redis.FlushAll();
        }
    }
}