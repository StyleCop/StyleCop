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

    public class Person
    {
        private static ConcurrentDictionary<int, string> names = new ConcurrentDictionary<int, string>();
        private int id = GetId();

        public Person(string name) => names.TryAdd(id, name); // constructors

        ~Person() => names.TryRemove(id, out _);              // finalizers

        public string Name
        {
            get => names[id];                                 // getters
            set => names[id] = value;                         // setters
        }
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

        public void LocalFunctionWithTypeConstraint<T>()
        {            
            T LocalFunction<T>() where T : Person
            {            
            }
        }

        public void LocalFunctionWithNullableReturn()
        {
            bool? Check(object target)
            {
            }
        }

        public async Task AsyncLocalFunction()
        {
            async Task Wait()
            {
            }
        }

        public async Task AsyncLocalFunctionWithReturnValue()
        {
            async Task<int> WaitInt()
            {
            }
        }

        public void LocalFunctionWithFullyQualifiedReturnType()
        {
            Ns1.Type Func1()
            {
            }

            Ns1.Ns2.Type Func2()
            {
            }
        }
    }

#endregion

#region Out Variables

    public class OutVariables
    {
        public void SimpleCases()
        {
            OutWithThisQualifier(out this.SomeField);
            OutWithPublicField(out someLocalType.PublicField1.PublicField2);
            SomMoq.Setup(s => s.SomeMethod(It.IsAny<Guid>(), out It.Ref<SomeType>.IsAny));
            a.TryGetValue(0, out ((d)));
            b.TryGetValue(0, out System.Collections.Generic.List<string>[] b1);
        }

        public void PrintCoordinates(Point p)
        {
            p.GetCoordinates(out int x, out int y);
            p.GetCoordinates(out var x, out _); // Test for discards.
        }

        public void PrintStars(string s)
        {
            if (int.TryParse(s, out var i))
            {
                return;
            }
        }

        public void TestForInlineOutVariables()
        {
            Dictionary<int, DateTime?> a = null;
            a.TryGetValue(0, out DateTime? b);

            Dictionary<int, (string, int)> tupleDictionary = null;
            tupleDictionary.TryGetValue(0, out (string, int) outValue);


            FullyQualifiedOut1(out Ns1.SomeType t);
            FullyQualifiedOut2(out Ns1.Ns2.SomeType t);
    }
}

#endregion

#region Tuple literal and Tuple types

    public class Tuples
    {
        public void TuplesLiteralsTest()
        {
            // Simple tuple literals
            var letters = ("a", "b");

            // named elements tuple literals
            var alphabetStart = (Alpha: "a", Beta: "b");

            // tuple literals with member access invocation
            var dateRange = (DateTime.MinValue, DateTime.MaxValue);

            // tuple literals with method invocation.
            var caculatedRange = (dates.First(), dates.Last());

            // tuple literal that as casting for a argument
            var cast = ((string)"a", "b");

            // tuple literal nested in another tuple literal
            var nested = (("a", 1), DateTime.Now);

            // tuple literals in return statement.
            return (first, middle, last);

            // named tuple elements in a literal
            return (first: first, middle: middle, last: last);
        }
        
        public void TupleTypesTest()
        {
            (int, double, DateTime) simpledeclaration;

            (int, string) intitializedField = (2, "Two");

            (int, string)[] tupleArray;

            (int, string)[] tuppleArrayInitialized = { (1, "One"), (2, "Two") };

            (double, string, DateTime)[] fixedSize = new (double, string, DateTime)[2];

            (string name, DateTime age) namedTuple;
            
            List<(string, int)> listOfTuple = new List<(string, int)>();

            List<(string name , int age)> listOfNamedTuple = new List<(string name , int age)>();

            List<(string name, DateTime dob)> myList = new List<(string name, DateTime dob)>()
                                                           {
                                                               ("A", DateTime.Now)
                                                           };

            List<(string[] name, DateTime dob)> myList1 = new List<(string[] name, DateTime dob)>()
                                                       {
                                                           (new [] {"A", "B"}, DateTime.Now)
                                                       };

            List<(string name , int? age)> listOfNamedTupleNullable = new List<(string name , int? age)>();
        }
        

        // tuple return type
        (string, string, string) TupleTypeTest(long id)
        {
            return (first, middle, last); // tuple literal
        }

        // tuple return type with elements names
        (string first, string middle, string last) TupleTypeWithNameTest(long id)
        {
            return (first, middle, last); // tuple literal
        }

        // Local function which return tuple types 
        public int Fibonacci(int x)
        {
            if (x < 0) throw new ArgumentException("Less negativity please!", nameof(x));
            return Fib(x).current;

            (int current, int previous) Fib(int i)
            {
                if (i == 0) return (1, 0);
                var (p, pp) = Fib(i - 1);
                return (p + pp, p);
            }
        }

        // Simple property
        (decimal, string ) TupleTypeProperty { get; set; }

        // Expression bodied property
        (double, string) TupleTypePropertyWithExpression => (12.2, "Twelve Point Two");

        // Property with accessor and expression body
        (decimal, string) TupleProperty
        {
            get => TupleTypeProperty;

            set => TupleTypeProperty = value;
        }

        public List<(IPEndPoint Source, IPEndPoint Destination)> ConnectionEndpoints { get; }

        // Indexer
        public (decimal, string) this[int i]
        {
            get => TupleTypeProperty;
            set => TupleTypeProperty = value;
        }

        public void DesconstructionTest()
        {
            (string fname, string lname) = person;

            (string fname, string _) = person;

            var (fname, lname) = person;

            var (_, lname) = person;
        }

        public void TupleEnumerationTest(IEnumerable<(string, int)> words)
        {
            foreach ((string word, int count) in words)
            {
            }

            foreach (var (word, count) in words)
            {
            }
        }

        public (int a, string b)? NullableTupleReturnType()
        {
        }
    }

#endregion

#region MethodStatments

    public class MethodStatements
    {
        public void TestInvocations()
        {
            somevariable
            .WithMemberInvocationOnAnotherLine();
        }

        public void YieldTest()
        {
            // In this context, yield is not a start of yield statement.
            int yield;
            yield = 5;

            // In the following contexts, yield is a start of yield statement
            yield break;
            yield return result;
        }
    }

# endregion
