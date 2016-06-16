using System;

namespace BugTracker.Data.MongoDb
{
	public class MongoConnectionHandler<T>  Where T : Class
	{
		public MongoCollection<T> MongoCollection { get; private set; }

		public MongoConnectionHandler()
		{
			const string connectionString = "mongodb://localhost:27017";

			var mongoClient = new MongoClient(connectionString);
			var mongoServer = mongoClient.GetServer();

			const string databaseName = "BugTracker";
			var db = mongoServer.GetDatabase(databaseName);

			MongoCollection = db.GetCollection<T>(typeof(T).Name.ToLower() + "s");
		}
	}
}

