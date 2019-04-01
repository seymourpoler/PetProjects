﻿using System;

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
            writter.WriteSuite(context.Name, depth);
            var nextLevelOfDepth = depth + 1;
            foreach (var aContext in context.Contexts)
            {
                WriteInDepth(depth: nextLevelOfDepth, context: aContext);                
            }

            context.BeforeAll.Invoke();
            foreach (var test in context.Tests)
            {
                try
                {
                    context.BeforeEach.Invoke();
                    test.Run();
                    writter.WriteSucessTest(text: test.Name, leftSeparation: nextLevelOfDepth);
                    totalNumberOfSuccessTests++;
                    context.AfterEach.Invoke();
                }
                catch (Exception e)
                {
                    writter.WriteFailTest(text: test.Name, errorMessage: e.Message, leftSeparation: nextLevelOfDepth);
                    totalNumberOfFailTests++;
                }
            }
            context.AfterAll.Invoke();
        }
    }
}