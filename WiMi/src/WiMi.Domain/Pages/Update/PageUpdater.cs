namespace WiMi.Domain.Pages.Update
{
    public class PageUpdater : IPageUpdater
    {
        readonly IExistPageRepository existPageRepository;

        public PageUpdater(
            IExistPageRepository existPageRepository)
        {
            this.existPageRepository = existPageRepository;
        }

        public ServiceExecutionResult Update(PageUpdatingRequest request)
        {
            if(!existPageRepository.Exist(request.Id))
            {
                return new ServiceExecutionResult(new Error(Error.ErrorCodes.NotFound));
            }
            throw new System.NotImplementedException();
        }
    }
}
