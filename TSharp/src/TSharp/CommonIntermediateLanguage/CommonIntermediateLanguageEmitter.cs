using LanguageExt;
using TSharp.Parse;

namespace TSharp.CommonIntermediateLanguage;

public class IntermediateLanguageEmitter
{
    public Either<Error, Unit> Emit(List<SyntaxNode> nodes)
    {
        foreach (var node in nodes)
        {
            Emit(node);
        }
       
        return Unit.Default;
    }

    private Either<Error, Unit> Emit(SyntaxNode node)
    {
        switch (node)
        {
            case SyntaxNode.Constant constant:
                if (constant.Value is Expression.Literal literal && int.TryParse(literal.Value, out int intValue))
                {
                    // Use System.Reflection.Emit to create a dynamic method
                    var method = new System.Reflection.Emit.DynamicMethod(
                        "EmitConstInt", // name
                        typeof(int),     // returns int
                        Type.EmptyTypes  // takes no arguments
                    );
                    var il = method.GetILGenerator();
                    il.Emit(System.Reflection.Emit.OpCodes.Ldc_I4, intValue);
                    il.Emit(System.Reflection.Emit.OpCodes.Stloc_0);
                    il.Emit(System.Reflection.Emit.OpCodes.Ldloc_0); // load for return
                    il.Emit(System.Reflection.Emit.OpCodes.Ret);
                    var result = (int)method.Invoke(null, null);
                    System.Console.WriteLine($"Dynamic method executed. {constant.Name.Lexeme} = {result}");
                    return Unit.Default;
                }
                else
                {
                    return new Error($"Only integer literals supported for 'const' emission");
                }
        }
        
        return Unit.Default;
    }
}