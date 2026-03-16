using LanguageExt;

namespace TSharp;

public class Compiler(Tokenizer tokenizer)
{
    public async Task<Either<Error, Unit>> Compile()
    {
        var tokens = tokenizer.Tokenize();
        throw new NotImplementedException();
    }
}