using BugTracker.Domain.Bugs.Commands.Models;
using BugTracker.Domain.Bugs.Commands.Repositories;
using System;

namespace BugTracker.Domain.Bugs.Commands
{
	public interface ICreateNewBug{
		void Create (CreationNewBugRequest request);
	}

	public class CreateNewBug : ICreateNewBug
	{
		private readonly IBugRepository bugRepository;

		public CreateNewBug (IBugRepository bugRepository){
			this.bugRepository = bugRepository;
		}

		public void Create(CreationNewBugRequest request){
			bugRepository.Save (request);
		}
	}
}

