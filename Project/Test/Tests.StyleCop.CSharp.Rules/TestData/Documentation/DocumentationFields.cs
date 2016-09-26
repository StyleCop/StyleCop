using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class DocumentationFields
    {
        /// <summary>
        /// This is the summary.
        /// </summary>
        public bool validField1;

        /// <summary>
        /// This is the summary.
        /// </summary>
        internal bool validField2;

        /// <summary>
        /// This is the summary.
        /// </summary>
        protected bool validField3;

        /// <summary>
        /// This is the summary.
        /// </summary>
        protected internal bool validField4;

        /// <summary>
        /// This is the summary.
        /// </summary>
        internal protected bool validField5;
        
        /// <summary>
        /// This is the summary.
        /// </summary>
        private bool validField6;

        /// <summary>
        /// This is the summary.
        /// </summary>
        public static bool validField7;

        /// <summary>
        /// This is the summary.
        /// </summary>
        public const int validField8 = 0;

        /// <summary>
        /// This is the summary.
        /// </summary>
        public readonly int validField9 = 1;

        /// <summary>This is the summary.
        /// </summary>
        public bool validField10;

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <remarks>Adding a remarks tag.</remarks>
        public int validField11;

        /// <summary>
        /// Summary description for field.
        /// </summary>
        public int invalidField1;

        /// <summary>
        /// The field's xml is invalid.
        /// </summary2>
        public int invalidField2;

        public int invalidField3;

        private int invalidField4;

        internal int invalidField5;

        protected int invalidField6;

        protected internal int invalidField7;

        internal protected int invalidField8;

        /// <summary>
        /// 
        /// </summary>
        public int invalidField9;

        /// <summary>
        /// Nospaceshereatall.
        /// </summary>
        public int invalidField10;

        /// <summary>
        /// Short.
        /// </summary>
        public int invalidField11;

        /// <summary>
        /// A)(@)*23408234082308230823048230940238409283409234098230498234not enough letters.
        /// </summary>
        public int invalidField12;

        /// <summary>
        /// no capital letter.
        /// </summary>
        public int invalidField13;

        /// <summary>
        /// No closing period
        /// </summary>
        public int invalidField14;

        public static int invalidField15;

        /// <summary>
        /// 
        /// </summary>
        public static int invalidField16;

        public const int invalidField17 = 0;

        public readonly int invalidField18 = 0;

        /// <summary>
        /// Finalizes an instance of the DocumentationFields class but has 4 empty documentation elements.
        /// </summary>
        /// <remarks></remarks>
        /// <example></example>
        /// <permission cref=""></permission>
        /// <exception cref=""></exception>
        ~DocumentationFields()
        {
        }
    }
}
