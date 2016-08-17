/// <summary>
/// A example.
/// </summary>
public class A
{
    /// <summary>
    /// Foo this instance.
    /// </summary>
    public static void Foo()
    {
    }
}

/// <summary>
/// Another example.
/// </summary>
public class B : A
{
    /// <summary>
    /// Initializes a new instance of the <see cref="B"/> class.
    /// </summary>
    public B()
    {
        Foo(); // <-- SA1101 false positive!
    }

    /// <summary>
    /// Foo the specified integer.
    /// </summary>
    /// <param name="i">The integer.</param>
    private void Foo(int i)
    {
    }
}