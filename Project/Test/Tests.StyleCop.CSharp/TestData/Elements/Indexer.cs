#region Normal Indexers
public class Class1
{
    bool this[int x]
    {
        get { return true; }
    }

    bool this[short x]
    {
        set { int y = x; }
    }

    bool this[long x]
    {
        get { return true; }
        set { int y = x; }
    }

    bool this[int x, params object[] items]
    {
        get { return true; }
    }

    int? this[int? x]
    {
        get { return 1; }
    }

    string[,,,] this[char x]
    {
        get { return null; }
    }

    bool this[int[] x, string[][] y, double[, ,][] z]
    {
        get
        {
            return true;
        }
    }

    bool ISomeInterface.this[bool x]
    {
        get { return true; }
    }
}

#endregion

#region Indexers with access modifiers

public class Class3
{
    public bool this[int x] { get { return true; } }
    internal bool this[short x] { get { return true; } }
    protected bool this[long x] { get { return true; } }
    protected internal bool this[double x] { get { return true; } }
    internal protected bool this[float x] { get { return true; } }
    private bool this[char x] { get { return true; } }

    public bool this[string x] 
    { 
        get { return true; }
        internal set { int y = x; }
    }

    public bool this[object x]
    {
        get { return true; }
        protected set { int y = x; }
    }

    public bool this[byte x]
    {
        get { return true; }
        protected internal set { int y = x; }
    }

    public bool this[int[] x]
    {
        get { return true; }
        internal protected set { int y = x; }
    }

    internal bool this[string[] x]
    {
        get { return true; }
        private set { int y = x; }
    }
}

#endregion

#region Indexers with other modifiers

public abstract class Class4
{
    public new bool this[int x]
    {
        get { return true; }
    }

    public virtual bool this[short x]
    {
        get { return true; }
    }

    public sealed bool this[long x]
    {
        get { return true; }
    }

    public override bool this[float x]
    {
        get { return true; }
    }

    public abstract bool this[double x]
    {
        get;
        set;
    }

    public extern bool this[string x]
    {
        get; set;
    }

    public unsafe short* this[int** x]
    {
        get { return null; }
        set
        {
            short y = 2;
            return &y;
        }
    }
}

public unsafe class UnsafeClass
{
    public short* this[int** x]
    {
        get 
        { 
            return null; 
        }

        set
        {
            short y = 2;
            return &y;
        }
    }
}

#endregion 

#region Indexers with attributes and headers

public class Class5
{
    [Attribute1(false), System.Attribute2(true, 2)]
    [Attribute3]
    public bool this[int x]
    {
        [Attribute1(false), System.Attribute2(true, 2)]
        [Attribute3]
        get { return true; }
        [Attribute1(false), System.Attribute2(true, 2)]
        [Attribute3]
        set { }
    }

    /// <summary>
    /// Header.
    /// </summary>
    /// <param name="x">Something.</param>
    /// <returns>Returns something.</returns>
    public bool this[short x]
    {
        get { return true; }
    }

    /// <summary>
    /// Header.
    /// </summary>
    /// <param name="x">Something.</param>
    /// <returns>Returns something.</returns>
    [Attribute1(false), System.Attribute2(true, 2)]
    [Attribute3]
    public new bool this[long x]
    {
        [Attribute1(false), System.Attribute2(true, 2)]
        [Attribute3]
        get { return true; }
    }

    /// <summary>
    /// Header.
    /// </summary>
    /// <param name="x">Something.</param>
    /// <returns>Returns something.</returns>
    // extra stuff
    [Attribute1(false), System.Attribute2(true, 2)]
    // extra stuff
    [Attribute3]
    // extra stuff
    public new bool this[char x]
    {
        // extra stuff
        [Attribute1(false), System.Attribute2(true, 2)]
        // extra stuff
        [Attribute3]
        // extra stuff
        get { return true; }
        // extra stuff
    }
}

#endregion

#region Indexers in Structs
public struct Struct1
{
    public bool this[int x]
    {
        get { return true; }
    }
}
#endregion 

#region Indexers in Interfaces
public interface Interface1
{
    public bool this[int x]
    {
        get;
        set;
    }
}
#endregion

#region Expression-bodied indexers
public class ExpressionBodied
{
    public string this[int x] => this[x.ToString()];

    public string this[string x] => $"Lower{x.ToLowerInvariant()}";
}
#endregion