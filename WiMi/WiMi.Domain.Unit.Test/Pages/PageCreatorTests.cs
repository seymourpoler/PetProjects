using Shouldly;
using System.Linq;
using WiMi.Domain.Pages;
using Xunit;
using System;

namespace WiMi.Domain.Unit.Test.Pages
{
    public class PageCreatorTests
    {
        IPageCreator creator;

        public PageCreatorTests()
        {
            creator = new PageCreator();
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
	}
}
