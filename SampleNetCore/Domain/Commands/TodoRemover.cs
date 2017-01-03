using Domain.Commands.Repositories;

namespace Domain.Commands
{
    public interface ITodoRemover
    {
        void Remove(int todoId);
    }
    public class TodoRemover : ITodoRemover
    {
        private readonly ITodoDeleteRepository repository;

        public TodoRemover(ITodoDeleteRepository repository)
        {
            this.repository = repository;
        }

        public void Remove(int todoId)
        {
            repository.Delete(todoId);
        }
    }
}
