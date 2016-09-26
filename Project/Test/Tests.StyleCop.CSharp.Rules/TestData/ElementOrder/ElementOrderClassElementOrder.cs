    namespace ElementOrderClassElementOrder1
{
    #region Field Order

    public class Class1
    {
        // Correct order
        public int field1;

        public Class1()
        {
        }
    }

    public class Class2
    {
        // Incorrect order.
        public Class2()
        {
        }

        public int field1;
    }

    public class Class3
    {
        // Correct order
        public int field1;

        ~Class3()
        {
        }
    }

    public class Class4
    {
        // Incorrect order.
        ~Class4()
        {
        }

        public int field1;
    }

    public class Class5
    {
        // Correct order
        public int field1;

        public delegate void Delegate1();
    }

    public class Class6
    {
        // Incorrect order.
        public delegate void Delegate1();

        public int field1;
    }

    public class Class7
    {
        // Correct order
        public int field1;

        public event EventHandler Event1;
    }

    public class Class8
    {
        // Incorrect order.
        public event EventHandler Event1;

        public int field1;
    }

    public class Class9
    {
        // Correct order
        public int field1;

        public enum Enum1
        {
        }
    }

    public class Class10
    {
        // Incorrect order.
        public enum Enum1
        {
        }

        public int field1;
    }

    public class Class11
    {
        // Correct order
        public int field1;

        public interface Interface1
        {
        }
    }

    public class Class12
    {
        // Incorrect order.
        public interface Interface1
        {
        }

        public int field1;
    }

    public class Class13
    {
        // Correct order
        public int field1;

        public bool Property1
        {
            get { return true; }
        }
    }

    public class Class14
    {
        // Incorrect order.
        public bool Property1
        {
            get { return true; }
        }

        public int field1;
    }

    public class Class15
    {
        // Correct order
        public int field1;

        public bool this[int x]
        {
            get { return true; }
        }
    }

    public class Class16
    {
        // Incorrect order.
        public bool this[int x]
        {
            get { return true; }
        }

        public int field1;
    }

    public class Class17
    {
        // Correct order
        public int field1;

        public bool Method1()
        {
            return true;
        }
    }

    public class Class18
    {
        // Incorrect order.
        public bool Method1()
        {
            return true;
        }

        public int field1;
    }

    public class Class19
    {
        // Correct order
        public int field1;

        public struct Struct1
        {
        }
    }

    public class Class20
    {
        // Incorrect order.
        public struct Struct1
        {
        }

        public int field1;
    }

    public class Class21
    {
        // Correct order
        public int field1;

        public class SubClass1
        {
        }
    }

    public class Class22
    {
        // Incorrect order.
        public class SubClass1
        {
        }

        public int field1;
    }

    #endregion Field Order

    #region Constructor Order

    public class Class23
    {
        // Correct order
        public Class23()
        {
        }

        ~Class23()
        {
        }
    }

    public class Class24
    {
        // Incorrect order.
        ~Class24()
        {
        }

        public Class24()
        {
        }
    }

    public class Class25
    {
        // Correct order
        public Class25()
        {
        }

        public delegate void Delegate1();
    }

    public class Class26
    {
        // Incorrect order.
        public delegate void Delegate1();

        public Class26()
        {
        }
    }

    public class Class27
    {
        // Correct order
        public Class27()
        {
        }

        public event EventHandler Event1;
    }

    public class Class28
    {
        // Incorrect order.
        public event EventHandler Event1;

        public Class28()
        {
        }
    }

    public class Class29
    {
        // Correct order
        public Class29()
        {
        }

        public enum Enum1
        { 
        }
    }

    public class Class30
    {
        // Incorrect order.
        public enum Enum1
        {
        }

        public Class30()
        {
        }
    }

    public class Class31
    {
        // Correct order
        public Class31()
        {
        }

        public interface Interface1
        {
        }
    }

    public class Class32
    {
        // Incorrect order.
        public interface Interface1
        {
        }

        public Class32()
        {
        }
    }

    public class Class33
    {
        // Correct order
        public Class33()
        {
        }

        public bool Property1
        {
            get { return true; }
        }
    }

    public class Class34
    {
        // Incorrect order.
        public bool Property1
        {
            get { return true; }
        }

        public Class34()
        {
        }
    }

    public class Class35
    {
        // Correct order
        public Class35()
        {
        }

        public bool this[int x]
        {
            get { return true; }
        }
    }

    public class Class36
    {
        // Incorrect order.
        public bool this[int x]
        {
            get { return true; }
        }

        public Class36()
        {
        }
    }

    public class Class37
    {
        // Correct order
        public Class37()
        {
        }

        public bool Method1()
        {
            return true;
        }
    }

    public class Class38
    {
        // Incorrect order.
        public bool Method1()
        {
            return true;
        }

        public Class38()
        {
        }
    }

    public class Class39
    {
        // Correct order
        public Class39()
        {
        }

        public struct Struct1
        {
        }
    }

    public class Class40
    {
        // Incorrect order.
        public struct Struct1
        {
        }

        public Class40()
        {
        }
    }


    public class Class41
    {
        // Correct order
        public Class41()
        {
        }

        public class SubClass1
        {
        }
    }

    public class Class42
    {
        // Incorrect order.
        public class SubClass1
        {
        }

        public Class42()
        {
        }
    }
    
    #endregion Constructor Order

    #region Destructor Order

    public class Class43
    {
        // Correct order
        ~Class43()
        {
        }

        public delegate void Delegate1();
    }

    public class Class44
    {
        // Incorrect order.
        public delegate void Delegate1();

        ~Class44()
        {
        }
    }

    public class Class45
    {
        // Correct order
        ~Class45()
        {
        }

        public event EventHandler Event1;
    }

    public class Class46
    {
        // Incorrect order.
        public event EventHandler Event1;

        ~Class46()
        {
        }
    }

    public class Class47
    {
        // Correct order
        ~Class47()
        {
        }

        public enum Enum1
        {
        }
    }

    public class Class48
    {
        // Incorrect order.
        public enum Enum1
        {
        }

        ~Class48()
        {
        }
    }

    public class Class49
    {
        // Correct order
        ~Class49()
        {
        }

        public interface Interface1
        {
        }
    }

    public class Class50
    {
        // Incorrect order.
        public interface Interface1
        {
        }

        ~Class50()
        {
        }
    }

    public class Class51
    {
        // Correct order
        ~Class51()
        {
        }

        public bool Property1
        {
            get { return true; }
        }
    }

    public class Class52
    {
        // Incorrect order.
        public bool Property1
        {
            get { return true; }
        }

        ~Class52()
        {
        }
    }

    public class Class53
    {
        // Correct order
        ~Class53()
        {
        }

        public bool this[int x]
        {
            get { return true; }
        }
    }

    public class Class54
    {
        // Incorrect order.
        public bool this[int x]
        {
            get { return true; }
        }

        ~Class54()
        {
        }
    }

    public class Class55
    {
        // Correct order
        ~Class55()
        {
        }

        public bool Method1()
        {
            return true;
        }
    }

    public class Class56
    {
        // Incorrect order.
        public bool Method1()
        {
            return true;
        }

        ~Class56()
        {
        }
    }

    public class Class57
    {
        // Correct order
        ~Class57()
        {
        }

        public struct Struct1
        {
        }
    }

    public class Class58
    {
        // Incorrect order.
        public struct Struct1
        {
        }

        ~Class58()
        {
        }
    }


    public class Class59
    {
        // Correct order
        ~Class59()
        {
        }

        public class SubClass1
        {
        }
    }

    public class Class60
    {
        // Incorrect order.
        public class SubClass1
        {
        }

        ~Class60()
        {
        }
    }

    #endregion Destructor Order

    #region Delegate Order

    public class Class61
    {
        // Correct order
        public delegate void Delegate1();

        public event EventHandler Event1;
    }

    public class Class62
    {
        // Incorrect order.
        public event EventHandler Event1;

        public delegate void Delegate1();
    }

    public class Class63
    {
        // Correct order
        public delegate void Delegate1();

        public enum Enum1
        {
        }
    }

    public class Class64
    {
        // Incorrect order.
        public enum Enum1
        {
        }

        public delegate void Delegate1();
    }

    public class Class65
    {
        // Correct order
        public delegate void Delegate1();

        public interface Interface1
        {
        }
    }

    public class Class66
    {
        // Incorrect order.
        public interface Interface1
        {
        }

        public delegate void Delegate1();
    }

    public class Class67
    {
        // Correct order
        public delegate void Delegate1();

        public bool Property1
        {
            get { return true; }
        }
    }

    public class Class68
    {
        // Incorrect order.
        public bool Property1
        {
            get { return true; }
        }

        public delegate void Delegate1();
    }

    public class Class69
    {
        // Correct order
        public delegate void Delegate1();

        public bool this[int x]
        {
            get { return true; }
        }
    }

    public class Class70
    {
        // Incorrect order.
        public bool this[int x]
        {
            get { return true; }
        }

        public delegate void Delegate1();
    }

    public class Class71
    {
        // Correct order
        public delegate void Delegate1();

        public bool Method1()
        {
            return true;
        }
    }

    public class Class72
    {
        // Incorrect order.
        public bool Method1()
        {
            return true;
        }

        public delegate void Delegate1();
    }

    public class Class73
    {
        // Correct order
        public delegate void Delegate1();

        public struct Struct1
        {
        }
    }

    public class Class74
    {
        // Incorrect order.
        public struct Struct1
        {
        }

        public delegate void Delegate1();
    }


    public class Class75
    {
        // Correct order
        public delegate void Delegate1();

        public class SubClass1
        {
        }
    }

    public class Class76
    {
        // Incorrect order.
        public class SubClass1
        {
        }

        public delegate void Delegate1();
    }

    #endregion Delegate Order

    #region Event Order

    public class Class77
    {
        // Correct order
        public event EventHandler Event1;

        public enum Enum1
        {
        }
    }

    public class Class78
    {
        // Incorrect order.
        public enum Enum1
        {
        }

        public event EventHandler Event1;
    }

    public class Class79
    {
        // Correct order
        public event EventHandler Event1;

        public interface Interface1
        {
        }
    }

    public class Class80
    {
        // Incorrect order.
        public interface Interface1
        {
        }

        public event EventHandler Event1;
    }

    public class Class81
    {
        // Correct order
        public event EventHandler Event1;

        public bool Property1
        {
            get { return true; }
        }
    }

    public class Class82
    {
        // Incorrect order.
        public bool Property1
        {
            get { return true; }
        }

        public event EventHandler Event1;
    }

    public class Class83
    {
        // Correct order
        public event EventHandler Event1;

        public bool this[int x]
        {
            get { return true; }
        }
    }

    public class Class84
    {
        // Incorrect order.
        public bool this[int x]
        {
            get { return true; }
        }

        public event EventHandler Event1;
    }

    public class Class85
    {
        // Correct order
        public event EventHandler Event1;

        public bool Method1()
        {
            return true;
        }
    }

    public class Class86
    {
        // Incorrect order.
        public bool Method1()
        {
            return true;
        }

        public event EventHandler Event1;
    }

    public class Class87
    {
        // Correct order
        public event EventHandler Event1;

        public struct Struct1
        {
        }
    }

    public class Class88
    {
        // Incorrect order.
        public struct Struct1
        {
        }

        public event EventHandler Event1;
    }


    public class Class89
    {
        // Correct order
        public event EventHandler Event1;

        public class SubClass1
        {
        }
    }

    public class Class90
    {
        // Incorrect order.
        public class SubClass1
        {
        }

        public event EventHandler Event1;
    }

    #endregion Event Order

    #region Enum Order

    public class Class91
    {
        // Correct order
        public enum Enum1
        {
        }

        public interface Interface1
        {
        }
    }

    public class Class92
    {
        // Incorrect order.
        public interface Interface1
        {
        }

        public enum Enum1
        {
        }
    }

    public class Class93
    {
        // Correct order
        public enum Enum1
        {
        }

        public bool Property1
        {
            get { return true; }
        }
    }

    public class Class94
    {
        // Incorrect order.
        public bool Property1
        {
            get { return true; }
        }

        public enum Enum1
        {
        }
    }

    public class Class95
    {
        // Correct order
        public enum Enum1
        {
        }

        public bool this[int x]
        {
            get { return true; }
        }
    }

    public class Class96
    {
        // Incorrect order.
        public bool this[int x]
        {
            get { return true; }
        }

        public enum Enum1
        {
        }
    }

    public class Class97
    {
        // Correct order
        public enum Enum1
        {
        }

        public bool Method1()
        {
            return true;
        }
    }

    public class Class98
    {
        // Incorrect order.
        public bool Method1()
        {
            return true;
        }

        public enum Enum1
        {
        }
    }

    public class Class99
    {
        // Correct order
        public enum Enum1
        {
        }

        public struct Struct1
        {
        }
    }

    public class Class100
    {
        // Incorrect order.
        public struct Struct1
        {
        }

        public enum Enum1
        {
        }
    }


    public class Class101
    {
        // Correct order
        public enum Enum1
        {
        }

        public class SubClass1
        {
        }
    }

    public class Class102
    {
        // Incorrect order.
        public class SubClass1
        {
        }

        public enum Enum1
        {
        }
    }

    #endregion Enum Order

    #region Interface Order

    public class Class103
    {
        // Correct order
        public interface Interface1
        {
        }

        public bool Property1
        {
            get { return true; }
        }
    }

    public class Class104
    {
        // Incorrect order.
        public bool Property1
        {
            get { return true; }
        }

        public interface Interface1
        {
        }
    }

    public class Class105
    {
        // Correct order
        public interface Interface1
        {
        }

        public bool this[int x]
        {
            get { return true; }
        }
    }

    public class Class106
    {
        // Incorrect order.
        public bool this[int x]
        {
            get { return true; }
        }

        public interface Interface1
        {
        }
    }

    public class Class107
    {
        // Correct order
        public interface Interface1
        {
        }

        public bool Method1()
        {
            return true;
        }
    }

    public class Class108
    {
        // Incorrect order.
        public bool Method1()
        {
            return true;
        }

        public interface Interface1
        {
        }
    }

    public class Class109
    {
        // Correct order
        public interface Interface1
        {
        }

        public struct Struct1
        {
        }
    }

    public class Class110
    {
        // Incorrect order.
        public struct Struct1
        {
        }

        public interface Interface1
        {
        }
    }

    public class Class111
    {
        // Correct order
        public interface Interface1
        {
        }

        public class SubClass1
        {
        }
    }

    public class Class112
    {
        // Incorrect order.
        public class SubClass1
        {
        }

        public interface Interface1
        {
        }
    }

    #endregion Interface Order

    #region Property Order

    public class Class113
    {
        // Correct order
        public bool Property1
        {
            get { return true; }
        }

        public bool this[int x]
        {
            get { return true; }
        }
    }

    public class Class114
    {
        // Incorrect order.
        public bool this[int x]
        {
            get { return true; }
        }

        public bool Property1
        {
            get { return true; }
        }
    }

    public class Class115
    {
        // Correct order
        public bool Property1
        {
            get { return true; }
        }

        public bool Method1()
        {
            return true;
        }
    }

    public class Class116
    {
        // Incorrect order.
        public bool Method1()
        {
            return true;
        }

        public bool Property1
        {
            get { return true; }
        }
    }

    public class Class117
    {
        // Correct order
        public bool Property1
        {
            get { return true; }
        }

        public struct Struct1
        {
        }
    }

    public class Class118
    {
        // Incorrect order.
        public struct Struct1
        {
        }

        public bool Property1
        {
            get { return true; }
        }
    }

    public class Class119
    {
        // Correct order
        public bool Property1
        {
            get { return true; }
        }

        public class SubClass1
        {
        }
    }

    public class Class120
    {
        // Incorrect order.
        public class SubClass1
        {
        }

        public bool Property1
        {
            get { return true; }
        }
    }

    #endregion Property Order

    #region Indexer Order

    public class Class121
    {
        // Correct order
        public bool this[int x]
        {
            get { return true; }
        }

        public bool Method1()
        {
            return true;
        }
    }

    public class Class122
    {
        // Incorrect order.
        public bool Method1()
        {
            return true;
        }

        public bool this[int x]
        {
            get { return true; }
        }
    }

    public class Class123
    {
        // Correct order
        public bool this[int x]
        {
            get { return true; }
        }

        public struct Struct1
        {
        }
    }

    public class Class124
    {
        // Incorrect order.
        public struct Struct1
        {
        }

        public bool this[int x]
        {
            get { return true; }
        }
    }

    public class Class125
    {
        // Correct order
        public bool this[int x]
        {
            get { return true; }
        }

        public class SubClass1
        {
        }
    }

    public class Class126
    {
        // Incorrect order.
        public class SubClass1
        {
        }

        public bool this[int x]
        {
            get { return true; }
        }
    }

    #endregion Indexer Order

    #region Method Order

    public class Class127
    {
        // Correct order
        public bool Method1()
        {
            return true;
        }

        public struct Struct1
        {
        }
    }

    public class Class128
    {
        // Incorrect order.
        public struct Struct1
        {
        }

        public bool Method1()
        {
            return true;
        }
    }

    public class Class129
    {
        // Correct order
        public bool Method1()
        {
            return true;
        }

        public class SubClass1
        {
        }
    }

    public class Class130
    {
        // Incorrect order.
        public class SubClass1
        {
        }

        public bool Method1()
        {
            return true;
        }
    }

    #endregion Method Order

    #region Struct Order

    public class Class131
    {
        // Correct order
        public struct Struct1
        {
        }

        public class SubClass1
        {
        }
    }

    public class Class132
    {
        // Incorrect order.
        public class SubClass1
        {
        }

        public struct Struct1
        {
        }
    }

    #endregion Struct Order
}