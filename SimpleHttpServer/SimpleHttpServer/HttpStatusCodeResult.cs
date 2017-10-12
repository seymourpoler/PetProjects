namespace SimpleHttpServer
{
    public static class HttpStatusCodeResult
    {
        public const string NotFound = "HTTP/1.1 404 Not Found";
        public const string Ok = "HTTP/1.1 200 OK\r\n\r\n\r\n";
    }
}