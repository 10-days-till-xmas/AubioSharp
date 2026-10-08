// ReSharper disable HeapView.ImplicitCapture

using AubioSharp.Bindings.Build;
using AubioSharp.Bindings.Build.PInvokeGenerator;

#region Constants

const string projectName = "AubioSharp.Bindings";
var projectDir = Directory($"../src/{projectName}").Path.MakeAbsolute(Context.Environment);
var testDir = Directory($"../test/{projectName}.Tests").Path.MakeAbsolute(Context.Environment);
var defaultAubioSourceDir = Directory(@"D:\source\aubio\src").Path;

#endregion

#region Arguments

var target = Argument("target", "Test");
var configuration = Argument("configuration", "Release");
var aubioSourceDir = Argument("aubio-source", defaultAubioSourceDir);

#endregion

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

#region Generators

Task("TestDoxygen")
   .Does(static () =>
    {
        DoxygenRunner.GenerateDocs();
        Information("done");
    });

Task("CleanGenerated")
   .Does(() =>
    {
        var targetDir = projectDir.Combine("Generated");
        var targetTestDir = testDir.Combine("Generated");
        Information($"Cleaning {targetDir}");
        CleanDirectory(targetDir);
        Information($"Cleaning {targetTestDir}");
        CleanDirectory(targetTestDir);
    });

Task("RunGenerator")
   .IsDependentOn("CleanGenerated")
   .Does(() =>
    {
        GeneratorRunner.Run(projectDir.Combine("GeneratorScripts"), aubioSourceDir);
    });

#endregion

Task("Clean")
   .WithCriteria(static _ => HasArgument("rebuild"))
   .Does(() =>
    {
        CleanDirectory(projectDir.Combine($"bin/{configuration}"));
    });

Task("Build")
   .IsDependentOn("Clean")
   .Does(() => DotNetBuild(projectDir.CombineWithFilePath($"{projectName}.csproj").FullPath, new DotNetBuildSettings
    {
        Configuration = configuration
    }));

Task("Test")
   .IsDependentOn("Build")
   .Does(() => DotNetTest(testDir.FullPath));

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);