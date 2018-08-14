using System;
using System.Collections.Generic;
using WiMi.Domain.Pages.Find;

namespace WiMi.Repositories.SQLite
{
    public class  FindPageRepository: IFindPageRepository
    {
        public IReadOnlyCollection<PageFindingResponse> Find()
        {
            throw new NotImplementedException();
        }
    }
}
