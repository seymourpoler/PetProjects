using System.Collections.Generic;

namespace TuduManayer.Domain.Todo.Search
{
    public interface ISearchTodoRepository
    {
        IReadOnlyCollection<Models.Todo> Search(string searchText);       
    }
}