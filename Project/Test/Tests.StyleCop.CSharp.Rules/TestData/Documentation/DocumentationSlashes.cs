using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    /// <summary>
    /// This is the summary.
    /// </summary>
    public class DocumentationSlashes
    {
        /// <summary>
        /// This is a summary.
        /// </summary>
        public void Method1()
        {
            // Two slashes can be used for comments.

            //// Four slashes can be used for comments.

            ///// Five slashes can be used for comments.

            /// Three slashes may not be used for comments. 
        }

        // The three slashes below are ok because it is part of an element header.

        /// 
        public void Method2()
        {
        }

        // The three slashes below are ok because it is part of an element header.

        /// This is part of a header. 
        public void Method3()
        {
        }

        // The three slashes below are ok because it is part of an element header.

        /// <summary>
        /// This is part of a header.
        /// </summary>
        public void Method4()
        {
        }

        /// <summary>
        /// This is a header.
        /// </summary>
        public void Method5()
        {
            ///
            //
            ///
            //
            ///
            ///

            /// bad
            // good
            /// bad
            // good
            /// bad 
            /// bad
        }
    }
}
