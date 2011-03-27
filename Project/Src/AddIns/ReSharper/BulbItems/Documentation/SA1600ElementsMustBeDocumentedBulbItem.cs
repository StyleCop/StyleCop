// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SA1600ElementsMustBeDocumentedBulbItem.cs" company="">
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
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper.BulbItems.Documentation
{
    #region Using Directives

    using JetBrains.ProjectModel;
    using JetBrains.TextControl;

    using StyleCop.ReSharper.BulbItems.Framework;
    using StyleCop.ReSharper.CodeCleanup.Rules;
    using StyleCop.ReSharper.Core;

    #endregion

    /// <summary>
    /// BulbItem - SA1600ElementsMustBeDocumentedBulbItem : Inserts an empty element doc header.
    /// </summary>
    internal class SA1600ElementsMustBeDocumentedBulbItem : V5BulbItemImpl
    {
        /// <inheritdoc />
        public override void ExecuteTransactionInner(ISolution solution, ITextControl textControl)
        {
            var file = Utils.GetCSharpFile(solution, textControl);

            // this covers the issue that constants (and maybe others) return the class if called as GetContainingElement<IDeclaration)
            var declaration = Utils.GetDeclarationClosestToTextControl(solution, textControl);

            if (declaration != null)
            {
                new DocumentationRules().InsertMissingDeclarationHeader(file, declaration);
            }
        }
    }
}