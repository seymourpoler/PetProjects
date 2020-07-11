using System.Collections.Generic;

namespace TuduManayer.Domain.Todo.Search
{
    public interface ISearchTodoService
    {
        IReadOnlyCollection<Models.Todo> Search(string searchText);
    }

    public class SearchTodoService : ISearchTodoService
    {
        private readonly ISearchTodoRepository repository;

        public SearchTodoService(ISearchTodoRepository repository)
        {
            this.repository = repository;
        }

        public IReadOnlyCollection<Models.Todo> Search(string searchText)
        {
            throw new System.NotImplementedException();
        }
    }
}