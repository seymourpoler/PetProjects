using Infrestructura;
using Infrestructura.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Web.Filters
{
    public class SessionRequiredFilterAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IStringEncoder stringEncoder;

        public SessionRequiredFilterAttribute(IStringEncoder stringEncoder)
        {
            this.stringEncoder = stringEncoder;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Request.IsAjaxRequest() && !IsValid(context))
            {
                context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
                return;
            }
            if (!IsValid(context))
            {
                context.Result = new RedirectToActionResult(
                actionName: "Forbidden",
                controllerName: "Error",
                routeValues: null);
            }
        }

        private bool IsValid(AuthorizationFilterContext context)
        {
            return context.HttpContext.Session.IsAvailable &&
                HasSession(context);
        }

        private bool HasSession(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.TryGetValue("user", out byte[] session))
            {
                return !String.IsNullOrWhiteSpace(stringEncoder.DecodeToString(session));
            }
            return false;
        }
    }
}
