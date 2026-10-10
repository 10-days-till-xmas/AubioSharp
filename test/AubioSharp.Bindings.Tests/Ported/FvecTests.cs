using AubioSharp.Bindings.Generated;

namespace AubioSharp.Bindings.Tests;

public sealed unsafe class FvecTests
{
    private static void AssertAllEqual(Fvec* a, float f)
    {
        for (var i = 0; i < a->length; i++)
            Assert.Equal(a->data[i], f);
    }

    [Fact]
    public void Main()
    {
        const uint length = 10;
        uint i;
        var vec = FvecMethods.new_fvec(length);
        var otherVec = FvecMethods.new_fvec(length);

        Assert.NotNull(vec);
        Assert.NotNull(otherVec);

        // vec->length matches requested size
        Assert.True(vec->length == length);

        // all elements are initialized to `0.`
        AssertAllEqual(vec, 0f);

        // all elements can be set to `1.`
        FvecMethods.fvec_ones(vec);
        AssertAllEqual(vec, 1f);

        // all elements can be set to `0.`
        FvecMethods.fvec_zeros(vec);
        AssertAllEqual(vec, 0f);

        // each element can be accessed directly
        for (i = 0; i < vec->length; i++)
        {
            vec->data[i] = i;
            Assert.Equal(i, vec->data[i]);
        }

        FvecMethods.fvec_print(vec);

        FvecMethods.fvec_set_sample(vec, 3, 2);
        // ReSharper disable once CompareOfFloatsByEqualityOperator
        Assert.Equal(3, FvecMethods.fvec_get_sample(vec, 2));

        Assert.True(FvecMethods.fvec_get_data(vec) == vec->data);

        // wrong parameters
        Assert.Null(FvecMethods.new_fvec(unchecked((uint)-1)));

        // copy to an identical size works
        FvecMethods.fvec_copy(vec, otherVec);
        FvecMethods.del_fvec(otherVec);

        // copy to a different size fail
        otherVec = FvecMethods.new_fvec(length + 1);
        FvecMethods.fvec_copy(vec, otherVec);
        FvecMethods.del_fvec(otherVec);

        // copy to a different size fail
        otherVec = FvecMethods.new_fvec(length - 1);
        FvecMethods.fvec_copy(vec, otherVec);

        // now destroys the vector
        if (vec != (Fvec*)IntPtr.Zero)
            FvecMethods.del_fvec(vec);
        if (otherVec != (Fvec*)IntPtr.Zero)
            FvecMethods.del_fvec(otherVec);
    }
}
