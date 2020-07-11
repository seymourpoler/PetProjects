using Microsoft.AspNetCore.Mvc;
using TuduManayer.Domain.Todo.Search;

namespace TuduManayer.web.api.Todo.Search
{
    public class SearchTodoController : Controller
    {
        private readonly ISearchTodoService service;

        public SearchTodoController(ISearchTodoService service)
        {
            this.service = service;
        }

        [HttpGet("/api/todos")]
        public IActionResult Search([FromQuery] string searchText)
        {
            var todos = service.Search(searchText);
            return Ok(todos);
        } 
    }
}