using System.Collections.Immutable;

namespace AubioSharp.Bindings.Build.PInvokeGenerator.Traversals;

public sealed class TraversePitch
    : HeaderConvertConfig
{
    public override string SubDirectory => "Pitch";

    public override ImmutableArray<string> HeadersToTraverse { get; } =
    [
        "pitch",
        "pitchfcomb",
        "pitchmcomb",
        "pitchschmitt",
        "pitchscpecacf",
        "pitchyin",
        "pitchyinfast",
        "pitchyinfft"
    ];

    public override ImmutableArray<string> ContainedTypes { get; } =
    [
        "_aubio_pitch_t",
        "_aubio_pitchfcomb_t",
        "_aubio_pitchmcomb_t",
        "_aubio_pitchschmitt_t",
        "_aubio_pitchspecacf_t",
        "_aubio_pitchyin_t",
        "_aubio_pitchyinfast_t",
        "_aubio_pitchyinfft_t"
        
    ];
}