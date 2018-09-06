using System;

namespace WiMi.Domain.Pages.Remove
{
    public interface IPageRemover
    {
        ServiceExecutionResult Remove(Guid id);
    }
}
