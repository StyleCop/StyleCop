#region Fields

namespace ElementOrderByAccess1
{
    public partial class Class1
    {
        // Correct order.
        public int field1;

        internal int field2;

        protected internal int field3;

        protected int field4;

        private int field5;
    }

    public partial class Class1
    {
        // Incorrect order.
        private int field6;

        protected int field7;
    }

    public partial class Class1
    {
        // Incorrect order.
        private int field8;

        protected internal int field9;
    }

    public partial class Class1
    {
        // Incorrect order.
        private int field10;

        internal int field11;
    }

    public partial class Class1
    {
        // Incorrect order.
        private int field12;

        public int field13;
    }

    public partial class Class1
    {
        // Incorrect order.
        protected int field14;

        protected internal int field15;
    }

    public partial class Class1
    {
        // Incorrect order.
        protected int field16;

        internal int field17;
    }

    public partial class Class1
    {
        // Incorrect order.
        protected int field18;

        public int field19;
    }

    public partial class Class1
    {
        // Incorrect order.
        protected internal int field20;

        internal int field21;
    }

    public partial class Class1
    {
        // Incorrect order.
        protected internal int field22;

        public int field23;
    }

    public partial class Class1
    {
        // Incorrect order.
        internal int field24;

        public int field25;
    }
}

#endregion Fields

#region Constructors

namespace ElementOrderByAccess2
{
    public partial class Class1
    {
        // Correct order.
        public Class1(int x, int y) { }

        internal Class1(int x, short y) { }

        protected internal Class1(int x, long y) { }

        protected Class1(int x, double y) { }

        private Class1(int x, float y) { }
    }

    public partial class Class1
    {
        // Incorrect order.
        private Class1(short x, short y) { }

        protected Class1(short x, int y) { }
    }

    public partial class Class1
    {
        // Incorrect order.
        private Class1(long x, long y) { }

        protected internal Class1(long x, int y) { }
    }

    public partial class Class1
    {
        // Incorrect order.
        private Class1(float x, float y) { }

        internal Class1(float x, int y) { }
    }

    public partial class Class1
    {
        // Incorrect order.
        private Class1(double x, double y) { }

        public Class1(double x, int y) { }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected Class1(byte x, byte y) { }

        protected internal Class1(byte x, int y) { }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected Class1(char x, char y) { }

        internal Class1(char x, int y) { }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected Class1(string x, string y) { }

        public Class1(string x, int y) { }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected internal Class1(object x, object y) { }

        internal Class1(object x, int y) { }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected internal Class1(int[] x, int[] y) { }

        public Class1(int[] x, int y) { }
    }

    public partial class Class1
    {
        // Incorrect order.
        internal Class1(short[] x, short[] y) { }

        public Class1(short[] x, int y) { }
    }
}

#endregion Constructors

#region Delegates

namespace ElementOrderByAccess3
{
    public partial class Class1
    {
        // Correct order.
        public delegate void Delegate1();

        internal delegate void Delegate2();

        protected delegate void Delegate3();

        protected delegate void Delegate4();

        private delegate void Delegate5();
    }

    public partial class Class1
    {
        // Incorrect order.
        private delegate void Delegate6();

        protected delegate void Delegate7();
    }

    public partial class Class1
    {
        // Incorrect order.
        private delegate void Delegate8();

        protected internal delegate void Delegate9();
    }

    public partial class Class1
    {
        // Incorrect order.
        private delegate void Delegate10();

        internal delegate void Delegate11();
    }

    public partial class Class1
    {
        // Incorrect order.
        private delegate void Delegate12();

        public delegate void Delegate13();
    }

    public partial class Class1
    {
        // Incorrect order.
        protected delegate void Delegate14();

        protected internal delegate void Delegate15();
    }

    public partial class Class1
    {
        // Incorrect order.
        protected delegate void Delegate16();

        internal delegate void Delegate17();
    }

    public partial class Class1
    {
        // Incorrect order.
        protected delegate void Delegate18();

        public delegate void Delegate19();
    }

    public partial class Class1
    {
        // Incorrect order.
        protected internal delegate void Delegate20();

        internal delegate void Delegate21();
    }

    public partial class Class1
    {
        // Incorrect order.
        protected internal delegate void Delegate22();

        public delegate void Delegate23();
    }

    public partial class Class1
    {
        // Incorrect order.
        internal delegate void Delegate24();

        public delegate void Delegate25();
    }
}

#endregion Delegates

#region Events

namespace ElementOrderByAccess4
{
    public partial class Class1
    {
        // Correct order.
        public event EventHandler Event1;

        internal event EventHandler Event2;

        protected internal event EventHandler Event3;

        protected event EventHandler Event4;

        private event EventHandler Event5;
    }

    public partial class Class1
    {
        // Incorrect order.
        private event EventHandler Event6;

        protected event EventHandler Event7;
    }

    public partial class Class1
    {
        // Incorrect order.
        private event EventHandler Event8;

