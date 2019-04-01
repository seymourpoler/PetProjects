using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace JasmineDotNet
{
    public class Context
    {
        public string Name { get; }
        
        private List<Context> contexts;
        public ReadOnlyCollection<Context> Contexts
        {
            get { return contexts.AsReadOnly(); }
        }

        public Action BeforeEach { get; set; }
        public Action BeforeAll { get; set; }
        public Action AfterEach { get; set; }
        public Action AfterAll { get; set; }

        private List<Test> tests;
        public ReadOnlyCollection<Test> Tests
        {
            get { return tests.AsReadOnly(); }
        }

        public static Context CreateEmpty()
        {
            return new Context(String.Empty);
        }

        public Context(string name)
        {
            Name = name;
            contexts = new List<Context>();
            BeforeEach = () => { };
            BeforeAll = () => { };
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

        public virtual void Build(Jasmine instance)
        {
            instance.Context = this;
            BuiltInstance = instance;
            for (var position = 0; position < contexts.Count; position++)
            {
                contexts[position].Build(instance);
            }
        }

        public Jasmine BuiltInstance { get; set; }
    }
}