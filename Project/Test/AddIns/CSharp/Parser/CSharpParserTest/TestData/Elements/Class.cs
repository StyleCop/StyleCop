#region Normal Classes
class Class1
{
}

class Class2<T>
{
}

class Class3<T, S>
{
}
#endregion

#region Classes with type constraints
class Class4<T> where T : class
{
}

class Class5<T> where T : struct
{
}

class Class6<T> where T : new()
{
}
#endregion

#region Classes with base classes and type constraints
class Class7<T> where T : System.Exception
{
}

class Class8<T> where T : class, System.Exception, new()
{
}

class Class9<T,U,V> where T : System.Exception where U : struct, int
{
}

class Class10<T, U, V>
    where T : System.Exception
    where U : struct, int
{
}

class 
    Class11
    <
    T, 
    U, 
    V
    >
    where 
    T 
    : 
    System.Exception
    where 
    U 
    : 
    struct
    , 
    int
{
}

class Class12 : System.Exception
{
}

class Class13 : System.Exception, System.ICloneable
{
}

class Class14 : System.ICloneable
{
}

class Class15<T> : System.Exception, System.ICloneable where T : System.IDisposable
{
}

class Class16<T>
    : 
    System.Exception
    , 
    System.ICloneable 
    where T : System.IDisposable
{
}
#endregion

#region Class with trailing semicolon
class Class17
{
};
#endregion

#region Nested classes
class NestedClass1
{
    class NestedClass2
    {
        class NestedClass3
        {
            class NestedClass4
            {
                class NestedClass5
                {
                    class NestedClass6<T> : Class17<T> where T : IFormattable
                    {
                    }
                }
            }
        }
    }
}
#endregion

#region Classes with access modifiers

public class ClassWithAccessModifier1
{
}

internal class ClassWithAccessModifier2
{
}

protected class ClassWithAccessModifier3
{
}

protected internal class ClassWithAccessModifier4
{
}

internal protected class ClassWithAccessModifier5
{
}

private class ClassWithAccessModifier6
{
}

#endregion

#region Classes with other modifiers

public class ClassWithModifier1
{
    public new class SubClass
    {
    }
}

public abstract class ClassWithModifier2
{
}

public sealed class ClassWithModifier3
{
}

public static class ClassWithModifier4
{
}

public static sealed abstract class ClassWithModifier5
{
} 

#endregion 

#region Partial Classes

public partial class PartialClass1
{
}

public partial class PartialClass2
{
}

public partial class PartialClass3
{
}

internal sealed partial class PartialClass2
{
}

#endregion

#region Classes with Attributes

[Attribute1(false), System.Attribute2(true, 2)]
[Attribute3]
public class ClassWithAttributes
{
}

#endregion

#region Classes with headers

/// <summary>
/// A class header.
/// </summary>
public class ClassWithHeader
{
}

#endregion

#region Classes with headers and attributes

/// <summary>
/// A class header.
/// </summary>
[Attribute1(false), System.Attribute2(true, 2)]
[Attribute3]
public class ClassWithHeaderAndAttributes
{
}

#endregion

#region Unsafe Class

public unsafe class UnsafeClass
{
    int* Method1(short** x)
    {
    }
}

#endregion