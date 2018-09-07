using System;

namespace WiMi.Domain.Pages
{
    public interface IExistPageRepository
    {
        bool Exist(Guid id);
    }
}
