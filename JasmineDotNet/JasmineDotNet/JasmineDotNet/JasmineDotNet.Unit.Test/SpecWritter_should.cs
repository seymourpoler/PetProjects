using Xunit;
using Moq;

namespace JasmineDotNet.Unit.Test
{
    public class SpecWritter_should
    {
        Mock<IWritter> writter;
        SpecWritter specWritter;
        
        public SpecWritter_should()
        {
            writter = new Mock<IWritter>();
            specWritter = new SpecWritter(writter.Object);
        }

        [Fact]
        public void write_one_level_context()
        {
            const string testSuiteName = "one level test suite";
            var context = new Context(testSuiteName);
            
            specWritter.Write(context);

            writter.Verify(x => x.WriteSuite(testSuiteName));
        }
        
        [Fact]
        public void write_one_success_test()
        {
            const string testSuiteName = "one level test suite";
            const string testName = "a success test";
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
            var context = new Context(testSuiteName);
            context.AddTest(new JasmineDotNet.Test(testName, () => { new Expect<string>("another").ToBeNull(); }));
            
            specWritter.Write(context);

            writter.Verify(x => x.WriteSuite(testSuiteName));
            writter.Verify(x => x.WriteFailTest(testName));
        }
        
        [Fact]
        public void write_total_number_of_success_test()
        {
            var context = new Context("a suite test");
            context.AddTest(new JasmineDotNet.Test("a test", () => { new Expect<string>(null).ToBeNull(); }));
            context.AddTest(new JasmineDotNet.Test("anoter test", () => { new Expect<string>(null).ToBeNull(); }));
            
            specWritter.Write(context);

            writter.Verify(x => x.WriteNumberOfTest(2, 0));
        }
        
        [Fact]
        public void write_total_number_of_fail_test()
        {
            var context = new Context("a suite test");
            context.AddTest(new JasmineDotNet.Test("a test", () => { new Expect<string>(null).ToBeNull(); }));
            context.AddTest(new JasmineDotNet.Test("anoter test", () => { new Expect<string>("f").ToBeNull(); }));
            
            specWritter.Write(context);

            writter.Verify(x => x.WriteNumberOfTest(1, 1));
        }
    }
}