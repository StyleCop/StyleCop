namespace ValidHungarian1
{
    using System;

    // Class must begin with an upper-case letter.
    public class Class1
    {
        // Some valid hungarian.
        private int xField;
        private int xxField;

        // Some invalid hungarian.
        private int yField;
        private int yyField;
    }

    public class Class2
    {
        public void Method1(int xVariable)
        {
        }

        public void Method2(int xxVariable)
        {
        }

        public void Method3(int yVariable)
        {
        }

        public void Method4(int yyVariable)
        {
        }

        public void Delegate1(int xVariable)
        {
        }

        public void Delegate2(int xxVariable)
        {
        }

        public delegate void Delegate3(int yVariable);

        public delegate void Delegate4(int yyVariable);

        public bool this[int xVariable]
        {
            get { return true; }
        }

        public bool this[short xxVariable]
        {
            get { return true; }
        }

        public bool this[long yVariable]
        {
            get { return true; }
        }

        public bool this[bool yyVariable]
        {
            get { return true; }
        }

        public void Method20()
        {
            int xField;
            int xxField;
            int yField;
            int yyField;
        }

        public bool Property20
        {
            set
            {
                int xField;
                int xxField;
                int yField;
                int yyField;
            }
        }
    }

    public class Class3
    {
        public static void Method1(string l‰nge, int a) //valid
        {
        }
        public static void Method2(string ‰Lange, int a) //invalid
        {
        }
        public static void Method3(string a2Lange, int a) //valid
        {
        }
    }
}
