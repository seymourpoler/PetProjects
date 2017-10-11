using Moq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.Routing;

namespace HttpRequestBuilder
{
	public class Builder
	{
		private Dictionary<string, string> _headerValues;
		private string _contentType;
		private string _httpMethod;

		public Builder(){
			_headerValues = new Dictionary<string, string>();
			_contentType = "text/html";
			_httpMethod = "GET";
		}

		public Mock<HttpRequestBase> Build()
		{
			var request =  new Mock<HttpRequestBase> ();
			if(_headerValues.Count > 0){
			request
				.Setup (x => x.Headers)
				.Returns (BuildHeaders ());
			}
			request
				.Setup (x => x.ContentType)
				.Returns (_contentType);
			request
				.Setup (x => x.HttpMethod)
				.Returns (_httpMethod);
			return request;
		}

		public Controller AddTo(Controller controller)
		{
			var requestBase = Build ();
			var context = new Mock<HttpContextBase>();
			context.Setup(x => x.Request).Returns(requestBase.Object);
			controller.ControllerContext = new ControllerContext(context.Object, new RouteData(), controller);
			return controller;
		}

		private NameValueCollection BuildHeaders()
		{
			var result = new NameValueCollection ();
			foreach(var header in _headerValues){
				result.Add (header.Key, header.Value);
			}
			return result;
		}

		public Builder WithHeader(string header, string value){
			_headerValues.Add (header, value);
			return this;
		}

		public Builder WithContentType(string contentType)
		{
			_contentType = contentType;
			return this;
		}

		public Builder WithHttpMethod(string httpMethod)
		{
			_httpMethod = httpMethod;
			return this;
		}
	}
}

