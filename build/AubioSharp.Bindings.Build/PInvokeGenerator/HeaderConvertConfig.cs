// ReSharper disable ReturnTypeCanBeEnumerable.Global I want explicit 

using System.Collections.Immutable;

namespace AubioSharp.Bindings.Build.PInvokeGenerator;

public abstract class HeaderConvertConfig
{
    public abstract string? SubDirectory { get; }
    public abstract ImmutableArray<string> HeadersToTraverse { get; }
    public abstract ImmutableArray<string> ContainedTypes { get; }
    public virtual ImmutableArray<string> ExcludedTypes { get; } = ImmutableArray<string>.Empty;

    public static string CNameToCSharpName(ReadOnlySpan<char> name)
    {
        var enumerator = name.Split(['_']);
        var result = new StringBuilder();
        foreach (var range in enumerator)
        {
            var part = name[range];
            if (part is "t") continue;
            if (part.Length == 0) continue;

            result.Append(char.ToUpper(part[0]));
            result.Append(part[1..]);
        }

        return result.ToString();
    }
}
