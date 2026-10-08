using System.Collections.Immutable;

namespace AubioSharp.Bindings.Build.PInvokeGenerator;

public sealed class TraverseEffects : HeaderConvertConfig
{
    public override string? SubDirectory => "Effects";

    public override ImmutableArray<string> HeadersToTraverse { get; } = [
        "pitchshift",
        "timestretch"
    ];

    public override ImmutableArray<string> ContainedTypes { get; } = [
        "_aubio_pitchshift_t",
        "_aubio_timestretch_t"
    ];
}

public sealed class TraverseUtils : HeaderConvertConfig
{
    public override string SubDirectory => "Utils";

    public override ImmutableArray<string> HeadersToTraverse { get; } = [
        "hist",
        "log",
        "parameter",
        "scale"
    ];

    public override ImmutableArray<string> ContainedTypes { get; } = [
        "_aubio_hist_t",
        "_aubio_parameter_t",
        "_aubio_scale_t",
        "aubio_log_level"
    ];
}
