using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    #region Test that common header errors are still flagged.

    /// <summary>
    /// 
    /// </summary>
    public class InvalidDocumentationCapitalLetterClass1
    {
    }

    public class InvalidDocumentationCapitalLetterClass2
    {
    }

    /// <summary
    /// This is the summary.
    /// </summary>
    public class InvalidDocumentationCapitalLetterClass3
    {
    }

    #endregion

    #region Test that formatting rules are not applied.

    /// <summary>
    /// no capital letter.
    /// </summary>
    public class ValidDocumentationCapitalLetterClass1
    {
    }

    /// <summary>
    /// This is the header.
    /// </summary>
    /// <typeparam name="T">no capital letter.</typeparam>
    public class ValidDocumentationCapitalLetterClass2<T>
    {
    }

    /// <summary>
    /// This is the summary.
    /// </summary>
    public class TempClass
    {
        /// <summary>
        /// Gets whatever.
        /// </summary>
        /// <value>no capital letter.</value>
        public int ValidDocumentationCapitalLetterProperty1
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x">no capital letter.</param>
        public void ValidDocumentationCapitalLetterMethod1(int x)
        {
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <returns>no capital letter.</returns>
        public int ValidDocumentationCapitalLetterMethod2()
        {
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="param1"><see langword="true" /> to test param; otherwise, <see langword="false" />.</param>
        /// <returns>no capital letter.</returns>
        public int ValidDocumentationCapitalLetterMethod3(string param1)
        {
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="param1"><c>true</c> to test param; otherwise, <see langword="false" />.</param>
        /// <returns>no capital letter.</returns>
        public int ValidDocumentationCapitalLetterMethod4(string param1)
        {
        }
    }

    #endregion
}
