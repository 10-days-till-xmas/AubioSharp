using System.Collections.Immutable;

namespace AubioSharp.Bindings.Build.PInvokeGenerator.Traversals;

public sealed class TraverseTempo
    : HeaderConvertConfig
{
    public override string SubDirectory => "Tempo";

    public override ImmutableArray<string> HeadersToTraverse { get; } =
    [
        "beattracking",
        "tempo"
    ];

    public override ImmutableArray<string> ContainedTypes { get; } =
    [
        "_aubio_beattracking_t",
        "_aubio_tempo_t"
    ];
}