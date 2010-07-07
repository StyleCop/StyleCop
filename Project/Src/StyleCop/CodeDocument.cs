//-----------------------------------------------------------------------
// <copyright file="CodeDocument.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation.
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
//-----------------------------------------------------------------------
namespace Microsoft.StyleCop
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Xml;

////    /// <summary>
////    /// Contains the parsed object model for a source code document.
////    /// </summary>
////    public abstract class CodeDocument : IDisposable, Microsoft.StyleCop.ICodeDocument
////    {
////        #region Private Fields

////        /// <summary>
////        /// The original source code document.
////        /// </summary>
////        private SourceCode sourceCode;

////        /// <summary>
////        /// Storage space for analyzer data.
////        /// </summary>
////        private Dictionary<string, object> analyzerData = new Dictionary<string, object>();

////        /// <summary>
////        /// Indicates whether the document is read-only.
////        /// </summary>
////        private bool readOnly = true;

////        #endregion Private Fields

////        #region Protected Constructors

////        /// <summary>
////        /// Initializes a new instance of the CodeDocument class.
////        /// </summary>
////        /// <param name="sourceCode">The source code document this instance represents.</param>
////        protected CodeDocument(SourceCode sourceCode)
////        {
////            Param.RequireNotNull(sourceCode, "sourceCode");
////            this.sourceCode = sourceCode;
////        }

////        #endregion Protected Constructors

////        #region Public Abstract Properties

////        /// <summary>
////        /// Gets the parsed contents of the document.
////        /// </summary>
////        public abstract ICodeElement DocumentContents
////        {
////            get;
////        }

////        #endregion Public Abstract Properties

////        #region Public Properties

////        /// <summary>
////        /// Gets the original source code document.
////        /// </summary>
////        public SourceCode SourceCode
////        {
////            get
////            {
////                return this.sourceCode;
////            }
////        }

////        /// <summary>
////        /// Gets the settings for the the project that contains the document.
////        /// </summary>
////        public Settings Settings
////        {
////            get
////            {
////                if (this.sourceCode != null)
////                {
////                    return this.sourceCode.Settings;
////                }

////                return null;
////            }
////        }

////        /// <summary>
////        /// Gets a value indicating whether the document is read-only.
////        /// </summary>
////        public bool ReadOnly
////        {
////            get
////            {
////                return this.readOnly;
////            }

////            internal set
////            {
////                this.readOnly = value;
////            }
////        }

////        #endregion Public Properties

////        #region Internal Properties

////        /// <summary>
////        /// Gets the analyzer data dictionary for the document.
////        /// </summary>
////        internal Dictionary<string, object> AnalyzerData
////        {
////            get
////            {
////                return this.analyzerData;
////            }
////        }

////        #endregion Internal Properties

////        #region Public Abstract Methods

////        /// <summary>
////        /// Writes the contents of the document to the given writer.
////        /// </summary>
////        /// <param name="writer">The writer.</param>
////        public abstract void Write(TextWriter writer);

////        #endregion Public Abstract Methods

////        #region Public Methods

////        /// <summary>
////        /// Disposes the contents of the class.
////        /// </summary>
////        public void Dispose()
////        {
////            this.Dispose(true);
////            GC.SuppressFinalize(this);
////        }

////        #endregion Public Methods

////        #region Protected Virtual Methods

////        /// <summary>
////        /// Disposes the contents of the class.
////        /// </summary>
////        /// <param name="disposing">Indicates whether to dispose unmanaged resources.</param>
////        protected virtual void Dispose(bool disposing)
////        {
////            Param.Ignore(disposing);
////        }

////        #endregion Protected Virtual Methods
////    }
}
