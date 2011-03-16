//-----------------------------------------------------------------------
// <copyright file="ICodeDocument.cs">
//   MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms o the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
//-----------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Contains the parsed object model for a source code document.
    /// </summary>
    public interface ICodeDocument : IDisposable
    {
        /// <summary>
        /// Gets the parsed contents of the document.
        /// </summary>
        ICodeElement DocumentContents { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the document is read-only.
        /// </summary>
        bool ReadOnly { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the document has been altered since it was first initialized.
        /// </summary>
        bool Dirty { get; set; }

        /// <summary>
        /// Gets the settings for the the project that contains the document.
        /// </summary>
        Settings Settings { get; }

        /// <summary>
        /// Gets the analyzer data dictionary for the document.
        /// </summary>
        Dictionary<string, object> AnalyzerData { get; }

        /// <summary>
        /// Gets the original source code document.
        /// </summary>
        SourceCode SourceCode { get; }

        /// <summary>
        /// Writes the contents of the document to the given writer.
        /// </summary>
        /// <param name="writer">The writer.</param>
        void Write(System.IO.TextWriter writer);
    }
}
