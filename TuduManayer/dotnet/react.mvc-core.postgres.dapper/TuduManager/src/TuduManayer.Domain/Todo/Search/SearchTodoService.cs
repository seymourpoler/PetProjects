using System.Collections.Generic;

namespace TuduManayer.Domain.Todo.Search
{
    public interface ISearchTodoService
    {
        IReadOnlyCollection<Models.Todo> Search(string searchText);
    }
}