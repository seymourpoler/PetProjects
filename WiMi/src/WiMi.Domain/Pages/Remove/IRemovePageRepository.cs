using System;

namespace WiMi.Domain.Pages.Remove
{
    public interface IRemovePageRepository
    {
        void Remove(Guid id);
    }
}
