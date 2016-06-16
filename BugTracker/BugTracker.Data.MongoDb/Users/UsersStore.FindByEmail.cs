using BugTracker.Data.MongoDb.Users.Entities;
using BugTracker.Domain.Users.Commands.Models;
using BugTracker.Domain.Users.Commands.Repositories;
using BugTracker.Domain.Users.Queries;
using BugTracker.Domain.Users.Queries.Dtos;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BugTracker.Data.MongoDb.Users
{
	public partial class UsersStore : IFindByEmail
	{
		public Domain.Users.Queries.Dtos.User FindByEmail (string email){
			throw new NotImplementedException();
		}
	}
}
