using System;

namespace JasmineDotNet
{
    public class Test
    {
        public string Name { get; }
        private readonly  Action action;

        public Test(string name, Action action)
        {
            Check.If<ArgumentNullException>(() => String.IsNullOrWhiteSpace(name));
            Check.IsNull<ArgumentNullException>(action);
            
            Name = name;
            this.action = action;
        }

        public void Run()
        {
            action.Invoke();
        }
    }
}

