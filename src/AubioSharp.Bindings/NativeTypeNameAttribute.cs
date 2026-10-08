using System;

namespace AubioSharp.Bindings;

public sealed class NativeTypeNameAttribute(string typeName) : Attribute
{
    public string TypeName { get; } = typeName;
}
