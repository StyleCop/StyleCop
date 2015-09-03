// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITreeNodeExtensions.cs" company="http://stylecop.codeplex.com">
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
//   Extension Methods for ITreeNode types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper.Extensions
{
    using System;

    using JetBrains.ReSharper.Psi.CSharp.Parsing;
    using JetBrains.ReSharper.Psi.ExtensionsAPI;
    using JetBrains.ReSharper.Psi.ExtensionsAPI.Tree;
    using JetBrains.ReSharper.Psi.Tree;
    using JetBrains.ReSharper.Resources.Shell;

    /// <summary>
    /// Extension Methods for ITreeNode types.
    /// </summary>
    public static class ITreeNodeExtensions
    {
        /// <summary>
        /// Inserts a newline after the Node provided.
        /// </summary>
        /// <param name="currentNode">
        /// The node to insert after.
        /// </param>
        /// <returns>
        /// An ITreeNode that has been inserted.
        /// </returns>
        public static ITreeNode InsertNewLineAfter(this ITreeNode currentNode)
        {
            LeafElementBase leafElement = GetLeafElement();
            using (WriteLockCookie.Create(true))
            {
                LowLevelModificationUtil.AddChildAfter(currentNode, new[] { leafElement });
            }

            return leafElement;
        }

        /// <summary>
        /// Inserts a newline in front of the Node provided.
        /// </summary>
        /// <param name="currentNode">
        /// The node to insert in front of.
        /// </param>
        /// <returns>
        /// The inserted ITreeNode.
        /// </returns>
        public static ITreeNode InsertNewLineBefore(this ITreeNode currentNode)
        {
            LeafElementBase leafElement = GetLeafElement();

            using (WriteLockCookie.Create(true))
            {
                LowLevelModificationUtil.AddChildBefore(currentNode, new[] { leafElement });
            }

            return leafElement;
        }

        /// <summary>
        /// Returns a LeafElementBase which contains a NewLine character.
        /// </summary>
        /// <returns>
        /// LeafElementBase containing a NewLine character.
        /// </returns>
        private static LeafElementBase GetLeafElement()
        {
            string newText = Environment.NewLine;
            return TreeElementFactory.CreateLeafElement(CSharpTokenType.NEW_LINE, new JetBrains.Text.StringBuffer(newText), 0, newText.Length);
        }
    }
}