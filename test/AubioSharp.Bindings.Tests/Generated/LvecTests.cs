// aubio is free software: you can redistribute it and/or modify it under the
// terms of the GNU General Public License as published by the Free Software
// Foundation, either version 3 of the License, or (at your option) any later
// version.

using System;
using System.Runtime.InteropServices;
using Xunit;

namespace AubioSharp.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="Lvec" /> struct.</summary>
public static unsafe partial class LvecTests
{
    /// <summary>Validates that the <see cref="Lvec" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(Lvec), Marshal.SizeOf<Lvec>());
    }

    /// <summary>Validates that the <see cref="Lvec" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(Lvec).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="Lvec" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(16, sizeof(Lvec));
        }
        else
        {
            Assert.Equal(8, sizeof(Lvec));
        }
    }
}