        protected internal event EventHandler Event9;
    }

    public partial class Class1
    {
        // Incorrect order.
        private event EventHandler Event10;

        internal event EventHandler Event11;
    }

    public partial class Class1
    {
        // Incorrect order.
        private event EventHandler Event12;

        public event EventHandler Event13;
    }

    public partial class Class1
    {
        // Incorrect order.
        protected event EventHandler Event14;

        protected internal event EventHandler Event15;
    }

    public partial class Class1
    {
        // Incorrect order.
        protected event EventHandler Event16;

        internal event EventHandler Event17;
    }

    public partial class Class1
    {
        // Incorrect order.
        protected event EventHandler Event18;

        public event EventHandler Event19;
    }

    public partial class Class1
    {
        // Incorrect order.
        protected internal event EventHandler Event20;

        internal event EventHandler Event21;
    }

    public partial class Class1
    {
        // Incorrect order.
        protected internal event EventHandler Event22;

        public event EventHandler Event23;
    }

    public partial class Class1
    {
        // Incorrect order.
        internal event EventHandler Event24;

        public event EventHandler Event25;
    }
}

#endregion Events

#region Enums

namespace ElementOrderByAccess5
{
    public partial class Class1
    {
        // Correct order.
        public enum Enum1 { }

        internal enum Enum2 { }

        protected internal enum Enum3 { }

        protected enum Enum4 { }

        private enum Enum5 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        private enum Enum6 { }

        protected enum Enum7 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        private enum Enum8 { }

        protected internal enum Enum9 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        private enum Enum10 { }

        internal enum Enum11 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        private enum Enum12 { }

        public enum Enum13 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected enum Enum14 { }

        protected internal enum Enum15 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected enum Enum16 { }

        internal enum Enum17 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected enum Enum18 { }

        public enum Enum19 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected internal enum Enum20 { }

        internal enum Enum21 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected internal enum Enum22 { }

        public enum Enum23 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        internal enum Enum24 { }

        public enum Enum25 { }
    }
}

#endregion Enums

#region Interfaces

namespace ElementOrderByAccess6
{
    public partial class Class1
    {
        // Correct order.
        public interface Interface1 { }

        internal interface Interface2 { }

        protected internal interface Interface3 { }

        protected interface Interface4 { }

        private interface Interface5 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        private interface Interface6 { }

        protected interface Interface7 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        private interface Interface8 { }

        protected internal interface Interface9 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        private interface Interface10 { }

        internal interface Interface11 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        private interface Interface12 { }

        public interface Interface13 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected interface Interface14 { }

        protected internal interface Interface15 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected interface Interface16 { }

        internal interface Interface17 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected interface Interface18 { }

        public interface Interface19 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected internal interface Interface20 { }

        internal interface Interface21 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected internal interface Interface22 { }

        public interface Interface23 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        internal interface Interface24 { }

        public interface Interface25 { }
    }
}

#endregion Interfaces

#region Properties

namespace ElementOrderByAccess7
{
    public partial class Class1
    {
        // Correct order.
        public bool Property1 { get { return true; }  }

        internal bool Property2 { get { return true; } }

        protected internal bool Property3 { get { return true; } }

        protected bool Property4 { get { return true; } }

        private bool Property5 { get { return true; } }
    }

    public partial class Class1
    {
        // Incorrect order.
        private bool Property6 { get { return true; } }

        protected bool Property7 { get { return true; } }
    }

    public partial class Class1
    {
        // Incorrect order.
        private bool Property8 { get { return true; } }

        protected internal bool Property9 { get { return true; } }
    }

    public partial class Class1
    {
        // Incorrect order.
        private bool Property10 { get { return true; } }

        internal bool Property11 { get { return true; } }
    }

    public partial class Class1
    {
        // Incorrect order.
        private bool Property12 { get { return true; } }

        public bool Property13 { get { return true; } }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected bool Property14 { get { return true; } }

        protected internal bool Property15 { get { return true; } }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected bool Property16 { get { return true; } }

        internal bool Property17 { get { return true; } }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected bool Property18 { get { return true; } }

        public bool Property19 { get { return true; } }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected internal bool Property20 { get { return true; } }

        internal bool Property21 { get { return true; } }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected internal bool Property22 { get { return true; } }

        public bool Property23 { get { return true; } }
    }

    public partial class Class1
    {
        // Incorrect order.
        internal bool Property24 { get { return true; } }

        public bool Property25 { get { return true; } }
    }
}

#endregion Properties

#region Indexers

namespace ElementOrderByAccess8
{
    public partial class Class1
    {
        // Correct order.
        public bool this[int x] { get { return true; } }

        internal bool this[short x] { get { return true; } }

        protected internal bool this[long x] { get { return true; } }

        protected bool this[byte x] { get { return true; } }

        private bool this[char x] { get { return true; } }
    }

    public partial class Class1
    {
        // Incorrect order.
        private bool this[float x] { get { return true; } }

