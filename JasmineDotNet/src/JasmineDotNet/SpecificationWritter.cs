using System;

namespace JasmineDotNet
{
    public class SpecificationWritter
    {
        readonly IWritter writter;
        int totalNumberOfFailTests = 0;
        int totalNumberOfSuccessTests = 0;
        int totalNumberOfIgnoredTests = 0;

        public SpecificationWritter(IWritter writter)
        {
            this.writter = writter;
        }

        public void Write(Specification specification)
        {
            const int firstLevelOfDepth = 0;
            WriteInDepth(depth: firstLevelOfDepth, specification: specification);
            writter.WriteNumberOfTest(
                success: totalNumberOfSuccessTests,
                ignored: totalNumberOfIgnoredTests,
                fail: totalNumberOfFailTests);
        }

        //TODO: refactor too long method
        void WriteInDepth(int depth, Specification specification)
        {
            if (specification.IsIgnored)
            {
                WriteIgnored(specification: specification, depth: depth);
                return;
            }
            WriteSuite(specification: specification, depth: depth);
            var nextLevelOfDepth = depth + 1;
            foreach (var aContext in specification.Contexts)
            {
                WriteInDepth(depth: nextLevelOfDepth, specification: aContext);
            }

            specification.BeforeAll.Invoke();
            foreach (var test in specification.Tests)
            {
                WriteTest(specification, test, nextLevelOfDepth);
            }

            specification.AfterAll.Invoke();
        }

        void WriteIgnored(Specification specification, int depth)
        {
            writter.WriteIgnored(text: specification.Name, leftSeparation: depth);
            var nextLevelOfDepth = depth + 1;
            foreach (var aContext in specification.Contexts)
            {
                WriteIgnored(specification: aContext, depth: nextLevelOfDepth);
            }
            foreach (var test in specification.Tests)
            {
                writter.WriteIgnored(text: test.Name, leftSeparation: depth);
                totalNumberOfIgnoredTests++;
            }
        }
        
        void WriteSuite(Specification specification, int depth)
        {
            if (specification.IsIgnored)
            {
                writter.WriteIgnored(text: specification.Name, leftSeparation: depth);
                return;
            }
            writter.WriteSuite(text: specification.Name, leftSeparation: depth);
        }
        
        void WriteTest(Specification specification, Test test, int levelOfDepth)
        {
            try
            {
                if (test.IsIgnored || specification.IsIgnored)
                {
                    writter.WriteIgnored(text: test.Name, leftSeparation: levelOfDepth);
                    totalNumberOfIgnoredTests++;
                }
                else
                {
                    specification.BeforeEach.Invoke();
                    test.Run();
                    writter.WriteSucessTest(text: test.Name, leftSeparation: levelOfDepth);
                    totalNumberOfSuccessTests++;
                    specification.AfterEach.Invoke();
                }
            }
            catch (Exception e)
            {
                writter.WriteFailTest(text: test.Name, errorMessage: e.Message, leftSeparation: levelOfDepth);
                totalNumberOfFailTests++;
            }
        }
    }
}