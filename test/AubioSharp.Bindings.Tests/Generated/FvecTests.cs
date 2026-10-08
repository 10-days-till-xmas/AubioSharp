// aubio is free software: you can redistribute it and/or modify it under the
// terms of the GNU General Public License as published by the Free Software
// Foundation, either version 3 of the License, or (at your option) any later
// version.

using System;
using System.Runtime.InteropServices;
using Xunit;

namespace AubioSharp.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="Fvec" /> struct.</summary>
public static unsafe partial class FvecTests
{
    /// <summary>Validates that the <see cref="Fvec" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(Fvec), Marshal.SizeOf<Fvec>());
    }

    /// <summary>Validates that the <see cref="Fvec" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(Fvec).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="Fvec" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(16, sizeof(Fvec));
        }
        else
        {
            Assert.Equal(8, sizeof(Fvec));
        }
    }
}
