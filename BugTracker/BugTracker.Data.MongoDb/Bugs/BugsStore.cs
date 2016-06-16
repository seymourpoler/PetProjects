using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BugTracker.Data.MongoDb.Bugs
{
	public partial class BugsStore
	{
		private const string CONNECTION_STRING = "mongodb://localhost:27017";
		private const string DATA_BASE_NAME = "BugTracker";
		private const string COLLECTION_NAME = "Bugs";

		private IMongoCollection<Entities.Bug> collection;

		public BugsStore ()
		{
			collection = new MongoClient (CONNECTION_STRING)
				.GetDatabase (DATA_BASE_NAME)
				.GetCollection<Entities.Bug> (COLLECTION_NAME);
		}
	}
}

