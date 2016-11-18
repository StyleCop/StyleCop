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
    public class ValidInheritDoc2 : ISomeInterface
    {
        /// <inheritdoc />
        public void Method1()
        {
        }
    }

    /// <inheritdoc />
    public interface ValidInheritDoc3 : ISomeInterface
    {
    }

    /// <inheritdoc />
    public class ValidInheritDoc4 : SomeClass, IWhatever
    {
        /// <inheritdoc />
        public void Method1()
        {
        }
    }

    /// <inheritdoc />
    public interface ValidInheritDoc5 : ISomeInterface, IWhatever
    {
    }

    public interface ValidInheritDoc6 : IWhatever
    {
        /// <inheritdoc />
        public void Method1();
    }

    /// <inheritdoc />
    public struct ValidInheritDoc7 : IWhatever
    {
        /// <inheritdoc />
        public void Method1();
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
    
    public class InvalidInheritDoc6 : BaseClass
    {
        public class InternalClass
        {
            /// <inheritdoc />
            public void Method1();
        }
    }
    public class ValidInheritDoc6
    {
        public class InternalClass
        {
            /// <inheritdoc />
            public override bool Equals(object obj)
            {
            }

            /// <inheritdoc />
            public override int GetHashCode()
            {
            }

            /// <inheritdoc />
            public override string ToString()
            {
            }
        }
    }

    public class InvalidInheritDoc6
    {
        public class InternalClass
        {
            /// <inheritdoc />
            public bool Equals(Object obj)
            {
            }            

            /// <inheritdoc />
            public override bool Equals(object obj1, object obj2)
            {
            }

            /// <inheritdoc />
            public override int GetHashCode(string a)
            {
            }

            /// <inheritdoc />
            public override string ToString(bool a)
            {
            }
        }
    }
}

namespace CSharpAnalyzersTest.ValidTestData2
{
    /// <summary>
    /// A demonstration interface.
    /// </summary>
    public interface ICanHasCheezBurger
    {
        /// <summary>
        /// Eat something.
        /// </summary>
        void Eat();

        /// <summary>
        /// Sleep, usually after eating.
        /// </summary>
        void Sleep();
    }

    /// <summary>
    /// Represents a feline.
    /// </summary>
    public partial class Cat : ICanHasCheezBurger
    {
        /// <inheritdoc />
        public void Eat()
        {
        }
    }

    /// <summary>
    /// Represents a feline.
    /// </summary>
    public partial class Cat
    {
        /// <inheritdoc />
        public void Sleep()
        {
            // Inheritdoc is valid here as the other partial class implements an interface
        }
    }

    // Inheritdoc is valid here because of the cref.
    /// <inheritdoc cref="ICanHasCheezBurger" />
    public class ValidInheritDoc1
    {
        /// <inheritdoc cref="ICanHasCheezBurger.Eat" />
        public void Method1();
    }
}