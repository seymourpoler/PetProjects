using System;
using System.Collections.Generic;
using WiMi.Domain.Pages.Find;

namespace WiMi.Repositories.SQLite
{
    public class  FindRepository: IFindRepository
    {
        public IReadOnlyCollection<PageFindingResponse> Find()
        {
            throw new NotImplementedException();
        }
    }
}
