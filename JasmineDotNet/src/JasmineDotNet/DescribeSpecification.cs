using System;

namespace JasmineDotNet
{
    public class DescribeSpecification : Specification
    {
        private readonly Action action;
        
        public DescribeSpecification(string testSuiteName, Action action)
            : base(testSuiteName)
        {
            Check.IsNull<ArgumentNullException>(action);
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