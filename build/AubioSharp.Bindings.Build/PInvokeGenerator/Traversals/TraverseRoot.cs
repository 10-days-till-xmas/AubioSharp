using System.Collections.Immutable;

namespace AubioSharp.Bindings.Build.PInvokeGenerator.Traversals;

public sealed class TraverseRoot : HeaderConvertConfig
{
    public override string? SubDirectory => null;

    public override ImmutableArray<string> HeadersToTraverse { get; } =
    [
        "fvec", "cvec", "fmat", "lvec",
        "mathutils", "musicutils", "vecutils"
    ];

    public override ImmutableArray<string> ContainedTypes { get; } =
        ["fvec_t", "cvec_t", "fmat_t", "lvec_t"];
}