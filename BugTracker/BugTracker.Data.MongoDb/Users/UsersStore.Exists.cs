using BugTracker.Domain.Users.Commands.Models;
using BugTracker.Domain.Users.Commands.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;

namespace BugTracker.Data.MongoDb.Users
{
	public partial class UsersStore : IUserRepository
	{
		public bool Exists(string email){
			return collection
				.AsQueryable ()
				.Any (x => x.Email == email);
		}
	
		public bool Exists(Domain.Users.Commands.Models.User user){
	 		return collection
				.AsQueryable ()
				.Where (x => x.Email == user.Email)
				.Where (x => x.Password == user.Password)
				.Any ();
		}
	}
}
