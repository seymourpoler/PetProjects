using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using WiMi.Domain;
using WiMi.Domain.Pages.Create;
using WiMi.Web.Controllers;
using Xunit;

namespace WiMi.Web.Unit.Test
{
    public class PagesControllerTests
    {
        Mock<IPageCreator> creator;
        PagesController controller;

        public PagesControllerTests()
        {
            creator = new Mock<IPageCreator>();
            controller = new PagesController(pageCreator: creator.Object);
        }

        [Fact]
        public void return_bad_request_when_request_is_null()
        {
            var result = controller.Create(request: null) as BadRequestObjectResult;

            result.StatusCode.Value.ShouldBe((int)HttpStatusCode.BadRequest);
            ((Error.ErrorCodes)result.Value).ShouldBe(Error.ErrorCodes.RequestCanNotBeNull);
        }
        
        [Fact]
        public void return_bad_request_when_there_is_a_error()
		{
			const string title = "title";
			const string body = "body";
			var executionResult = new ServiceExecutionResult(new List<Error> { new Error(fieldId: "Title", errorCode: nameof(Error.ErrorCodes.Required)) });
			creator
				.Setup(x => x.Create(It.Is<PageCreationRequest>(y => y.Title == title)))
				.Returns(executionResult);
            var request = new Models.PageCreationRequest { Title = title, Body = body };

            var result = controller.Create(request) as BadRequestObjectResult;

			result.StatusCode.Value.ShouldBe((int)HttpStatusCode.BadRequest);
            ((ReadOnlyCollection<Error>)result.Value).First().FieldId.ShouldContain("Title");
            ((ReadOnlyCollection<Error>)result.Value).First().ErrorCode.ShouldContain(nameof(Error.ErrorCodes.Required));
		}

		[Fact]
        public void return_ok()
        {
            const string title = "title";
            const string body = "body";
            creator
				.Setup(x => x.Create(It.Is<PageCreationRequest>(y => y.Body == body)))
				.Returns(new ServiceExecutionResult());
            var request = new Models.PageCreationRequest { Title = title, Body = body };

            var result = controller.Create(request) as OkResult;

			result.StatusCode.ShouldBe((int)HttpStatusCode.OK);
        }
    }
}
