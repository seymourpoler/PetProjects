using System;

namespace JasmineDotNet
{
    public class Jasmine
    {
        private Action beforeAll;
        private Action beforeEach;
        private Action afterEach;
        
        public void Describe(string testSuiteName, Action action)
        {
            Check.If<ArgumentNullException>(() => String.IsNullOrWhiteSpace(testSuiteName));
            Check.IsNull<ArgumentNullException>(action);

            if (beforeAll.IsNotNull())
            {
                beforeAll.Invoke();
            }
            action.Invoke();
        }

        public void BeforeAll(Action action)
        {
            Check.IsNull<ArgumentNullException>(action);

            beforeAll = action;
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

            if (beforeEach.IsNotNull())
            {
                beforeEach.Invoke();
            }
            
            test.Invoke();
            
            if (afterEach.IsNotNull())
            {
                afterEach.Invoke();
            }
        }
    }
}