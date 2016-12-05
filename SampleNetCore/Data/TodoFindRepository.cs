/* current FrameWork 4.6 */
using Domain.Queries;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Data
{
    public class TodoFindRepository : ITodoFindRepository
    {
        private readonly SampleDbContext context;

        public TodoFindRepository(SampleDbContext context)
        {
            this.context = context;
        }

        public IReadOnlyCollection<Todo> Find()
        {
            return new ReadOnlyCollection<Todo>(
                list: context.Todos.Select(Build).ToList());
        }

        private Todo Build(Entities.Todo todo)
        {
            return new Todo(
                id: todo.Id,
                title: todo.Title,
                description: todo.Description);
        }
    }
}