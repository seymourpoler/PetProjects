using Microsoft.AspNetCore.Mvc;
using System;
using TuduManayer.BussinessLogic.Login;
using TuduManayer.BussinessLogic.Login.Models;

namespace TuduManayer.UserInterface.AspNetCore.Mvc.Login.Controllers
{
    public partial class LoginController : Controller
    {
        private readonly ILoginValidator loginValidator;

        public LoginController(ILoginValidator loginValidator)
        {
            this.loginValidator = loginValidator;
        }
        public IActionResult Login(LoginRequest request)
        {
            loginValidator.Validate(
                request: new LoginValidationRequest(email: request.Email, password: request.PassWord));
            throw new NotImplementedException();
        }
    }

    public class LoginRequest
    {
        public string Email { get; set;}
        public string PassWord { get; set; }
    }
}
