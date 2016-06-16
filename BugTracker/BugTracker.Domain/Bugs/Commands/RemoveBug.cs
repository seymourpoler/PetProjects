using BugTracker.Domain.Bugs.Commands.Repositories;
using System;

namespace BugTracker.Domain.Bugs.Commands
{
	public interface IRemoveBug{
		void Remove (string userEmail, string idBug);
	}

	public class RemoveBug : IRemoveBug
	{
		private readonly IBugRepository bugRepository;

		public RemoveBug (IBugRepository bugRepository)
		{
			this.bugRepository = bugRepository;
		}

		public void Remove (string userEmail, string idBug){
			if (String.IsNullOrWhiteSpace (idBug)) {
				throw new IdBugIsRequiredException ();
			}
			if (!bugRepository.Exists (userEmail, idBug)) {
				throw new BugDoesNotBelongToCurrentUserException ();
			}
			bugRepository.Remove (userEmail, idBug);
		}
	}

	public class IdBugIsRequiredException: Exception{}
	public class BugDoesNotBelongToCurrentUserException:Exception{}

}

