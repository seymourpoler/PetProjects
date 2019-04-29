namespace RedisDotNet
{
    public class ConnectedSocketFactory
    {
        private string _host;
        private int _port;

        public ConnectedSocketFactory(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public ConnectedSocket Create()
        {
            var socket = new ConnectedSocket(host: _host, port: _port);
            return socket;
        }
    }
}