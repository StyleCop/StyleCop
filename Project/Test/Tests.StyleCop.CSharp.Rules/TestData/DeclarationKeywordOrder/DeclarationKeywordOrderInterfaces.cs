using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    interface ValidInterface1
    {
    }

    public interface ValidInterface2
    {
    }

    internal interface ValidInterface3
    {
    }

    protected interface ValidInterface4
    {
    }

    protected internal interface ValidInterface5
    {
    }

    private interface ValidInterface6
    {
    }

    new interface ValidInterface31
    {
    }

    public new interface ValidInterface32
    {
    }

    internal new interface ValidInterface33
    {
    }

    protected new interface ValidInterface34
    {
    }

    protected internal new interface ValidInterface35
    {
    }

    private new interface ValidInterface36
    {
    }

    // Invalid Interfaces.
    internal protected interface InvalidInterface1
    {
    }

    new public interface InvalidInterface36
    {
    }

    new internal interface InvalidInterface37
    {
    }

    new protected interface InvalidInterface38
    {
    }

    new protected internal interface InvalidInterface39
    {
    }

    new internal protected interface InvalidInterface40
    {
    }

    protected new internal interface InvalidInterface41
    {
    }

    internal new protected interface InvalidInterface42
    {
    }

    internal protected new interface InvalidInterface43
    {
    }

    new private interface InvalidInterface44
    {
    }
}
