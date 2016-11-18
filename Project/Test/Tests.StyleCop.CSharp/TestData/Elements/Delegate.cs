#region Normal Delegates
delegate void Delegate1();

delegate void Delegate2(int x);

delegate void Delegate3(int[][] x, ref string y);

delegate void Delegate4(short? @class, out string y);

delegate void Delegate5(int x, params object[] items);

delegate void Delegate6<T>(T x);

delegate void Delegate7<T, S>(T x, int y);

delegate int? Delegate8();

delegate string[,,,] Delegate9();

#endregion

#region Delegates with type constraints
delegate void DelegateWithTypeConstraint1<T>(int x) where T : class;

delegate void DelegateWithTypeConstraint2<T>(int x) where T : struct;

delegate void DelegateWithTypeConstraint3<T>(int x) where T : new();

delegate void DelegateWithTypeConstraint4<T, S>() where T : System.IServiceProvider, new() where S : Type1;
#endregion

#region Nested delegate
class ClassWithNestedDelegate1
{
    delegate bool NestedDelegate1();

    public delegate bool NestedDelegate2();

    private delegate bool NestedDelegate3();
}
#endregion

#region Delegates with access modifiers

public delegate void DelegateWithAccessModifier1();
internal delegate void DelegateWithAccessModifier2();
protected delegate void DelegateWithAccessModifier3();
protected internal delegate void DelegateWithAccessModifier4();
internal protected delegate void DelegateWithAccessModifier5();
private delegate void DelegateWithAccessModifier6();

#endregion

#region Delegates with other modifiers

public class ClassWithNestedDelegate2
{
    public new delegate void DelegateWithModifier1();

    public unsafe delegate short* DelegateWithModifier2(int** x);
}

#endregion 

#region Delegate with Attributes

[Attribute1(false), System.Attribute2(true, 2)]
[Attribute3]
public delegate void DelegateWithAttributes();

#endregion

#region Delegate with headers

/// <summary>
/// A delegate header.
/// </summary>
/// <param name="x">A parameter.</param>
// Comment
public delegate void DelegateWithHeader(int x);

#endregion

#region Delegates with headers and attributes

/// <summary>
/// A delegate header.
/// </summary>
/// <param name="x">A parameter.</param>
[Attribute1(false), System.Attribute2(true, 2)]
[Attribute3]
public delegate void DelegateWithHeaderAndAttributes(int x);

#endregion