using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class DocumentationRequireValueTags
    {
        #region Test that value tags are not required.

        /// <summary>
        /// Gets a value indicating whether whatever.
        /// </summary>
        public bool ValidProperty1
        {
            get { return null; }
        }

        /// <summary>
        /// Gets a value indicating whether whatever.
        /// </summary>
        internal bool ValidProperty2
        {
            get { return null; }
        }

        /// <summary>
        /// Gets a value indicating whether whatever.
        /// </summary>
        protected bool ValidProperty3
        {
            get { return null; }
        }

        /// <summary>
        /// Gets a value indicating whether whatever.
        /// </summary>
        protected internal bool ValidProperty4
        {
            get { return null; }
        }

        /// <summary>
        /// Gets a value indicating whether whatever.
        /// </summary>
        internal protected bool ValidProperty5
        {
            get { return null; }
        }

        /// <summary>
        /// Gets a value indicating whether whatever.
        /// </summary>
        private bool ValidProperty6
        {
            get { return null; }
        }

        /// <summary>
        /// Gets a value indicating whether whatever.
        /// </summary>
        public bool ValidProperty7
        {
            get { return null; }
        }

        /// <summary>
        /// Gets a value indicating whether whatever.
        /// </summary>
        public static bool ValidProperty8
        {
            get { return null; }
        }

        /// <summary>
        /// Gets a value indicating whether whatever.
        /// </summary>
        public unsafe bool ValidProperty9
        {
            get { return null; }
        }

        #endregion

        // A known violation
        public bool KnownViolation
        {
            get { return false; }
        }
    }
}
