using System.Collections.Immutable;

namespace AubioSharp.Bindings.Build.PInvokeGenerator.Traversals;

public sealed class TraverseSynth
    : HeaderConvertConfig
{
    public override string SubDirectory => "Synth";

    public override ImmutableArray<string> HeadersToTraverse { get; } =
    [
        "sampler",
        "wavetable"
    ];

    public override ImmutableArray<string> ContainedTypes { get; } =
    [
        "_aubio_sampler_t",
        "_aubio_wavetable_t"
    ];
}