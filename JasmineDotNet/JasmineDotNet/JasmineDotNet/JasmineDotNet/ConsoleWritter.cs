using System;

namespace JasmineDotNet
{
    public class ConsoleWritter: IWritter
    {
        public void WriteSuite(string text, int leftSeparation = 0)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            WriteLeftSeparation(leftSeparation);
            Console.WriteLine(text);
        }

        public void WriteSucessTest(string text, int leftSeparation = 0)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            WriteLeftSeparation(leftSeparation);
            Console.WriteLine(text);
        }

        public void WriteFailTest(string text, string errorMessage, int leftSeparation = 0)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            WriteLeftSeparation(leftSeparation);
            Console.WriteLine(text);
            Console.WriteLine("errorMessage: " + errorMessage);
        }

        public void WriteNumberOfTest(int success, int fail)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            var message = $"Total tests: { success + fail}, success: {success}, fail: {fail}";
            Console.WriteLine(message);
        }

        static void WriteLeftSeparation(int separation)
        {
            for (var i = 0; i < separation; i++)
            {
                Console.Write(" ");
            }
        }
    }
}