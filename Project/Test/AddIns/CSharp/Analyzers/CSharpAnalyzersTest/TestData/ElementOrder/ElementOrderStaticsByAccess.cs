namespace ElementOrderStaticsByAccess1
{
    public class Class1
    {
        public int staticField;

        // Correct order.
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
}