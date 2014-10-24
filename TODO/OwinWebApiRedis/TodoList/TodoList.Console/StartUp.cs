using Owin;
using System;
using System.Web.Http;
using Microsoft.Owin.Cors;
using System.Net.Http.Headers;
using TodoList.Console.UI.IoC;

namespace TodoList.Console
{
    public class StartUp
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var httpConfiguration = SetUpHttpConfiguration();
            appBuilder.UseCors(CorsOptions.AllowAll);
            appBuilder.UseWebApi(httpConfiguration);
        }

        private HttpConfiguration SetUpHttpConfiguration()
        {
            var httpConfiguration = new HttpConfiguration();
            httpConfiguration.Routes.MapHttpRoute(
                name: "DefaultAppi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
            httpConfiguration.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            httpConfiguration.DependencyResolver = new NinjectResolver(NinjectConfig.CreateKernel());
            httpConfiguration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            return httpConfiguration;
        }
    }
}
