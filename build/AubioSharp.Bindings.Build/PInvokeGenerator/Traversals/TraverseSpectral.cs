using System.Collections.Immutable;

namespace AubioSharp.Bindings.Build.PInvokeGenerator.Traversals;

public sealed class TraverseSpectral
    : HeaderConvertConfig
{
    public override string SubDirectory => "Spectral";

    public override ImmutableArray<string> HeadersToTraverse { get; } =
    [
        "awhitening",
        "dct",
        "fft",
        "filterbank",
        "filterbank_mel",
        "mfcc",
        "phasevoc",
        "specdesc",
        "tss"
    ];

    public override ImmutableArray<string> ContainedTypes { get; } =
    [
        "_aubio_spectral_whitening_t",
        "_aubio_dct_t",
        "_aubio_fft_t",
        "_aubio_filterbank_t",
        "_aubio_mfcc_t",
        "_aubio_pvoc_t",
        "_aubio_specdesc_t",
        "_aubio_tss_t"
    ];
}