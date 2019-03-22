using System;

namespace JasmineDotNet
{
    public class Test
    {
        public string Name { get; }
        private Action action;

        public Test(string name, Action action)
        {
            Name = name;
            this.action = action;
        }
    }
}
