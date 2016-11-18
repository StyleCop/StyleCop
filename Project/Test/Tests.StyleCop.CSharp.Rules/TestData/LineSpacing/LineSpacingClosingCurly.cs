#region Namespaces

namespace LineSpacingClosingCurly1
{
    using System;
}

namespace LineSpacingClosingCurly2
{
    using System;

}

#endregion Namespaces

#region Class, Struct, Interface

namespace LineSpacingClosingCurly3
{
    public class Class1
    {
        private int field;
    }

    public class Class2
    {
        private int field;

    }

    public struct Struct1
    {
        private int field;
    }

    public struct Struct2
    {
        private int field;

    }

    public interface Interface1
    {
        void Method1();
    }

    public interface Interface2
    {
        void Method1();

    }
}

#endregion Class, Struct, Interface

#region Method, Property, Enum, etc

namespace LineSpacingClosingCurly4
{
    public class Class1
    {
        // Fields
        private int[] items =
            {
                1
            };

        private int[] items =
            {
                1

            };

        // Constructors
        public Class1()
        {
            int i = 0;
        }

        public Class1()
        {
            int i = 0;

        }

        // Destructors
        ~Class1()
        {
            int i = 0;
        }

        ~Class1()
        {
            int i = 0;

        }

        // Methods
        public void Method1()
        {
            int i = 0;
        }

        public void Method2()
        {
            int i = 0;

        }

        // Properties
        public bool Property1
        {
            get { return true; }
        }

        public bool Property2
        {
            get { return true; }

        }

        public bool Property3
        {
            get 
            { 
                return true; 
            }
        }

        public bool Property4
        {
            get 
            { 
                return true; 

            }
        }

        // Indexers
        public bool this[int x]
        {
            get { return true; }
        }

        public bool this[short x]
        {
            get { return true; }

        }

        public bool this[long x]
        {
            get
            {
                return true;
            }
        }

        public bool this[float x]
        {
            get
            {
                return true;

            }
        }

        // Enums
        public enum Enum1
        {
            Item
        }

        public enum Enum1
        {
            Item

        }
    }
}

#endregion Method, Property, Enum, etc

#region If, While, For, etc.

namespace LineSpacingClosingCurly5
{
    public class Class1
    {
        public void Method1()
        {
            // Block statement
            {
                int x = 0;
            }

            {
                int y = 0;

            }

            // try/catch/finally
            try
            {
                int z = 0;
            }
            catch (System.Exception ex)
            {
                int a = 0;
            }
            finally
            {
                int b = 0;
            }

            try
            {
                int c = 0;

            }
            catch (System.Exception ex)
            {
                int d = 0;

            }
            finally
            {
                int e = 0;

            }

            // Do-while
            do
            {
                int c = 0;
            }
            while (true);

            do
            {
                int f = 0;

            }
            while (true);

            // if-else
            if (true)
            {
                int g = 0;
            }
            else if (false)
            {
                int h = 0;
            }
            else
            {
                int i = 0;
            }

            // if-else
            if (true)
            {
                int j = 0;

            }
            else if (false)
            {
                int k = 0;

            }
            else
            {
                int l = 0;

            }

            // lock
            lock (this)
            {
                int m = 0;
            }

            lock (this)
            {
                int m = 0;

            }

            // switch
            int switcher = 0;
            switch (switcher)
            {
                case 1:
                    break;
            }

            switch (switcher)
            {
                case 1:
                    break;

            }

            // unsafe
            unsafe
            {
                int n = 0;
            }

            unsafe
            {
                int o = 0;

            }

            // using
            using (Form form1 = new Form())
            {
                int p = 0;
            }

            using (Form form1 = new Form())
            {
                int q = 0;

            }

            // while
            while (true)
            {
                int r = 0;
            }

            while (true)
            {
                int s = 0;

            }

            // Array initializer.
            int[] t = new int[]
            {
                1
            };

            int[] u = new int[]
            {
                1

            };

            // Anonymous method.
            Form form3 = new Form();
            form3.BeginInvoke((MethodInvoker)delegate
            {
                int v = 0;
            });

            Form form4 = new Form();
            form4.BeginInvoke((MethodInvoker)delegate
            {
                int w = 0;

            });
        }
    }

}

#endregion If, While, For, etc.

#region Events

namespace LineSpacingClosingCurly6
{
    public class Class1
    {
        // Properties
        public event EventHandler Event1
        {
            add { }
        }

        public event EventHandler Event2
        {
            add { }

        }

        public event EventHandler Event3
        {
            add
            {
                int i = 0;
            }
        }

        public event EventHandler Event4
        {
            add
            {
                int i = 0;

            }
        }
    }
}

#endregion Events
