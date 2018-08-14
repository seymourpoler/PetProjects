using Moq;
using Shouldly;
using System;
using System.Linq;
using WiMi.Domain.Pages;
using WiMi.Domain.Pages.Create;
using Xunit;

namespace WiMi.Domain.Unit.Test
{
    public class PageCreatorTests
    {
        Mock<ISavePageRepository> repository;
        IPageCreator creator;

        public PageCreatorTests()
        {
            repository = new Mock<ISavePageRepository>();
            creator = new PageCreator(repository.Object);
        }

        [Fact]
        public void return_error_when_title_is_null()
        {
            var result = creator.Create(new PageCreationRequest(title: null, body: "a"));

            result.IsOk.ShouldBeFalse();
            result.Errors.First().FieldId.ShouldBe("Title");
            result.Errors.First().ErrorCode.ShouldBe(nameof(Error.ErrorCodes.Required));
        }

        [Fact]
        public void return_error_when_title_is_empty()
        {
            var result = creator.Create(new PageCreationRequest(title: String.Empty, body: "a"));

            result.IsOk.ShouldBeFalse();
            result.Errors.First().FieldId.ShouldBe("Title");
            result.Errors.First().ErrorCode.ShouldBe(nameof(Error.ErrorCodes.Required));
        }

        [Fact]
        public void return_error_when_body_is_null()
        {
            var result = creator.Create(new PageCreationRequest(title: "a", body: null));

            result.IsOk.ShouldBeFalse();
            result.Errors.First().FieldId.ShouldBe("Body");
            result.Errors.First().ErrorCode.ShouldBe(nameof(Error.ErrorCodes.Required));
        }

        [Fact]
        public void return_error_when_body_is_empty()
        {
            var result = creator.Create(new PageCreationRequest(title: "a", body: String.Empty));

            result.IsOk.ShouldBeFalse();
            result.Errors.First().FieldId.ShouldBe("Body");
            result.Errors.First().ErrorCode.ShouldBe(nameof(Error.ErrorCodes.Required));
        }
    }
}
