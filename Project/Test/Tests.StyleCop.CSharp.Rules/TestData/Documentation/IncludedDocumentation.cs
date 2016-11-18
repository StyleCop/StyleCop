using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    /// <summary>
    /// Invalid use of the include tag.
    /// </summary>
    public class InvalidIncludedDocumentation
    {
        // An empty include tag.
        /// <include />
        public void Method1()
        {
        }

        // An include tag with an empty file and no path.
        /// <include file="" />
        public void Method2()
        {
        }

        // An includ tag with an empty file and path.
        /// <include file="" path="" />
        public void Method3()
        {
        }

        // An include tag with no file and an empty path.
        /// <include path="" />
        public void Method4()
        {
        }

        // An include tag with a non-existent file and an empty path.
        /// <include file="NonExistentFile.xml" path="" />
        public void Method5()
        {
        }

        // An include tag with a non-existent file.
        /// <include file="NonExistentFile.xml" path="somethinginvalid" />
        public void Method6()
        {
        }

        // An include tag with a valid file and no path.
        /// <include file="IncludedDocumentation.xml" />
        public void Method7()
        {
        }

        // An include tag with a valid file and an empty path.
        /// <include file="IncludedDocumentation.xml" path=""/>
        public void Method8()
        {
        }

        // An include tag with a valid file and an invalid path.
        /// <include file="IncludedDocumentation.xml" path="somethinginvalid"/>
        public void Method9()
        {
        }

        // An include tag with a badly formed file path.
        /// <include file="XH:\\badpath" path="somethinginvalid" />
        public void Method10()
        {
        }

        // An include tag with a valid file and a badly formed xpath.
        /// <include file="IncludedDocumentation.xml" path="\\\\\\LSKHSDKFHSDF+++++++++LSDFHSKDFH----------KHJ*" />
        public void Method11()
        {
        }

        // An include tag with a valid file and path, but missing the required elements for the method.
        /// <include file="IncludedDocumentation.xml" path="root/SummaryOnly/*" />
        public int Method12(int x, int y)
        {
        }

        // A header with a valid include tag containing the summary, and a second include tag which is invalid.
        /// <include file="IncludedDocumentation.xml" path="root/SummaryOnly/*" />
        /// <param name="x"><include file="missingfile.xml" path="somethinginvalid" /></param>
        /// <param name="y">The second parameter.</param>
        /// <returns>Returns an int.</returns>
        public int Method13(int x, int y)
        {
        }

        // An empty summary.
        /// <include file="IncludedDocumentation.xml" path="root/EmptySummary/*" />
        public void Method1()
        {
        }

        // Summary text starting with a lower-case letter.
        /// <include file="IncludedDocumentation.xml" path="root/LowerCaseSummary/*" />
        public void Method1()
        {
        }

        // Two identical documentation text values.
        /// <summary>
        /// This is a summary.
        /// </summary>
        /// <include file="IncludedDocumentation.xml" path="root/Param1/*" />
        /// <include file="IncludedDocumentation.xml" path="root/Param2/*" />
        public void Method1(int param1, int param2)
        {
        }
    }

    /// <summary>
    /// Valid use of the include tag.
    /// </summary>
    public class ValidIncludedDocumentation
    {
        /// <include file="IncludedDocumentation.xml" path="root/SummaryOnly/*" />
        public void Method1()
        {
        }

        /// <summary>
        /// This is a summary.
        /// </summary>
        /// <include file="IncludedDocumentation.xml" path="root/NameParameter/*" />
        /// <include file="IncludedDocumentation.xml" path="root/TypeParameter/*" />
        public void Method1(string name, string type)
        {
        }

        /// <include file="IncludedDocumentation.xml" path="root/SummaryOnly/*" />
        /// <include file="IncludedDocumentation.xml" path="root/NameParameter/*" />
        /// <include file="IncludedDocumentation.xml" path="root/TypeParameter/*" />
        public void Method1(string name, string type)
        {
        }

        /// <include file="IncludedDocumentation.xml" path="root/SummaryOnly/*" />
        /// <include file="IncludedDocumentation.xml" path="root/TwoParameters/*" />
        public void Method1(string name, string type)
        {
        }

        /// <include file="IncludedDocumentation.xml" path="root/SummaryOnly/*" />
        /// <include file="IncludedDocumentation.xml" path="root/TwoParameters/*" />
        /// <returns>A return value.</returns>
        public int Method1(string name, string type)
        {
        }

        /// <include file="IncludedDocumentation.xml" path="root/FullMethodHeader/*" />
        public int Method1(string name, string type)
        {
        }
    }
}
