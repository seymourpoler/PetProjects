using System;
using BugTracker.Domain.Users.Commands.Models;

namespace BugTracker.Domain.Users.Commands.Repositories
{
	public interface IUserRepository
	{
		bool Exists (string email);
		bool Exists (User user);
		void Save (User user);
	}
}

