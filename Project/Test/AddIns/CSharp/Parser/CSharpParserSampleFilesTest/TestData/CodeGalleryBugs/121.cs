// <copyright file="Program.cs" company="Nobody">
// Copyright © Nobody
// </copyright>
// <author>Nick Lowe</author>
// <email>foo@bar.com</email>
// <date>2008-10-2</date>
// <summary>SA0102 with a nullable generic type reference test.</summary>

namespace BugTest
{
    /// <summary>Program class.</summary>
    public class Program
    {
        /// <summary>Main method.</summary>
        public static void Main()
        {
            // The following will cause a SA0102: A syntax error has been discovered in file.
            // It does not matter if the generic type is a value or reference type.
            // (Uncomment to test.)

            // Foo<short>? foo1 = new Foo<short>();
            // Foo<Bar>? foo2 = new Foo<Bar>();

            // From the constructor for Qux, we can see that this appears to be an issue for variable declaration.
            // We do not get a SA0102 in the Qux class.
            // (Uncomment to test.)

            // new Qux<short>(new Baz<short>());
        }

        /// <summary>Foo struct.</summary>
        /// <typeparam name="T">Generic type.</typeparam>
        public struct Foo<T>
        {
        }

        /// <summary>Baz class.</summary>
        /// <typeparam name="T">Some type.</typeparam>
        public struct Baz<T>
        {
            /// <summary>Generic value.</summary>
            private T value;

            /// <summary>Initializes a new instance of the Baz struct.</summary>
            /// <param name="value">Generic value.</param>
            public Baz(T value)
            {
                this.value = value;
            }

            /// <summary>Gets or sets the value;</summary>
            /// <typeparam name="T">Some type.</typeparam>
            /// <value>The value.</value>
            public T Value
            {
                get { return this.value; }
                set { this.value = value; }
            }
        }

        /// <summary>Bar class.</summary>
        public class Bar
        {
        }

        /// <summary>Qux class.</summary>
        /// <typeparam name="T">Some type.</typeparam>
        public class Qux<T>
        {
            /// <summary>Initializes a new instance of the Qux class.</summary>
            /// <param name="qux">Qux instance.</param>
            public Qux(Baz<T>? qux)
            {
            }
        }
    }
}
