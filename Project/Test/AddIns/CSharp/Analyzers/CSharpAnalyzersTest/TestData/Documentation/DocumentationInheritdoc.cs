using System;

namespace CSharpAnalyzersTest.ValidTestData
{
    /// <inheritdoc />
    public class ValidInheritDoc1 : SomeClass
    {
        /// <inheritdoc />
        public void Method1()
        {
        }
    }

    /// <inheritdoc />
    public interface ValidInheritDoc2 : ISomeInterface
    {
    }

    /// <inheritdoc />
    public class ValidInheritDoc3 : SomeClass, IWhatever
    {
        /// <inheritdoc />
        public void Method1()
        {
        }
    }

    /// <inheritdoc />
    public interface ValidInheritDoc4 : ISomeInterface, IWhatever
    {
    }
}

namespace CSharpAnalyzersTest.InvalidTestData
{
    /// <inheritdoc />
    public delegate void Handler();

    /// <inheritdoc />
    public enum Enum1
    {
    }

    public enum Enum2
    {
        /// <inheritdoc />
        Item
    }

    /// <inheritdoc />
    public class InvalidInheritDoc1
    {
    }

    /// <inheritdoc />
    public struct InvalidInheritDoc2
    {
    }

    /// <inheritdoc />
    public interface InvalidInheritDoc3
    {
    }

    public class InvalidInheritDoc4
    {
        /// <inheritdoc />
        public void Method1()
        {
        }
    }

    public interface InvalidInheritDoc5
    {
        /// <inheritdoc />
        public void Method1();
    }

    public interface InvalidInheritDoc6 : IWhatever
    {
        /// <inheritdoc />
        public void Method1();
    }

    public struct InvalidInheritDoc7 : IWhatever
    {
        /// <inheritdoc />
        public void Method1();
    }

    public class InvalidInheritDoc8 : BaseClass
    {
        public class InternalClass
        {
            /// <inheritdoc />
            public void Method1();
        }
    }
}