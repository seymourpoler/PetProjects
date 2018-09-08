using System;

namespace WiMi.Domain.Pages
{
    public class Page
    {
        public Guid Id { get; }
		public string Title { get; set; }
		public string Body { get; set; }
		public DateTime CreationDate { get; }

		public Page(string title, string body)
        {
            Id = Guid.NewGuid();
			Title = title;
			Body = body;
			CreationDate = DateTime.UtcNow;
        }

        public Page(PersistenceState persistenceState)
        {
            Id = persistenceState.Id;
            Title = persistenceState.Title;
            Body = persistenceState.Body;
            CreationDate = persistenceState.CreationDate;
        }

        public class PersistenceState
        {
            public Guid Id { get; }
            public string Title { get; }
            public string Body { get; }
            public DateTime CreationDate { get; }

            public PersistenceState(Guid id, string title, string body, DateTime creationDate)
            {
                Id = id;
                Title = title;
                Body = body;
                CreationDate = creationDate;
            }
        }
    }
}
