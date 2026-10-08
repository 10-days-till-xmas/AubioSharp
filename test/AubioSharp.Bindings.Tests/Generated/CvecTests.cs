// aubio is free software: you can redistribute it and/or modify it under the
// terms of the GNU General Public License as published by the Free Software
// Foundation, either version 3 of the License, or (at your option) any later
// version.

using System;
using System.Runtime.InteropServices;
using Xunit;

namespace AubioSharp.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="Cvec" /> struct.</summary>
public static unsafe partial class CvecTests
{
    /// <summary>Validates that the <see cref="Cvec" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(Cvec), Marshal.SizeOf<Cvec>());
    }

    /// <summary>Validates that the <see cref="Cvec" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(Cvec).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="Cvec" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(24, sizeof(Cvec));
        }
        else
        {
            Assert.Equal(12, sizeof(Cvec));
        }
    }
}
