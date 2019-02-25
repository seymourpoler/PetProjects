using System;

namespace JasmineDotNet
{
    public class Jasmine
    {
        public void Describe(string testSuiteName, Action action)
        {
            Check.If<ArgumentNullException>(() => String.IsNullOrWhiteSpace(testSuiteName));
            Check.IsNull<ArgumentNullException>(action);
        }
    }
}