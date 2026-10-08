using System.Collections.Immutable;

namespace AubioSharp.Bindings.Build.PInvokeGenerator.Traversals;

public sealed class TraverseEffects : HeaderConvertConfig
{
    public override string SubDirectory => "Effects";

    public override ImmutableArray<string> HeadersToTraverse { get; } =
    [
        "pitchshift",
        "timestretch"
    ];

    public override ImmutableArray<string> ContainedTypes { get; } =
    [
        "_aubio_pitchshift_t",
        "_aubio_timestretch_t"
    ];
}