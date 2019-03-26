using System;

namespace JasmineDotNet
{
    public class DescribeContext : Context
    {
        private readonly Action action;
        
        public DescribeContext(string testSuiteName, Action action)
            : base(testSuiteName)
        {
            this.action = action;
        }
        
        public override void Build(Jasmine instance)
        {
            base.Build(instance);
            action.Invoke();
            for (var position = 0; position < Contexts.Count; position++)
            {
                Contexts[position].Build(instance);
            }
        }
    }
}