//-----------------------------------------------------------------------
// <copyright file="DocumentAnalysisStatus.cs">
//   MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
//-----------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Keeps track of the analysis status for a single code document.
    /// </summary>
    internal class DocumentAnalysisStatus
    {
        #region Private Fields

        /// <summary>
        /// The document being parsed.
        /// </summary>
        private ICodeDocument document;

        /// <summary>
        /// Indicates whether the contents of the class have been initialized.
        /// </summary>
        private bool initialized;

        /// <summary>
        /// Indicates whether the analysis is complete.
        /// </summary>
        private bool complete;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the DocumentAnalysisStatus class.
        /// </summary>
        public DocumentAnalysisStatus()
        {
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether the contents of the class have been initialized.
        /// </summary>
        public bool Initialized
        {
            get
            {
                return this.initialized;
            }

            set
            {
                Param.Ignore(value);
                this.initialized = value;
            }
        }

        /// <summary>
        /// Gets or sets the document being parsed.
        /// </summary>
        public ICodeDocument Document
        {
            get
            {
                return this.document;
            }

            set
            {
                Param.RequireNotNull(value, "Document");
                this.document = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the analysis for this file is complete.
        /// </summary>
        public bool Complete
        {
            get
            {
                return this.complete;
            }

            set
            {
                Param.Ignore(value);
                this.complete = value;
            }
        }

        #endregion Public Properties
    }
}
