using System.CodeDom.Compiler;
using System.Reflection;
using System.Runtime.InteropServices;

namespace AubioSharp.Bindings.Tests;

public sealed class PInvokeExtractTests(AubioLibraryFixture aubioLibHandle) : IClassFixture<AubioLibraryFixture>
{
    public static readonly TheoryData<string> MethodNames =
    [
        .. from type in typeof(NativeTypeNameAttribute).Assembly.GetTypes()
           where type.GetCustomAttribute<GeneratedCodeAttribute>() is { Tool: "ClangSharp" }
           from method in type.GetMethods()
           where method.IsStatic
           where method.Attributes.HasFlag(MethodAttributes.PinvokeImpl)
           let attr = method.GetCustomAttribute<DllImportAttribute>()
           where attr is { Value: "aubio" }
           select attr.EntryPoint ?? method.Name
    ];

    [Theory]
    [MemberData(nameof(MethodNames))]
    public void VerifyFunctionPresenceInDll(string funcName)
    {
        Assert.True(NativeLibrary.TryGetExport(aubioLibHandle.Handle, funcName, out _));
    }
}