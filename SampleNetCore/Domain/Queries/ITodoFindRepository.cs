using System.Collections.Generic;

namespace Domain.Queries
{
    public interface ITodoFindRepository
    {
        IReadOnlyCollection<Todo> Find();
    }

    public class Todo
    {
        public int Id { get; }
        public string Title { get; }
        public string Description { get; }

        public Todo(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }
    }
}
