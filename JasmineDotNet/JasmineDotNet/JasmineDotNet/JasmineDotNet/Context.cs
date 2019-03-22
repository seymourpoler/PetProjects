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
        private List<Test> tests;
        public IReadOnlyCollection<Test> Tests { get { return tests.AsReadOnly(); } }

        public static Context CreateEmpty()
        {
            return new Context(String.Empty, () => { });
        }

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

        public void AddTest(Test test)
        {
            tests.Add(test);
        }
    }
}
