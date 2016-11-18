namespace ElementOrderConstField1
{
    // Correct placement.
    public struct Struct1
    {
        private const int field1 = 0;

        private int field2;
    }

    // Incorrect placement.
    public struct Struct2
    {
        private int field1;

        private const int field2 = 0;
    }

    // Correct placement.
    public struct Struct3
    {
        private readonly int field1 = 0;

        private int field2;
    }

    // Incorrect placement.
    public struct Struct4
    {
        private int field1;

        private readonly int field2 = 0;
    }

    // Correct placement.
    public struct Struct5
    {
        private const int field2 = 0;

        private readonly int field1 = 0;
    }

    // Correct placement.
    public struct Struct6
    {
        private const int field1 = 0;

        private readonly int field2 = 0;
    }

    // Correct placement.
    public class Class1
    {
        private const int field1 = 0;

        private int field2;
    }

    // Incorrect placement.
    public class Class2
    {
        private int field1;

        private const int field2 = 0;
    }

    // Correct placement.
    public class Class3
    {
        private readonly int field1 = 0;

        private int field2;
    }

    // Incorrect placement.
    public class Class4
    {
        private int field1;

        private readonly int field2 = 0;
    }

    // Correct placement.
    public class Class5
    {
        private const int field1 = 0;

        private readonly int field2 = 0;
    }

    // Correct placement.
    public class Class6
    {
        private const int field1 = 0;

        private readonly int field2 = 0;
    }
}