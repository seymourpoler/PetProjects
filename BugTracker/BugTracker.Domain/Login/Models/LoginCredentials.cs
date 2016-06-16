using System;

namespace BugTracker.Domain.Login.Models
{
	public class LoginCredentials
	{
		public string Email{ get; private set;}
		public string Password { get; private set;}
		
		public LoginCredentials (string email, string password)
		{
			Email = email;
			Password = password;
		}
	}
}

