// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CodeDocument.cs" company="https://github.com/StyleCop">
//   MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. If you cannot locate the  
//   Microsoft Public License, please send an email to dlr@microsoft.com. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
// <summary>
//   Contains the parsed object model for a source code document.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Contains the parsed object model for a source code document.
    /// </summary>
    public abstract class CodeDocument : IDisposable
    {
        #region Fields

        /// <summary>
        /// Storage space for analyzer data.
        /// </summary>
        private Dictionary<string, object> analyzerData = new Dictionary<string, object>();

        /// <summary>
        /// The original source code document.
        /// </summary>
        private SourceCode sourceCode;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the CodeDocument class.
        /// </summary>
        /// <param name="sourceCode">
        /// The source code document this instance represents.
        /// </param>
        protected CodeDocument(SourceCode sourceCode)
        {
            Param.RequireNotNull(sourceCode, "sourceCode");
            this.sourceCode = sourceCode;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the parsed contents of the document.
        /// </summary>
        public abstract ICodeElement DocumentContents { get; }

        /// <summary>
        /// Gets the settings for the the project that contains the document.
        /// </summary>
        public Settings Settings
        {
            get
            {
                if (this.sourceCode != null)
                {
                    return this.sourceCode.Settings;
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the original source code document.
        /// </summary>
        public SourceCode SourceCode
        {
            get
            {
                return this.sourceCode;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the analyzer data dictionary for the document.
        /// </summary>
        internal Dictionary<string, object> AnalyzerData
        {
            get
            {
                return this.analyzerData;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Disposes the contents of the class.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Disposes the contents of the class.
        /// </summary>
        /// <param name="disposing">
        /// Indicates whether to dispose unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            Param.Ignore(disposing);

            if (disposing)
            {
                this.sourceCode = null;
                this.analyzerData = null;
            }
        }

        #endregion
    }
}