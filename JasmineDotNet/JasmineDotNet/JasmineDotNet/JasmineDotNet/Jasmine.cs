using System;

namespace JasmineDotNet
{
    public class Jasmine
    {
        private Action beforeAll;
        
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

        public void BeforeEach(Action beforeEach)
        {
            Check.IsNull<ArgumentNullException>(beforeEach);
            throw new NotImplementedException();
        }
        
        public void It(string testName, Action test)
        {
            Check.If<ArgumentNullException>(() => String.IsNullOrWhiteSpace(testName));
            Check.IsNull<ArgumentNullException>(test);
            
            test.Invoke();
        }
    }
}