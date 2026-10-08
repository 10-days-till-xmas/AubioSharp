using System.Collections.Immutable;

namespace AubioSharp.Bindings.Build.PInvokeGenerator.Traversals;

public sealed class TraverseIo : HeaderConvertConfig
{
    public override string SubDirectory => "Io";

    public override ImmutableArray<string> HeadersToTraverse { get; } =
    [
        //"audio_unit",
        "ioutils",
        "sink",
        //"sink_apple_audio",
        //"sink_sndfile",
        //"sink_wavwrite",
        "source",
        //"source_apple_audio",
        //"source_avcodec",
        //"source_sndfile",
        //"source_waveread"
    ];

    public override ImmutableArray<string> ContainedTypes { get; } = ["_aubio_sink_t", "_aubio_source_t"];
}