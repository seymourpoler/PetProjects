using WiMi.Domain.Pages.Find;

namespace WiMi.Domain.Pages.Update
{
    public class PageUpdater : IPageUpdater
    {
        readonly IExistPageRepository existPageRepository;
        readonly IFindPageRepository findPageRepository;
        readonly IUpdatePageRepository updatePageRepository;

        public PageUpdater(
            IExistPageRepository existPageRepository,
            IUpdatePageRepository updatePageRepository, 
            IFindPageRepository findPageRepository)
        {
            this.existPageRepository = existPageRepository;
            this.updatePageRepository = updatePageRepository;
            this.findPageRepository = findPageRepository;
        }

        public ServiceExecutionResult Update(PageUpdatingRequest request)
        {
            if(!existPageRepository.Exist(request.Id))
            {
                return new ServiceExecutionResult(new Error(Error.ErrorCodes.NotFound));
            }
            var page = findPageRepository.FindBy(request.Id);
            page.Title = request.Title;
            page.Body = request.Body;
            updatePageRepository.Update(page);
            return new ServiceExecutionResult();
        }
    }
}
