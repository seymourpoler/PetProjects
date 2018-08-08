using System.Collections.Generic;

namespace WiMi.Domain.Pages.Find
{
    public interface IFindRepository
    {
        IReadOnlyCollection<PageFindingResponse> Find();
    }
}
