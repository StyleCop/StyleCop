public class Class1
{
    ~Class1()
    {
    }
}

public class Class2
{
    unsafe ~Class2() 
    {
        short y = 2;
        &y = 4;
    }
}

public unsafe class Class3
{
    ~Class3() 
    {
        short y = 2;
        &y = 4;
    }
}

public class Class4
{
    extern ~Class4();
}

public class Class5
{
    static ~Class5()
    {
    }
}

public class Class6
{
    [Attribute1(false), System.Attribute2(true, 2)]
    [Attribute3]
    ~Class6()
    {
    }
}

public class Class7
{
    /// <summary>
    /// A destructor.
    /// </summary>
    ~Class7()
    {
    }
}

public class Class8
{
    /// <summary>
    /// A destructor.
    /// </summary>
    [Attribute1(false), System.Attribute2(true, 2)]
    [Attribute3]
    ~Class8()
    {
    }
}

public struct Struct1
{
    ~Struct1()
    {
    }
}
