using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using TuduManayer.Domain.Todo.Search;
using TuduManayer.web.api.Todo.Search;
using Xunit;

namespace TuduManayer.web.api.Test.Todo.Search
{
    public class SearchTodoControllerShould
    {
        private Mock<ISearchTodoService> service;
        private SearchTodoController controller;


        public SearchTodoControllerShould()
        {
            service = new Mock<ISearchTodoService>();
            controller = new SearchTodoController(service.Object);
        }

        [Fact]
        public void return_todos()
        {
            const string searchText = "search-text";
            var todos = new Domain.Todo.Search.Models.Todo[] { };
            service
                .Setup(x => x.Search(searchText))
                .Returns(todos);

            var response = controller.Search(searchText)  as OkObjectResult;
            
            response.StatusCode.Value.ShouldBe<int>((int)HttpStatusCode.OK);
            response.Value.ShouldBeOfType<Domain.Todo.Search.Models.Todo[]>();
        }
    }
}