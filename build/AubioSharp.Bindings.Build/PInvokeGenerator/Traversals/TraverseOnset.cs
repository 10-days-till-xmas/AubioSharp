using System.Collections.Immutable;

namespace AubioSharp.Bindings.Build.PInvokeGenerator.Traversals;

public sealed class TraverseOnset
    : HeaderConvertConfig
{
    public override string SubDirectory => "Onset";

    public override ImmutableArray<string> HeadersToTraverse { get; } =
    [
        "onset",
        "peakpicker"
    ];

    public override ImmutableArray<string> ContainedTypes { get; } =
    [
        "_aubio_onset_t",
        "_aubio_peakpicker_t"
    ];
}