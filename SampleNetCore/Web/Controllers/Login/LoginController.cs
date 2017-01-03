using Infrestructura;
using Microsoft.AspNetCore.Mvc;
using Web.Services;

namespace Web.Controllers.Login
{
    public class LoginController : Controller
    {
        private readonly ILoginValidator loginValidator;
        private readonly IStringEncoder stringEncoder;

        public LoginController(ILoginValidator loginValidator,  IStringEncoder stringEncoder)
        {
            this.stringEncoder = stringEncoder;
            this.loginValidator = loginValidator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(LoginRequest request) {
            if (IsValid(request))
            {
                HttpContext.Session.Set("user", stringEncoder.EncodeToBytes(request.Email));
                return Ok();
            }
            return BadRequest();
        }

        private bool IsValid(LoginRequest request)
        {
            return loginValidator.IsValid(
                request: new LoginValidationRequest(
                    email: request.Email,
                    password: request.Password));
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
