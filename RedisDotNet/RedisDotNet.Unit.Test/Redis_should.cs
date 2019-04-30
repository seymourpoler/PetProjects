using Xunit;
using Moq;

namespace RedisDotNet.Unit.Test
{
    public class Redis_should
    {
        Mock<ConnectedSocketFactory> socketFactory;
        Mock<ConnectedSocket> socket;
        IRedis redis;

        public Redis_should()
        {
            socket = new Mock<ConnectedSocket>();
            socketFactory = new Mock<ConnectedSocketFactory>();
            socketFactory
                .Setup(x => x.Create())
                .Returns(socket.Object);
            redis = new Redis(socketFactory.Object);
        }
        
        [Fact]
        public void set_value()
        {
            redis.Set("foo", "bar");
            
            socket
                .Verify(x => x.Send(It.Is<string>(y => y.Contains("*3\r\n$3\r\nSET\r\n$3\r\nfoo\r\n$3\r\n")) ));
        }
        
        [Fact]
        public void clean_all_keys()
        {
            redis.FlushAll();

            socket
                .Verify(x => x.Send(It.Is<string>(y => y.Contains("*1\r\n$8\r\nFLUSHALL\r\n"))));
        }

        [Fact]
        public void remove_a_key()
        {
            redis.Remove("foo");
            
            socket
                .Verify(x => x.Send(It.Is<string>(y => y.Contains("*2\r\n$3\r\nDEL\r\n$3\r\nfoo\r\n"))));
        }

        [Fact]
        public void contains_a_key()
        {
            redis.ContainsKey("key");
            
            socket
                .Verify(x => x.Send(It.Is<string>(y => y.Contains("*1\r\n$6\r\nEXISTS\r\nkey"))));
        }
    }
}