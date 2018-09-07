using Moq;
using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using WiMi.Domain.Pages;
using WiMi.Domain.Pages.Update;
using Xunit;

namespace WiMi.Domain.Unit.Test.Pages
{
    public class PageUpdaterTests
    {
        Mock<IExistPageRepository> existPageRepository;
        IPageUpdater updater;

        public PageUpdaterTests()
        {
            existPageRepository = new Mock<IExistPageRepository>();
            updater = new PageUpdater(
                existPageRepository: existPageRepository.Object);
        }

        [Fact]
        public async Task return_not_found_error_when_page_is_not_found()
        {
            var id = Guid.NewGuid();
            existPageRepository
                .Setup(x => x.Exist(id))
                .Returns(false);

            var result = updater.Update(new PageUpdatingRequest(
                id: id,
                title: "title",
                body: "body"));

            result.IsOk.ShouldBeFalse();
            result.Errors.First().FieldId.ShouldBe(Error.GeneralFieldIdError);
            result.Errors.First().ErrorCode.ShouldBe(nameof(Error.ErrorCodes.NotFound));
        }
    }
}
