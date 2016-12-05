using Domain.Commands.Models;
using Domain.Commands.Repositories;

namespace Domain.Commands
{
    public interface ITodoCreator
    {
        void Create(TodoCreationRequest request);
    }

    public class TodoCreator : ITodoCreator
    {
        private readonly ITodoInsertRepository repository;

        public TodoCreator(ITodoInsertRepository repository)
        {
            this.repository = repository;
        }

        public void Create(TodoCreationRequest request)
        {
            repository.Insert(
                todo: new Todo(
                    title: request.Title,
                    description: request.Description));
        }
    }

    public class Todo
    {
        public string Title { get; }
        public string Description { get; }

        public Todo(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
