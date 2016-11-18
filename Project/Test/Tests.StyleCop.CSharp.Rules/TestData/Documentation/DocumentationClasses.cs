using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    /// <summary>
    /// This is the summary for the class.
    /// </summary>
    public class ValidDocumentationClass1
    {
    }

    /// <summary>
    /// This is the summary for the class.
    /// </summary>
    protected class ValidDocumentationClass2
    {
    }

    /// <summary>
    /// This is the summary for the class.
    /// </summary>
    internal class ValidDocumentationClass3
    {
    }

    /// <summary>
    /// This is the summary for the class.
    /// </summary>
    internal protected class ValidDocumentationClass4
    {
    }

    /// <summary>
    /// This is the summary for the class.
    /// </summary>
    protected internal class ValidDocumentationClass5
    {
    }

    /// <summary>
    /// This is the summary for the class.
    /// </summary>
    private class ValidDocumentationClass6
    {
    }

    /// <summary>
    /// This is the summary for the class.
    /// </summary>
    public static class ValidDocumentationClass7
    {
    }

    /// <summary>
    /// This is the summary for the class.
    /// </summary>
    public sealed class ValidDocumentationClass8
    {
    }

    /// <summary>
    /// This is the summary for the class.
    /// </summary>
    public unsafe class ValidDocumentationClass9
    {
    }

    /// <summary>
    /// This is the summary for the class.
    /// </summary>
    public class ValidDocumentationClass10 : List<int>, IList
    {
    }

    /// <summary>
    /// This is the summary for the class.
    /// </summary>
    /// <typeparam name="S">This is the first generic parameter.</typeparam>
    /// <typeparam name="T">This is the second generic parameter.</typeparam>
    public class ValidDocumentationClass11<S, T>
    {
    }

    /// <summary>This is the summary for the class.</summary><typeparam name="S">This is the first generic parameter.</typeparam><typeparam name="T">This is the second generic parameter.</typeparam>
    public class ValidDocumentationClass12<S, T>
    {
    }

    /// <summary>
    /// This is the summary for the class.
    /// </summary>
    /// <typeparam name="S">This is the first generic parameter.</typeparam>
    /// <typeparam name="T">This is the second generic parameter.</typeparam>
    public class ValidDocumentationClass13<S, T> where T : int where S : string
    {
    }

    /// <summary>
    /// This is the summary for the class.
    /// </summary>
    /// <remarks>Adding a remarks tag.</remarks>
    public class ValidDocumentationClass14
    {
    }

    /// <content>
    /// The partial class uses a content tag.
    /// </content>
    public partial class ValidDocumentationClass15
    {
    }

    /// <summary>
    /// The partial class uses a summary tag.
    /// </summary>
    public partial class ValidDocumentationClass16
    {
    }

    /// <summary>
    /// Summary description for class.
    /// </summary>
    public class InvalidDocumentationClass1
    {
    }

    /// <summary>
    /// This class's xml is invalid. The closing tag is ill-formed.
    /// /summary>
    public class InvalidDocumentationClass2
    {
    }

    public class InvalidDocumentationClass3
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public class InvalidDocumentationClass4
    {
    }

    /// <summary>
    /// Nospaceshereatall.
    /// </summary>
    public class InvalidDocumentationClass5
    {
    }

    /// <summary>
    /// Short.
    /// </summary>
    public class InvalidDocumentationClass6
    {
    }

    /// <summary>
    /// A)(@)*23408234082308230823048230940238409283409234098230498234not enough letters.
    /// </summary>
    public class InvalidDocumentationClass7
    {
    }

    /// <summary>
    /// no capital letter.
    /// </summary>
    public class InvalidDocumentationClass8
    {
    }

    /// <summary>
    /// No closing period
    /// </summary>
    public class InvalidDocumentationClass9
    {
    }

    /// <summary>
    /// This is the summary.
    /// </summary>
    public class InvalidDocumentationClass10<T>
    {
    }

    /// <summary>
    /// This is the summary.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class InvalidDocumentationClass11<T>
    {
    }

    /// <summary>
    /// This is the summary.
    /// </summary>
    /// <typeparam name="T">Nospaceshereatall.</typeparam>
    public class InvalidDocumentationClass12<T>
    {
    }

    /// <summary>
    /// This is the summary.
    /// </summary>
    /// <typeparam name="T">Short.</typeparam>
    public class InvalidDocumentationClass13<T>
    {
    }

    /// <summary>
    /// This is the summary.
    /// </summary>
    /// <typeparam name="T">A)(@)*23408234082308230823048230940238409283409234098230498234not enough letters.</typeparam>
    public class InvalidDocumentationClass14<T>
    {
    }

    /// <summary>
    /// This is the summary.
    /// </summary>
    /// <typeparam name="T">no capital letter.</typeparam>
    public class InvalidDocumentationClass15<T>
    {
    }

    /// <summary>
    /// This is the summary.
    /// </summary>
    /// <typeparam name="T">No closing period</typeparam>
    public class InvalidDocumentationClass16<T>
    {
    }

    /// <summary>
    /// This line is copied.
    /// </summary>
    /// <typeparam name="T">This line is copied.</typeparam>
    /// <typeparam name="S">This is the second type param.</typeparam>
    public class InvalidDocumentationClass17<T, S>
    {
    }

    /// <summary>
    /// This line is copied.
    /// </summary>
    /// <typeparam name="T">This is the first type param.</typeparam>
    /// <typeparam name="S">This line is copied.</typeparam>
    public class InvalidDocumentationClass18<T, S>
    {
    }

    /// <summary>
    /// This is the summary.
    /// </summary>
    /// <typeparam name="T">This line is copied.</typeparam>
    /// <typeparam name="S">This line is copied.</typeparam>
    public class InvalidDocumentationClass19<T, S>
    {
    }

    /// <summary>
    /// The parameters are in the wrong order.
    /// </summary>
    /// <typeparam name="S">This is the second param.</typeparam>
    /// <typeparam name="T">This is the first param.</typeparam>
    public class InvalidDocumentationClass20<T, S>
    {
    }

    /// <summary>
    /// Typeparam tag is missing name attribute.
    /// </summary>
    /// <typeparam>This is the first param.</typeparam>
    public class InvalidDocumentationClass21<T>
    {
    }

    /// <summary>
    /// Typeparam tag is missing name attribute.
    /// </summary>
    /// <typeparam name="">This is the first param.</typeparam>
    public class InvalidDocumentationClass22<T>
    {
    }

    /// <summary>
    /// This is the summary.
    /// </summary>
    /// <typeparam name="S">This is the wrong type param.</typeparam>
    public class InvalidDocumentationClass23<T>
    {
    }

    internal class InvalidDocumentationClass24
    {
    }

    protected class InvalidDocumentationClass25
    {
    }

    private class InvalidDocumentationClass26
    {
    }

    protected internal class InvalidDocumentationClass27
    {
    }

    internal protected class InvalidDocumentationClass28
    {
    }

    internal static class InvalidDocumentationClass29
    {
    }

    public sealed class InvalidDocumentationClass30
    {
    }

    /////// <summary>
    /////// This is the summary.
    /////// </summary>
    /////// <remarks></remarks>
    ////public class InvalidDocumentationClass31
    ////{
    ////}

    /// <summary>
    /// This is the summary.
    /// </summary>
    /// <typeparam name="T">This is the first param.</typeparam>
    /// <typeparam name="S">This is the second param.</typeparam>
    /// <typeparam name="W">This is the third param.</typeparam>
    internal class InvalidDocumentationClass32<T, S>
    {
    }

    /// <summary>
    /// This is the summary.
    /// </summary>
    /// <typeparam name="T">This is the first param.</typeparam>
    /// <typeparam name="S">This is the second param.</typeparam>
    /// <typeparam>This is the third param.</typeparam>
    internal class InvalidDocumentationClass33<T, S>
    {
    }

    /// <summary>
    /// <summary>
    /// This is the summary.
    /// </summary>
    /// <typeparam name="T">This is the first param.</typeparam>
    /// <typeparam name="S">This is the second param.</typeparam>
    /// <typeparam name="">This is the third param.</typeparam>
    internal class InvalidDocumentationClass34<T, S>
    {
    }

    /// <content>
    /// The class is not partial, yet it uses a content tag rather than a summary tag.
    /// </content>
    public class InvalidDocumentationClass35
    {
    }

    public partial class InvalidDocumentationClass36
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public partial class InvalidDocumentationClass37
    {
    }

    /// <remarks>These are some remarks.</remarks>
    public partial class InvalidDocumentationClass38
    {
    }

    /// <summary>
    /// The typeparam tag are missing from this partial item.
    /// </summary>
    public partial class InvalidDocumentationClass39<T>
    {
    }

    /// <summary>
    /// The typeparam tag is missing for the W param.
    /// </summary>
    /// <typeparam name="T">This is the first param.</typeparam>
    /// <typeparam name="S">This is the second param.</typeparam>
    public class InvalidDocumentationClass40<T, S, W>
    {
    }

    /// <summary>
    /// This exception class is thrown by the application if it encounters an
    /// unrecoverable error.
    /// </summary>
    [Serializable]
    public class CustomException : Exception
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <overloads>There are four overloads for the constructor</overloads>
        public CustomException()
        {
        }

        /// <inheritdoc />
        public CustomException(string message)
            : base(message)
        {
            // Inherit documentation from the base Exception class matching
            // this constructor's signature.
        }

        /// <inheritdoc />
        public CustomException(string message, Exception innerException) :
            base(message, innerException)
        {
            // Inherit documentation from the base Exception class matching
            // this constructor's signature.
        }

        /// <inheritdoc />
        protected CustomException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // Inherit documentation from the base Exception class matching
            // this constructor's signature.
        }

        /// <summary>
        /// The ID.
        /// </summary>
        /// <remarks>
        /// The summary above is OK as text must be 10 characters long or at least 2 words.
        /// </remarks>
        public class InvalidDocumentationClass6
        {
            /// <summary>
            /// Gets a value indicating whether the component is in design mode.
            /// </summary>
            /// <value>Always <c>false</c>.</value>
            public bool Property1
            {
                get { return false; }
            }
        }
    }

    /// <exclude />
    public class ExcludedClassDocs
    {
        // Ensures that classes with "/// <exclude />" don't get flagged for documentation checks.
    }
}
