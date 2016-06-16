using System;

namespace BugTracker.Domain.Users.Queries.Dtos
{
	public class User
	{
		public string Email{get; set;}

		public User (string email)
		{
			Email = email;
		}
	}
}

