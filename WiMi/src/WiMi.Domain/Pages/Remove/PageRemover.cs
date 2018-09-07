using System;

namespace WiMi.Domain.Pages.Remove
{
    public class PageRemover : IPageRemover
    {
        readonly IExistPageRepository existPageRepository;
        readonly IRemovePageRepository removePageRepository;

        public PageRemover(
            IExistPageRepository existPageRepository, 
            IRemovePageRepository removePageRepository)
        {
            this.existPageRepository = existPageRepository;
            this.removePageRepository = removePageRepository;
        }

        public ServiceExecutionResult Remove(Guid id)
        {
            if(!existPageRepository.Exist(id))
            {
                return new ServiceExecutionResult(
                    new Error(Error.ErrorCodes.NotFound));
            }
            removePageRepository.Remove(id);
            return new ServiceExecutionResult();
        }
    }
}
