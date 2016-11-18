using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    struct ValidStruct1
    {
    }

    public struct ValidStruct2
    {
    }

    internal struct ValidStruct3
    {
    }

    protected struct ValidStruct4
    {
    }

    protected internal struct ValidStruct5
    {
    }

    private struct ValidStruct6
    {
    }

    new struct ValidStruct31
    {
    }

    public new struct ValidStruct32
    {
    }

    internal new struct ValidStruct33
    {
    }

    protected new struct ValidStruct34
    {
    }

    protected internal new struct ValidStruct35
    {
    }

    private new struct ValidStruct36
    {
    }

    // Invalid structs.
    internal protected struct InvalidStruct1
    {
    }

    new public struct InvalidStruct36
    {
    }

    new internal struct InvalidStruct37
    {
    }

    new protected struct InvalidStruct38
    {
    }

    new protected internal struct InvalidStruct39
    {
    }

    new internal protected struct InvalidStruct40
    {
    }

    protected new internal struct InvalidStruct41
    {
    }

    internal new protected struct InvalidStruct42
    {
    }

    internal protected new struct InvalidStruct43
    {
    }

    new private struct InvalidStruct44
    {
    }
}
