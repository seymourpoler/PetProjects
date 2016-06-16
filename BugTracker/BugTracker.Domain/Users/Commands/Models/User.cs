using System;

namespace BugTracker.Domain.Users.Commands.Models
{
	public class User
	{
		public string Email{ get; set;}
		public string Password{ get; set;}

		private User(string email, string password){
			Email = email;
			Password = password;
		}

		public static User Create(string email, string password){
			if(String.IsNullOrWhiteSpace(email)){
				throw new UserNameIsRequiredException();
			}
			if (String.IsNullOrWhiteSpace (password)) {
				throw new UserPasswordIsRequiredException ();
			}
			return new User (email, password);
		}
	}

	public class UserPasswordIsRequiredException: Exception{}
	public class UserNameIsRequiredException: Exception{}
}

