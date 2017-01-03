using System.Linq;
using Domain.Commands.Repositories;

namespace Data
{
    public class TodoDeleteRepository : ITodoDeleteRepository
    {
        private readonly SampleDbContext context;

        public TodoDeleteRepository(SampleDbContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            var todoFound = context.Todos.FirstOrDefault(x => x.Id == id);
            if (todoFound == null)
            {
                throw new TodoNotFoundException();
            }
            context.Todos.Remove(entity: todoFound);
            context.SaveChanges();
        }
    }
}
