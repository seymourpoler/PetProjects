using Domain.Queries;
using Microsoft.AspNetCore.Mvc;
using Web.Filters;

namespace Web.Controllers.Todo
{
    [TypeFilter(typeof(SessionRequiredFilterAttribute))]
    [TypeFilter(typeof(InternalServerErrorExceptionFilterAttribute))]
    public class TodoController : Controller
    {
        private readonly ITodoFindRepository repository;

        public TodoController(ITodoFindRepository repository)
        {
            this.repository = repository;
        }

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
