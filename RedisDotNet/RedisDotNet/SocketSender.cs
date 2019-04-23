using System.Text;

namespace RedisDotNet
{
    public interface ISocketSender
    {
        void Send(string value);
        void Send(byte[] value);
    }

    public class SocketSender : ISocketSender
    {
        readonly  string _host;
        readonly int _port;

        public SocketSender(
            string host = "localhost", 
            int port = 6379)
        {
            _host = host;
            _port = port;
        }
        
        public void Send(string value)
        {
            using (var socket = SocketFactory.Create(host: _host, port: _port))
            {
                socket.Send(Encoding.UTF8.GetBytes(value));
            }
        }
        
        public void Send(byte[] value)
        {
            using (var socket = SocketFactory.Create(host: _host, port: _port))
            {
                socket.Send(value);
            }
        }
    }
}