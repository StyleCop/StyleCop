using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class NonPrivateFields
    {
        // These should throw violations.
        public int publicAccessModifier;
        internal int internalAccessModifier;
        protected int protectedAccessModifier;

        public static int publicStaticAccessModifier;
        internal static int internalStaticAccessModifier;
        protected static int protectedStaticAccessModifier;

        // These should not throw violations.
        private int privateAccessModifier;
        private static int privateStaticAccessModifier;

        // This should not throw a violation.
        public const int publicConst = 0;

        public struct MyInternalStruct
        {
            // This should not throw a violation.
            public int privateStructField;
        }

        public class MyInternalClass
        {
            // These should throw violations.
            public int publicAccessModifier;
            internal int internalAccessModifier;
            protected int protectedAccessModifier;

            public static int publicStaticAccessModifier;
            internal static int internalStaticAccessModifier;
            protected static int protectedStaticAccessModifier;

            // These should not throw violations.
            private int privateAccessModifier;
            private static int privateStaticAccessModifier;

            // This should not throw a violation.
            public const int publicConst = 0;

            // Should not throw a violation.
            public static readonly int publicStaticReadOnlyField;
        }
    }
}
