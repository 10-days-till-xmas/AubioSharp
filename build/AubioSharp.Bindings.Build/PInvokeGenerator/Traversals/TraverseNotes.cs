using System.Collections.Immutable;

namespace AubioSharp.Bindings.Build.PInvokeGenerator.Traversals;

public sealed class TraverseNotes : HeaderConvertConfig
{
    public override string SubDirectory => "Notes";

    public override ImmutableArray<string> HeadersToTraverse { get; } =
    [
        "notes"
    ];

    public override ImmutableArray<string> ContainedTypes { get; } =
    [
        "_aubio_notes_t",
    ];
}