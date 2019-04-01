using System;
using JasmineDotNet.Expects;

namespace JasmineDotNet
{
    public class Jasmine
    {
        public void describe(string testSuiteName, Action action)
        {          
            Context.AddContext(new DescribeContext(testSuiteName, action));
        }

        public void xdescribe(string testSuiteName, Action action)
        {
            testSuiteName = testSuiteName;
        }

        public void beforeAll(Action action)
        {
            Context.BeforeAll = action;
        }

        public void afterAll(Action action)
        {
            Context.AfterAll = action;
        }

        public void beforeEach(Action action)
        {
            Context.BeforeEach = action;
        }

        public void afterEach(Action action)
        {
            Context.AfterEach = action;
        }

        public void it(string testName, Action action)
        {
            Context.AddTest(new Test(testName, action));
        }

        public void xit(string testName, Action test)
        {
        }

        public Expected<T> expect<T>(T value)
        {
            return new Expected<T>(value);
        }

        internal Context Context { get; set; }
    }
}