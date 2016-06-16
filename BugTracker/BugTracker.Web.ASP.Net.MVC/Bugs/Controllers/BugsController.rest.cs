using BugTracker.Domain.Bugs.Commands.Models;
using BugTracker.Domain.Bugs.Commands;
using BugTracker.Domain.Bugs.Queries;
using BugTracker.Web.ASP.Net.MVC.Session.ActionFilters;
using BugTracker.Web.ASP.Net.MVC.Models;
using BugTracker.Web.ASP.Net.MVC.Session.Services;
using System;
using System.Web.Mvc;

namespace BugTracker.Web.ASP.Net.MVC.Bugs.Controllers
{
	public partial class BugsController : Controller
	{
		private readonly ISessionService sessionService;
		private readonly IFindBugsByUserEmail findByUserEmail;
		private readonly ICreateNewBug createNewBug;
		private readonly IRemoveBug removeBug;

		public BugsController (ISessionService sessionService, IFindBugsByUserEmail findByUserEmail, ICreateNewBug createNewBug, IRemoveBug removeBug)
		{
			this.sessionService = sessionService;
			this.findByUserEmail = findByUserEmail;
			this.createNewBug = createNewBug;
			this.removeBug = removeBug;
		}

		[HttpGet]
		public JsonResult GetBugsByUser(){
			try{
				Response.StatusCode = HttpStatusCode.Ok;
				var bugsFound = findByUserEmail.Find(email: GetCurrentUserEmail());
				return Json (bugsFound, JsonRequestBehavior.AllowGet);

			}catch(Exception){
				Response.StatusCode = HttpStatusCode.InternalServerError;
				return Json (new
					{
						success = false,
						errorCode = "internalServerError"
					});
			}
		}

		[HttpPost]
		public JsonResult CreateNewBug(CreationNewBugRequest request){
			try{
				createNewBug.Create (
					new BugTracker.Domain.Bugs.Commands.Models.CreationNewBugRequest (
						email: GetCurrentUserEmail (),
						name: request.Name,
						description: request.Description));
				Response.StatusCode = HttpStatusCode.Ok;
				return Json (new {success = true});
			}catch(UserEmailIsRequiredException){
				Response.StatusCode = HttpStatusCode.Unauthorized;
				return Json (new
					{
						success = false,
						errorCode = "userEmailIsRequired"
					});
			}
			catch(BugNameIsRequiredException){
				Response.StatusCode = HttpStatusCode.BadRequest;
				return Json (new
					{
						success = false,
						errorCode = "bugNameIsRequired"
					});
				
			}catch(Exception){
				Response.StatusCode = HttpStatusCode.InternalServerError;
				return Json (new
					{
						success = false,
						errorCode = "internalServerError"
					});	
			}
		}

		[HttpDelete]
		public JsonResult RemoveBug(string idBug){
			try{
				removeBug.Remove(
					userEmail: GetCurrentUserEmail(),
					idBug: idBug);
				return Json (new {success = true});
			}
			catch(IdBugIsRequiredException){
				Response.StatusCode = HttpStatusCode.BadRequest;
				return Json (new
					{
						success = false,
						errorCode = "idBugIsRequired"
					});
			}
			catch(BugDoesNotBelongToCurrentUserException){
				Response.StatusCode = HttpStatusCode.BadRequest;
				return Json (new
					{
						success = false,
						errorCode = "bugDoesNotBelongToCurrentUser"
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

		private string GetCurrentUserEmail(){
			var currentSession = sessionService.GetCurrentSession ();
			return currentSession.Email;
		}
	}

	public class CreationNewBugRequest{
		public string Name{get; set;}
		public string Description{ get; set;}
	}
}

