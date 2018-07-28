using Shouldly;
using System.Linq;
using WiMi.Domain.Pages;
using Xunit;
using System;
using Moq;
using WiMi.Domain.Pages.Create;

namespace WiMi.Domain.Unit.Test.Pages
{
    public class PageCreatorTests
    {
		Mock<IPageRepository> repository;
        IPageCreator creator;

        public PageCreatorTests()
        {
			repository = new Mock<IPageRepository>();
			creator = new PageCreator(repository: repository.Object);
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

		[Fact]
        public void return_some_errors_when_there_are_some_errors()
        {
            var result = creator.Create(new PageCreationRequest(title: null, body: String.Empty));

            result.IsOk.ShouldBeFalse();
			result.Errors.Count.ShouldBe(2);
        }

		[Fact]
        public void creates_page()
        {
			const string title = "title";
			const string body = "body";

			var result = creator.Create(new PageCreationRequest(title: title, body: body));

			result.IsOk.ShouldBeTrue();
			repository
				.Verify(x => x.Save(It.Is<Page>(y => y.Title == title)));
        }
	}
}
