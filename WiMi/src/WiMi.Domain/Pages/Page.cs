using System;

namespace WiMi.Domain.Pages
{
    public class Page
    {
        public Guid Id { get; }
		public string Title { get; }
		public string Body { get; }
		public DateTime CreationDate { get; }

		public Page(string title, string body)
        {
            Id = Guid.NewGuid();
			Title = title;
			Body = body;
			CreationDate = DateTime.UtcNow;
        }
    }
}
