using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;

namespace TSharp.Emit;

public class FileWriter(string filePath)
{
    private const string assemblyName = "test";
    
    public virtual void Write(string content)
    {
        var assemblyBuilder = new PersistedAssemblyBuilder(
            new AssemblyName(assemblyName),
            typeof(object).Assembly
        );
        var  metadataBuilder = assemblyBuilder.GenerateMetadata(
            out BlobBuilder ilStream,
            out BlobBuilder fieldData);
        var moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName);
        var programType = moduleBuilder.DefineType(
            "$Program",
            TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.Sealed
        );
        var entryPoint = programType.DefineMethod(
            "Main",
            MethodAttributes.Public | MethodAttributes.Static,
            typeof(void),
            Type.EmptyTypes
        );
        
        // Create an executable with entry point
        var peHeader = PEHeaderBuilder.CreateExecutableHeader();

        ManagedPEBuilder peBuilder = new(
            header: peHeader,
            metadataRootBuilder: new MetadataRootBuilder(metadataBuilder),
            ilStream: ilStream,
            mappedFieldData: fieldData,
            entryPoint: MetadataTokens.MethodDefinitionHandle(entryPoint.MetadataToken)
        );

        BlobBuilder peBlob = new();
        peBuilder.Serialize(peBlob);

        // Write the executable
        using FileStream fileStream = new(filePath, FileMode.Create, FileAccess.Write);
        peBlob.WriteContentTo(fileStream);
    }
}