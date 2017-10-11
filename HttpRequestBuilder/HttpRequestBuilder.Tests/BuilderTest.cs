using NUnit.Framework;
using HttpRequestBuilder;
using FluentAssertions;
using System.Web;
using System.Web.Mvc;
using Moq;

namespace HttpRequestBuilder.Tests
{
	[TestFixture]
	public class BuilderTest
	{
		[Test]
		public void BuildHttpRequestBase()
		{
			var result = new Builder().Build ();

			result.Should ().BeOfType<Mock<HttpRequestBase>> ();
		}

		[Test]
		public void BuildHttpRequestBaseWithHeader()
		{
			var header = "header";
			var headerValue = "headerValue";

			var result = new Builder ()
				.WithHeader (header, headerValue)
				.Build ();

			result.Object.Headers [header].Should ().Be (headerValue);
		}
			
		[Test]
		public void BuildHttpRequestBaseWithMoreThanOneHeader()
		{
			var headerOne = "headerOne";
			var headerValueOne = "headerValueOne";
			var headerTwo = "headerTwo";
			var headerValueTwo = "headerValueTwo";

			var result = new Builder ()
				.WithHeader (headerOne, headerValueOne)
				.WithHeader (headerTwo, headerValueTwo)
				.Build ();

			result.Object.Headers [headerOne].Should ().Be (headerValueOne);
			result.Object.Headers [headerTwo].Should ().Be (headerValueTwo);
		}

		[Test]
		public void BuildHttpRequestBaseWithContentType()
		{
			var contentType = "ContentType";

			var result = new Builder ()
				.WithContentType (contentType)
				.Build ();

			result.Object.ContentType.Should ().Be (contentType);
		}

		[Test]
		public void BuildHttpRequestBaseWithHttpMethod()
		{
			var httpMethod = "httpMethod";

			var result = new Builder ()
				.WithHttpMethod (httpMethod)
				.Build ();

			result.Object.HttpMethod.Should ().Be (httpMethod);
		}

		[Test]
		public void AddToControllerHttpRequestWithContentType()
		{
			var contentType = "Content-Type";
			var controller = new ProductsController ();

			var controllerResult = new Builder ()
				.WithContentType (contentType)
				.AddTo (controller);

			controllerResult.Request.ContentType.Should ().Be (contentType);
		}

		[Test]
		public void AddToControllerHttpRequestWithHttpMethod()
		{
			var httpMethod = "httpMethod";
			var controller = new ProductsController ();

			var controllerResult = new Builder ()
				.WithHttpMethod (httpMethod)
				.AddTo (controller);

			controllerResult.Request.HttpMethod.Should ().Be (httpMethod);
		}

		[Test]
		public void AddToControllerHttpRequestWithHeader()
		{
			var header = "header";
			var headerValue = "headerValue";
			var controller = new ProductsController ();

			var controllerResult = new Builder ()
				.WithHeader (header, headerValue)
				.AddTo (controller);

			controllerResult.Request.Headers [header].Should ().Be (headerValue);
		}
	}

	class ProductsController : Controller{}
}