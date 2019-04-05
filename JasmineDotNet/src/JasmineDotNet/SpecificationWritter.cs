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

        void WriteInDepth(int depth, Specification specification)
        {
            writter.WriteSuite(specification.Name, depth);
            var nextLevelOfDepth = depth + 1;
            foreach (var aContext in specification.Contexts)
            {
                WriteInDepth(depth: nextLevelOfDepth, specification: aContext);
            }

            specification.BeforeAll.Invoke();
            foreach (var test in specification.Tests)
            {
                Run(specification, test, nextLevelOfDepth);
            }

            specification.AfterAll.Invoke();
        }

        void Run(Specification specification, Test test, int levelOfDepth)
        {
            try
            {
                if (test.IsIgnored)
                {
                    writter.WriteIgnoredTest(text: test.Name, leftSeparation: levelOfDepth);
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