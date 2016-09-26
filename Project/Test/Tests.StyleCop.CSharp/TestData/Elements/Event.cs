#region Normal Events
public class Class1
{
    event EventHandler Event1;

    event EventHandler Event2
    {
        add { } 
    }

    event EventHandler Event3
    {
        remove { }
    }

    event EventHandler Event4
    {
        add { }
        remove { }
    }

    event EventHandler<int> Event5;
    
    event System.EventHandler<int> Event6;

    event System.EventHandler<int> Event7
    {
        add { int x = 2; }
        remove { int y = 3; }
    }
}
#endregion

#region Events with access modifiers

public class Class3
{
    public event EventHandler Event1;
    internal event EventHandler Event2;
    protected event EventHandler Event3;
    protected internal event EventHandler Event4;
    internal protected event EventHandler Event5;
    private event EventHandler Event6;
}

#endregion

#region Events with other modifiers

public abstract class Class4
{
    public new event EventHandler Event1;

    public static event EventHandler Event2;

    public virtual event EventHandler Event3;

    public sealed event EventHandler Event4;

    public override event EventHandler Event5;

    public abstract event EventHandler Event6;

    public extern event EventHandler Event7;

    public unsafe event EventHandler<int**> Event8
    {
        add
        {
            short y = 2;
            return &x;
        }

        remove
        {
            short y = 2;
            return &x;
        }
    }
}

public unsafe class UnsafeClass
{
    public event EventHandler<int**> Event1
    {
        add
        {
            short y = 2;
            return &x;
        }

        remove
        {
            short y = 2;
            return &x;
        }
    }
}

#endregion 

#region Events with sttributes and headers

public class Class5
{
    [Attribute1(false), System.Attribute2(true, 2)]
    [Attribute3]
    public event EventHandler Event1
    {
        [Attribute1(false), System.Attribute2(true, 2)]
        [Attribute3]
        add
        {
        }

        [Attribute1(false), System.Attribute2(true, 2)]
        [Attribute3]
        remove
        {
        }
    }

    /// <summary>
    /// An event.
    /// </summary>
    public event EventHandler Event2
    {
        add
        {
        }

        remove
        {
        }
    }
    /// <summary>
    /// An event.
    /// </summary>
    [Attribute1(false), System.Attribute2(true, 2)]
    [Attribute3]
    public event EventHandler Event3
    {
        [Attribute1(false), System.Attribute2(true, 2)]
        [Attribute3]
        add
        {
        }

        [Attribute1(false), System.Attribute2(true, 2)]
        [Attribute3]
        remove
        {
        }
    }
}

#endregion

#region Events in Structs
public struct Struct1
{
    public event EventHandler Event1
    {
        add
        {
        }
        remove
        {
        }
    }
}
#endregion 

#region Events in Interfaces
public interface Interface1
{
    event EventHandler Event1;
}
#endregion