using System;
using System.Collections.Generic;

namespace WiMi.Domain.Pages.Find
{
    public class PageFinder : IPageFinder
    {
		readonly IFindPageRepository repository;

		public PageFinder(IFindPageRepository repository)
        {
            this.repository = repository;
        }

        public IReadOnlyCollection<PageFindingResponse> Find()
        {
            return repository.Find();
        }

        public Page FindBy(Guid id)
        {
            return repository.FindBy(id);
        }
    }
}
