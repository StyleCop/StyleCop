using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    #region Test that common header errors are still flagged.

    /// <summary>
    /// 
    /// </summary>
    public class InvalidDocumentationFormattingRuleClass1
    {
    }

    public class InvalidDocumentationFormattingRuleClass2
    {
    }

    /// <summary
    /// This is the summary.
    /// </summary>
    public class InvalidDocumentationFormattingRuleClass3
    {
    }

    #endregion

    #region Test that formatting rules are not applied.

    /// <summary>
    /// Nospaceshereatall.
    /// </summary>
    public class ValidDocumentationFormattingRuleClass1
    {
    }

    /// <summary>
    /// Short.
    /// </summary>
    public class ValidDocumentationFormattingRuleClass2
    {
    }

    /// <summary>
    /// A)(@)*23408234082308230823048230940238409283409234098230498234not enough letters.
    /// </summary>
    public class ValidDocumentationFormattingRuleClass3
    {
    }

    /// <summary>
    /// This is the header.
    /// </summary>
    /// <typeparam name="T">Nospaceshereatall.</typeparam>
    public class ValidDocumentationFormattingRuleClass4<T>
    {
    }

    /// <summary>
    /// This is the header.
    /// </summary>
    /// <typeparam name="T">Short.</typeparam>
    public class ValidDocumentationFormattingRuleClass5<T>
    {
    }

    /// <summary>
    /// This is the header.
    /// </summary>
    /// <typeparam name="T">A)(@)*23408234082308230823048230940238409283409234098230498234not enough letters.</typeparam>
    public class ValidDocumentationFormattingRuleClass6<T>
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
        /// <value>Nospaceshereatall.</value>
        public int ValidDocumentationFormattingRuleProperty1
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets whatever.
        /// </summary>
        /// <value>Short.</value>
        public int ValidDocumentationFormattingRuleProperty2
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets whatever.
        /// </summary>
        /// <value>A)(@)*23408234082308230823048230940238409283409234098230498234not enough letters.</value>
        public int ValidDocumentationFormattingRuleProperty3
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x">Nospaceshereatall.</param>
        public void ValidDocumentationFormattingRuleMethod1(int x)
        {
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x">Short.</param>
        public void ValidDocumentationFormattingRuleMethod2(int x)
        {
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x">A)(@)*23408234082308230823048230940238409283409234098230498234not enough letters.</param>
        public void ValidDocumentationFormattingRuleMethod3(int x)
        {
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <returns>Nospaceshereatall.</returns>
        public int ValidDocumentationFormattingRuleMethod4()
        {
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <returns>Short.</returns>
        public int ValidDocumentationFormattingRuleMethod5()
        {
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <returns>A)(@)*23408234082308230823048230940238409283409234098230498234not enough letters.</returns>
        public int ValidDocumentationFormattingRuleMethod6()
        {
        }
    }

    #endregion

    #region Valid with Tags

    /// <summary>
    /// A <see cref="SomeNameLongerThan10Chars"/>.
    /// </summary>
    public class TagText1
    {
    }

    /// <summary>
    /// A <seealso cref="SomeNameLongerThan10Chars"/>.
    /// </summary>
    public class TagText2
    {
    }

    /// <summary>
    /// A <c>SomeTextLongerThan10Chars</c>.
    /// </summary>
    public class TagText3
    {
    }

    /// <summary>
    /// A <code>SomeTextLongerThan10Chars</code>.
    /// </summary>
    public class TagText4
    {
    }

    /// <summary>
    /// A <list type="bullet"><item>SomeTextLongerThan10Chars</item></list>.
    /// </summary>
    public class TagText5
    {
    }

    /// <summary>
    /// A <para>SomeTextLongerThan10Chars</para>.
    /// </summary>
    public class TagText6
    {
    }

    /// <summary>
    /// A <paramref name="SomeTextLongerThan10Chars"/>.
    /// </summary>
    public class TagText7
    {
    }

    /// <summary>
    /// Test the use of see cref tags within documentation elements.
    /// </summary>
    public class MethodWithSeeCrefs
    {
        /// <summary>
        /// Returns an <seealso cref="T:System.Data.IDataReader"/> for the specified column ordinal.
        /// </summary>
        /// <param name="i">The index of the field to find.</param>
        /// <returns>
        /// An <see cref="T:System.Data.IDataReader"/>.
        /// </returns>
        /// <exception cref="T:System.IndexOutOfRangeException">
        /// The index passed was outside the range of 0 through <see cref="P:System.Data.IDataRecord.FieldCount"/>.
        /// </exception>
        public IDataReader GetData(int i)
        {
        }
    }

    #endregion
}
