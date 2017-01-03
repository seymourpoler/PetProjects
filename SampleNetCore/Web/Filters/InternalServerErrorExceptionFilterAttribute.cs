using Infrestructura.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.Filters
{
    public class InternalServerErrorExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.HttpContext.Request.IsAjaxRequest())
            {
                context.ExceptionHandled = true;
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
                return;
            }
            context.Result = new RedirectToActionResult(
            actionName: "InternalServerError",
            controllerName: "Error",
            routeValues: null);
        }
    }
}
