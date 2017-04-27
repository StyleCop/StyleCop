public class Class1
{
    int a;

    int b, c;

    int d = 2;

    int d = 2, f;

    string f, g = "hello" + 2;

    bool h = true, i = false, j;
}

public class Class2
{
    int[][] a;

    int? b = true;

    SomeType<bool, SomeOtherType<int, short[][,,]>> c = new SomeType<bool, SomeOtherType<int, short[][,,]>>(4);

    int?[,] d;
}

public class Class3
{
    new int a;

    static int b;

    const int c = 5 + 3 - 2;

    readonly int d;

    volatile object e;

    unsafe int* f = null;
}

public unsafe class Class4
{
    int* f = null;
}

public class Class5
{
    int a = 2;

    int b = "string";

    int c = 2 + 4 * Something.Value;

    int[] d = new int[2];

    int[] e = new int[] { 2, 3 };

    int[] f = { 2, 3 };

    int[][] g = { { 2, 3 }, { 4, 5, 6 }, { Something.Value } };

    List<bool> h = new List<bool>(5);

    List<bool> i = new List<bool>() { true, false, true, true, false };

    SomeItem j = new SomeItem() { X = 2, Y = 4 };

    Point k = new Point { X = 0, };

    Point l = new Point(0, 1) { X = 0, Y = 1 };

    Rectangle m = new Rectangle
    {
        P1 = new Point { X = 0, Y = 1 },
        P2 = new Point { X = 2, Y = 3 }
    };

    Rectangle n = new Rectangle
    {
        P1 = { X = 0, Y = 1 },
        P2 = { X = 2, Y = 3 }
    };

    List<Contact> o = new List<Contact> 
    {
        new Contact 
        {
            Name = "Chris Smith",
            PhoneNumbers = { "206-555-0101", "425-882-8080" }
        },
        new Contact 
        {
            Name = "Bob Harris",
            PhoneNumbers = { "650-555-0199" }
        }
    };

    var p = new { };

    var q = new { Name = "Lawnmower" };
    
    var r = new { Name = "Lawnmower", Price = 495.00 };
    
    var s = new { Name = "Lawnmower", Price = 495.00, };

    var t = { Name = "Lawnmower" };

    var u = { Name = "Lawnmower", Price = 495.00 };

    var v = { Name = "Lawnmower", Price = 495.00, };        
}

public class Class6
{
    public int a;
    internal int b;
    protected int c;
    protected internal int d;
    internal protected int e;
    private int f;
}

public class Class7
{
    [Attribute1(false), System.Attribute2(true, 2)]
    [Attribute3]
    public int a;

    /// <summary>
    /// A field header.
    /// </summary>
    public int b;

    /// <summary>
    /// A field header.
    /// </summary>
    [Attribute1(false), System.Attribute2(true, 2)]
    [Attribute3]
    public int c;

    /// <summary>
    /// A field header.
    /// </summary>
    // extra stuff
    [Attribute1(false), System.Attribute2(true, 2)]
    // extra stuff
    [Attribute3]
    // extra stuff
    public int d /* extra */=/*extra */2;
    // extra stuff
}

public unsafe class Class8
{
    // A fixed array type.
    public fixed uint restartOff[4];

    // A generic nullable type.
    public ArraySegment<byte>? loadedData;
}

public class NonDefaultWhiteSpace
{
    public int [] a;

    public System.Int32 [ ] b;

    public int[]c;

    public System.Int32 [] d = { 1, 2 };

    public int [ ] e = {3,4};
}

public class BinaryLiteralsAndDigitSeperator
{
    var b = 0b101010111100110111101111;

    var b1 = 0B101010111100110111101111;

    long longValue1 = 4_294_967_296.32_54;

    long longValue2 = 0x1_0000_0000;

    long longValue3 = 0b1_0000_0000_0000_0000_0000_0000_0000_0000;


    public void RegressionChecksForDigitSeparator()
    {
        this._someVariable = new SomeVariableObject(this._somOtherVariable);        
    }
}

public class TupleTypes
{
    (string, int) simpleTupleType;

    private (string, int) simpleTupleTypeWithScope;

    (string Name, double Age) tupleTypeWithNames;

    (string, double, (string, string)) nestedTupleTypes;

    (string Name, double Age, (string City, string Country)) nestedTupleTypesWithNames;

    (List<string>, List<double>) tupleTypesWithGenerics;

    (List<string> Names, List<double> Scores) tupleTypesWithGenericsAndNames;

    (List<string>, Dictionary<double, List<double>>) tupleTypesWithNestedGenerics;

    (List<string> Names, Dictionary<double, List<double>> Scores) tupleTypesWithNestedGenericsAndNames;

    (string[], double[]) tupleTypesWithArrays;

    (string[] Names, double[] Scores) tupleTypesWithArraysAndNames;

    (string[], double[][]) tupleTypesWithMultiDimensionalArrays;

    (string[] Names, double[][] Scores) tupleTypesWithMultiDimensionalArraysAndNames;

    (List<string>[], List<double[]>) tupleWithMixedArrayAndGenerics;

    (List<string>[] Names, List<double[]> Scores) tupleWithMixedArrayAndGenericsAndNames;

    (int, string) intitializedField = (2, "Two");

    (int, string)[] tupleArray;

    (int, string)[] tuppleArrayInitialized = { (1, "One"), (2, "Two") };

    List<(double, string, DateTime)> tupleInsideList;

    List<(string name, DateTime dob)> namedTupleInsideList;

    List<(string, (string, double))> nestedTuplesInsideList;
}

