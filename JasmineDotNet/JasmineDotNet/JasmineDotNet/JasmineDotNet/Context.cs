using System;
using System.Collections.Generic;

namespace JasmineDotNet
{
    public class Context
    {
        public string Name { get; }
        private List<Context> contexts;
        public IReadOnlyCollection<Context> Contexts { get { return contexts.AsReadOnly(); } }
        private List<Test> tests;
        public IReadOnlyCollection<Test> Tests { get { return tests.AsReadOnly(); } }
        
        public static Context CreateEmpty()
        {
            return new Context(String.Empty);
        }
        
        public Context(string name)
        {
            Name = name;
            contexts = new List<Context>();
            tests = new List<Test>();
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