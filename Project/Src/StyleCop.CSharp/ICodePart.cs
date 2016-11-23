// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICodePart.cs" company="https://github.com/StyleCop">
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
//   An interface implemented by types that describe a code part.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// An interface implemented by types that describe a code part.
    /// </summary>
    public interface ICodePart
    {
        #region Public Properties

        /// <summary>
        /// Gets the type of the code part.
        /// </summary>
        CodePartType CodePartType { get; }

        /// <summary>
        /// Gets the line number that this code unit appears on in the document.
        /// </summary>
        int LineNumber { get; }

        /// <summary>
        /// Gets the location of this code unit within the document.
        /// </summary>
        CodeLocation Location { get; }

        /// <summary>
        /// Gets the parent of this code part.
        /// </summary>
        ICodePart Parent { get; }

        #endregion
    }
}