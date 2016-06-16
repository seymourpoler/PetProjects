using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace BugTrucker.Web.ASP.Net.MVC
{
	public class BugTrackerHttpControllerSelector : DefaultHttpControllerSelector
	{
		private readonly HttpConfiguration _configuration;

		public BugTrackerHttpControllerSelector(HttpConfiguration configuration)
			: base(configuration)
		{
			_configuration = configuration;
		}

		public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
		{
			return new HttpControllerDescriptor(_configuration, "ProductsApiController", typeof(ProductsApiController));
		}
	}
}

