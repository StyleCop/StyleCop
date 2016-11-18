// Namespace must begin with an upper-case letter.
namespace invalidNaming1
{
    using System;

    // Class must begin with an upper-case letter.
    public class class1
    {
        // Enum must begin with an upper-case letter.
        public enum enum1
        {

        }

        // Struct must begin with an upper-case letter.
        public class struct1
        {

        }

        // Delegate must begin with an upper-case letter.
        public delegate void delegate1();

        // Event must begin with an upper-case letter.
        public event EventHandler event1;

        // Property must begin with an upper-case letter.
        public bool property1
        {
            get { return true; }
        }

        // Method must begin with an upper-case letter.
        public void method1()
        {
        }

        // Interface must begin with I
        public interface MyInterface1
        {
        }

        // Private or protected fields must begin with lower-case letter.
        private int Field1;
        protected int Field2;

        // Public or internal fields must begin with an upper-case letter.
        public int field3;
        internal int field4;
        protected internal int field5;

        // Const must begin with upper-case letter.
        private const int const1 = 0;

        // Non-private readonly must begin with upper-case letter.
        internal readonly int readonly3;
        protected readonly int readonly4;
        protected internal readonly int readonly5;
        public readonly int readonly6;

        // Fields must not use hungarian
        private int xField;
        private int xyField;
        private readonly int xField2;
        private readonly int xyField2;

        // Fields must not start with m_ or s_.
        private int m_field;
        private int s_field;
        private const int m_Field2 = 0;
        private const int s_Field2 = 0;
        private readonly int m_field3;
        private readonly int s_field3;

        // Fields must not start with _.
        private int _field;
        private const int _Field2 = 0;
        private readonly int _field3;

        // Fields must not contain _.
        private int fi_eld;
        private const int Fi_eld2 = 0;
        private readonly int fi_eld3;

        private int field_;
        private const int Field2_ = 0;
        private readonly int field3_;
    }

    public class Class2
    {
        public void Method1(int variable)
        {
        }

        public void Method2(int xVariable)
        {
        }

        public void Method3(int xxVariable)
        {
        }

        public void Method4(int _variable)
        {
        }

        public void Method5(int varia_ble)
        {
        }

        public void Method6(int variable_)
        {
        }

        public delegate void Delegate1(int variable);

        public delegate void Delegate2(int xVariable);

        public delegate void Delegate3(int xxVariable);

        public delegate void Delegate4(int _variable);

        public delegate void Delegate5(int varia_ble);

        public delegate void Delegate6(int variable_);

        public bool this[int variable]
        {
            get { return true; }
        }

        public bool this[short xVariable]
        {
            get { return true; }
        }

        public bool this[long xxVariable]
        {
            get { return true; }
        }

        public bool this[float _variable]
        {
            get { return true; }
        }

        public bool this[double varia_ble]
        {
            get { return true; }
        }

        public bool this[byte variable_]
        {
            get { return true; }
        }

        public void Method20()
        {
            // Variables must not use hungarian
            int xField;
            int xyField;

            // Variables must not start with _.
            int _field;
            const int _Field2 = 0;
        }

        public bool Property20
        {
            set
            {
                // Variables must not use hungarian
                int xField;
                int xyField;

                // Variables must not start with _.
                int _field;
                const int _Field2 = 0;
            }
        }
    }

    /// <summary>
    /// Checks that class member rules are firing correctly when multiple events are declared within a single element.
    /// </summary>
    public class CheckEvents
    {
        public event EventHandler Event1;
        public event EventHandler event2;
        public event EventHandler Event3, Event4;
        public event EventHandler event5, Event6;
        public event EventHandler Event7, event8;
        public event EventHandler event9, event10;
        public event EventHandler Event11, Event12, event13;
        public event EventHandler Event14 = null, event15 = null;
    }

    public class InvalidIndexerParameterNaming
    {
        /// <summary>
        /// Test comment 1
        /// </summary>
        /// <param name="Index">Parameter 1</param>
        /// <returns>Return value 1</returns>
        public char this[char Index]
        {
            get
            {
                return ' ';
            }

            set
            {
            }
        }
    }

    public class Class3
    {
        private int a2Field;
    }

    public class Class4
    {
        private static readonly int thisField;
    }
}
