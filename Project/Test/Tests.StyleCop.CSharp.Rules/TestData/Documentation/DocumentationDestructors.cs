using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class ValidDocumentationDestructor1
    {
        /// <summary>
        /// This is the summary for the destructor.
        /// </summary>
        ~ValidDocumentationDestructor1()
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class ValidDocumentationDestructor2
    {
        /// <summary>
        /// This is the summary for the destructor.
        /// </summary>
        /// <remarks>Adding a remarks tag.</remarks>
        ~ValidDocumentationDestructor2()
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationDestructor3
    {
        /// <summary>
        /// Summary description for destructor.
        /// </summary>
        ~InvalidDocumentationDestructor3()
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationDestructor4
    {
        /// <summary>
        /// The destructor's xml is invalid. <see
        /// </summary>
        ~InvalidDocumentationDestructor4()
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationDestructor5
    {
        ~InvalidDocumentationDestructor5()
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationDestructor6
    {
        /// <summary>
        /// 
        /// </summary>
        ~InvalidDocumentationDestructor6()
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationDestructor7
    {
        /// <summary>
        /// Nospaceshereatall.
        /// </summary>
        ~InvalidDocumentationDestructor7()
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationDestructor8
    {
        /// <summary>
        /// Short.
        /// </summary>
        ~InvalidDocumentationDestructor8()
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationDestructor9
    {
        /// <summary>
        /// A)(@)*23408234082308230823048230940238409283409234098230498234not enough letters.
        /// </summary>
        ~InvalidDocumentationDestructor9()
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationDestructor10
    {
        /// <summary>
        /// no capital letter.
        /// </summary>
        ~InvalidDocumentationDestructor10()
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationDestructor11
    {
        /// <summary>
        /// No closing period
        /// </summary>
        ~InvalidDocumentationDestructor11()
        {
        }
    }


    /// <summary>
    /// This is the class summary.
    /// </summary>
    internal class InvalidDocumentationDestructor12
    {
        ~InvalidDocumentationDestructor12()
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    protected class InvalidDocumentationDestructor13
    {
        ~InvalidDocumentationDestructor13()
        {
        }
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationDestructor14
    {
        /// <summary>
        /// This is the private class.
        /// </summary>
        private class PrivateClass
        {
            ~PrivateClass()
            {
            }
        }
    }

    /////// <summary>
    /////// This is the class summary.
    /////// </summary>
    ////protected class InvalidDocumentationDestructor15
    ////{
    ////    /// <summary>
    ////    /// This is the summary.
    ////    /// </summary>
    ////    /// <remarks></remarks>
    ////    ~InvalidDocumentationDestructor15()
    ////    {
    ////    }
    ////}
}
