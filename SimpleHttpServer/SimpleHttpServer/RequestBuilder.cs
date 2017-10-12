using System;
namespace SimpleHttpServer
{
    public class RequestBuilder
    {
        private readonly RequestParser requestParser;

        public RequestBuilder(
        RequestParser requestParser)
        {
            this.requestParser = requestParser;
        }

        public Request Build(System.Net.Sockets.NetworkStream stream)
        {
            var requestDrawAsString = stream.ConvertToString();
            var values = requestDrawAsString.Split('\n');
            return new Request(
                method: GetMethodFrom(values),
                path: String.Empty,
                protocol: String.Empty);
        }

        private string GetMethodFrom(string [] values)
        {
            return values[0];
        }
    }
}
