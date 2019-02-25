using System;

namespace JasmineDotNet
{
    public class Jasmine
    {
        public void Describe(string testSuiteName, Action action)
        {
            Check.If<ArgumentNullException>(() => String.IsNullOrWhiteSpace(testSuiteName));
            Check.IsNull<ArgumentNullException>(action);
            
            action.Invoke();
        }

        public void BeforeAll(Action action)
        {
            Check.IsNull<ArgumentNullException>(action);
            
            throw new NotImplementedException();
        }
    }
}