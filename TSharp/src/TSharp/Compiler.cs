using LanguageExt;
using TSharp.Emit;
using TSharp.Lex;
using TSharp.Parse;

namespace TSharp;

public class Compiler(Tokenizer tokenizer, Parser parser, CommonIntermediateLanguageEmitter commonIntermediateLanguageEmitter)
{
    public async Task<Either<Error, Unit>> Compile()
    {
        var result = await (
            from tokens in tokenizer.Tokenize().ToAsync()
            from syntax in parser.Parse(tokens).ToAsync()
            from pp in commonIntermediateLanguageEmitter.Emit(syntax).ToAsync()
            select pp
        );
        // var abstractSyntaxTree = parser.Parse(tokens);
        
        throw new NotImplementedException();
    }
}