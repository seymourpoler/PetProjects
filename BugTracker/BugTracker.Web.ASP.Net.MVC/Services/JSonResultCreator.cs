using System;
using System.Web.Mvc;
using BugTracker.Web.ASP.Net.MVC.Models;

namespace BugTracker.Web.ASP.Net.MVC
{
	public interface IJSonResultCreator
	{
		
	}

	public class JSonResultCreator : IJSonResultCreator
	{
		public JsonResult Create(HttpStatusCode statusCode, dynamic viewModel){
			Response.StatusCode = statusCode;
		}
	}
}

