using Domain.Commands.Repositories;

namespace Data
{
    public partial class TodoInsertRepository : ITodoInsertRepository
    {
        private readonly SampleDbContext context;

        public TodoInsertRepository(SampleDbContext context)
        {
            this.context = context;
        }

        public void Insert(Domain.Commands.Todo todo)
        {
            context.Todos.Add(
                entity: new Entities.Todo
                {
                    Title = todo.Title,
                    Description = todo.Description
                });
            context.SaveChanges();
        }
    }
}
