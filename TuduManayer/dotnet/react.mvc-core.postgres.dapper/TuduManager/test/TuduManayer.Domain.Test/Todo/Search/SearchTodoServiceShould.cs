using System.Collections.Generic;
using Moq;
using Shouldly;
using TuduManayer.Domain.Todo.Search;
using Xunit;

namespace TuduManayer.Domain.Test.Todo.Search
{
    public class SearchTodoServiceShould
    {
        private Mock<ISearchTodoRepository> repository;
        private ISearchTodoService service;

        public SearchTodoServiceShould()
        {
            repository = new Mock<ISearchTodoRepository>();
            service = new SearchTodoService(repository.Object);
        }

        [Fact]
        public void return_todos()
        {
            const string searchText = "search-text";
            
            var result = service.Search(searchText);

            result.ShouldBeOfType<IReadOnlyCollection<Domain.Todo.Search.Models.Todo>>();
        }
    }
}