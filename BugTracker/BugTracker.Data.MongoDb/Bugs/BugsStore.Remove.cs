using BugTracker.Domain.Bugs.Commands.Repositories;
using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Linq;

namespace BugTracker.Data.MongoDb.Bugs
{
	public partial class BugsStore : IBugRepository
	{
		public void Remove(string userEmail, string  idBug){
			collection
				.DeleteOne (
				x => x.Id.ToString () == idBug &&
				x.Email == userEmail);
		}
	}
}

