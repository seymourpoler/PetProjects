using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Net;
using System.Web.Http.Results;
using WiMi.CrossCutting;
using WiMi.Domain;
using WiMi.Domain.Pages;
using WiMi.Web.Controllers;
using Xunit;

namespace WiMi.Web.Unit.Test
{
    public class PagesControllerTests
    {
        Mock<IPageCreator> creator;
        HttpActionResultBuilder httpActionResultBuilder;
        PagesController controller;

        public PagesControllerTests()
        {
            creator = new Mock<IPageCreator>();
            httpActionResultBuilder = new HttpActionResultBuilder(new JsonSerializer());
            controller = new PagesController(
                pageCreator: creator.Object,
                httpActionResultBuilder: httpActionResultBuilder);
        }

        [Fact]
        public void return_bad_request_when_request_is_null()
        {
            var result = controller.Create(request: null) as ResponseMessageResult;

            result.Response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
            result.Response.Content.ReadAsStringAsync().Result.ShouldContain(nameof(Error.ErrorCodes.RequestCanNotBeNull));
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
			
			var result = controller.Create(new Models.PageCreationRequest{Title = title, Body = body}) as ResponseMessageResult;

			result.Response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
			result.Response.Content.ReadAsStringAsync().Result.ShouldContain(nameof(Error.ErrorCodes.Required));
		}

		[Fact]
        public void return_ok()
        {
            const string title = "title";
            const string body = "body";
            creator
				.Setup(x => x.Create(It.Is<PageCreationRequest>(y => y.Body == body)))
				.Returns(new ServiceExecutionResult());

            var result = controller.Create(new Models.PageCreationRequest { Title = title, Body = body }) as ResponseMessageResult;

			result.Response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }
    }
}
