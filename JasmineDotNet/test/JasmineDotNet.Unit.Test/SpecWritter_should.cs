using JasmineDotNet.Expects;
using Xunit;
using Moq;

namespace JasmineDotNet.Unit.Test
{
    public class SpecWritter_should
    {
        Mock<IWritter> writter;
        SpecificationWritter _specificationWritter;
        
        public SpecWritter_should()
        {
            writter = new Mock<IWritter>();
            _specificationWritter = new SpecificationWritter(writter.Object);
        }

        [Fact]
        public void write_one_level_context()
        {
            const string testSuiteName = "one level test suite";
            var context = new Specification(testSuiteName);
            
            _specificationWritter.Write(context);

            writter.Verify(x => x.WriteSuite(testSuiteName, 0));
        }
        
        [Fact]
        public void write_two_levels_contexts()
        {
            const string firstLevelTestSuiteName = "first level test suite";
            const string secondLevelTestSuiteName = "second level test suite";
            var context = new Specification(firstLevelTestSuiteName);
            context.AddContext(new Specification(secondLevelTestSuiteName));
            
            _specificationWritter.Write(context);

            writter.Verify(x => x.WriteSuite(secondLevelTestSuiteName, 1));
        }
        
        [Fact]
        public void write_one_success_test()
        {
            const string testSuiteName = "one level test suite";
            const string testName = "a success test";
            var context = new Specification(testSuiteName);
            context.AddTest(new JasmineDotNet.Test(testName, () => { }));
            
            _specificationWritter.Write(context);

            writter.Verify(x => x.WriteSuite(testSuiteName, 0));
            writter.Verify(x => x.WriteSucessTest(testName, 1));
        }
        
        [Fact]
        public void write_one_fail_test()
        {
            const string testSuiteName = "one level test suite";
            const string testName = "a success test";
            var context = new Specification(testSuiteName);
            context.AddTest(new JasmineDotNet.Test(testName, () => { new Expected<string>("another").ToBeNull(); }));
            
            _specificationWritter.Write(context);

            writter.Verify(x => x.WriteSuite(testSuiteName, 0));
            writter.Verify(x => x.WriteFailTest(testName, It.IsAny<string>(), 1));
        }
        
        [Fact]
        public void write_total_number_of_success_test()
        {
            var context = new Specification("a suite test");
            context.AddTest(new JasmineDotNet.Test("a test", () => { new Expected<string>(value:null).ToBeNull(); }));
            context.AddTest(new JasmineDotNet.Test("anoter test", () => { new Expected<string>(value:null).ToBeNull(); }));
            
            _specificationWritter.Write(context);

            writter.Verify(x => x.WriteNumberOfTest(2, 0, 0));
        }
        
        [Fact]
        public void write_total_number_of_ignored_test()
        {
            var context = new Specification("a suite test");
            context.AddTest(new JasmineDotNet.Test("a test", () => { new Expected<string>(value:null).ToBeNull(); }));
            context.AddTest(new JasmineDotNet.Test("anoter test", () => { new Expected<string>("f").ToBeNull(); }, true));

            _specificationWritter.Write(context);

            writter.Verify(x => x.WriteNumberOfTest(1, 1, 0));
        }

        [Fact]
        public void write_total_number_of_fail_test()
        {
            var context = new Specification("a suite test");
            context.AddTest(new JasmineDotNet.Test("a test", () => { new Expected<string>(value:null).ToBeNull(); }));
            context.AddTest(new JasmineDotNet.Test("anoter test", () => { new Expected<string>("f").ToBeNull(); }));

            _specificationWritter.Write(context);

            writter.Verify(x => x.WriteNumberOfTest(1, 0, 1));
        }
        
        [Fact]
        public void write_total_number_of_test_in_different_levels_of_depths()
        {
            var context = new Specification("a suite test");
            context.AddTest(new JasmineDotNet.Test("a test", () => { new Expected<string>(value:null).ToBeNull(); }));
            context.AddTest(new JasmineDotNet.Test("anoter test", () => { new Expected<string>("f").ToBeNull(); }));
            
            var anotherContext = new Specification("another suite of tests");
            anotherContext.AddTest(new JasmineDotNet.Test("another test", () => {new Expected<string>("null").ToBeNull();}));
            context.AddContext(anotherContext);

            _specificationWritter.Write(context);

            writter.Verify(x => x.WriteNumberOfTest(1, 0, 2));
        }
    }
}