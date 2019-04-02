using System;
using JasmineDotNet.Expects;

namespace JasmineDotNet
{
    public class Jasmine
    {
        public void describe(string testSuiteName, Action action)
        {          
            Specification.AddContext(new DescribeSpecification(testSuiteName, action));
        }

        public void xdescribe(string testSuiteName, Action action)
        {
            testSuiteName = testSuiteName;
        }

        public void beforeAll(Action action)
        {
            Specification.BeforeAll = action;
        }

        public void afterAll(Action action)
        {
            Specification.AfterAll = action;
        }

        public void beforeEach(Action action)
        {
            Specification.BeforeEach = action;
        }

        public void afterEach(Action action)
        {
            Specification.AfterEach = action;
        }

        public void it(string testName, Action action)
        {
            Specification.AddTest(new Test(testName, action));
        }

        public void xit(string testName, Action test)
        {
        }

        public Expected<T> expect<T>(T value)
        {
            return new Expected<T>(value);
        }

        internal Specification Specification { get; set; }
    }
}