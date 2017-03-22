using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    /// <summary>
    /// The text ends with two periods..
    /// </summary>
    public class InvalidDocumentationPeriodClass1
    {
    }

    /// <summary>
    /// This is the header.
    /// </summary>
    /// <typeparam name="T">The text ends with two periods..</typeparam>
    public class InvalidDocumentationPeriodClass2<T>
    {
    }

    /// <summary>
    /// The text contains two periods.. But not at the end.
    /// </summary>
    public class InvalidDocumentationPeriodClass3
    {
    }

    /// <summary>
    /// The text contains three periods...which is valid.
    /// </summary>
    public class ThreePeriodsClass1
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
        /// <value>The text ends with two periods..</value>
        public int InvalidDocumentationPeriodProperty1
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x">The text ends with two periods..</param>
        public void InvalidDocumentationPeriodMethod1(int x)
        {
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <returns>The text ends with two periods..</returns>
        public int InvalidDocumentationPeriodMethod2()
        {
        }
    }
}
