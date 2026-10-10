# AubioSharp

## AubioSharp.Bindings
.NET bindings for [Aubio](https://github.com/aubio/aubio), for usage via P/Invoke

## AubioSharp.Bindings.Build
Build scripts for generating the bindings via [ClangSharpPInvokeGenerator](https://github.com/dotnet/ClangSharp)

## AubioSharp (planned)
C# fully managed port of [Aubio](https://github.com/aubio/aubio), modified for 
maximum ease of use within the .NET ecosystem

---

### AubioSharp.Bindings.Build arguments
- `--target`: the target task to run
- `--configuration`: the target build configuration
- `--aubio-source`: path to the aubio headers source directory
#### Tasks
- `RunDoxygen` - generates the documentation from the headers (Not yet implemented)
- `CleanGenerated` - cleans the directories for generated outputs
- `RunGenerator` - generates the bindings
- `Clean` - cleans the build output directories
- `Build` - builds the project
- `Test` - runs the unit tests
- `GenerateAndTest`