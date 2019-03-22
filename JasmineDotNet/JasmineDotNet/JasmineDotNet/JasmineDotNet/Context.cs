using System;
using System.Collections.Generic;

namespace JasmineDotNet
{
    public class Context
    {
        public string Name { get; }
        private List<Context> contexts;
        public IReadOnlyCollection<Context> Contexts { get { return contexts.AsReadOnly(); } }
        private Action action;

        public Context(string name, Action action)
        {
            Name = name;
            this.action = action;
            contexts = new List<Context>();
        }

        public void AddContext(Context context)
        {
            contexts.Add(context);
        }
    }
}
