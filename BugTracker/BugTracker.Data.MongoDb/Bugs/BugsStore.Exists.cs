using BugTracker.Domain.Bugs.Commands.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;

namespace BugTracker.Data.MongoDb.Bugs
{
	public partial class BugsStore : IBugRepository 
	{
		public bool Exists(string userEmail,string idBug){
			return collection
				.AsQueryable ()
				.Where(x => x.Id.ToString () == idBug)
				.Where(x => x.Email == userEmail)
				.Any ();
		}
	}
}

