using Domain.Commands;
using Infrestructura;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Web.Controllers.Todo
{
    public class CreateTodoController : Controller
    {
        private readonly ITodoCreator creator;
        private readonly IJsonSerializer serializer;

        public CreateTodoController(ITodoCreator creator, IJsonSerializer serializer)
        {
            this.creator = creator;
            this.serializer = serializer;
        }

        [HttpPost]
        public IActionResult Create(TodoCreationRequest request)
        {
            try {
                var creationResult = Domain.Commands.Models.TodoCreationRequest.Create(
                    title: request.Title,
                    description: request.Description);
                if (!creationResult.IsValid)
                {
                    return BadRequest(
                        error: serializer.Serialize(
                            entity: creationResult.Errors));
                }
                creator.Create(
                    request: creationResult.Model);
                return Ok();
            }
            catch (Exception ex) {
                return StatusCode(500);
            }
        }
    }

    public class TodoCreationRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
