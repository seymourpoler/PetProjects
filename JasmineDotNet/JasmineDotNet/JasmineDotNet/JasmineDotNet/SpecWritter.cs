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
            writter.WriteSuite(context.Name);

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
            writter.WriteNumberOfTest(success: totalNumberOfSuccessTests, fail: totalNumberOfFailTests);
        }
    }
}