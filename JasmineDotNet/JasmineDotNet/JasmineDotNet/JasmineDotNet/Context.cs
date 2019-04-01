using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace JasmineDotNet
{
    public class Context
    {
        public string Name { get; }
        public Jasmine BuiltInstance { get; set; }
        
        private List<Context> contexts;
        public ReadOnlyCollection<Context> Contexts
        {
            get { return contexts.AsReadOnly(); }
        }

        Action beforeEach;
        public Action BeforeEach
        {
            get { return beforeEach; }
            set
            {
                Check.IsNull<ArgumentException>(value);
                beforeEach = value;
            } 
        }

        private Action beforeAll;
        public Action BeforeAll
        {
            get { return beforeAll; }
            set
            {
                Check.IsNull<ArgumentNullException>(value);
                beforeAll = value;
            } 
        }

        Action afterEach;
        public Action AfterEach
        {
            get { return afterEach; }
            set
            {
                Check.IsNull<ArgumentNullException>(value);
                afterEach = value;
            }
        }

        Action afterAll;
        public Action AfterAll
        {
            get { return afterAll; }
            set
            {
                Check.IsNull<ArgumentNullException>(value);
                afterAll = value;
            }
        }

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
            Check.If<ArgumentNullException>(() => String.IsNullOrWhiteSpace(name));
            
            Name = name;
            contexts = new List<Context>();
            beforeEach = () => { };
            beforeAll = () => { };
            afterEach = () => { };
            afterAll = () => { };
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
            for (var position = 0; position < contexts.Count; position++)
            {
                contexts[position].Build(instance);
            }
        }
    }
}