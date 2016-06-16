using System;

namespace BugTracker.Domain.Bugs.Commands.Models
{
	public class CreationNewBugRequest{
		public string UserEmail{ get; private set;}
		public string Name{ get; private set;}
		public string Description{ get; private set;}

		public CreationNewBugRequest(string email, string name, string description){
			if (String.IsNullOrWhiteSpace (email)) {
				throw new UserEmailIsRequiredException ();			
			}
			if (String.IsNullOrWhiteSpace (name)) {
				throw new BugNameIsRequiredException ();
			}

			UserEmail = email;
			Name = name;
			Description = description;
		}
	}

	public class UserEmailIsRequiredException: Exception{}
	public class BugNameIsRequiredException: Exception{}
}

