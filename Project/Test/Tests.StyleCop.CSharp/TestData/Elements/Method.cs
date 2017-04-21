#region Normal Methods
public class Class1
{
    void Method1()
    {
    }

    void Method2(int x)
    {
    }

    void Method3(int[][] x, ref string y)
    {
    }

    void Method4(short? @class, out string y)
    {
    }

    void Method5(int x, params object[] items)
    {
    }

    static void Method6(this int x, int y)
    {
    }

    void Method7<T>(T x)
    {
    }

    void Method8<T, S>(T x, int y)
    {
    }

    int? Method9()
    {
        return 2;
    }

    string[, , ,] Method10()
    {
        return null;
    }

    void Method11(int?[,] arg)
    {
    }
}
#endregion

#region Methods with type constraints
public class Class2
{
    bool MethodWithTypeConstraint1<T>(int x) where T : class
    {
        return true;
    }

    bool MethodWithTypeConstraint2<T>(int x) where T : struct
    {
        return false;
    }

    void MethodWithTypeConstraint3<T>(int x) where T : new()
    {
    }

    void MethodWithTypeConstraint4<T, S>() where T : System.IServiceProvider, new() where S : Type1
    {
    }
}
#endregion

#region Methods with access modifiers

public class Class3
{
    public void MethodWithAccessModifier1() { }
    internal void MethodWithAccessModifier2() { }
    protected void MethodWithAccessModifier3() { }
    protected internal void MethodWithAccessModifier4() { }
    internal protected void MethodWithAccessModifier5() { }
    private void MethodWithAccessModifier6() { }
}

#endregion

#region Methods with other modifiers

public abstract class Class4
{
    public new void MethodWithNewModifier1()
    {
    }

    public unsafe short* MethodWithUnsafeModifier2(int** x, int*[] y)
    {
        short y = 2;
        return &x;
    }

    public static void MethodWithStaticModifier()
    {
    }

    public virtual void MethodWithVirtualModifier(object[,,] item)
    {
    }

    public sealed string MethodWithSealedModifier()
    {
        return @"hello";
    }

    public override void MethodWithOverrideModifier()
    {
    }

    public abstract void MethodWithAbstractModifier(string x);

    public extern int MethodWithExternModifier(int x);

    public partial char MethodWithPartialModifier(string x)
    {
    }
}

public unsafe class UnsafeClass
{
    public short* MethodWithUnsafeModifier2(int** x)
    {
        short y = 2;
        return &x;
    }
}

#endregion 

#region Methods with sttributes and headers

public class Class5
{
    [Attribute1(false), System.Attribute2(true, 2)]
    [Attribute3]
    public void MethodWithAttributes();

    /// <summary>
    /// A method header.
    /// </summary>
    /// <param name="x">A parameter.</param>
    // Comment
    public void MethodWithHeader(int x)
    {
    }

    /// <summary>
    /// A method header.
    /// </summary>
    /// <param name="x">A parameter.</param>
    [Attribute1(false), System.Attribute2(true, 2)]
    [Attribute3]
    public void MethodWithHeaderAndAttributes(int x)
    {
    }
}

#endregion

#region Methods in Structs
public struct Struct1
{
    internal int Method1(string x)
    {
        return 2;
    }
}
#endregion 

#region Methods in Interfaces
public interface Interface1
{
    int Method1(string x);
}
#endregion

#region Operator overloads

public class Class6
{
    // Unary operators
    public static Class6 operator +(Class6 item) { return null; }
    public static Class6 operator -(Class6 item) { return null; }
    public static Class6 operator !(Class6 item) { return null; }
    public static Class6 operator ~(Class6 item) { return null; }
    public static Class6 operator ++(Class6 item) { return null; }
    public static Class6 operator --(Class6 item) { return null; }
    public static Class6 operator true(Class6 item) { return null; }
    public static Class6 operator false(Class6 item) { return null; }

