using System;

namespace WiMi.Domain.Pages
{
    public class Page
    {
		public string Title { get; }
		public string Body { get; }
		public DateTime CreationDate { get; }

		public Page(string title, string body)
        {
			Title = title;
			Body = body;
			CreationDate = DateTime.UtcNow;
        }
    }
}
