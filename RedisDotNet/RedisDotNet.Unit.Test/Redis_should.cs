using Xunit;
using Moq;

namespace RedisDotNet.Unit.Test
{
    public class Redis_should
    {
        Mock<ISocketSender> socketSender;
        IRedis redis;

        public Redis_should()
        {
            socketSender = new Mock<ISocketSender>();
            redis = new Redis(socketSender.Object);
        }

        
        [Fact]
        public void set_value()
        {
            redis.Set("foo", "bar");
            
            socketSender
                .Verify(x => x.Send(It.Is<string>(y => y.Contains("*3\r\n$3\r\nSET\r\n")) ));
        }
        
        [Fact]
        public void clean_all_keys()
        {
            redis.Set("keyOne", "bar");
            redis.Set("keyTwo", "bar");
            redis.Set("keyThree", "bar");
            redis.Set("keyFour", "bar");

            redis.FlushAll();

            socketSender
                .Verify(x => x.Send(It.Is<string>(y => y.Contains("*1\r\n$8\r\nFLUSHALL\r\n"))));
        }
    }
}