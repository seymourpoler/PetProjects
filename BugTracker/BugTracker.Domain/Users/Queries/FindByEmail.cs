using BugTracker.Domain.Users.Queries.Dtos;
using System;
using System.Collections.Generic;

namespace BugTracker.Domain.Users.Queries
{
	public interface IFindByEmail
	{
		User FindByEmail (string email);
	}
}

