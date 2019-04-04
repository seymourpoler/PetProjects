using System;

namespace JasmineDotNet
{
    public class Test
    {
        public string Name { get; }
        public bool IsIgnored {get;}
        private readonly  Action action;

        public Test(string name, Action action, bool isIgnored=false)
        {
            Check.If<ArgumentNullException>(() => String.IsNullOrWhiteSpace(name));
            Check.IsNull<ArgumentNullException>(action);
            
            Name = name;
            this.action = action;
            IsIgnored = isIgnored;
        }

        public void Run()
        {
            action.Invoke();
        }
    }
}

