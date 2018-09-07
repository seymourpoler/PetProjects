using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WiMi.Domain;
using WiMi.Domain.Pages.Find;
using WiMi.Domain.Pages.Update;
using WiMi.Web.Controllers.Pages;
using Xunit;

namespace WiMi.Web.Unit.Test
{
    public class UpdatePageControllerTests
    {
        Mock<IPageFinder> finder;
        Mock<IPageUpdater> updater;
        UpdatePageController controller;

        public UpdatePageControllerTests()
        {
            finder = new Mock<IPageFinder>();
            updater = new Mock<IPageUpdater>();
            controller = new UpdatePageController(
                finder.Object,
                updater.Object);
        }

        [Fact]
        public async Task return_bad_request_when_request_is_null()
        {
            var result = controller.Update(null) as BadRequestObjectResult;

            result.StatusCode.Value.ShouldBe((int)HttpStatusCode.BadRequest);
            ((ReadOnlyCollection<Error>)result.Value).First().FieldId.ShouldContain(Error.GeneralFieldIdError);
            ((ReadOnlyCollection<Error>)result.Value).First().ErrorCode.ShouldContain(nameof(Error.ErrorCodes.RequestCanNotBeNull));
        }

        [Fact]
        public async Task return_bad_request_when_there_are_errors()
        {
            Guid id = Guid.NewGuid();
            updater
                .Setup(x => x.Update(It.Is<PageUpdatingRequest>(y => y.Id == id)))
                .Returns(new ServiceExecutionResult(new Error(Error.ErrorCodes.NotFound)));

            var result = controller.Update(new Models.PageUpdatingRequest { Id = id }) as BadRequestObjectResult;

            result.StatusCode.Value.ShouldBe((int)HttpStatusCode.BadRequest);
            ((ReadOnlyCollection<Error>)result.Value).First().FieldId.ShouldContain(Error.GeneralFieldIdError);
            ((ReadOnlyCollection<Error>)result.Value).First().ErrorCode.ShouldContain(nameof(Error.ErrorCodes.NotFound));
        }
    }
}
