using System;

namespace JasmineDotNet
{
    public class Jasmine
    {
        public void describe(string testSuiteName, Action action)
        {
            Check.If<ArgumentNullException>(() => String.IsNullOrWhiteSpace(testSuiteName));
            Check.IsNull<ArgumentNullException>(action);
            
            Context.AddContext(new DescribeContext(testSuiteName, action));
        }

        public void xdescribe(string testSuiteName, Action action)
        {
            testSuiteName = testSuiteName;
        }

        public void beforeAll(Action action)
        {
            Check.IsNull<ArgumentNullException>(action);
            
            Context.BeforeAll  = action;
        }

        public void afterAll(Action action)
        {
            Check.IsNull<ArgumentNullException>(action);

            Context.AfterAll = action;
        }

        public void beforeEach(Action action)
        {
            Check.IsNull<ArgumentNullException>(action);
            
            Context.BeforeEach = action;
        }

        public void afterEach(Action action)
        {
            Check.IsNull<ArgumentNullException>(action);

            Context.AfterEach = action;
        }

        public void it(string testName, Action action)
        {
            Check.If<ArgumentNullException>(() => String.IsNullOrWhiteSpace(testName));
            Check.IsNull<ArgumentNullException>(action);
            
            Context.AddTest(new Test(testName, action));
        }

        public void xit(string testName, Action test)
        {
        }

        public Expect<T> expect<T>(T value)
        {
            return new Expect<T>(value);
        }

        internal Context Context { get; set; }
    }
}