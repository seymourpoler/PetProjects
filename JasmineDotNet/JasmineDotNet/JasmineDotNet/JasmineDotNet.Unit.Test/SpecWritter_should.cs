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

            writter.Verify(x => x.WriteSuite(testSuiteName));
        }
        
        [Fact]
        public void write_one_success_test()
        {
            const string testSuiteName = "one level test suite";
            const string testName = "a success test";
            var writter = new Mock<IWritter>(); 
            var specWritter = new SpecWritter(writter.Object);
            var context = new Context(testSuiteName);
            context.AddTest(new JasmineDotNet.Test(testName, () => { }));
            
            specWritter.Write(context);

            writter.Verify(x => x.WriteSuite(testSuiteName));
            writter.Verify(x => x.WriteSucessTest(testName));
        }
        
        [Fact]
        public void write_one_fail_test()
        {
            const string testSuiteName = "one level test suite";
            const string testName = "a success test";
            var writter = new Mock<IWritter>(); 
            var specWritter = new SpecWritter(writter.Object);
            var context = new Context(testSuiteName);
            context.AddTest(new JasmineDotNet.Test(testName, () => { new Expect<string>("another").ToBeNull(); }));
            
            specWritter.Write(context);

            writter.Verify(x => x.WriteSuite(testSuiteName));
            writter.Verify(x => x.WriteFailTest(testName));
        }
    }
}