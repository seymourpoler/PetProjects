namespace WiMi.Domain.Pages
{
    public class PageCreationRequest
    {
        public string Title { get; }
        public string Body { get; }

        public PageCreationRequest(string title, string body)
        {
            Title = title;
            Body = body;
        }
    }
}
