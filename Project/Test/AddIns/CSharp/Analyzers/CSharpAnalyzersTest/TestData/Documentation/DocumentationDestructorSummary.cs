using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    /// <summary>
    /// Valid destructor headers.
    /// </summary>
    public class Class1
    {
        /// <summary>
        /// Finalizes an instance of the Class1 class.
        /// </summary>
        ~Class1()
        {
        }
    }

    /// <summary>
    /// Invalid destructor header.
    /// </summary>
    public class Class2
    {
        /// <summary>
        /// Some other wording.
        /// </summary>
        public ~Class2()
        {
        }
    }

    /// <summary>
    /// Invalid destructor header.
    /// </summary>
    public class Class3
    {
        /// <summary>
        /// Finalizes an instance of the LJSEDFLJSDF class
        /// </summary>
        public ~Class3()
        {
        }
    }

    /// <summary>
    /// Invalid destructor header.
    /// </summary>
    public class Class4
    {
        /// <summary>
        /// finalizes an instance of the Class4 class
        /// </summary>
        public ~Class4()
        {
        }
    }

    /// <summary>
    /// Destructor headers containing cref tags.
    /// </summary>
    public class Class5
    {
        /// <summary>
        /// Finalizes an instance of the <see cref="Class5"/> class.
        /// </summary>
        public ~Class5()
        {
        }
    }
}
