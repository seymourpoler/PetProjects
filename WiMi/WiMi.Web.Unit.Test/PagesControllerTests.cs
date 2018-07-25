using Moq;
using Shouldly;
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
    }
}
