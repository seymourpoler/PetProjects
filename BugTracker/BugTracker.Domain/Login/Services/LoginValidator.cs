using System;
using System.Linq;
using System.Collections.Generic;
using BugTracker.Domain.Login.Models;

namespace BugTracker.Domain.Login.Services
{
	public interface ILoginValidator
	{
		bool Validate (LoginCredentials loginCredentials);
	}

	public class LoginValidator : ILoginValidator
	{
		private IEnumerable<credentials> credentials;
		public LoginValidator ()
		{
			credentials = new []{ 
				new credentials{Email = "admin", Password = "1234"}
			};
		}

		public bool Validate(LoginCredentials loginCredentials)
		{
			var credentialFound = credentials
				.Where (x => x.Email == loginCredentials.Email)
				.Where (x => x.Password == loginCredentials.Password)
				.FirstOrDefault ();
			return credentialFound != null;
		}
	}

	internal class credentials
	{
		public string Email{ get; set;}
		public string Password{get; set;}
	}
}

