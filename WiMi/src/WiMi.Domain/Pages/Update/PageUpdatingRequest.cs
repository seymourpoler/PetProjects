using System;

namespace WiMi.Domain.Pages.Update
{
    public class PageUpdatingRequest
    {
        public Guid Id { get; }
        public string Title { get; }
        public string Body { get; } 

        public PageUpdatingRequest(Guid id, string title, string body)
        {
            Id = id;
            Title = title;
            Body = body;
        }
    }
}
