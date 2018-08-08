using System.Collections.Generic;

namespace WiMi.Domain.Pages.Find
{
    public interface IPageFinder
    {
        IReadOnlyCollection<PageFindingResponse> Find();
    }
}
