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
        #region Test that headers can be ommitted from fields.
        
        public bool validField1;

        internal bool validField2;

        protected bool validField3;

        protected internal bool validField4;

        internal protected bool validField5;
        
        private bool validField6;

        public static bool validField7;

        public const int validField8 = 0;

        public readonly int validField9 = 1;

        #endregion

        #region Test that invalid headers on fields are still flagged.

        /// <summary>
        /// 
        /// </summary>
        public bool invalidField1;

        /// <summary>
        /// 
        /// </summary>
        internal bool invalidField2;

        /// <summary>
        /// 
        /// </summary>
        protected bool invalidField3;

        /// <summary>
        /// 
        /// </summary>
        protected internal bool invalidField4;

        /// <summary>
        /// 
        /// </summary>
        internal protected bool invalidField5;

        /// <summary>
        /// 
        /// </summary>
        private bool invalidField6;

        /// <summary>
        /// 
        /// </summary>
        public static bool invalidField7;

        /// <summary>
        /// 
        /// </summary>
        public const int invalidField8 = 0;

        /// <summary>
        /// 
        /// </summary>
        public readonly int invalidField9 = 1;

        #endregion
    }
}
