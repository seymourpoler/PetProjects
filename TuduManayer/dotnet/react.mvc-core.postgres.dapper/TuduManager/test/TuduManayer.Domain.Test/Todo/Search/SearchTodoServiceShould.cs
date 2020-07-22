using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            repository
                .Setup(x => x.Search(searchText))
                .Returns(new List<Domain.Todo.Search.Models.Todo>().AsReadOnly());
            
            var result = service.Search(searchText);

            result.ShouldBeOfType<ReadOnlyCollection<Domain.Todo.Search.Models.Todo>>();
        }
    }
}