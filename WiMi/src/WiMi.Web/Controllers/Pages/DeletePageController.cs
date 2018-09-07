using Microsoft.AspNetCore.Mvc;
using System;
using WiMi.Domain.Pages.Remove;

namespace WiMi.Web.Controllers.Pages
{
    public class DeletePageController : Controller
    {
        readonly IPageRemover remover;

        public DeletePageController(IPageRemover pageRemover)
        {
            remover = pageRemover;
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var result = remover.Remove(id);
            if (result.IsOk)
            {
                return Ok();
            }
            return BadRequest(result.Errors);
        }
    }
}