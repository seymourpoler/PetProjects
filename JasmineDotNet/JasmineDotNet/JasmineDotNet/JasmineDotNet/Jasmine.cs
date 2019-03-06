using System;

namespace JasmineDotNet
{
    public class Jasmine
    {
        private Action beforeAll;
        private bool isExecutedBeForeAll;
        
        private Action afterAll;
        private bool isExecutedAfterAll;

        private Action beforeEach;
        private Action afterEach;

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

        public void BeforeEach(Action action)
        {
            Check.IsNull<ArgumentNullException>(action);

            beforeEach = action;
        }

        public void AfterEach(Action action)
        {
            Check.IsNull<ArgumentNullException>(action);

            afterEach = action;
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
            
            if (beforeEach.IsNotNull())
            {
                beforeEach.Invoke();
            }
            
            test.Invoke();
            
            if (afterEach.IsNotNull())
            {
                afterEach.Invoke();
            }

            if (afterAll.IsNotNull() && !isExecutedAfterAll)
            {
                isExecutedAfterAll = true;
                afterAll.Invoke();
            }

        }
    }
}