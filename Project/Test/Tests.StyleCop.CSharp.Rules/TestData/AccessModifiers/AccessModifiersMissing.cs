using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    #region Missing Access Modifiers

    delegate void TopLevelDelegateMissingAccessModifier();

    enum TopLevelEnumMissingAccessModifier
    {
    }

    class ClassMissingAccessModifier
    {
        int fieldMissingAccessModifier;

        const int constFieldMissingAccessModifier = 1;

        readonly int readonlyFieldMissingAccessModifier = 2;

        ClassMissingAccessModifier()
        {
        }

        delegate void DelegateMissingAccessModifier();

        event DelegateMissingAccessModifier EventMissingAccessModifier;

        enum EnumMissingAccessModifier
        {
        }

        bool PropertyMissingAccessModifier
        {
            get
            {
                return true;
            }
        }

        void MethodMissingAccessModifier()
        {
        }

        struct StructMissingAccessModifier
        {
        }

        class InternalClassMissingAccessModifier
        {
            int internalFieldMissingAccessModifier;

            InternalClassMissingAccessModifier()
            {
            }

            delegate void InternalDelegateMissingAccessModifier();

            event InternalDelegateMissingAccessModifier InternalEventMissingAccessModifier;

            enum InternalEnumMissingAccessModifier
            {
            }

            bool InternalPropertyMissingAccessModifier
            {
                get
                {
                    return true;
                }
            }

            void InternalMethodMissingAccessModifier()
            {
            }

            struct InternalStructMissingAccessModifier
            {
            }
        }

        static int staticFieldMissingAccessModifier;

        static void StaticClassMissingAccessModifier()
        {
        }

        static bool StaticPropertyMissingAccessModifier
        {
            get
            {
                return true;
            }
        }

        static void StaticMethodMissingAccessModifier()
        {
        }
    }

    #endregion Missing Access Modifiers

    #region Having Access Modifiers

    public delegate void TopLevelDelegateMissingAccessModifier();

    public enum TopLevelEnumMissingAccessModifier
    {
    }

    public class ClassMissingAccessModifier
    {
        private int fieldMissingAccessModifier;

        public const int constFieldMissingAccessModifier = 1;

        public readonly int readonlyFieldMissingAccessModifier = 2;

        public ClassMissingAccessModifier()
        {
        }

        public delegate void DelegateMissingAccessModifier();

        public event DelegateMissingAccessModifier EventMissingAccessModifier;

        public enum EnumMissingAccessModifier
        {
        }

        public bool PropertyMissingAccessModifier
        {
            get
            {
                return true;
            }
        }

        public void MethodMissingAccessModifier()
        {
        }

        public struct StructMissingAccessModifier
        {
        }

        public class InternalClassMissingAccessModifier
        {
            private int internalFieldMissingAccessModifier;

            public InternalClassMissingAccessModifier()
            {
            }

            public delegate void InternalDelegateMissingAccessModifier();

            public event InternalDelegateMissingAccessModifier InternalEventMissingAccessModifier;

            public enum InternalEnumMissingAccessModifier
            {
            }

            public bool InternalPropertyMissingAccessModifier
            {
                get
                {
                    return true;
                }
            }

            public void InternalMethodMissingAccessModifier()
            {
            }

            public struct InternalStructMissingAccessModifier
            {
            }
        }

        public static int staticFieldMissingAccessModifier;

        public static void StaticClassMissingAccessModifier()
        {
        }

        public static bool StaticPropertyMissingAccessModifier
        {
            get
            {
                return true;
            }
        }

        public static void StaticMethodMissingAccessModifier()
        {
        }
    }

    #endregion Having Access Modifiers

    #region Partial Methods

    public partial class Hello
    {
        // Does not require an access modifier.
        partial void Method1()
        {
        }

        // Requires an access modifier.
        void Method2()
        {
        }
    }

    #endregion Partial Methods
}
