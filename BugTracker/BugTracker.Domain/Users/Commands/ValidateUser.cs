using BugTracker.Domain.Users.Commands.Models;
using System;

namespace BugTracker.Domain.Users.Commands
{
	public interface IValidateUser{
		bool Validate (User user);
	}
	public class ValidateUser
	{
		public ValidateUser ()
		{
		}

		public bool Validate(User user){
			throw new NotImplementedException ();
		}
	}
}

