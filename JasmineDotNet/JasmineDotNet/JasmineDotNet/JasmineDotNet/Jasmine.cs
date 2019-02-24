using System;

namespace JasmineDotNet
{
    public class Jasmine
    {
        public void Describe(string testSuiteName, Action action)
        {
            Check.IsNull<ArgumentNullException>(testSuiteName);
            Check.IsNull<ArgumentNullException>(action);
        }
    }
}