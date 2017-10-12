using System;
using System.Net;
using System.Net.Sockets;

namespace SimpleHttpServer
{
    public class HttpListener
    {
        private readonly RequestParser requestParser;

        public HttpListener(RequestParser requestParser)
        {
            this.requestParser = requestParser;
        }

        public Request Listen(int port)
        {
            var endPoint = new IPEndPoint(IPAddress.Any, port);
            var tcpListener = new TcpListener(endPoint);
            var stream = tcpListener.AcceptTcpClient().GetStream();
            return requestParser.Parse(stream);
            throw new NotImplementedException();
        }
    }
}