using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    #region Test that we still get errors when headers are missing for public, protected, protected internal, and internal elements.
    
    public class InvalidDocumentationIgnorePrivatesClass1
    {
    }

    protected class InvalidDocumentationIgnorePrivatesClass2
    {
    }

    protected internal class InvalidDocumentationIgnorePrivatesClass3
    {
    }

    public struct InvalidDocumentationIgnorePrivatesStruct1
    {
    }

    protected struct InvalidDocumentationIgnorePrivatesStruct2
    {
    }

    internal struct InvalidDocumentationIgnorePrivatesStruct3
    {
    }

    public interface InvalidDocumentationIgnorePrivatesInterface1
    {
    }

    protected interface InvalidDocumentationIgnorePrivatesInterface2
    {
    }

    protected internal interface InvalidDocumentationIgnorePrivatesInterface3
    {
    }

    public enum InvalidDocumentationIgnorePrivatesEnum1
    {
    }

    protected enum InvalidDocumentationIgnorePrivatesEnum2
    {
    }

    internal enum InvalidDocumentationIgnorePrivatesEnum3
    {
    }

    /// <summary>
    /// This is a header.
    /// </summary>
    public enum InvalidDocumentationIgnorePrivatesEnum4
    {
        Item
    }

    /// <summary>
    /// This is a header.
    /// </summary>
    protected enum InvalidDocumentationIgnorePrivatesEnum5
    {
        Item
    }

    /// <summary>
    /// This is a header.
    /// </summary>
    protected internal enum InvalidDocumentationIgnorePrivatesEnum6
    {
        Item
    }

    public delegate void InvalidDocumentationIgnorePrivatesDelegate1();

    protected delegate void InvalidDocumentationIgnorePrivatesDelegate2();

    internal delegate void InvalidDocumentationIgnorePrivatesDelegate3();

    #endregion

    #region Test that headers are still required for public, protected, and internal items inside of a protected class.

    /// <summary>
    /// This is the summary.
    /// </summary>
    protected class InvalidDocumentationIgnorePrivatesProtectedClass1
    {
        public class InvalidDocumentationIgnorePrivatesClass1
        {
        }

        protected class InvalidDocumentationIgnorePrivatesClass2
        {
        }

        protected internal class InvalidDocumentationIgnorePrivatesClass3
        {
        }

        public struct InvalidDocumentationIgnorePrivatesStruct1
        {
        }

        protected struct InvalidDocumentationIgnorePrivatesStruct2
        {
        }

        internal struct InvalidDocumentationIgnorePrivatesStruct3
        {
        }

        public interface InvalidDocumentationIgnorePrivatesInterface1
        {
        }

        protected interface InvalidDocumentationIgnorePrivatesInterface2
        {
        }

        protected internal interface InvalidDocumentationIgnorePrivatesInterface3
        {
        }

        public enum InvalidDocumentationIgnorePrivatesEnum1
        {
        }

        protected enum InvalidDocumentationIgnorePrivatesEnum2
        {
        }

        internal enum InvalidDocumentationIgnorePrivatesEnum3
        {
        }

        /// <summary>
        /// This is a header.
        /// </summary>
        public enum InvalidDocumentationIgnorePrivatesEnum4
        {
            Item
        }

        /// <summary>
        /// This is a header.
        /// </summary>
        protected enum InvalidDocumentationIgnorePrivatesEnum5
        {
            Item
        }

        /// <summary>
        /// This is a header.
        /// </summary>
        internal enum InvalidDocumentationIgnorePrivatesEnum6
        {
            Item
        }

        public delegate void InvalidDocumentationIgnorePrivatesDelegate1();

        protected delegate void InvalidDocumentationIgnorePrivatesDelegate2();

        protected internal delegate void InvalidDocumentationIgnorePrivatesDelegate3();

        public InvalidDocumentationIgnorePrivatesProtectedClass1(int x)
        {
        }

        protected InvalidDocumentationIgnorePrivatesProtectedClass1(short x)
        {
        }

        protected internal InvalidDocumentationIgnorePrivatesProtectedClass1(long x)
        {
        }

        public event EventHandler InvalidDocumentationIgnorePrivatesEvent1;

        protected event EventHandler InvalidDocumentationIgnorePrivatesEvent2;

        internal event EventHandler InvalidDocumentationIgnorePrivatesEvent3;

        public int this[int x]
        {
            get { return 0; }
        }

        protected int this[short x]
        {
            get { return 0; }
        }

        protected internal int this[long x]
        {
            get { return 0; }
        }

        public int InvalidDocumentationIgnorePrivatesProperty1
        {
            get { return 0; }
        }

        protected int InvalidDocumentationIgnorePrivatesProperty2
        {
            get { return 0; }
        }

        internal int InvalidDocumentationIgnorePrivatesProperty3
        {
            get { return 0; }
        }

        public int InvalidDocumentationIgnorePrivatesMethod1()
        {
            return 0;
        }

        protected int InvalidDocumentationIgnorePrivatesMethod2()
        {
            return 0;
        }

        protected internal int InvalidDocumentationIgnorePrivatesMethod3()
        {
            return 0;
        }

        public int InvalidDocumentationIgnorePrivatesField1;

        protected int InvalidDocumentationIgnorePrivatesField2;

        internal int InvalidDocumentationIgnorePrivatesField3;
    }

    #endregion 

    #region Test that we are allowed to have private elements without headers

    private class ValidDocumentationIgnorePrivatesClass1
    {
    }

    private class ValidDocumentationIgnorePrivatesClass2
    {
    }

    private struct ValidDocumentationIgnorePrivatesStruct1
    {
    }

    private struct ValidDocumentationIgnorePrivatesStruct2
    {
    }

    private interface ValidDocumentationIgnorePrivatesInterface1
    {
    }

    private interface ValidDocumentationIgnorePrivatesInterface2
    {
    }

    private enum ValidDocumentationIgnorePrivatesEnum1
    {
    }

    private enum ValidDocumentationIgnorePrivatesEnum2
    {
    }

    /// <summary>
    /// This is a header.
    /// </summary>
    private enum ValidDocumentationIgnorePrivatesEnum4
    {
        Item
    }

    /// <summary>
    /// This is a header.
    /// </summary>
    private enum ValidDocumentationIgnorePrivatesEnum5
    {
        Item
    }

    private delegate void ValidDocumentationIgnorePrivatesDelegate1();

    private delegate void ValidDocumentationIgnorePrivatesDelegate2();

    #endregion

    #region Test that we are allowed to have missing headers for private items within a protected class.

    /// <summary>
    /// This is the summary.
    /// </summary>
    protected class ValidDocumentationIgnorePrivatesProtectedClass1
    {
        private class ValidDocumentationIgnorePrivatesClass1
        {
        }

        private class ValidDocumentationIgnorePrivatesClass2
        {
        }

        private struct ValidDocumentationIgnorePrivatesStruct1
        {
        }

        private struct ValidDocumentationIgnorePrivatesStruct2
        {
        }

        private interface ValidDocumentationIgnorePrivatesInterface1
        {
        }

        private interface ValidDocumentationIgnorePrivatesInterface2
        {
        }

        private enum ValidDocumentationIgnorePrivatesEnum1
        {
        }

        private enum ValidDocumentationIgnorePrivatesEnum2
        {
        }

        /// <summary>
        /// This is a header.
        /// </summary>
        private enum ValidDocumentationIgnorePrivatesEnum4
        {
            Item
        }

        /// <summary>
        /// This is a header.
        /// </summary>
        private enum ValidDocumentationIgnorePrivatesEnum5
        {
            Item
        }

        private delegate void ValidDocumentationIgnorePrivatesDelegate1();

        private delegate void ValidDocumentationIgnorePrivatesDelegate2();

        private ValidDocumentationIgnorePrivatesProtectedClass1(int x)
        {
        }

        private ValidDocumentationIgnorePrivatesProtectedClass1(short x)
        {
        }

        private event EventHandler ValidDocumentationIgnorePrivatesEvent1;

        private event EventHandler ValidDocumentationIgnorePrivatesEvent2;

        private int this[int x]
        {
            get { return 0; }
        }

        private int this[short x]
        {
            get { return 0; }
        }

        private int ValidDocumentationIgnorePrivatesProperty1
        {
            get { return 0; }
        }

        private int ValidDocumentationIgnorePrivatesProperty2
        {
            get { return 0; }
        }

        private int ValidDocumentationIgnorePrivatesMethod1()
        {
            return 0;
        }

        private int ValidDocumentationIgnorePrivatesMethod2()
        {
            return 0;
        }

        private int ValidDocumentationIgnorePrivatesField1;

        private int ValidDocumentationIgnorePrivatesField2;
    }

    #endregion

    #region Test that we get errors for private items which have invalid headers.

    /// <remarks>
    /// The summary tag is missing.
    /// </remarks>
    private class ValidDocumentationIgnorePrivatesClass1
    {
    }

    /// <remarks>
    /// The summary tag is missing.
    /// </remarks>
    private class ValidDocumentationIgnorePrivatesClass2
    {
    }

    /// <remarks>
    /// The summary tag is missing.
    /// </remarks>
    private struct ValidDocumentationIgnorePrivatesStruct1
    {
    }

    /// <remarks>
    /// The summary tag is missing.
    /// </remarks>
    private struct ValidDocumentationIgnorePrivatesStruct2
    {
    }

    /// <remarks>
    /// The summary tag is missing.
    /// </remarks>
    private interface ValidDocumentationIgnorePrivatesInterface1
    {
    }

    /// <remarks>
    /// The summary tag is missing.
    /// </remarks>
    private interface ValidDocumentationIgnorePrivatesInterface2
    {
    }

    /// <remarks>
    /// The summary tag is missing.
    /// </remarks>
    private enum ValidDocumentationIgnorePrivatesEnum1
    {
    }

    /// <remarks>
    /// The summary tag is missing.
    /// </remarks>
    private enum ValidDocumentationIgnorePrivatesEnum2
    {
    }

    /// <summary>
    /// This is a header.
    /// </summary>
    private enum ValidDocumentationIgnorePrivatesEnum4
    {
        /// <remarks>
        /// The summary tag is missing.
        /// </remarks>
        Item
    }

    /// <summary>
    /// This is a header.
    /// </summary>
    private enum ValidDocumentationIgnorePrivatesEnum5
    {
        /// <remarks>
        /// The summary tag is missing.
        /// </remarks>
        Item
    }

    /// <remarks>
    /// The summary tag is missing.
    /// </remarks>
    private delegate void ValidDocumentationIgnorePrivatesDelegate1();

    /// <remarks>
    /// The summary tag is missing.
    /// </remarks>
    private delegate void ValidDocumentationIgnorePrivatesDelegate2();

    #endregion

    #region Test that we get errors for all items which have invalid headers, inside of a private class.

    /// <summary>
    /// This is the summary.
    /// </summary>
    private class InvalidDocumentationIgnorePrivatesProtectedClass4
    {
        /// <summary>
        /// 
        /// </summary>
        public class InvalidDocumentationIgnorePrivatesClass1
        {
        }

        /// <summary>
        /// 
        /// </summary>
        protected class InvalidDocumentationIgnorePrivatesClass2
        {
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal class InvalidDocumentationIgnorePrivatesClass3
        {
        }

        /// <summary>
        /// 
        /// </summary>
        internal class InvalidDocumentationIgnorePrivatesClass4
        {
        }

        /// <summary>
        /// 
        /// </summary>
        private class InvalidDocumentationIgnorePrivatesClass5
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public struct InvalidDocumentationIgnorePrivatesStruct1
        {
        }

        /// <summary>
        /// 
        /// </summary>
        protected struct InvalidDocumentationIgnorePrivatesStruct2
        {
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal struct InvalidDocumentationIgnorePrivatesStruct3
        {
        }

        /// <summary>
        /// 
        /// </summary>
        internal struct InvalidDocumentationIgnorePrivatesStruct4
        {
        }

        /// <summary>
        /// 
        /// </summary>
        private struct InvalidDocumentationIgnorePrivatesStruct5
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public interface InvalidDocumentationIgnorePrivatesInterface1
        {
        }

        /// <summary>
        /// 
        /// </summary>
        protected interface InvalidDocumentationIgnorePrivatesInterface2
        {
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal interface InvalidDocumentationIgnorePrivatesInterface3
        {
        }

        /// <summary>
        /// 
        /// </summary>
        internal interface InvalidDocumentationIgnorePrivatesInterface4
        {
        }

        /// <summary>
        /// 
        /// </summary>
        private interface InvalidDocumentationIgnorePrivatesInterface5
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public enum InvalidDocumentationIgnorePrivatesEnum1
        {
        }

        /// <summary>
        /// 
        /// </summary>
        protected enum InvalidDocumentationIgnorePrivatesEnum2
        {
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal enum InvalidDocumentationIgnorePrivatesEnum3
        {
        }

        /// <summary>
        /// 
        /// </summary>
        internal enum InvalidDocumentationIgnorePrivatesEnum4
        {
        }

        /// <summary>
        /// 
        /// </summary>
        private enum InvalidDocumentationIgnorePrivatesEnum5
        {
        }

        /// <summary>
        /// This is a header.
        /// </summary>
        public enum InvalidDocumentationIgnorePrivatesEnum6
        {
            /// <summary>
            /// 
            /// </summary>
            Item
        }

        /// <summary>
        /// This is a header.
        /// </summary>
        protected enum InvalidDocumentationIgnorePrivatesEnum7
        {
            /// <summary>
            /// 
            /// </summary>
            Item
        }

        /// <summary>
        /// This is a header.
        /// </summary>
        protected internal enum InvalidDocumentationIgnorePrivatesEnum8
        {
            /// <summary>
            /// 
            /// </summary>
            Item
        }

        /// <summary>
        /// This is a header.
        /// </summary>
        internal enum InvalidDocumentationIgnorePrivatesEnum9
        {
            /// <summary>
            /// 
            /// </summary>
            Item
        }

        /// <summary>
        /// This is a header.
        /// </summary>
        private enum InvalidDocumentationIgnorePrivatesEnum10
        {
            /// <summary>
            /// 
            /// </summary>
            Item
        }

        /// <summary>
        /// 
        /// </summary>
        public delegate void InvalidDocumentationIgnorePrivatesDelegate1();

        /// <summary>
        /// 
        /// </summary>
        protected delegate void InvalidDocumentationIgnorePrivatesDelegate2();

        /// <summary>
        /// 
        /// </summary>
        protected internal delegate void InvalidDocumentationIgnorePrivatesDelegate3();

        /// <summary>
        /// 
        /// </summary>
        internal delegate void InvalidDocumentationIgnorePrivatesDelegate();

        /// <summary>
        /// 
        /// </summary>
        private delegate void InvalidDocumentationIgnorePrivatesDelegate();

        /// <summary>
        /// 
        /// </summary>
        public InvalidDocumentationIgnorePrivatesProtectedClass4(int x)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        protected InvalidDocumentationIgnorePrivatesProtectedClass4(short x)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal InvalidDocumentationIgnorePrivatesProtectedClass4(long x)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        internal InvalidDocumentationIgnorePrivatesProtectedClass4(byte x)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        private InvalidDocumentationIgnorePrivatesProtectedClass4(char x)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler InvalidDocumentationIgnorePrivatesEvent1;

        /// <summary>
        /// 
        /// </summary>
        protected event EventHandler InvalidDocumentationIgnorePrivatesEvent2;

        /// <summary>
        /// 
        /// </summary>
        protected internal event EventHandler InvalidDocumentationIgnorePrivatesEvent3;

        /// <summary>
        /// 
        /// </summary>
        internal event EventHandler InvalidDocumentationIgnorePrivatesEvent4;

        /// <summary>
        /// 
        /// </summary>
        private event EventHandler InvalidDocumentationIgnorePrivatesEvent5;

        /// <summary>
        /// 
        /// </summary>
        public int this[int x]
        {
            get { return 0; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected int this[short x]
        {
            get { return 0; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal int this[long x]
        {
            get { return 0; }
        }

        /// <summary>
        /// 
        /// </summary>
        internal int this[char x]
        {
            get { return 0; }
        }

        /// <summary>
        /// 
        /// </summary>
        private int this[byte x]
        {
            get { return 0; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int InvalidDocumentationIgnorePrivatesProperty1
        {
            get { return 0; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected int InvalidDocumentationIgnorePrivatesProperty2
        {
            get { return 0; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal int InvalidDocumentationIgnorePrivatesProperty3
        {
            get { return 0; }
        }

        /// <summary>
        /// 
        /// </summary>
        internal int InvalidDocumentationIgnorePrivatesProperty4
        {
            get { return 0; }
        }

        /// <summary>
        /// 
        /// </summary>
        private int InvalidDocumentationIgnorePrivatesProperty5
        {
            get { return 0; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int InvalidDocumentationIgnorePrivatesMethod1()
        {
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        protected int InvalidDocumentationIgnorePrivatesMethod2()
        {
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal int InvalidDocumentationIgnorePrivatesMethod3()
        {
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        internal int InvalidDocumentationIgnorePrivatesMethod4()
        {
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        private int InvalidDocumentationIgnorePrivatesMethod5()
        {
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        public int InvalidDocumentationIgnorePrivatesField1;

        /// <summary>
        /// 
        /// </summary>
        protected int InvalidDocumentationIgnorePrivatesField2;

        /// <summary>
        /// 
        /// </summary>
        protected internal int InvalidDocumentationIgnorePrivatesField3;

        /// <summary>
        /// 
        /// </summary>
        internal int InvalidDocumentationIgnorePrivatesField4;

        /// <summary>
        /// 
        /// </summary>
        private int InvalidDocumentationIgnorePrivatesField5;
    }

    #endregion

    #region Test that headers are still required for public, protected, and internal items inside of a class which has no access modifier.

    /// <summary>
    /// This is the summary.
    /// </summary>
    class InvalidDocumentationIgnorePrivatesClassMissingAccessModifer1
    {
        public class InvalidDocumentationIgnorePrivatesClass1
        {
        }

        protected class InvalidDocumentationIgnorePrivatesClass2
        {
        }

        internal class InvalidDocumentationIgnorePrivatesClass3
        {
        }

        public struct InvalidDocumentationIgnorePrivatesStruct1
        {
        }

        protected struct InvalidDocumentationIgnorePrivatesStruct2
        {
        }

        protected internal struct InvalidDocumentationIgnorePrivatesStruct3
        {
        }

        public interface InvalidDocumentationIgnorePrivatesInterface1
        {
        }

        protected interface InvalidDocumentationIgnorePrivatesInterface2
        {
        }

        internal interface InvalidDocumentationIgnorePrivatesInterface3
        {
        }

        public enum InvalidDocumentationIgnorePrivatesEnum1
        {
        }

        protected enum InvalidDocumentationIgnorePrivatesEnum2
        {
        }

        protected internal enum InvalidDocumentationIgnorePrivatesEnum3
        {
        }

        /// <summary>
        /// This is a header.
        /// </summary>
        public enum InvalidDocumentationIgnorePrivatesEnum4
        {
            Item
        }

        /// <summary>
        /// This is a header.
        /// </summary>
        protected enum InvalidDocumentationIgnorePrivatesEnum5
        {
            Item
        }

        /// <summary>
        /// This is a header.
        /// </summary>
        internal enum InvalidDocumentationIgnorePrivatesEnum6
        {
            Item
        }

        public delegate void InvalidDocumentationIgnorePrivatesDelegate1();

        protected delegate void InvalidDocumentationIgnorePrivatesDelegate2();

        protected internal delegate void InvalidDocumentationIgnorePrivatesDelegate3();

        public InvalidDocumentationIgnorePrivatesClassMissingAccessModifer1(int x)
        {
        }

        protected InvalidDocumentationIgnorePrivatesClassMissingAccessModifer1(short x)
        {
        }

        internal InvalidDocumentationIgnorePrivatesClassMissingAccessModifer1(long x)
        {
        }

        public event EventHandler InvalidDocumentationIgnorePrivatesEvent1;

        protected event EventHandler InvalidDocumentationIgnorePrivatesEvent2;

        protected internal event EventHandler InvalidDocumentationIgnorePrivatesEvent3;

        public int this[int x]
        {
            get { return 0; }
        }

        protected int this[short x]
        {
            get { return 0; }
        }

        internal int this[long x]
        {
            get { return 0; }
        }

        public int InvalidDocumentationIgnorePrivatesProperty1
        {
            get { return 0; }
        }

        protected int InvalidDocumentationIgnorePrivatesProperty2
        {
            get { return 0; }
        }

        internal int InvalidDocumentationIgnorePrivatesProperty3
        {
            get { return 0; }
        }

        public int InvalidDocumentationIgnorePrivatesMethod1()
        {
            return 0;
        }

        protected int InvalidDocumentationIgnorePrivatesMethod2()
        {
            return 0;
        }

        protected internal int InvalidDocumentationIgnorePrivatesMethod3()
        {
            return 0;
        }

        public int InvalidDocumentationIgnorePrivatesField1;

        protected int InvalidDocumentationIgnorePrivatesField2;

        internal int InvalidDocumentationIgnorePrivatesField3;
    }

    #endregion 

    #region Test that headers are still required for public, protected and internal items inside of a struct which has no access modifier.

    /// <summary>
    /// This is the summary.
    /// </summary>
    struct InvalidDocumentationIgnorePrivatesStructMissingAccessModifer1
    {
        public int Field1;
    }

    #endregion

    #region Tests that headers are not required for classes, structs, and interfaces, even if they are private
    /// <summary>
    /// This is header for this class.
    /// </summary>
    public class InvalidDocumentationIgnorePrivatesPrivateClassInterfaceAndStruct
    {
        private class PrivateClassMissingHeader
        {
        }

        private interface PrivateInterfaceMissingHeader
        {
        }

        private struct PrivateStructMissingHeader
        {
        }

        /// <summary>
        /// 
        /// </summary>
        private class PrivateClassEmptyHeader
        {
        }

        /// <summary>
        /// 
        /// </summary>
        private interface PrivateInterfaceEmptyHeader
        {
        }

        /// <summary>
        /// 
        /// </summary>
        private struct PrivateStructEmptyHeader
        {
        }
    }

    #endregion
}
