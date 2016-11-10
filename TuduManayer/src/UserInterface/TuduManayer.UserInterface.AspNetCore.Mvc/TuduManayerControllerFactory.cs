﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using TuduManayer.UserInterface.AspNetCore.Mvc.Login.Controllers;
using TuduManayer.UserInterface.AspNetCore.Mvc.Controllers;

namespace TuduManayer.UserInterface.AspNetCore.Mvc
{
    public class TuduManayerControllerFactory : IControllerFactory
    {
        public object CreateController(ControllerContext context)
        {
            if (context.ActionDescriptor.ControllerTypeInfo.AsType() == typeof(LoginController))
            {
                return new LoginController(
                    loginValidator: new TuduManayer.BussinessLogic.Login.LoginValidator());
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
