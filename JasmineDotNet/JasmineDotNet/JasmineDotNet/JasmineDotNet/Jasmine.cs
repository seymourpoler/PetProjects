using System;

namespace JasmineDotNet
{
    public class Jasmine
    {
        private Action beforeAll;
        private bool isExecutedBeForeAll;

        public Jasmine()
        {
            isExecutedBeForeAll = false;
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
            
            throw new NotImplementedException();
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
        }
    }
}