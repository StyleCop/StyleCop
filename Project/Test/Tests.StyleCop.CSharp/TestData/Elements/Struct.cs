#region Normal Structs
struct Struct1
{
}

struct Struct2<T>
{
}

struct Struct3<T, S>
{
}
#endregion

#region Structs with type constraints
struct Struct4<T> where T : class
{
}

struct Struct5<T> where T : struct
{
}

struct Struct6<T> where T : new()
{
}
#endregion

#region Structs with implemented interfaces and type constraints
struct Struct7<T> where T : IException
{
}

struct Struct8<T> where T : class, IException, new()
{
}

struct Struct9<T,U,V> where T : IException where U : struct, int
{
}

struct Struct10<T, U, V>
    where T : IException
    where U : struct, int
{
}

struct
    Struct11
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

struct Struct12 : IException
{
}

struct Struct13 : IException, System.ICloneable
{
}

struct Struct14 : System.ICloneable
{
}

struct Struct15<T> : IException, System.ICloneable where T : System.IDisposable
{
}

struct Struct16<T>
    : 
    IException
    , 
    System.ICloneable 
    where T : System.IDisposable
{
}
#endregion

#region Struct with trailing semicolon
struct Struct17
{
};
#endregion

#region Nested structs
class ClassWithNestedStruct1
{
    struct NestedStruct1
    {
    }
}
#endregion

#region Structs with access modifiers

public struct StructWithAccessModifier1
{
}

internal struct StructWithAccessModifier2
{
}

protected struct StructWithAccessModifier3
{
}

protected internal struct StructWithAccessModifier4
{
}

internal protected struct StructWithAccessModifier5
{
}

private struct StructWithAccessModifier6
{
}

#endregion

#region Structs with other modifiers

public class ClassWithNestedStruct2
{
    public new struct StructWithModifier1
    {
    }
}

#endregion 

#region Partial Structs

public partial struct PartialStruct1
{
}

public partial struct PartialStruct2
{
}

public partial struct PartialStruct3
{
}

internal partial struct PartialStruct2
{
}

#endregion

#region Structs with Attributes

[Attribute1(false), System.Attribute2(true, 2)]
[Attribute3]
public struct StructWithAttributes
{
}

#endregion

#region Structs with headers

/// <summary>
/// A struct header.
/// </summary>
public struct StructWithHeader
{
}

#endregion

#region Structs with headers and attributes

/// <summary>
/// A struct header.
/// </summary>
[Attribute1(false), System.Attribute2(true, 2)]
[Attribute3]
public struct StructWithHeaderAndAttributes
{
}

#endregion

#region Unsafe Struct

public unsafe struct UnsafeStruct
{
    int* Method1(short** x)
    {
    }
}

#endregion