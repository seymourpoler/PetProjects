using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using Web.Login.Controllers;
using Web.Controllers;

namespace Web
{
    public class CustomControllerFactory : IControllerFactory
    {
        public object CreateController(ControllerContext context)
        {
            if(context.ActionDescriptor.ControllerTypeInfo.AsType() == typeof(LoginController))
            {
                return new LoginController();
            }
            return new HomeController();
        }

        public void ReleaseController(ControllerContext context, object controller)
        {
            IDisposable dispose = controller as IDisposable;
            if (dispose != null)
            {
                dispose.Dispose();
            }
        }
    }
}
