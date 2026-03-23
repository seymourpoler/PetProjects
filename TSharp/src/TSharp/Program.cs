using LanguageExt;
using Microsoft.Extensions.DependencyInjection;
using TSharp.Lex;
using TSharp.Parse;

namespace TSharp;

public class Program
{
    public static async Task Main(string[] args)
    {
        _ = await (
            from argumentParsed in ArgumentsParser.Parse(args).ToAsync()
            from compilerCreated in CreateCompiler(argumentParsed.fileName).ToAsync()
            select compilerCreated
        ).Match(
            Right: compiler => compiler.Compile(),
            Left: error =>
            {
                Console.WriteLine($"Error: {error.Message}");
                Environment.Exit(1);
                return null; // This line will never be reached, but is required to satisfy the return type.
            }
        );
    }

    private static Either<Error, Compiler> CreateCompiler(string filePath)
    {
        var services = new ServiceCollection();
        services.AddSingleton<Compiler>();
        services.AddSingleton<Tokenizer>();
        services.AddSingleton<Parser>();
        services.AddSingleton<FileReader>();
        services.AddSingleton<IO>(_ => new IO(filePath));
		
        using var serviceProvider = services.BuildServiceProvider();
        return serviceProvider.GetRequiredService<Compiler>();
    }
}