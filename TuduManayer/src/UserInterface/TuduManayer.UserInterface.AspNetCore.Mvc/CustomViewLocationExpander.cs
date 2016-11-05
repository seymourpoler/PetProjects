using Microsoft.AspNetCore.Mvc.Razor;
using System.Collections.Generic;

namespace TuduManayer.UserInterface.AspNetCore.Mvc
{
    public class TuduManayerViewLocationExpander : IViewLocationExpander
    {
        public void PopulateValues(ViewLocationExpanderContext context)
        {
            context.Values["customviewlocation"] = nameof(TuduManayerViewLocationExpander);
        }

        public IEnumerable<string> ExpandViewLocations(
                  ViewLocationExpanderContext context,
                  IEnumerable<string> viewLocations)
        {
            return new[]{
                "~/{1}/Views/{0}.cshtml",
                "~/{1}/Views/shared/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                "/Views/{1}/{0}.cshtml",
                "~/Views/{1}/{0}.cshtml"
            };
        }
    }
}
