namespace WiMi.Domain.Pages.Create
{
    public interface IPageCreator
    {
        ServiceExecutionResult Create(PageCreationRequest request);
    }
}
