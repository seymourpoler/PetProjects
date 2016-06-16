using BugTracker.Domain.Bugs.Queries.Dtos;
using System;
using System.Collections.Generic;

namespace BugTracker.Domain.Bugs.Queries
{
	public interface IFindBugsByUserEmail
	{
		IReadOnlyCollection<Bug> Find (string email);
	}
}

