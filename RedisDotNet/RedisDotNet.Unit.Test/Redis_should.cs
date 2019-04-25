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

        
        //[Fact]
        public void set_value()
        {
            redis.Set("foo", "bar");
            
            socketSender
                .Verify(x => x.Send(It.Is<string>(y => y.Contains("*3\r\n$3\r\nSET\r\n")) ));
        }
        
        [Fact]
        public void clean_all_keys()
        {
            redis.FlushAll();

            socketSender
                .Verify(x => x.Send(It.Is<string>(y => y.Contains("*1\r\n$8\r\nFLUSHALL\r\n"))));
        }

        [Fact]
        public void remove_a_key()
        {
            redis.Remove("a-key");
            
            socketSender
                .Verify(x => x.Send(It.Is<string>(y => y.Contains("*1\r\n$3\r\nDEL\r\na-key"))));
        }

        [Fact]
        public void contains_a_key()
        {
            redis.ContainsKey("key");
            socketSender
                .Verify(x => x.Send(It.Is<string>(y => y.Contains("*1\r\n$6\r\nEXISTS\r\nkey"))));
        }
    }
}