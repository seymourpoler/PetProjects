using LanguageExt;

namespace TSharp;

public static class ArgumentsParser
{
    public static Either<Error, ArgumentsParsedResult> Parse(string[] arguments)
    {
        if (arguments == null || arguments.Length == 0 || string.IsNullOrWhiteSpace(arguments.First()))
        {
            return new Error("No arguments provided.");
        }

        return new ArgumentsParsedResult(arguments.First());
    } 
}