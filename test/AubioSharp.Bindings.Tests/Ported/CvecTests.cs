using AubioSharp.Bindings.Generated;

namespace AubioSharp.Bindings.Tests.Ported;

public sealed class CvecTests
{
    [Fact]
    public unsafe void Main()
    {
        var windowSize = 16u;
        var complexVector = CvecMethods.new_cvec(windowSize);
        var otherCvector = CvecMethods.new_cvec(windowSize);

        Assert.True(CvecMethods.cvec_norm_get_data(complexVector) == complexVector->norm);
        Assert.True(CvecMethods.cvec_phas_get_data(complexVector) == complexVector->phas);
        Assert.True(complexVector->length == (windowSize / 2) + 1);

        // all elements are initialized to 0
        for (var i = 0; i < complexVector->length; i++)
        {
            Assert.Equal(expected: 0f, complexVector->norm[i]);
            Assert.Equal(expected: 0f, complexVector->phas[i]);
        }

        CvecMethods.cvec_norm_set_sample(complexVector, val: 2, position: 1);
        Assert.Equal(expected: 2, CvecMethods.cvec_norm_get_sample(complexVector, position: 1));

        CvecMethods.cvec_phas_set_sample(complexVector, val: 2, position: 1);
        Assert.Equal(expected: 2, CvecMethods.cvec_phas_get_sample(complexVector, position: 1));

        CvecMethods.cvec_print(complexVector);

        // set all norm and phas elements to 0
        CvecMethods.cvec_zeros(complexVector);
        for (var i = 0; i < complexVector->length; i++)
        {
            Assert.Equal(0, complexVector->norm[i]);
            Assert.Equal(0, complexVector->phas[i]);
        }

        // set all norm elements to 1
        CvecMethods.cvec_norm_ones(complexVector);
        for (var i = 0; i < complexVector->length; i++)
            Assert.Equal(1, complexVector->norm[i]);

        // set all norm elements to 0
        CvecMethods.cvec_norm_zeros(complexVector);
        for (var i = 0; i < complexVector->length; i++)
            Assert.Equal(expected: 0, complexVector->norm[i]);

        // set all phas elements to 1
        CvecMethods.cvec_phas_ones(complexVector);
        for (var i = 0; i < complexVector->length; i++)
            Assert.Equal(expected: 1, complexVector->phas[i]);

        // set all phas elements to 0
        CvecMethods.cvec_phas_zeros(complexVector);
        for (var i = 0; i < complexVector->length; i++) Assert.Equal(expected: 0, complexVector->phas[i]);

        CvecMethods.cvec_copy(complexVector, otherCvector);
        // copy to self
        CvecMethods.cvec_copy(complexVector, complexVector);
        // copy to a different size fails
        CvecMethods.del_cvec(otherCvector);
        otherCvector = CvecMethods.new_cvec(windowSize + 2);
        CvecMethods.cvec_copy(complexVector, otherCvector);

        if (complexVector == null)
            CvecMethods.del_cvec(complexVector);
        if (otherCvector == null)
            CvecMethods.del_cvec(otherCvector);

        // wrong parameters
        unchecked { Assert.Null(CvecMethods.new_cvec((uint)-1)); }

        Assert.Null(CvecMethods.new_cvec(length: 0));
    }
}
