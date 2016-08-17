using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    /// <summary>
    /// Valid constructor headers.
    /// </summary>
    public class Class1
    {
        /// <summary>
        /// Initializes a new instance of the Class1 class.
        /// </summary>
        public Class1()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Class1 class with a bunch of extra text on the end.
        /// </summary>
        public Class1()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Class1 class.
        /// </summary>
        internal Class1()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Class1 class.
        /// </summary>
        protected Class1()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Class1 class.
        /// </summary>
        protected internal Class1()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Class1 class.
        /// </summary>
        internal protected Class1()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Class1 class.
        /// </summary>
        /// <param name="x">Some parameter.</param>
        private Class1(int x)
        {
        }

        /// <summary>
        /// Prevents a default instance of the Class1 class from being created.
        /// </summary>
        private Class1()
        {
        }

        /// <summary>
        /// Initializes static members of the Class1 class.
        /// </summary>
        public static Class1()
        {
        }

        /// <summary>
        /// Initializes static members of the Class1 class.
        /// </summary>
        internal static Class1()
        {
        }

        /// <summary>
        /// Initializes static members of the Class1 class.
        /// </summary>
        protected static Class1()
        {
        }

        /// <summary>
        /// Initializes static members of the Class1 class.
        /// </summary>
        protected internal static Class1()
        {
        }

        /// <summary>
        /// Initializes static members of the Class1 class.
        /// </summary>
        internal protected static Class1()
        {
        }

        /// <summary>
        /// Initializes static members of the Class1 class.
        /// </summary>
        private static Class1()
        {
        }
    }

    /// <summary>
    /// Invalid constructor headers.
    /// </summary>
    public class Class2
    {
        /// <summary>
        /// Some other wording.
        /// </summary>
        public Class2()
        {
        }

        /// <summary>
        /// Initializes a new instance of the WrongClassName class
        /// </summary>
        protected Class2()
        {
        }

        /// <summary>
        ///               Initializes a new instance of the Class1 class               .
        /// </summary>
        internal Class2()
        {
        }

        /// <summary>
        /// Prevents a dadefault instance of the Class2 class from being created
        /// </summary>
        private Class2()
        {
        }

        /// <summary>
        /// prevents a default instance of the Class2 class from being created
        /// </summary>
        private Class2()
        {
        }

        /// <summary>
        /// Prevents a default instance of the WrongName class from being created.
        /// </summary>
        private Class2()
        {
        }

        /// <summary>
        /// Initializes static members of the ClassX class.
        /// </summary>
        public static Class2()
        {
        }

        /// <summary>
        /// Blah.
        /// </summary>
        internal static Class2()
        {
        }
    }

    /// <summary>
    /// Constructor headers containing cref tags.
    /// </summary>
    public class Class3
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Class3"/> class.
        /// </summary>
        public Class3()
        {
        }

        /// <summary>
        /// Initializes static members of the <see cref="Class3"></see> class.
        /// </summary>
        public static Class3()
        {
        }
    }

    /// <summary>
    /// Valid constructor headers within a struct.
    /// </summary>
    public struct Struct1
    {
        /// <summary>
        /// Initializes a new instance of the Struct1 struct.
        /// </summary>
        /// <param name="x">Some integer.</param>
        public Struct1(int x)
        {
        }

        /// <summary>
        /// Prevents a default instance of the Struct1 struct from being created.
        /// </summary>
        private Struct1()
        {
        }

        /// <summary>
        /// Initializes static members of the Struct1 struct.
        /// </summary>
        static Struct1()
        {
        }
    }

    public class ConstructorSummaryOnMultipleLines
    {
        /// <summary>
        /// Initializes a new instance of the ConstructorSummaryOnMultipleLines class.
        /// </summary>
        /// <param name="x">A parameter.</param>
        public ConstructorSummaryOnMultipleLines(int x)
        {
        }

        /// <summary>
        /// Initializes a new instance of 
        /// the ConstructorSummaryOnMultipleLines class.
        /// </summary>
        /// <param name="x">A parameter.</param>
        /// <remarks>This summary is valid.</remarks>
        public ConstructorSummaryOnMultipleLines(short x)
        {
        }

        /// <summary>
        /// Initializes a new instance of
        ///  the ConstructorSummaryOnMultipleLines 
        /// class.
        /// </summary>
        /// <param name="x">A parameter.</param>
        /// <remarks>This summary is valid. The second line begins with a space
        /// but there is no space at the end of the first line.</remarks>
        public ConstructorSummaryOnMultipleLines(long x)
        {
        }

        /// <summary>
        /// Initializes a new instance of the 
        ///    ConstructorSummaryOnMultipleLines class.
        /// </summary>
        /// <param name="x">A parameter.</param>
        /// <remarks>This summary is invalid because of extra spaces at the start of the second line.</remarks>
        public ConstructorSummaryOnMultipleLines(bool x)
        {
        }

        /// <summary>
        /// Initializes a new instance of     
        /// the ConstructorSummaryOnMultipleLines class.
        /// </summary>
        /// <param name="x">A parameter.</param>
        /// <remarks>This summary is invalid because there is extra space at the end of the first line.</remarks>
        public ConstructorSummaryOnMultipleLines(string x)
        {
        }

        /// <summary>
        /// Initializes a new instance of the 
        /// 
        /// ConstructorSummaryOnMultipleLines class.
        /// </summary>
        /// <param name="x">A parameter.</param>
        /// <remarks>This summary is actually considered valid, because when the extra
        /// whitespace at the beginning of each line is stripped away, the summary text matches
        /// the expected text.</remarks>
        public ConstructorSummaryOnMultipleLines(char x)
        {
        }
    }

    public class NestedClassesConstructorSummary
    {
        private class Class1
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="NestedClassesConstructorSummary.Class1"/> class.
            /// </summary>
            /// <remarks>valid</remarks>
            public Class1()
            {
            }

            private class Class2
            {
                /// <summary>
                /// Initializes a new instance of the <see cref="NestedClassesConstructorSummary.Class1.Class2"/> class.
                /// </summary>
                /// <remarks>valid</remarks>
                public Class2()
                {
                }
            }
        }

        private class Class3
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="CSharpAnalyzersTest.TestData.NestedClassesConstructorSummary.Class3"/> class.
            /// </summary>
            /// <remarks>valid</remarks>
            public Class3()
            {
            }
            private class Class4
            {
                /// <summary>
                /// Initializes a new instance of the <see cref="CSharpAnalyzersTest.TestData.NestedClassesConstructorSummary.Class3.Class4"/> class.
                /// </summary>
                /// <remarks>valid</remarks>
                public Class4()
                {
                }
            }
        }

        private class Class5
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="TestData.NestedClassesConstructorSummary.Class5"/> class.
            /// </summary>
            /// <remarks>valid</remarks>
            public Class5()
            {
            }

            private class Class6
            {
                /// <summary>
                /// Initializes a new instance of the <see cref="TestData.NestedClassesConstructorSummary.Class5.Class6"/> class.
                /// </summary>
                /// <remarks>valid</remarks>
                public Class6()
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref="Class6"/> class.
                /// </summary>
                /// <remarks>valid</remarks>
                public Class6(int a)
                {
                }
            }
        }
    }
}
