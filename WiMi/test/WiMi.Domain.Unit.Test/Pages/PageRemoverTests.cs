using Moq;
using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using WiMi.Domain.Pages;
using WiMi.Domain.Pages.Remove;
using Xunit;

namespace WiMi.Domain.Unit.Test.Pages
{
    public class PageRemoverTests
    {
        Mock<IExistPageRepository> existRepository;
        IPageRemover remover;

        public PageRemoverTests()
        {
            existRepository = new Mock<IExistPageRepository>();
            remover = new PageRemover(existRepository.Object);
        }

        [Fact]
        public async Task return_not_found_when_page_is_not_found()
        {
            var id = Guid.NewGuid();
            existRepository
                .Setup(x => x.Exist(id))
                .Returns(false);

            var result = remover.Remove(id);

            result.IsOk.ShouldBeFalse();
            result.Errors.First().ErrorCode.ShouldBe(nameof(Error.ErrorCodes.NotFound));

        }
    }
}
