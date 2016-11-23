// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICodeElement.cs" company="https://github.com/StyleCop">
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
//   An interface implemented by types that describes an element within a code document.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System.Collections.Generic;

    /// <summary>
    /// An interface implemented by types that describes an element within a code document.
    /// </summary>
    public interface ICodeElement
    {
        #region Public Properties

        /// <summary>
        /// Gets the collection of child elements beneath this element.
        /// </summary>
        IEnumerable<ICodeElement> ChildCodeElements { get; }

        /// <summary>
        /// Gets the document that contains the code part.
        /// </summary>
        CodeDocument Document { get; }

        /// <summary>
        /// Gets the fully qualified name of the element.
        /// </summary>
        string FullyQualifiedName { get; }

        /// <summary>
        /// Gets the line number that this code part appears on in the document.
        /// </summary>
        int LineNumber { get; }

        /// <summary>
        /// Gets the violations found in this element.
        /// </summary>
        ICollection<Violation> Violations { get; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Adds one violation to this element.
        /// </summary>
        /// <param name="violation">
        /// The violation to add.
        /// </param>
        /// <returns>
        /// Returns false if there is already an identical violation in the element.
        /// </returns>
        bool AddViolation(Violation violation);

        /// <summary>
        /// Clears the analyzer tags for this element.
        /// </summary>
        /// <remarks>This method should only be called by the StyleCop framework.</remarks>
        void ClearAnalyzerTags();

        #endregion
    }
}