using BugTracker.Domain.Bugs.Commands.Models;
using System;

namespace BugTracker.Domain.Bugs.Commands.Repositories
{
	public interface IBugRepository
	{
		void Save(CreationNewBugRequest request);
		void Remove (string userEmail, string idBug);
		bool Exists (string userEmail, string idBug);
	}
}

