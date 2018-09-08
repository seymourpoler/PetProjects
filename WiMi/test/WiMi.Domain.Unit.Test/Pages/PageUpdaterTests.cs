using Moq;
using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using WiMi.Domain.Pages;
using WiMi.Domain.Pages.Find;
using WiMi.Domain.Pages.Update;
using Xunit;

namespace WiMi.Domain.Unit.Test.Pages
{
    public class PageUpdaterTests
    {
        Mock<IExistPageRepository> existPageRepository;
        Mock<IFindPageRepository> findPageRepository;
        Mock<IUpdatePageRepository> updatePageRepository;
        IPageUpdater updater;

        public PageUpdaterTests()
        {
            existPageRepository = new Mock<IExistPageRepository>();
            findPageRepository = new Mock<IFindPageRepository>();
            updatePageRepository = new Mock<IUpdatePageRepository>();
            updater = new PageUpdater(
                existPageRepository: existPageRepository.Object,
                findPageRepository: findPageRepository.Object,
                updatePageRepository: updatePageRepository.Object);
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

        [Fact]
        public async Task return_ok_when_update_page()
        {
            var id = Guid.NewGuid();
            const string bodyUpdated = "body-updated";
            existPageRepository
                .Setup(x => x.Exist(id))
                .Returns(true);
            findPageRepository
                .Setup(x => x.FindBy(id))
                .Returns(BuildPage(id));

            var result = updater.Update(new PageUpdatingRequest(
                id: id,
                title: "title",
                body: bodyUpdated));

            result.IsOk.ShouldBeTrue();
            updatePageRepository
                .Verify(x => x.Update(It.Is<Page>(y =>
                    y.Id == id &&
                    y.Body == bodyUpdated)));
        }
        static Page BuildPage(Guid id)
        {
            return new Page(new Page.PersistenceState(
                id: id,
                title: "title",
                body: "body",
                creationDate: DateTime.UtcNow));
        }
    }
}
