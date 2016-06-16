using BugTracker.Domain.Users.Commands;
using BugTracker.Domain.Users.Commands.Models;
using BugTracker.Web.ASP.Net.MVC.Models;
using BugTracker.Web.ASP.Net.MVC.Session.Services;
using System;
using System.Web.Mvc;

namespace BugTracker.Web.ASP.Net.MVC.Login.Controllers
{
	public partial class LoginController : Controller
	{
		private readonly ISessionService sessionService;
		private readonly IValidateLoginUser validateLoginUser;

		public LoginController(ISessionService sessionService, IValidateLoginUser validateLoginUser)
		{
			this.sessionService = sessionService;
			this.validateLoginUser = validateLoginUser;
		}

		[HttpPost]
		public JsonResult Login(LoginRequest request)
		{
			try{
				if (!IsValid (request)) {
					Response.StatusCode = HttpStatusCode.BadRequest;
					return Json (new
						{
							success = false,
							errorCode = "badRequest"
						});
				}
				sessionService.SetSession (
					new Session.Models.Session { 
						Email = request.Login
					});
				Response.StatusCode = HttpStatusCode.Ok;
				return Json (new {success=true});
			}catch(Exception){
				Response.StatusCode = HttpStatusCode.InternalServerError;
				return Json (new
					{
						success = false,
						errorCode = "internalServerError"
					});
			}
		}

		private bool IsValid(LoginRequest request)
		{
			return validateLoginUser.Validate (
				BugTracker.Domain.Users.Commands.Models.User.Create (
					email: request.Login,
					password: request.Password));
		}
	}

	public class LoginRequest
	{
		public string Login {get; set;}
		public string Password { get; set;}
	}
}

