namespace ElementOrderStaticsByAccess1
{
    public class Class1
    {
        // Correct order.
        public int staticField;

        internal static int staticField1;
    }

    public class Class2
    {
        // Incorrect order.
        internal static int staticField1;

        public int staticField;
    }

    public class Class3
    {
        // Correct order.
        protected bool Property2
        {
            get { return true; }
        }

        private static bool Property1
        {
            get { return true; }
        }
    }

    public class Class4
    {
        // Incorrect order.
        private static bool Property1
        {
            get { return true; }
        }

        protected bool Property2
        {
            get { return true; }
        }
    }

    public class Class5
    {
        // Correct order.
        internal bool Method2()
        {
            return true;
        }

        private static bool Method1()
        {
            return true;
        }
    }

    public class Class6
    {
        // Incorrect order.
        private static bool Method1()
        {
            return true;
        }

        internal bool Method2()
        {
            return true;
        }
    }

    public class Class7
    {
        // Incorrect order, but an allowed exclusion for readonly dependency properties pattern.
        private static readonly DependencyPropertyKey MyPropertyKey =
            DependencyProperty.RegisterReadOnly("MyProperty", typeof(string), typeof(Class7));

        public static readonly DependencyProperty MyProperty = MyPropertyKey.DependencyProperty;
    }

    public class Class8
    {
        // A more realistic scenario, with unrelated properties above and below the allowed exclusion.
        public static readonly DependencyProperty UnrelatedProperty =
            DependencyProperty.Register("UnrelatedProperty", typeof(string), typeof(Class8));

        private static readonly DependencyPropertyKey MyPropertyKey =
            DependencyProperty.RegisterReadOnly("MyProperty", typeof(string), typeof(Class8));

        public static readonly DependencyProperty MyProperty = MyPropertyKey.DependencyProperty;

        public static readonly DependencyProperty UnrelatedProperty1 =
            DependencyProperty.Register("UnrelatedProperty1", typeof(string), typeof(Class8));
    }

    public class Class9
    {
        public static readonly DependencyProperty UnrelatedProperty =
            DependencyProperty.Register("UnrelatedProperty", typeof(string), typeof(Class9));

        private static readonly DependencyPropertyKey MyPropertyKey =
            DependencyProperty.RegisterReadOnly("MyProperty", typeof(string), typeof(Class9));

        // Normally, this would flag as a violation, but becuase of the special case exclusion for
        // DependencyPropertyKey, this case would not. On the other hand it is strange to declare 
        // DependencyPropertyKey and not expose it outside of the class.
        public static int i = 13;
    }
}