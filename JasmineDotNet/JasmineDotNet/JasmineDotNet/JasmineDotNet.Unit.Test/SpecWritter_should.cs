using JasmineDotNet.Expects;
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

            writter.Verify(x => x.WriteSuite(testSuiteName, 0));
        }
        
        [Fact]
        public void write_two_levels_contexts()
        {
            const string firstLevelTestSuiteName = "first level test suite";
            const string secondLevelTestSuiteName = "second level test suite";
            var context = new Context(firstLevelTestSuiteName);
            context.AddContext(new Context(secondLevelTestSuiteName));
            
            specWritter.Write(context);

            writter.Verify(x => x.WriteSuite(secondLevelTestSuiteName, 1));
        }
        
        [Fact]
        public void write_one_success_test()
        {
            const string testSuiteName = "one level test suite";
            const string testName = "a success test";
            var context = new Context(testSuiteName);
            context.AddTest(new JasmineDotNet.Test(testName, () => { }));
            
            specWritter.Write(context);

            writter.Verify(x => x.WriteSuite(testSuiteName, 0));
            writter.Verify(x => x.WriteSucessTest(testName, 1));
        }
        
        [Fact]
        public void write_one_fail_test()
        {
            const string testSuiteName = "one level test suite";
            const string testName = "a success test";
            var context = new Context(testSuiteName);
            context.AddTest(new JasmineDotNet.Test(testName, () => { new Expected<string>("another").ToBeNull(); }));
            
            specWritter.Write(context);

            writter.Verify(x => x.WriteSuite(testSuiteName, 0));
            writter.Verify(x => x.WriteFailTest(testName, It.IsAny<string>(), 1));
        }
        
        [Fact]
        public void write_total_number_of_success_test()
        {
            var context = new Context("a suite test");
            context.AddTest(new JasmineDotNet.Test("a test", () => { new Expected<string>(value:null).ToBeNull(); }));
            context.AddTest(new JasmineDotNet.Test("anoter test", () => { new Expected<string>(value:null).ToBeNull(); }));
            
            specWritter.Write(context);

            writter.Verify(x => x.WriteNumberOfTest(2, 0));
        }

        [Fact]
        public void write_total_number_of_fail_test()
        {
            var context = new Context("a suite test");
            context.AddTest(new JasmineDotNet.Test("a test", () => { new Expected<string>(value:null).ToBeNull(); }));
            context.AddTest(new JasmineDotNet.Test("anoter test", () => { new Expected<string>("f").ToBeNull(); }));

            specWritter.Write(context);

            writter.Verify(x => x.WriteNumberOfTest(1, 1));
        }
        
        [Fact]
        public void write_total_number_of_test_in_different_levels_of_depths()
        {
            var context = new Context("a suite test");
            context.AddTest(new JasmineDotNet.Test("a test", () => { new Expected<string>(value:null).ToBeNull(); }));
            context.AddTest(new JasmineDotNet.Test("anoter test", () => { new Expected<string>("f").ToBeNull(); }));
            
            var anotherContext = new Context("another suite of tests");
            anotherContext.AddTest(new JasmineDotNet.Test("another test", () => {new Expected<string>("null").ToBeNull();}));
            context.AddContext(anotherContext);

            specWritter.Write(context);

            writter.Verify(x => x.WriteNumberOfTest(1, 2));
        }
    }
}