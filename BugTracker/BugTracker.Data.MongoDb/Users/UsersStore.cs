using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace BugTracker.Data.MongoDb.Users
{
	public partial class UsersStore
	{
		private const string CONNECTION_STRING = "mongodb://localhost:27017";
		private const string DATA_BASE_NAME = "BugTracker";
		private const string COLLECTION_NAME = "Users";

		private IMongoCollection<Entities.User> collection;

		public UsersStore ()
		{
			collection = new MongoClient (CONNECTION_STRING)
				.GetDatabase (DATA_BASE_NAME)
				.GetCollection<Entities.User> (COLLECTION_NAME);
		}
	}
}