    // Binary operators
    public static Class6 operator +(Class6 item1, Class6 item2) { return null; }
    public static Class6 operator -(Class6 item1, Class6 item2) { return null; }
    public static Class6 operator *(Class6 item1, Class6 item2) { return null; }
    public static Class6 operator /(Class6 item1, Class6 item2) { return null; }
    public static Class6 operator %(Class6 item1, Class6 item2) { return null; }
    public static Class6 operator &(Class6 item1, Class6 item2) { return null; }
    public static Class6 operator |(Class6 item1, Class6 item2) { return null; }
    public static Class6 operator ^(Class6 item1, Class6 item2) { return null; }
    public static Class6 operator <<(Class6 item1, Class6 item2) { return null; }
    public static Class6 operator >>(Class6 item1, Class6 item2) { return null; }
    public static Class6 operator ==(Class6 item1, Class6 item2) { return null; }
    public static Class6 operator !=(Class6 item1, Class6 item2) { return null; }
    public static Class6 operator >(Class6 item1, Class6 item2) { return null; }
    public static Class6 operator <(Class6 item1, Class6 item2) { return null; }
    public static Class6 operator >=(Class6 item1, Class6 item2) { return null; }
    public static Class6 operator <=(Class6 item1, Class6 item2) { return null; }

    // Conversion operators
    public static implicit operator Class6(Class4 item) { return null; }
    public static explicit operator Class6(Class4 item) { return null; }
}

public class Class7
{
    // extern operators
    public extern Class7 operator +(Class7 item);
    public extern Class7 operator *(Class7 item1, Class7 item2);
    public extern implicit operator Class7(Class4 item);
}

public class Class8<T, S>
{
    // operators on generic type
    public static Class8<T, S> operator +(Class8<T, S> item)
    {
        return null;
    }

    public static Class8<T, S> operator *(Class8<T, S> item1, Class8<T, S> item2)
    {
        return null;
    }

    public static implicit operator Class8(Class4 item)
    {
        return null;
    }
}

#endregion

#region Expression Bodied

// Introduced in C# 6
    public class ExpressionBodied
    {
        public string Test(string a) => a + "b";

        public Point Move(int variableX, int variableY) => new Point(x + variableX, y + variableY);

        public string GetLastName() => throw new NotImplementedException();
    }

#endregion

#region Ref Returns And Locals

    public class RefReturnsAndLocals
    {
        public ref int Find(int number, int[] numbers)
        {
            return ref numbers[0];
        }

        public ref int FindSomeMore(int number, int[] number) => ref numbers[1];

        public void TestCaller()
        {           
            ref int place = ref Find(7, array);
        }
    }

#endregion

#region Local Functions

    class LocalFunctionsTest
    {
        public void SimpleLocalFunction()
        {
            int LocalFunction()
            {
                return 1;
            }
        }

        public int LocalFunctionWithCaller()
        {
            return LocalFunction1();

            int LocalFunction1()
            {
                return 2;
            }
        }

        public int[] LocalFunctionWithArrayReturn()
        {
            return LocalFunction3();

            int[] LocalFunction3()
            {
                return new[] { 1 };
            }
        }

        public IEnumerable<T> LocalFunctionWithGenericType<T>(IEnumerable<T> source, Func<T, bool> filter)
        {
            return Iterator();

            IEnumerable<T> Iterator()
            {
                foreach (var element in source)
                {
                    if (filter(element))
                    {
                        yield return element;
                    }
                }
            }
        }

        public int LocalFunctionWithExpressionBody()
        {
            return LocalFunction1();

            int LocalFunction1() => 2;
        }

        public SomeType MultipleLocalFunctions()
        {
            SomeType LocalFunction1()
            {
                return new SomeType();
            }

            SomeOtherType LocalFunction2()
            {
                return new SomeOtherType();
            }

            YetAnotherType LocalFunction2() => new YetAnotherType();
        }

        public int RecursiveLocalFunction()
        {
            return LocalFunction1();

            int LocalFunction1()
            {
                return LocalFunction1();
            }
        }

        public int NestedLocalFunctions()
        {
            return OuterLocalFunction();

            int OuterLocalFunction()
            {
                return InnerLocalFunction();

                int InnerLocalFunction()
                {
                    return 3;
                }
            }
        }

        public void LocalFunctionWithRefReturn()
        {
            ref int use = ref LocalFunctionRef(new[] { 3, 4 });

            ref int LocalFunctionRef(int[] args)
            {
                return ref args[4];
            }
        }

        public int MultipleSquareBracketInLocalFunction()
        {
            return 1;

            int[][] InnerLocalFunction()
            {
                return null;
            }
        }

        public int MultipleAngleBracketInLocalFunction()
        {
            return 1;

            Dictionary<int,List<string>> InnerLocalFunction()
            {
                return null;
            }
        }

        public int MixedAngleAndSquareBracketsInLocalFunction()
        {
            return 1;

            Dictionary<int,string[]> LocalFunction1()
            {
                return null;
            }

            List<string>[] LocalFunction2()
            {
                return null;
            }
        }
    }

#endregion