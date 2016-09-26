namespace LineSpacingXmlHeaders1
{
    public class Class1
    {
        // The comment is ok.
        public void Method()
        {
        }

        // The comment is no good because it is followed by a blank line.
        
        public void Method2()
        {
        }

        // The comment is no good because it is followed by a blank line.

        
        public void Method3()
        {
        }

        // The comment is no good because it is followed by a blank line.

        // This comment is ok.
        // This comment is ok.
        public void Method5(int x)
        {
            // This comment is ok.
        }

        public void Method6()
        {
            // The comment is no good because it is followed by a blank line.

        }
    }

    public class Class2
    {
        // The comment is ok.
        public void Method()
        {
        }
        // The comment is no good because it is not preceded by a blank line.
        public void Method2()
        {
        }
        // The comment is no good because it is not preceded by a blank line.

        // This comment is ok.
        // This comment is ok.
        public void Method5(int x)
        {
            // This comment is ok.
        }

        #region This is a region.
        // The comment is ok.
        public class SubClass1
        {
        }
        #endregion

        #if true
        // The comment is ok.
        #endif
    }

    public class Class3
    {
        //// The comment is ok.
        public void Method()
        {
        }

        //// The comment is ok.

        public void Method2()
        {
        }

        //// The comment is ok.


        public void Method3()
        {
        }

        //// The comment is ok.

        //// The comment is ok.
        //// The comment is ok.
        public void Method5(int x)
        {
            //// The comment is ok.
        }

        public void Method6()
        {
            //// The comment is ok.

        }
    }

    public class Class2
    {
        //// The comment is ok.
        public void Method()
        {
        }
        //// The comment is ok.
        public void Method2()
        {
        }
        //// The comment is ok.

        //// The comment is ok.
        //// The comment is ok.
        public void Method5(int x)
        {
            //// The comment is ok.
        }

        #region This is a region.
        //// The comment is ok.
        public class SubClass1
        {
        }
        #endregion

        #if true
        //// The comment is ok.
        #endif
    }
}