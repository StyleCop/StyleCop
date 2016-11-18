using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class ValidDocumentationConstructor1
    {
        /// <summary>
        /// This is the summary for the constructor.
        /// </summary>
        public ValidDocumentationConstructor1()
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class ValidDocumentationConstructor2
    {
        /// <summary>
        /// This is the summary for the constructor.
        /// </summary>
        /// <param name="x">This is the first parameter.</param>
        /// <param name="y">This is the second parameter.</param>
        /// <param name="z">This is the third parameter.</param>
        public ValidDocumentationConstructor2(int x, string[] y, List<int[]> z)
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class ValidDocumentationConstructor3
    {
        /// <summary>This is the summary for the constructor.</summary><param name="x">This is the first parameter.</param>
        /// <param name="y">This is the second parameter.</param><param name="z">This is the third parameter.</param>
        public ValidDocumentationConstructor3(int x, string[] y, List<int[]> z)
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class ValidDocumentationConstructor4
    {
        /// <summary>
        /// This is the summary for the constructor. Some of the text is repeated.
        /// </summary>
        /// <param name="x">The parameter is not used.</param>
        /// <param name="y">The parameter is not used.</param>
        /// <param name="z">The parameter is not used.</param>
        public ValidDocumentationConstructor4(int x, string[] y, List<int[]> z)
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class ValidDocumentationConstructor5
    {
        /// <summary>
        /// This is the summary for the constructor.
        /// </summary>
        internal ValidDocumentationConstructor5()
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class ValidDocumentationConstructor6
    {
        /// <summary>
        /// This is the summary for the constructor.
        /// </summary>
        protected ValidDocumentationConstructor6()
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class ValidDocumentationConstructor7
    {
        /// <summary>
        /// This is the summary for the constructor.
        /// </summary>
        protected internal ValidDocumentationConstructor7()
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class ValidDocumentationConstructor8
    {
        /// <summary>
        /// This is the summary for the constructor.
        /// </summary>
        internal protected ValidDocumentationConstructor8()
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class ValidDocumentationConstructor9
    {
        /// <summary>
        /// This is the summary for the constructor.
        /// </summary>
        private ValidDocumentationConstructor9()
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class ValidDocumentationConstructor10
    {
        /// <summary>
        /// This is the summary for the constructor.
        /// </summary>
        /// <remarks>Adding a remarks tag.</remarks>
        public ValidDocumentationConstructor10()
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class ValidDocumentationConstructor11
    {
        /// <summary>
        /// This is the summary for the static constructor.
        /// </summary>
        static ValidDocumentationConstructor11()
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationConstructor1
    {
        /// <summary>
        /// Summary description for constructor.
        /// </summary>
        public InvalidDocumentationConstructor1()
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationConstructor2
    {
        /// <summary
        /// The constructor's xml is invalid. The opening tag is ill-formed.
        /// </summary>
        public InvalidDocumentationConstructor2()
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationConstructor3
    {
        public InvalidDocumentationConstructor3()
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationConstructor4
    {
        /// <summary>
        /// 
        /// </summary>
        public InvalidDocumentationConstructor4()
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationConstructor5
    {
        /// <summary>
        /// Nospaceshereatall.
        /// </summary>
        public InvalidDocumentationConstructor5()
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationConstructor6
    {
        /// <summary>
        /// Short.
        /// </summary>
        public InvalidDocumentationConstructor6()
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationConstructor7
    {
        /// <summary>
        /// A)(@)*23408234082308230823048230940238409283409234098230498234not enough letters.
        /// </summary>
        public InvalidDocumentationConstructor7()
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationConstructor8
    {
        /// <summary>
        /// no capital letter.
        /// </summary>
        public InvalidDocumentationConstructor8()
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationConstructor9
    {
        /// <summary>
        /// No closing period
        /// </summary>
        public InvalidDocumentationConstructor9()
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationConstructor10
    {
        /// <summary>
        /// This is the summary.
        /// </summary>
        public InvalidDocumentationConstructor10(int x)
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationConstructor11
    {
        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x"></param>
        public InvalidDocumentationConstructor11(int x)
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationConstructor12
    {
        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x">Nospaceshereatall.</param>
        public InvalidDocumentationConstructor12(int x)
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationConstructor13
    {
        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x">Short.</param>
        public InvalidDocumentationConstructor13(int x)
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationConstructor14
    {
        /// <summary>
        /// Thisis the summary.
        /// </summary>
        /// <param name="x">A)(@)*23408234082308230823048230940238409283409234098230498234not enough letters.</param>
        public InvalidDocumentationConstructor14(int x)
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationConstructor15
    {
        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x">no capital letter.</param>
        public InvalidDocumentationConstructor15(int x)
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationConstructor16
    {
        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x">No closing period</param>
        public InvalidDocumentationConstructor16(int x)
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationConstructor17
    {
        /// <summary>
        /// This line is copied.
        /// </summary>
        /// <param name="x">This line is copied.</param>
        /// <param name="y">This is the second parameter.</param>
        public InvalidDocumentationConstructor17(int x, int y)
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationConstructor18
    {
        /// <summary>
        /// This line is copied.
        /// </summary>
        /// <param name="x">This is the first parameter.</param>
        /// <param name="y">This line is copied.</param>
        public InvalidDocumentationConstructor18(int x, int y)
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationConstructor19
    {
        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x">This line is copied.</param>
        /// <param name="y">This line is copied.</param>
        public InvalidDocumentationConstructor19(int x, int y)
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationConstructor20
    {
        /// <summary>
        /// The parameters are in the wrong order.
        /// </summary>
        /// <param name="y">This is the second parameter.</param>
        /// <param name="x">This is the first parameter.</param>
        public InvalidDocumentationConstructor20(int x, int y)
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationConstructor21
    {
        /// <summary>
        /// Param tag is missing the name attribute.
        /// </summary>
        /// <param>This is the first parameter.</param>
        public InvalidDocumentationConstructor21(int x)
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationConstructor22
    {
        /// <summary>
        /// Param tag name attribute is empty.
        /// </summary>
        /// <param name="">This is the first parameter.</param>
        public InvalidDocumentationConstructor22(int x)
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationConstructor23
    {
        /// <summary>
        /// Param tag name is incorrect.
        /// </summary>
        /// <param name="y">This is the first parameter.</param>
        public InvalidDocumentationConstructor23(int x)
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationConstructor24
    {
        internal InvalidDocumentationConstructor24()
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationConstructor25
    {
        protected InvalidDocumentationConstructor25()
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationConstructor26
    {
        protected internal InvalidDocumentationConstructor26()
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationConstructor27
    {
        private InvalidDocumentationConstructor27()
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    internal class InvalidDocumentationConstructor28
    {
        public InvalidDocumentationConstructor28()
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    internal class InvalidDocumentationConstructor29
    {
        private InvalidDocumentationConstructor29()
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationConstructor30
    {
        static InvalidDocumentationConstructor30()
        {
        }
    }

    /////// <summary>
    /////// This is the class summary.
    /////// </summary>
    ////public class InvalidDocumentationConstructor31
    ////{
    ////    /// <summary>
    ////    /// This is the summary.
    ////    /// </summary>
    ////    /// <remarks></remarks>
    ////    public InvalidDocumentationConstructor31()
    ////    {
    ////    }
    ////}

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationConstructor32
    {
        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x">This is the first parameter.</param>
        /// <param name="y">This is the second parameter.</param>
        /// <param name="y">This is the third parameter.</param>
        public InvalidDocumentationConstructor32(int x, int y)
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationConstructor33
    {
        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x">This is the first parameter.</param>
        /// <param name="y">This is the second parameter.</param>
        /// <param name="">This is the third parameter.</param>
        public InvalidDocumentationConstructor33(int x, int y)
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationConstructor34
    {
        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x">This is the first parameter.</param>
        /// <param name="y">This is the second parameter.</param>
        /// <param>This is the third parameter.</param>
        public InvalidDocumentationConstructor34(int x, int y)
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationConstructor35
    {
        /// <summary>
        /// This is the summary. Param tag is missing for Z.
        /// </summary>
        /// <param name="x">The first param.</param>
        /// <param name="y">The second param.</param>
        public InvalidDocumentationConstructor35(int x, int y, int z)
        {
        }
    }
}
