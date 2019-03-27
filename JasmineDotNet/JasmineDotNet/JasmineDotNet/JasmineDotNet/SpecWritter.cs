using System;

namespace JasmineDotNet
{
    public class SpecWritter
    {
        readonly IWritter writter;
        int totalNumberOfFailTests = 0;
        int totalNumberOfSuccessTests = 0;
            
        public SpecWritter(IWritter writter)
        {
            this.writter = writter;
        }

        public void Write(Context context)
        {
            const int firstLevelOfDepth = 0;
            WriteInDepth(depth: firstLevelOfDepth, context: context);
            writter.WriteNumberOfTest(success: totalNumberOfSuccessTests, fail: totalNumberOfFailTests);
        }

        void WriteInDepth(int depth, Context context)
        {
            writter.WriteSuite(context.Name);
            var nextLevelOfDepth = depth + 1;
            foreach (var aContext in context.Contexts)
            {
                WriteInDepth(nextLevelOfDepth, aContext);                
            }

            foreach (var test in context.Tests)
            {
                try
                {
                    test.Run();
                    writter.WriteSucessTest(test.Name);
                    totalNumberOfSuccessTests++;
                }
                catch (Exception e)
                {
                    writter.WriteFailTest(test.Name);
                    totalNumberOfFailTests++;
                }
            }
        }
    }
}