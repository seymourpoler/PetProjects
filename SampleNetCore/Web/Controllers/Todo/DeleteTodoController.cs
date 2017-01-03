using Domain.Commands;
using Domain.Commands.Repositories;
using Infrestructura;
using Microsoft.AspNetCore.Mvc;
using Web.Filters;

namespace Web.Controllers.Todo
{
    [TypeFilter(typeof(InternalServerErrorExceptionFilterAttribute))]
    public class DeleteTodoController: Controller
    {
        private readonly ITodoRemover remover;
        private readonly IJsonSerializer serializer;

        public DeleteTodoController(ITodoRemover remover, IJsonSerializer serializer)
        {
            this.remover = remover;
            this.serializer = serializer;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try {
                remover.Remove(id);
                return Ok();
            }
            catch (TodoNotFoundException) {
                return BadRequest(
                        error: serializer.Serialize(
                            entity: "TodoNotFound"));
            }
        }
    }
}
