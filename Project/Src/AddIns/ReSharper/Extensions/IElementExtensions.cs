// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IElementExtensions.cs" company="http://stylecop.codeplex.com">
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
namespace StyleCop.ReSharper.Extensions
{
    using System;

    using JetBrains.ReSharper.Psi.Tree;

    /// <summary>
    /// Extension methods for Token types.
    /// </summary>
    public static class IElementExtensions
    {
        /// <summary>
        /// Determines if the <see cref="ITreeNode"/> is a whitespace new line.
        /// </summary>
        /// <param name="element">
        /// The <see cref="ITokenNode"/> value to check.
        /// </param>
        /// <returns>
        /// <c>true</c>if <paramref name="element"/> is a New Line; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="element"/>is <c>null</c>.
        /// </exception>
        public static bool IsNewLine(this ITreeNode element)
        {
            IWhitespaceNode whitespaceNode = element as IWhitespaceNode;
            return whitespaceNode != null && whitespaceNode.IsNewLine;
        }

        /// <summary>
        /// Determines if the <see cref="ITreeNode"/> is a whitespace.
        /// </summary>
        /// <param name="element">
        /// The <see cref="ITokenNode"/> value to check.
        /// </param>
        /// <returns>
        /// <c>true</c>if <paramref name="element"/> is a whitespace; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="element"/>is <c>null</c>.
        /// </exception>
        public static bool IsWhitespace(this ITreeNode element)
        {
            IWhitespaceNode whitespaceNode = element as IWhitespaceNode;
            return whitespaceNode != null;
        }
    }
}