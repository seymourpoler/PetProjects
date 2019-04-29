namespace RedisDotNet
{
    public class ConnectedSocketFactory
    {
        private string _host;
        private int _port;

        //For tests
        public ConnectedSocketFactory()
        {
            
        }
        public ConnectedSocketFactory(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public virtual ConnectedSocket Create()
        {
            var socket = new ConnectedSocket(host: _host, port: _port);
            return socket;
        }
    }
}