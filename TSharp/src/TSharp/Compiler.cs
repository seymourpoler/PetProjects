using LanguageExt;
using TSharp.Lex;
using TSharp.Parse;
using TSharp.CommonIntermediateLanguage;

namespace TSharp;

public class Compiler(Tokenizer tokenizer, Parser parser, IntermediateLanguageEmitter intermediateLanguageEmitter)
{
    public async Task<Either<Error, Unit>> Compile()
    {
        var result = await (
            from tokens in tokenizer.Tokenize().ToAsync()
            from syntax in parser.Parse(tokens).ToAsync()
            from pp in intermediateLanguageEmitter.Emit(syntax).ToAsync()
            select pp
        );
        // var abstractSyntaxTree = parser.Parse(tokens);
        
        throw new NotImplementedException();
    }
}