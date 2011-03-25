//-----------------------------------------------------------------------
// <copyright file="">
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
//-----------------------------------------------------------------------

namespace StyleCop.ReSharper.BulbItems.Spacing
{
    #region Using Directives

    using System.Text.RegularExpressions;

    using JetBrains.ProjectModel;
    using JetBrains.TextControl;

    using StyleCop.ReSharper.BulbItems.Framework;

    #endregion

    /// <summary>
    /// BulbItem - FormatDocumentationHeader : Fixes documention headers.
    /// </summary>
    internal class FormatDocumentationHeader : V5BulbItemImpl
    {
        public override void ExecuteTransactionInner(ISolution solution, ITextControl textControl)
        {
            var documentation = this.DocumentRange.GetText();
            var regEx = new Regex("(((///[ ^ ] *)|\"))|((///))");
            documentation = regEx.Replace(documentation, "/// ");
            textControl.Document.ReplaceText(this.DocumentRange.TextRange, documentation);
        }
    }
}