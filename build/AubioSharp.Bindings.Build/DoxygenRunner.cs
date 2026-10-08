namespace AubioSharp.Bindings.Build;

public static class DoxygenRunner
{
    private const string DoxygenToolPackageId = "DemaConsulting.DoxygenTool";

    private static readonly FilePath DoxygenConfig =
        File("../src/AubioSharp.Bindings/GeneratorScripts/Doxyfile")
           .Path
           .MakeAbsolute(Context.Environment).FullPath;

    public static void GenerateDocs()
    {
        Information($"{DoxygenConfig}");
        Context.DotNetToolExecute(DoxygenToolPackageId, new DotNetToolExecuteSettings
        {
            ArgumentCustomization = static args =>
                args.AppendQuoted(DoxygenConfig.FullPath)
        });
    }
}
