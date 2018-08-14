using Moq;
using WiMi.Domain.Pages.Find;
using WiMi.Web.Controllers.Pages;

namespace WiMi.Web.Unit.Test
{
	public class FindPagesControllerTests
    {
		Mock<IPageFinder> finder;
		FindPagesController controller;

        public FindPagesControllerTests()
        {
			finder = new Mock<IPageFinder>();
			controller = new FindPagesController(finder.Object);
        }
    }
}
