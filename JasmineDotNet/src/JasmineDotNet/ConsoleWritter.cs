using System;

namespace JasmineDotNet
{
    public class ConsoleWritter : IWritter
    {
        public void WriteSuite(string text, int leftSeparation = 0)
        {
            WriteLeftSeparation(leftSeparation);
            WriteWhite(text);
            Console.WriteLine();
        }

        public void WriteSucessTest(string text, int leftSeparation = 0)
        {
            WriteLeftSeparation(leftSeparation);
            WriteGreen(text);
            Console.WriteLine();
        }

        public void WriteFailTest(string text, string errorMessage, int leftSeparation = 0)
        {
            WriteLeftSeparation(leftSeparation);
            WriteRed(text);
            Console.WriteLine();
            WriteLeftSeparation(leftSeparation);
            WriteRed("errorMessage: " + errorMessage);
            Console.WriteLine();
        }

        public void WriteNumberOfTest(int success, int fail)
        {
            Console.WriteLine();
            Console.WriteLine();
            WriteWhite($"Total tests: {success + fail}");
            WriteWhite(",");
            WriteGreen($" success: {success}");
            WriteWhite(",");
            WriteRed($" fail: {fail}");
            Console.WriteLine();
        }

        void WriteWhite(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
        }
        
        void WriteGreen(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(message);
        }
        
        void WriteRed(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(message);
        }

        static void WriteLeftSeparation(int separation)
        {
            var leftSeparation = separation * 2;
            for (var i = 0; i < leftSeparation; i++)
            {
                Console.Write(" ");
            }
        }
    }
}