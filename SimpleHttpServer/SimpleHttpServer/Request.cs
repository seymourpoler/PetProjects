namespace SimpleHttpServer
{
    public class Request
    {
        public string Method { get; private set; }
        public string Path { get; private set; }
        public string Protocol { get; private set; }
        
        public Request(
            string method,
            string path, 
            string protocol)
        {
            Method = method;
            Path = path;
            Protocol = protocol;
        }
    }

	public class Request2
	{
		public string Method { get; private set; }
        public string Host { get; private set; }
        public string Connection { get; private set; }
        public string CacheControl { get; private set; }
        public string UpgradeInsecureRequests { get; private set; }
        public string UserAgent { get; private set; }
        public string Accept { get; private set; }
        public string Dnt { get; private set; }
        public string AcceptEncoding { get; private set; }
        public string AcceptLanguage { get; private set; }

		public Request2(
			string method,
			string host,
			string connection,
            string cacheControl,
            string upgradeInsecureRequests,
            string userAgent,
            string accept,
            string dnt,
            string acceptEncoding,
            string acceptLanguage)
		{
			Method = method;
            Host = host;
            Connection = connection;
            CacheControl = cacheControl;
            UpgradeInsecureRequests = upgradeInsecureRequests;
            UserAgent = userAgent;
            Accept = accept;
            Dnt = dnt;
            AcceptEncoding = acceptEncoding;
            AcceptLanguage = acceptLanguage;
		}
	}
}