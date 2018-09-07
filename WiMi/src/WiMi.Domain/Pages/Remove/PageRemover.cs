using System;

namespace WiMi.Domain.Pages.Remove
{
    public class PageRemover : IPageRemover
    {
        readonly IExistPageRepository existPageRepository;

        public PageRemover(
            IExistPageRepository existPageRepository)
        {
            this.existPageRepository = existPageRepository;
        }

        public ServiceExecutionResult Remove(Guid id)
        {
            if(!existPageRepository.Exist(id))
            {
                return new ServiceExecutionResult(
                    new Error(Error.ErrorCodes.NotFound));
            }
            throw new NotImplementedException();
        }
    }
}
