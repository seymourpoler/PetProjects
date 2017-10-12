﻿using System;
using System.Net;
using System.Net.Sockets;

namespace SimpleHttpServer
{
    public class Server
    {
        private TcpListener listener;
        private readonly RequestParser requestParser;
        private readonly Logger logger;
        
        //TODO: add factory
        public Server(
            Logger logger)
        {
            requestParser = new RequestParser(logger);
            this.logger = logger;
        }

        public void Start(int port)
        {
            const int maxSizeBuffer = 1000;
            const bool forever = true;
            TcpClient client =  null;
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            try
            {
                while (forever)
                {
     				var result = new Byte[maxSizeBuffer];
                    client = listener.AcceptTcpClient();
                    var stream = client.GetStream();
                    var request = requestParser.Parse(stream);
//                    Request request = GetRequest(requestData);
//                    ProcessRequest(request, stream);

	                var response = $"{HttpStatusCodeResult.Ok}Hello";
	                var msg = System.Text.Encoding.ASCII.GetBytes(response);
	                stream.Write(msg, 0, msg.Length);
                    client.Close();
                }
            }
            finally
            {
                client?.Close();
                listener.Stop();
            }
        }

        public void Stop()
        {
            listener.Stop();
        }

		private void GenerateResponse(
			string content, 
			NetworkStream stream,
			string responseHeader)
		{
			var response = HttpStatusCodeResult.Ok + content;
			var msg = System.Text.Encoding.ASCII.GetBytes(response);
			stream.Write(msg, 0, msg.Length);
		}
    }
}
