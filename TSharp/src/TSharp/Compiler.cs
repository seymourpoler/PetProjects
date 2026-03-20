using LanguageExt;
using TSharp.Lexer;

namespace TSharp;

public class Compiler(Tokenizer tokenizer, Parser.Parser parser)
{
    public async Task<Either<Error, Unit>> Compile()
    {
        var tokens = tokenizer.Tokenize();
        var abstractSyntaxTree = parser.Parse(tokens);
        
        throw new NotImplementedException();
    }
}