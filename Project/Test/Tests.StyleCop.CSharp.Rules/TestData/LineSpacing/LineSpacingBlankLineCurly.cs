#region Namespaces

namespace LineSpacingBlankLineCurly1
{
}

namespace LineSpacingBlankLineCurly2
{

}

#endregion Namespaces

#region Class, Struct, Interface

namespace LineSpacingBlankLineCurly3
{
    public class Class1
    {
    }

    public class Class2
    {

    }

    public struct Struct1
    {
    }

    public struct Struct2
    {

    }

    public interface Interface1
    {
    }

    public interface Interface2
    {

    }
}

#endregion Class, Struct, Interface

#region Method, Property, Enum, etc

namespace LineSpacingBlankLineCurly4
{
    public class Class1
    {
        // Fields
        private int[] items =
            {
            };

        private int[] items =
            {
        
            };

        // Constructors
        public Class1()
        {
        }

        public Class1()
        {

        }

        // Destructors
        ~Class1()
        {
        }

        ~Class1()
        {
        
        }

        // Methods
        public void Method1()
        {
        }

        public void Method2()
        {

        }

        // Properties
        public bool Property1
        {
        }

        public bool Property2
        {

        }

        public bool Property3
        {
            set 
            { 
            }
        }

        public bool Property4
        {
            set 
            { 
                
            }
        }

        // Indexers
        public bool this[int x]
        {
        }

        public bool this[short x]
        {

        }

        public bool this[long x]
        {
            set
            {
            }
        }

        public bool this[float x]
        {
            set
            {

            }
        }

        // Enums
        public enum Enum1
        {
        }

        public enum Enum1
        {

        }
    }
}

#endregion Method, Property, Enum, etc

#region If, While, For, etc.

namespace LineSpacingBlankLineCurly5
{
    public class Class1
    {
        public void Method1()
        {
            // Block statement
            {
            }

            {
             
            }

            // try/catch/finally
            try
            {
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
            }

            try
            {

            }
            catch (System.Exception ex)
            {
                
            }
            finally
            {
                
            }

            // Do-while
            do
            {
            }
            while (true);

            do
            {

            }
            while (true);

            // if-else
            if (true)
            {
            }
            else if (false)
            {
            }
            else
            {
            }

            // if-else
            if (true)
            {

            }
            else if (false)
            {

            }
            else
            {

            }

            // lock
            lock (this)
            {
            }

            lock (this)
            {

            }

            // switch
            int switcher = 0;
            switch (switcher)
            {
            }

            switch (switcher)
            {

            }

            // unsafe
            unsafe
            {
            }

            unsafe
            {

            }

            // using
            using (Form form1 = new Form())
            {
            }

            using (Form form1 = new Form())
            {

            }

            // while
            while (true)
            {
            }

            while (true)
            {

            }

            // Array initializer.
            int[] t = new int[]
            {
            };

            int[] u = new int[]
            {

            };

            // Anonymous method.
            Form form3 = new Form();
            form3.BeginInvoke((MethodInvoker)delegate
            {
            });

            Form form4 = new Form();
            form4.BeginInvoke((MethodInvoker)delegate
            {

            });
        }
    }
}

#endregion If, While, For, etc.

#region Events

namespace LineSpacingBlankLineCurly6
{
    public class Class1
    {
        // Properties
        public event EventHandler Event1
        {
        }

        public event EventHandler Event2
        {

        }

        public event EventHandler Event3
        {
            add
            {
            }
        }

        public event EventHandler Event4
        {
            add
            {

            }
        }

        // These are all invalid blank lines before opening curly brackets
        public void Method1()
        {            
            {
            }

            // try/catch/finally
            try
            
            {
            }
            catch (System.Exception ex)
            
            {
            }
            finally
            
            {
            }

            // Do-while
            do
            
            {
            }
            while (true);

            // if-else
            if (true)
            
            {
            }
            else if (false)
            
            {
            }
            else
            
            {
            }

            // lock
            lock (this)
            
            {
            }

            // switch
            int switcher = 0;
            switch (switcher)
            
            {
            }

            // unsafe
            unsafe
            
            {
            }

            // using
            using (Form form1 = new Form())
            
            {
            }

            // while
            while (true)
            
            {
            }

            // Array initializer.
            int[] t = new int[]
            
            {
            };

            // Anonymous method.
            Form form3 = new Form();
            form3.BeginInvoke((MethodInvoker)delegate
            
            {
            });
        }
    }
}

#endregion Events