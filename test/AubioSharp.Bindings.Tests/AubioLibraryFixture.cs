using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace AubioSharp.Bindings.Tests;

[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
public sealed class AubioLibraryFixture : IDisposable
{
    public nint Handle { get; } = NativeLibrary.Load("aubio");

    public void Dispose()
    {
        NativeLibrary.Free(Handle);
    }
}
