using System.Collections.Generic;

namespace JasmineDotNet
{
    public class Context
    {
        public string Name { get; }
        private List<Context> _contexts;
        public IReadOnlyCollection<Context> Contexts { get { return _contexts.AsReadOnly(); } }
        private List<Test> _tests;
        public IReadOnlyCollection<Test> Tests { get { return _tests.AsReadOnly(); } }

        public Context(string name)
        {
            _contexts = new List<Context>();
            _tests = new List<Test>();
            Name = name;
        }
        
        
    }
}