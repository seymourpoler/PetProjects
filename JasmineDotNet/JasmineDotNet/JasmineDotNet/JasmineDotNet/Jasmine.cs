using System;

namespace JasmineDotNet
{
    public class Jasmine
    {
        private Action beforeAll;
        private bool isExecutedBeForeAll;
        private Action afterAll;
        private bool isExecutedAfterAll;

        public Jasmine()
        {
            isExecutedBeForeAll = false;
            isExecutedAfterAll = false;
        }
        
        public void Describe(string testSuiteName, Action action)
        {
            Check.If<ArgumentNullException>(() => String.IsNullOrWhiteSpace(testSuiteName));
            Check.IsNull<ArgumentNullException>(action);

            action.Invoke();
        }

        public void BeforeAll(Action action)
        {
            Check.IsNull<ArgumentNullException>(action);

            beforeAll = action;
        }

        public void AfterAll(Action action)
        {
            Check.IsNull<ArgumentNullException>(action);
            afterAll = action;
        }

        public void It(string testName, Action test)
        {
            Check.If<ArgumentNullException>(() => String.IsNullOrWhiteSpace(testName));
            Check.IsNull<ArgumentNullException>(test);
            
            if (beforeAll.IsNotNull() && !isExecutedBeForeAll)
            {
                isExecutedBeForeAll = true;
                beforeAll.Invoke();
            }
            
            test.Invoke();

            if (afterAll.IsNotNull() && !isExecutedAfterAll)
            {
                isExecutedAfterAll = true;
                afterAll.Invoke();
            }
        }
    }
}