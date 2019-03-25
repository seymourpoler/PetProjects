using System;

namespace JasmineDotNet
{
    public class Test
    {
        public string Name { get; }
        public Action action { get; }
        
        public Test(string name, Action action)
        {
            Name = name;
            this.action = action;
        }
    }
}