using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WiMi.Domain;
using WiMi.Domain.Pages.Remove;
using WiMi.Web.Controllers.Pages;
using Xunit;

namespace WiMi.Web.Unit.Test
{
    public class DeletePageControllerTests
    {
        Mock<IPageRemover> remover;
        DeletePageController controller;

        public DeletePageControllerTests()
        {
            remover = new Mock<IPageRemover>();
            controller = new DeletePageController(remover.Object);
        }

        [Fact]
        public async Task return_bad_request_when_there_are_an_errors()
        {
            var pageId = Guid.NewGuid();
            remover
                .Setup(x => x.Remove(pageId))
                .Returns(new ServiceExecutionResult(new Error(Error.ErrorCodes.NotFound)));

            var result = controller.Delete(pageId) as BadRequestObjectResult;

            result.StatusCode.Value.ShouldBe((int)HttpStatusCode.BadRequest);
            ((ReadOnlyCollection<Error>)result.Value).First().FieldId.ShouldBe(Error.GeneralFieldIdError);
            ((ReadOnlyCollection<Error>)result.Value).First().ErrorCode.ShouldBe(nameof(Error.ErrorCodes.NotFound));
        }

        [Fact]
        public async Task return_ok_when_page_is_removed()
        {
            var pageId = Guid.NewGuid();
            remover
                .Setup(x => x.Remove(pageId))
                .Returns(new ServiceExecutionResult());

            var result = controller.Delete(pageId) as OkResult;

            result.StatusCode.ShouldBe((int)HttpStatusCode.OK);
        }
    }
}