        protected bool this[double x] { get { return true; } }
    }

    public partial class Class1
    {
        // Incorrect order.
        private bool this[string x] { get { return true; } }

        protected internal bool this[object x] { get { return true; } }
    }

    public partial class Class1
    {
        // Incorrect order.
        private bool this[int x, int y] { get { return true; } }

        internal bool this[int x, short y] { get { return true; } }
    }

    public partial class Class1
    {
        // Incorrect order.
        private bool this[int x, long y] { get { return true; } }

        public bool this[int x, byte y] { get { return true; } }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected bool this[int x, char y] { get { return true; } }

        protected internal bool this[int x, double y] { get { return true; } }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected bool this[int x, float y] { get { return true; } }

        internal bool this[int x, string y] { get { return true; } }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected bool this[int x, object y] { get { return true; } }

        public bool this[short x, short y] { get { return true; } }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected internal bool this[short x, int y] { get { return true; } }

        internal bool this[short x, long y] { get { return true; } }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected internal bool this[short x, float y] { get { return true; } }

        public bool this[short x, double y] { get { return true; } }
    }

    public partial class Class1
    {
        // Incorrect order.
        internal bool this[short x, byte y] { get { return true; } }

        public bool this[short y, char y] { get { return true; } }
    }
}

#endregion Indexers

#region Methods

namespace ElementOrderByAccess9
{
    public partial class Class1
    {
        // Correct order.
        public bool Method1() { return true; }

        internal bool Method2() { return true; }

        protected internal bool Method3() { return true; }

        protected bool Method4() { return true; }

        private bool Method5() { return true; }
    }

    public partial class Class1
    {
        // Incorrect order.
        private bool Method6() { return true; }

        protected bool Method7() { return true; }
    }

    public partial class Class1
    {
        // Incorrect order.
        private bool Method8() { return true; }

        protected internal bool Method9() { return true; }
    }

    public partial class Class1
    {
        // Incorrect order.
        private bool Method10() { return true; }

        internal bool Method11() { return true; }
    }

    public partial class Class1
    {
        // Incorrect order.
        private bool Method12() { return true; }

        public bool Method13() { return true; }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected bool Method14() { return true; }

        protected internal bool Method15() { return true; }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected bool Method16() { return true; }

        internal bool Method17() { return true; }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected bool Method18() { return true; }

        public bool Method19() { return true; }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected internal bool Method20() { return true; }

        internal bool Method21() { return true; }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected internal bool Method22() { return true; }

        public bool Method23() { return true; }
    }

    public partial class Class1
    {
        // Incorrect order.
        internal bool Method24() { return true; }

        public bool Method25() { return true; }
    }
}

#endregion Methods

#region Structs

namespace ElementOrderByAccess10
{
    public partial class Class1
    {
        // Correct order.
        public struct Struct1 { }

        internal struct Struct2 { }

        protected internal struct Struct3 { }

        protected struct Struct4 { }

        private struct Struct5 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        private struct Struct6 { }

        protected struct Struct7 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        private struct Struct8 { }

        protected internal struct Struct9 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        private struct Struct10 { }

        internal struct Struct11 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        private struct Struct12 { }

        public struct Struct13 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected struct Struct14 { }

        protected internal struct Struct15 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected struct Struct16 { }

        internal struct Struct17 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected struct Struct18 { }

        public struct Struct19 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected internal struct Struct20 { }

        internal struct Struct21 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected internal struct Struct22 { }

        public struct Struct23 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        internal struct Struct24 { }

        public struct Struct25 { }
    }
}

#endregion Structs

#region Classes

namespace ElementOrderByAccess11
{
    public partial class Class1
    {
        // Correct order.
        public class SubClass1 { }

        internal class SubClass2 { }

        protected internal class SubClass3 { }

        protected class SubClass4 { }

        private class SubClass5 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        private class SubClass6 { }

        protected class SubClass7 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        private class SubClass8 { }

        protected internal class SubClass9 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        private class SubClass10 { }

        internal class SubClass11 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        private class SubClass12 { }

        public class SubClass13 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected class SubClass14 { }

        protected internal class SubClass15 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected class SubClass16 { }

        internal class SubClass17 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected class SubClass18 { }

        public class SubClass19 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected internal class SubClass20 { }

        internal class SubClass21 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        protected internal class SubClass22 { }

        public class SubClass23 { }
    }

    public partial class Class1
    {
        // Incorrect order.
        internal class SubClass24 { }

        public class SubClass25 { }
    }
}

#endregion Classes

namespace ElementOrderByAccess12
{
    public class Class1
    {
        private class Class2
        {
            // Incorrect order.
            internal void SomethingInternal() { }
            public void SomethingPublic() { }
            private void SomethingPrivate() { }
        }
    }
}

namespace ElementOrderByAccess13
{
    public class Class1
    {
        private Class1()
        {
        }

        static Class1()
        {
        }
    }
}