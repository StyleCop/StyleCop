#region Namespaces

namespace LineSpacingXmlHeaders1
{
    public class Class1
    {
        /// <summary>
        /// This header is ok.
        /// </summary>
        public void Method()
        {
        }

        /// <summary>
        /// This header is no good because it is followed by a blank line.
        /// </summary>
        
        public void Method2()
        {
        }

        /// <summary>
        /// This header is no good because it is followed by a blank line.
        /// </summary>

        
        public void Method3()
        {
        }

        /// <summary>This header is no good because it is followed by a blank line.</summary>
        public void Method4()
        {
        }

        /// <summary>
        /// This header is no good because it is followed by a blank line.
        /// </summary>

        /// <param name="x">This part of the header is ok.</param>
        public void Method5(int x)
        {
        }
    }

    public class Class2
    {
        /// <summary>
        /// This header is ok.
        /// </summary>
        public void Method()
        {
        }
        /// <summary>
        /// This header is no good because it is not preceded by a blank line.
        /// </summary>
        public void Method2()
        {
        }
        /// <summary>This header is no good because it is not preceded a blank line.</summary>
        public void Method3()
        {
        }

        // This is a comment.
        /// <summary>
        /// This header is no good because it is not preceded a blank line.
        /// </summary>
        public void Method4(int x)
        {
        }

        #region This is a region.
        /// <summary>
        /// This header is ok.
        /// </summary>
        public class SubClass1
        {
            /// <summary>
            /// This header is ok.
            /// </summary>
            public void Method5()
            {
            }
        }
        #endregion

        #if true
        /// <summary>
        /// This header is ok.
        /// </summary>
        public void Method6()
        {
        }
        #endif
    }
}

#endregion Namespaces
