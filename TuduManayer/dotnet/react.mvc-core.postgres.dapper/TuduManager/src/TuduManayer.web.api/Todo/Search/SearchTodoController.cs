using System;
using Microsoft.AspNetCore.Mvc;

namespace TuduManayer.web.api.Todo.Search
{
    public class SearchTodoController: Controller
    {
        [HttpGet("/api/todos")]
        public IActionResult Search([FromQuery] string searchText)
        {
            return Ok();
            throw new NotImplementedException();
        } 
    }
}