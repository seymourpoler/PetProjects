using BugTracker.Data.MongoDb.Bugs.Entities;
using BugTracker.Domain.Bugs.Commands.Models;
using BugTracker.Domain.Bugs.Commands.Repositories;
using MongoDB.Driver;
using System;
using System.Linq;

namespace BugTracker.Data.MongoDb.Bugs
{
	public partial class BugsStore : IBugRepository
	{
		public void Save(CreationNewBugRequest request){
			collection.InsertOne (
				new Bug{
					Email = request.UserEmail,
					Name = request.Name,
					Description = request.Description
				});
		}
	}
}

