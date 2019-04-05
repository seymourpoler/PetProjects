using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace JasmineDotNet
{
    public class Specification
    {
        public string Name { get; }
        public bool IsIgnored { get; }
        private List<Specification> specifications;
        public ReadOnlyCollection<Specification> Specifications
        {
            get { return specifications.AsReadOnly(); }
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

        public static Specification CreateEmpty()
        {
            return new Specification("No soecification of tests");
        }

        public Specification(string name, bool isIgnored=false)
        {
            Check.If<ArgumentNullException>(() => String.IsNullOrWhiteSpace(name));
            
            Name = name;
            IsIgnored = isIgnored;
            specifications = new List<Specification>();
            beforeEach = () => { };
            beforeAll = () => { };
            afterEach = () => { };
            afterAll = () => { };
            tests = new List<Test>();
        }

        public void AddContext(Specification specification)
        {
            specifications.Add(specification);
        }

        public void AddTest(Test test)
        {
            tests.Add(test);
        }

        public virtual void Build(Jasmine instance)
        {
            instance.Specification = this;
            for (var position = 0; position < specifications.Count; position++)
            {
                specifications[position].Build(instance);
            }
        }
    }
}