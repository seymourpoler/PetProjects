﻿using Microsoft.AspNetCore.Mvc;

namespace TuduManayer.UserInterface.AspNetCore.Mvc.Login.Controllers
{
    public class LoginController :  Controller
    {
        public IActionResult Index()
        {
            return View();
            //return View("Index.cshtml");
            //return View("~/Login/Views/Index.cshtml");
        }
    }
}
