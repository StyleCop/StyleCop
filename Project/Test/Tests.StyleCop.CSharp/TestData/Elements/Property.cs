#region Normal Properties
public class Class1
{
    bool Property1
    {
        get
        {
            return true;
        }
    }

    bool Property2
    {
        set
        {
        }
    }

    bool Property3
    {
        get
        {
            return false;
        }
        set { int x = value; }
    }
}
#endregion

#region Properties with access modifiers

public class Class3
{
    public bool PropertyWithAccessModifier1 { get { return true; } }
    internal bool PropertyWithAccessModifier2 { get { return true; } }
    protected bool PropertyWithAccessModifier3 { get { return true; } }
    protected internal bool PropertyWithAccessModifier4 { get { return true; } }
    internal protected bool PropertyWithAccessModifier5 { get { return true; } }
    private bool PropertyWithAccessModifier6 { get { return true; } }

    public bool PropertyWithAccessModifier7
    {
        get { return true; }
        internal set { }
    }

    protected bool PropertyWithAccessModifier8
    {
        get { return true; }
        internal set { }
    }

    public bool PropertyWithAccessModifier9
    {
        get { return true; }
        protected internal set { }
    }


    public bool PropertyWithAccessModifier10
    {
        get { return true; }
        internal protected set { }
    }

    internal bool PropertyWithAccessModifier11
    {
        get { return true; }
        private set { }
    }
}

#endregion

#region Properties with other modifiers

public abstract class Class4
{
    public new bool PropertyWithNewModifier
    {
        get { return true; }
    }

    public unsafe short* PropertyWithUnsafeModifier2
    {
        get
        {
            short y = 2;
            return &x;
        }
    }

    public static int PropertyWithStaticModifier
    {
        set { }
    }

    public virtual string PropertyWithVirtualModifier
    {
        get { return ""; }
    }

    public sealed string PropertyWithSealedModifier
    {
        get { return @"hello"; }
    }

    public override void PropertyWithOverrideModifier
    {
        set { }
    }

    public abstract void PropertyWithAbstractModifier { get; set; }

    public extern int PropertyWithExternModifier { set; get; }
}

public unsafe class UnsafeClass
{
    public short* PropertyWithUnsafeModifier2
    {
        get
        {
            short y = 2;
            return &x;
        }
    }
}

#endregion 

#region Properties with sttributes and headers

public class Class5
{
    [Attribute1(false), System.Attribute2(true, 2)]
    [Attribute3]
    public bool PropertyWithAttributes
    {
        [Attribute1(false), System.Attribute2(true, 2)]
        [Attribute3]
        get { return false; }
        [Attribute1(false), System.Attribute2(true, 2)]
        [Attribute3]
        set { }
    }

    /// <summary>
    /// A header.
    /// </summary>
    // Comment
    public bool PropertyWithHeader
    { get { return true; } }

    /// <summary>
    /// A header.
    /// </summary>
    [Attribute1(false), System.Attribute2(true, 2)]
    [Attribute3]
    public void PropertyWithHeaderAndAttributes
    {
        [Attribute1(false), System.Attribute2(true, 2)]
        set { }
    }
}

#endregion

#region Properties in Structs
public struct Struct1
{
    internal int Property1
    {
        get { return 2; }
    }
}
#endregion 

#region Properties in Interfaces
public interface Interface1
{
    int Property1 { set; get; }
}
#endregion

#region Properties initializer and Expression bodied member C# 6

public class ClassPropInit1
{
    public int Property1 { get; set; } = 45;

    public int Property2 { get; set; }
        = 46;

    public int Property3 { get; set; } =
        47;

    public int Property4
    {
        get;
        set;
    }
        =
        48;

    public byte[] Property5 { get; } = { 211, 63, 107, 31, 8, 247, 168, 41, 167, 204, 75, 127, 230, 63, 141, 88 };

    public byte[] Property6 { get; } = { };

    public byte[] Property7 { get; }
        = { };

    public byte[] Property8 {get;}={};

    public byte[] Property9 { get; } = GetValue();

    public byte[] Property10 { get; } = System.DateTime.Now.ToString();

    public byte[] Property11 { get; }
        = System.DateTime.Now.ToString();

    public byte[] Property12 { get; } =
        System.DateTime.Now.ToString();
}

public class ExpressionBodiedMember
{
    public double Distance => Sqrt((y * x) + (y * y));
}

#endregion

#region Ref Returns And Locals

public class RefReturnsAndLocals
{
    private int testValue = 0;

    public ref int TestValue
    {
        get
        {
            return ref testValue;
        }
    }

    public void TestCaller()
    {
        ref int localTestValue = ref TestValue;
    }
}

#endregion