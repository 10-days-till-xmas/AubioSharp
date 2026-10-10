using System.Collections.Immutable;

namespace AubioSharp.Bindings.Build.PInvokeGenerator.Traversals;

public sealed class TraverseTemporal
    : HeaderConvertConfig
{
    public override string SubDirectory => "Temporal";

    public override ImmutableArray<string> HeadersToTraverse { get; } =
    [
        "a_weighting",
        "biquad",
        "c_weighting",
        "filter",
        "resampler",
    ];

    public override ImmutableArray<string> ContainedTypes { get; } =
    [
        "_aubio_filter_t",
        "_aubio_resampler_t"
    ];
}