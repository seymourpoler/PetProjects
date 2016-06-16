using BugTracker.Data.MongoDb.Users.Entities;
using BugTracker.Domain.Users.Commands.Models;
using BugTracker.Domain.Users.Commands.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace BugTracker.Data.MongoDb.Users
{
	public partial class UsersStore : IUserRepository
	{
		public void Save(Domain.Users.Commands.Models.User user){
			collection.InsertOne (
				new Entities.User {
					Email = user.Email,
					Password = user.Password
				});
		}
	}
}
