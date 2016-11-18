using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    #region Test that common header errors are still flagged.

    /// <summary>
    /// 
    /// </summary>
    public class InvalidDocumentationPeriodClass1
    {
    }

    public class InvalidDocumentationPeriodClass2
    {
    }

    /// <summary
    /// This is the summary.
    /// </summary>
    public class InvalidDocumentationPeriodClass3
    {
    }

    #endregion

    #region Test that formatting rules are not applied.

    /// <summary>
    /// There is no period
    /// </summary>
    public class ValidDocumentationPeriodClass1
    {
    }

    /// <summary>
    /// This is the header.
    /// </summary>
    /// <typeparam name="T">There is no period</typeparam>
    public class ValidDocumentationPeriodClass2<T>
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
        /// <value>There is no period</value>
        public int ValidDocumentationPeriodProperty1
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x">There is no period</param>
        public void ValidDocumentationPeriodMethod1(int x)
        {
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <returns>There is no period</returns>
        public int ValidDocumentationPeriodMethod2()
        {
        }
    }

    #endregion
}
