#region Normal Interfaces
interface Interface1
{
}

interface Interface2<T>
{
}

interface Interface3<T, S>
{
}
#endregion

#region Interfaces with type constraints
interface Interface4<T> where T : class
{
}

interface Interface5<T> where T : struct
{
}

interface Interface6<T> where T : new()
{
}
#endregion

#region Interfaces with implemented interfaces and type constraints
interface Interface7<T> where T : IException
{
}

interface Interface8<T> where T : class, IException, new()
{
}

interface Interface9<T,U,V> where T : IException where U : struct, int
{
}

interface Interface10<T, U, V>
    where T : IException
    where U : struct, int
{
}

interface
    Interface11
    <
    T, 
    U, 
    V
    >
    where 
    T 
    : 
    IException
    where 
    U 
    : 
    struct
    , 
    int
{
}

interface Interface12 : IException
{
}

interface Interface13 : IException, System.ICloneable
{
}

interface Interface14 : System.ICloneable
{
}

interface Interface15<T> : IException, System.ICloneable where T : System.IDisposable
{
}

interface Interface16<T>
    : 
    IException
    , 
    System.ICloneable 
    where T : System.IDisposable
{
}
#endregion

#region Interface with trailing semicolon
interface Interface17
{
};
#endregion

#region Nested Interfaces
class ClassWithNestedInterface1
{
    interface NestedInterface1
    {
    }
}
#endregion

#region Interfaces with access modifiers

public interface InterfaceWithAccessModifier1
{
}

internal interface InterfaceWithAccessModifier2
{
}

protected interface InterfaceWithAccessModifier3
{
}

protected internal interface InterfaceWithAccessModifier4
{
}

internal protected interface InterfaceWithAccessModifier5
{
}

private interface InterfaceWithAccessModifier6
{
}

#endregion

#region Interfaces with other modifiers

public class ClassWithNestedInterface2
{
    public new interface InterfaceWithModifier1
    {
    }
}

#endregion 

#region Partial Interfaces

public partial interface PartialInterface1
{
}

public partial interface PartialInterface2
{
}

public partial interface PartialInterface3
{
}

internal partial interface PartialInterface2
{
}

#endregion

#region Interfaces with Attributes

[Attribute1(false), System.Attribute2(true, 2)]
[Attribute3]
public interface InterfaceWithAttributes
{
}

#endregion

#region Interfaces with headers

/// <summary>
/// An interface header.
/// </summary>
public interface InterfaceWithHeader
{
}

#endregion

#region Interfaces with headers and attributes

/// <summary>
/// An interface header.
/// </summary>
[Attribute1(false), System.Attribute2(true, 2)]
[Attribute3]
public interface InterfaceWithHeaderAndAttributes
{
}

#endregion

#region Unsafe Interface

public unsafe interface UnsafeInterface
{
    int* Method1(short** x);
}

#endregion