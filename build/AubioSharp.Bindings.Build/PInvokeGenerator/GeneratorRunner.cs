using AubioSharp.Bindings.Build.PInvokeGenerator.Traversals;

namespace AubioSharp.Bindings.Build.PInvokeGenerator;

public static class GeneratorRunner
{
    private const string GeneratorToolPackageId = "clangsharppinvokegenerator";

    public static readonly HeaderConvertConfig[] Configs =
    [
        new TraverseRoot(),
        new TraverseIo(),
        new TraverseEffects(),
        new TraverseUtils(),
        new TraverseNotes(),
        new TraverseOnset(),
        new TraversePitch(),
        new TraverseSpectral(),
        new TraverseSynth(),
        new TraverseTempo(),
        new TraverseTemporal()
    ];

    public static void Run(DirectoryPath workingDirectory, DirectoryPath aubioSourceDirectory)
    {
        foreach (var config in Configs)
            ExecuteFolder(config, workingDirectory, aubioSourceDirectory);
    }

    private static void ExecuteFolder(HeaderConvertConfig config,
        DirectoryPath workingDirectory, DirectoryPath aubioSourceDirectory)
    {
        var dir = config.SubDirectory is null ? "" : '/' + config.SubDirectory;
        var ns = config.SubDirectory is null ? "" : '.' + config.SubDirectory;
        Context.DotNetToolExecute(GeneratorToolPackageId, new DotNetToolExecuteSettings
        {
            WorkingDirectory = workingDirectory,
            ArgumentCustomization = args =>
            {
                args.AddBaseArgs()
                    .AddStripBaseTypeNames()
                     //.RemapOverrides()
                    .AppendSwitch("--generate", "tests-xunit")
                    .AppendSwitch("--namespace", $"AubioSharp.Bindings.Generated{ns}")
                    .AppendSwitch("--output", $"../Generated{dir}")
                    .Traverse(config, aubioSourceDirectory);
                if (config is TraverseIo)
                    args.AppendSwitch("--traverse",
                        aubioSourceDirectory.Combine("io")
                                            .CombineWithFilePath("sink.c")
                                            .FullPath);
                args.AppendSwitch("--remap-type", "aubio_log_function_t=AubioLogFunction");
                foreach (var cfg in Configs)
                    args.Remap(cfg);
                args.AppendSwitch("--language", "c")
                    .AppendSwitch("--test-output",
                         $"../../../test/AubioSharp.Bindings.Tests/Generated{dir}");
                return args;
            }
        });
    }

    private static readonly string[] NativeNamesToStrip =
        ["uint_t", "smpl_t", "lsmp_t", "sint_t"];

    extension(ProcessArgumentBuilder args)
    {
        public ProcessArgumentBuilder AddBaseArgs() =>
            args
               .AppendSwitch("--log", string.Join(' ',
                    //"potential-typedef-remappings",
                    "exclusions"))
               .AppendSwitch("--config",
                    "file=multi " +
                    "codegen=latest " +
                    "types=windows")
               .AppendSwitch("--define-macro", "AUBIO_UNSTABLE")
               .AppendSwitch("--generate",
                    "doc-includes=true " +
                    "native-bitfield-attribute=true " +
                    "file-scoped-namespaces " +
                    "tests-xunit " +
                    "generated-code=type")
               .AppendSwitch("--header-file",
                    "../Aubio-LICENSE.txt")
               .AppendSwitch("--file",
                    @"D:\source\aubio\src\aubio.h")
               .AppendSwitch("--library-path",
                    "aubio");

        public ProcessArgumentBuilder AddStripBaseTypeNames()
        {
            if (NativeNamesToStrip.Length == 0) return args;

            args.Append("--native-type-names-to-strip");

            foreach (var name in NativeNamesToStrip)
                args.AppendQuoted($"const {name} *")
                    .AppendQuoted($"{name} **")
                    .AppendQuoted($"{name} *")
                    .Append(name);

            return args;
        }

        public ProcessArgumentBuilder Traverse(HeaderConvertConfig config, DirectoryPath aubioSourceDir)
        {
            if (config.SubDirectory is not null)
                aubioSourceDir = aubioSourceDir.Combine(config.SubDirectory);
            foreach (var header in config.HeadersToTraverse)
            {
                var hPath = aubioSourceDir.CombineWithFilePath($"{header}.h");
                args.AppendSwitch("--traverse", hPath.FullPath);
            }

            return args;
        }

        public ProcessArgumentBuilder Remap(HeaderConvertConfig config)
        {
            foreach (var typeName in config.ContainedTypes)
            {
                var csharpName = HeaderConvertConfig.CNameToCSharpName(typeName);
                args.AppendSwitch("--remap-type", $"{typeName}={csharpName}");
                var pubTypeName = typeName.TrimStart('_');
                var name = pubTypeName[^2..] == "_t" ? pubTypeName[..^2] : pubTypeName;
                var methodsClassName = $"{csharpName}Methods";

                args.Append("--with-class")
                    .Append($"{name}_*={methodsClassName}")
                    .Append($"new_{name}={methodsClassName}")
                    .Append($"del_{name}={methodsClassName}");

                args.Append("--native-type-names-to-strip")
                    .AppendQuoted($"const {pubTypeName} *")
                    .AppendQuoted($"{pubTypeName} *");
            }

            return args;
        }

        public ProcessArgumentBuilder RemapOverrides()
        {
            args.AppendSwitch("--remap-type", "aubio_log_level=AubioLogLevel");
            return args;
        }
    }
}