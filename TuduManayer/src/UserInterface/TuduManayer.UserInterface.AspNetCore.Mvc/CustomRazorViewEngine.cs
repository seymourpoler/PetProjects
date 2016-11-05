using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;

namespace TuduManayer.UserInterface.AspNetCore.Mvc
{
    public class CustomRazorViewEngine : RazorViewEngine
    {
        private readonly string[] _customAreaFormats = new string[]
        {
            //"/Views/{2}/{1}/{0}.cshtml",
            "/{1}/Views/{0}",
            "~/{1}/Views/{0}",
            "~{1}/Views/{0}",
            "{1}/Views/{0}"
        };

       public CustomRazorViewEngine(
           IRazorPageFactoryProvider pageFactory, 
           IRazorPageActivator pageActivator, 
           HtmlEncoder htmlEncoder, 
           IOptions<RazorViewEngineOptions> optionsAccessor, 
           ILoggerFactory loggerFactory)
            : base(pageFactory, pageActivator, htmlEncoder, optionsAccessor, loggerFactory){}
    }
}
