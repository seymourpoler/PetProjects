using Xunit;
using Moq;

namespace JasmineDotNet.Unit.Test
{
    public class SpecWritter_should
    {
        [Fact]
        public void write_one_level_context()
        {
            const string testSuiteName = "one level test suite";
            var writter = new Mock<IWritter>(); 
            var specWritter = new SpecWritter(writter.Object);
            var context = new Context(testSuiteName);
            
            specWritter.Write(context);

            writter.Verify(x => x.Write(testSuiteName));
        }
    }
}