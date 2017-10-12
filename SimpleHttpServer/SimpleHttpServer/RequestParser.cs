using System;
using System.Net.Sockets;

namespace SimpleHttpServer
{
    public class RequestParser
    {
        private readonly Logger logger;

        public RequestParser(Logger logger)
        {
            this.logger = logger;
        }

        public Request Parse(NetworkStream stream)
        {
            const int minimumOfRequestField = 3;
            
            var streamAsString = stream.ConvertToString();
            var values = streamAsString.Split(' ');
            if (values.Length < minimumOfRequestField)
                throw new InvalidRequest();

            var request = new Request(
                method: values[0],
                path: values[1],
                protocol: values[2].Split('\n')[0]);
            
            logger.Log($"Method: {request.Method}\nPath: {request.Path}\nProtocol: {request.Protocol}");
            return request;
        }   
    }
    
    public class InvalidRequest : Exception{} 
}