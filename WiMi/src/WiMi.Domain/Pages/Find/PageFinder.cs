using System.Collections.Generic;

namespace WiMi.Domain.Pages.Find
{
    public class PageFinder : IPageFinder
    {
        readonly IFindRepository repository;

        public PageFinder(IFindRepository repository)
        {
            this.repository = repository;
        }

        public IReadOnlyCollection<PageFindingResponse> Find()
        {
            return repository.Find();
        }
    }
}
