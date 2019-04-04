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

        //TDOO: refactor extract method
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
                try
                {
                    if (test.IsIgnored)
                    {
                        totalNumberOfIgnoredTests++;
                    }
                    else 
                    {
                        specification.BeforeEach.Invoke();
                        test.Run();
                        writter.WriteSucessTest(text: test.Name, leftSeparation: nextLevelOfDepth);
                        totalNumberOfSuccessTests++;
                        specification.AfterEach.Invoke();
                    }
                }
                catch (Exception e)
                {
                    writter.WriteFailTest(text: test.Name, errorMessage: e.Message, leftSeparation: nextLevelOfDepth);
                    totalNumberOfFailTests++;
                }
            }

            specification.AfterAll.Invoke();
        }
    }
}