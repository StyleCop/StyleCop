#region Normal Constructors
public class Class1
{
    Class1()
    {
    }

    Class1(int x)
    {
    }

    Class1(int[][] x, ref string y)
    {
    }

    Class1(short? @class, out string y)
    {
    }

    Class1(int x, params object[] items)
    {
        x = 0;
    }
}
#endregion

#region Constructors with initializers
public class Class2
{
    Class2(int x) : this()
    {
    }

    Class2(short x) : base()
    {
    }

    Class2(long x) : this(Something.Value, 2, "string")
    {
    }

    Class2(int x, int y) : base(32, true, false)
    {
    }
}
#endregion

#region Constructors with access modifiers

public class Class3
{
    public Class3(int x) { }
    internal Class3(long x) { }
    protected Class3(short x) { }
    protected internal Class3(double x) { }
    internal protected Class3(float x) { }
    private Class3(string x) { }
}

#endregion

#region Constructors with other modifiers

public class Class4
{
    public unsafe Class4(int** x) 
    {
        short y = 2;
        &y = 4;
    }

    public static Class4()
    {
    }

    public extern Class4(int x);
}

public unsafe class UnsafeClass
{
    public UnsafeClass(int** x) 
    {
        short y = 2;
        &y = 4;
    }
}

#endregion 

#region Constructors with sttributes and headers

public class Class5
{
    [Attribute1(false), System.Attribute2(true, 2)]
    [Attribute3]
    public Class5(int x) 
    {
    }

    /// <summary>
    /// A header.
    /// </summary>
    /// <param name="x">A parameter.</param>
    // Comment
    public Class5(long x) 
    {
    }

    /// <summary>
    /// A header.
    /// </summary>
    /// <param name="x">A parameter.</param>
    [Attribute1(false), System.Attribute2(true, 2)]
    [Attribute3]
    public Class5(short x) 
    {
    }
}

#endregion

#region Constructors in Structs
public struct Struct1
{
    public Struct1(int x) 
    {
    }
}
#endregion 