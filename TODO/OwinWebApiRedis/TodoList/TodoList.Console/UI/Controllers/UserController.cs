using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TodoList.Console.Domain.Entities;
using TodoList.Console.Domain.Services;

namespace TodoList.Console.UI.Controllers
{
    public class UserController: ApiController
    {
        private IUsersService _usersService;
        public UserController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public HttpResponseMessage Login(User credentials)
        {
            try
            {
                var loginResult = _usersService.Login(credentials);
                if(!loginResult)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
