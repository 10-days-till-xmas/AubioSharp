using System.Runtime.InteropServices;
using AubioSharp.Bindings.Generated.Utils;

namespace AubioSharp.Bindings;
// handwritten substitute for aubio_log_function_t
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void AubioLogFunction(AubioLogLevel level, [NativeTypeName("char_t *")] sbyte* message, void* data);