using BugTracker.Domain.Users.Commands.Models;
using BugTracker.Domain.Users.Commands.Repositories;
using System;

namespace BugTracker.Domain.Users.Commands
{
	public interface ICreateUser
	{
		void Create (User user);
	}
	
	public class CreateUser : ICreateUser
	{
		private readonly IUserRepository userRepository;

		public CreateUser(IUserRepository userRepository){
			this.userRepository = userRepository;
		}

		public void Create(User user){
			if (userRepository.Exists (user.Email)) {
				throw new UserAlreadyExistsException ();
			}
			userRepository.Save (user);
		}
	}

	public class UserAlreadyExistsException : Exception{}
}

