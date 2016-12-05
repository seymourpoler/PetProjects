using Domain.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Todo
{
    public class TodoController : Controller
    {
        private readonly ITodoFindRepository repository;

        public TodoController(ITodoFindRepository repository)
        {
            this.repository = repository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(
                viewName: "Index",
                model: repository.Find());
        }

        public IActionResult New()
        {
            return View(
                viewName: "New");
        }
    }
}
