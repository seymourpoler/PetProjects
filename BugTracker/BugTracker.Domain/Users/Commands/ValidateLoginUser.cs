using BugTracker.Domain.Users.Commands.Models;
using BugTracker.Domain.Users.Commands.Repositories;

namespace BugTracker.Domain.Users.Commands
{
	public interface IValidateLoginUser{
		bool Validate (User user);
	}

	public class ValidateLoginUser : IValidateLoginUser
	{
		private readonly IUserRepository userRepository;

		public ValidateLoginUser (IUserRepository userRepository)
		{
			this.userRepository = userRepository;
		}

		public bool Validate (User user){
			return userRepository.Exists (user);
		}
	}
}

