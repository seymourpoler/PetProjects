using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using WiMi.CrossCutting.Serializers;
using System;

namespace WiMi.Web.Controllers
{
	public class HttpActionResultBuilder
	{
		readonly ISerializer serializer;

		public HttpActionResultBuilder(ISerializer serializer)
		{
			this.serializer = serializer;
		}

		public IHttpActionResult Build<T>(HttpStatusCode httpStatuscode, T entity) where T : class
        {
			var response = new HttpResponseMessage(httpStatuscode)
			{
				Content = new StringContent(
					content: serializer.Serializer(entity),
					encoding: Encoding.UTF8, 
					mediaType: "application/json")
			};

			return new ResponseMessageResult(response);
        }

		public IHttpActionResult Build(HttpStatusCode httpStatuscode)
        {
            var response = new HttpResponseMessage
            {
				StatusCode = httpStatuscode,
                Content = new StringContent(
					content: String.Empty,
                    encoding: Encoding.UTF8,
                    mediaType: "application/json")
            };

            return new ResponseMessageResult(response);
        }
    }
}
