namespace WiMi.Domain.Pages.Update
{
    public interface IPageUpdater
    {
        ServiceExecutionResult Update(PageUpdatingRequest request);
    }
}
