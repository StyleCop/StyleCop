// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TokenNodeTypeExtensions.cs" company="http://stylecop.codeplex.com">
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
//   Extension methods for Token types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace JetBrains.ReSharper.Psi.Parsing
{
    #region Using Directives

    using System;
    using System.Linq;

    #endregion

    /// <summary>
    /// Extension methods for Token types.
    /// </summary>
    public static class TokenNodeTypeExtensions
    {
        #region Public Methods and Operators

        /// <summary>
        /// Determines if an <see cref="Enum"/> is one of a specified list of values.
        /// </summary>
        /// <param name="e">
        /// The <see cref="Enum"/> value to check.
        /// </param>
        /// <param name="values">
        /// An array of <see cref="Enum"/> values to check, which should be of the same type as <paramref name="e"/>.
        /// </param>
        /// <returns>
        /// <c>true</c>if <paramref name="e"/> is contained in <paramref name="values"/>; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Either <paramref name="e"/> or <paramref name="values"/> is <c>null</c>.
        /// </exception>
        public static bool IsOneOf(this TokenNodeType e, params TokenNodeType[] values)
        {
            return values.Contains(e);
        }

        #endregion
    }
}