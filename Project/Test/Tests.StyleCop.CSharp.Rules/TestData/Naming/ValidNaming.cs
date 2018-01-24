// Namespace must begin with an upper-case letter.
namespace ValidNaming1
{
    using System;

    // Add one known error.
    public class class0
    {
    }

    // Class must begin with an upper-case letter.
    public class Class1
    {
        // Enum must begin with an upper-case letter.
        public enum Enum1
        {

        }

        // Struct must begin with an upper-case letter.
        public class Struct1
        {

        }

        // Delegate must begin with an upper-case letter.
        public delegate void Delegate1();

        // Event must begin with an upper-case letter.
        public event EventHandler Event1;

        // Property must begin with an upper-case letter.
        public bool Property1
        {
            get { return true; }
        }

        // Method must begin with an upper-case letter.
        public void Method1()
        {
        }

        // operator overload can start with lower-case.
        public bool operator !=(Class1 x, Class1 y)
        {
        }

        // Interface must begin with I
        public interface IMyInterface1
        {
        }

        // Private or protected fields must begin with lower-case letter.
        private int field1;
        protected int field2;

        // Public or internal fields must begin with an upper-case letter.
        public int Field3;
        internal int Field4;
        protected internal int Field5;

        // Const must begin with upper-case letter.
        private const int Const1 = 0;

        // Private readonly must begin with lower-case letter.
        private readonly int readonly1;
        private readonly int readonly2;

        // Non-private readonly must begin with upper-case letter.
        internal readonly int Readonly3;
        protected readonly int Readonly4;
        protected internal readonly int Readonly5;
        public readonly int Readonly6;

        // Fields must not use hungarian, but three characters are ok.
        private int xyzField;
    }

    public class Class2
    {
        public void Method1(int variable)
        {
        }

        public void Delegate1(int variable)
        {
        }

        public bool this[int variable]
        {
            get { return true; }
        }

        public void Method2()
        {
            int field1;
            const int Const1 = 0;
            int xyzField;
        }

        public bool Property1
        {
            set
            {
                int field1;
                const int Const1 = 0;
                int xyzField;
                var _; // dont care variable is valid in C# 7
            }
        }

        // stylecop should not complain about the __arglist parameter name beginning with an underscore.
        public void TestArgList(string format, __arglist)
        {
        }
    }

    public class Class3
    {
        private static readonly int AField;
    }

    public class ChineseCultureCasing
    {
        public readonly int 欢Bob;

        public int 欢Field;

        public static readonly int 欢StaticReadonly;

        public bool 欢迎
        {
            set
            {
                int 欢field1;
                const int 欢Const1 = 0;
            }
            get
            {

            }
        }
    }
}
