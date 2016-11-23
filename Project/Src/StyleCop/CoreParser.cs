// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CoreParser.cs" company="https://github.com/StyleCop">
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
//   A "fake" parser class used by the StyleCop engine to register
//   violations exposed by the core engine.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;

    /// <summary>
    /// A "fake" parser class used by the StyleCop engine to register 
    /// violations exposed by the core engine.
    /// </summary>
    internal class CoreParser : SourceParser
    {
        #region Public Methods and Operators

        /// <summary>
        /// Parses a source code document.
        /// </summary>
        /// <param name="sourceCode">
        /// The source code to parse.
        /// </param>
        /// <param name="passNumber">
        /// The current pass number.
        /// </param>
        /// <param name="document">
        /// The parsed representation of the file.
        /// </param>
        /// <returns>
        /// Returns false if no further parsing should be done on this file.
        /// </returns>
        public override bool ParseFile(SourceCode sourceCode, int passNumber, ref CodeDocument document)
        {
            Param.Ignore(sourceCode, passNumber, document);
            throw new NotImplementedException();
        }

        #endregion
    }
}