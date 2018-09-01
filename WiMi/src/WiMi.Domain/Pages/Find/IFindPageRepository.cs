using System;
using System.Collections.Generic;

namespace WiMi.Domain.Pages.Find
{
    public interface IFindPageRepository
    {
        IReadOnlyCollection<PageFindingResponse> Find();
        Page FindBy(Guid id);
    }
}
