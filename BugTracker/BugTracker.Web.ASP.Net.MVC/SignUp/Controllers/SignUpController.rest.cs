using BugTracker.Domain.Users.Commands;
using BugTracker.Domain.Users.Commands.Models;
using BugTracker.Web.ASP.Net.MVC.Models;
using BugTracker.Web.ASP.Net.MVC.Session.Services;
using System;
using System.Web.Mvc;

namespace BugTracker.Web.ASP.Net.MVC.SignUp.Controllers
{
	public partial class SignUpController : Controller
	{
		private readonly ICreateUser createUser;
		private readonly ISessionService sessionService;

		public SignUpController (ICreateUser createUser, ISessionService sessionService)
		{
			this.createUser = createUser;
			this.sessionService = sessionService;
		}

		public JsonResult SignUp(SignUpRequest request)
		{
			try{
				createUser.Create (
					Domain.Users.Commands.Models.User.Create (
						email: request.Email,
						password: request.Password));
				sessionService.SetSession (
					new Session.Models.Session { 
						Email = request.Email
					});
				return Json (new {success=true});
			}
			catch(UserPasswordIsRequiredException) {
				Response.StatusCode = HttpStatusCode.BadRequest;
				return Json (new
					{
						success = false,
						errorCode = "userPasswordIsRequired"
					});
			}
			catch(UserNameIsRequiredException){
				Response.StatusCode = HttpStatusCode.BadRequest;
				return Json (new
					{
						success = false,
						errorCode = "userNameIsRequired"
					});
			}
			catch(UserAlreadyExistsException){
				Response.StatusCode = HttpStatusCode.BadRequest;
				return Json (new
					{
						success = false,
						errorCode = "userAlreadyExists"
					});
			}
			catch(Exception){
				Response.StatusCode = HttpStatusCode.InternalServerError;
				return Json (new
					{
						success = false,
						errorCode = "internalServerError"
					});
			}
		}
	}

	public class SignUpRequest{
		public string Email{get; set;}
		public string Password{get; set;}
	}
}

