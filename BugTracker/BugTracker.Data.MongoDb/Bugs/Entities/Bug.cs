using MongoDB.Bson;
using System;

namespace BugTracker.Data.MongoDb.Bugs.Entities
{
	public class Bug
	{
		public ObjectId Id { get; set; }
		public string Name { get; set;}
		public string Description { get; set;}
		public string Email { get; set;}
	}
}

