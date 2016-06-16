using BugTracker.Domain.Bugs.Commands;
using BugTracker.Domain.Bugs.Commands.Repositories;
using BugTracker.Domain.Users.Commands;
using System;

namespace BugTracker.Web.ASP.Net.MVC.Factories
{
	public class CommandsFactory
	{
		public static IValidateLoginUser ValidateLoginUser()
		{
			return new ValidateLoginUser (
				userRepository: RepositoriesFactory.UserRepository());
		}

		public static ICreateUser CreateUser(){
			return new CreateUser (
				userRepository: RepositoriesFactory.UserRepository());
		}

		public static ICreateNewBug CreateNewBug(){
			return new CreateNewBug (
				RepositoriesFactory.BugRepository());
		}

		public static IRemoveBug RemoveBug(){
			return new RemoveBug (
				RepositoriesFactory.BugRepository());
		}
	}
}

