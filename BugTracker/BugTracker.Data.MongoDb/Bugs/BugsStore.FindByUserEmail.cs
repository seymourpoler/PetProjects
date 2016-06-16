using BugTracker.Domain.Bugs.Queries.Dtos;
using BugTracker.Domain.Bugs.Queries;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BugTracker.Data.MongoDb.Bugs
{
	public partial class BugsStore : IFindBugsByUserEmail
	{
		public IReadOnlyCollection<Domain.Bugs.Queries.Dtos.Bug> Find (string email)
		{
			return new ReadOnlyCollection<Bug> (collection
				.AsQueryable ()
				.Where (x => x.Email == email)
				.Select (Build)
				.ToList ());
		}

		private Domain.Bugs.Queries.Dtos.Bug Build(Entities.Bug bug){
			return new Domain.Bugs.Queries.Dtos.Bug{ 
				Id = bug.Id.ToString(),
				Name = bug.Name
			};
		}
	}
}

