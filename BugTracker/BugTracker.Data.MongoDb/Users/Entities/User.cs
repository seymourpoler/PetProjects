using MongoDB.Bson;
using System;

namespace BugTracker.Data.MongoDb.Users.Entities
{
	public class User
	{
		public ObjectId Id { get; set; }
		public String Email{get; set;}
		public String Password{get; set;}
	}
}
