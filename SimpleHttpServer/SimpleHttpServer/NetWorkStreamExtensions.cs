using System;
using System.Net.Sockets;

namespace SimpleHttpServer
{
    public static class NetworkStreamExtensions
    {
        public static string ConvertToString(this NetworkStream stream)
        {
            if (stream == null) return String.Empty;
            const int maxBufferSize = 1024;
            var buffer = new byte[maxBufferSize];
            var sizeRead = stream.Read(buffer, 0, buffer.Length);
            return System.Text.Encoding.ASCII.GetString(buffer, 0, sizeRead);
        }
    }
}