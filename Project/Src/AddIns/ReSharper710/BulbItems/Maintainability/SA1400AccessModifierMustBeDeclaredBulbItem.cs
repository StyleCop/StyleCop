// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SA1400AccessModifierMustBeDeclaredBulbItem.cs" company="http://stylecop.codeplex.com">
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
//   The s a 1400 access modifier must be declared bulb item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper710.BulbItems.Maintainability
{
    #region Using Directives

    using JetBrains.ProjectModel;
    using JetBrains.TextControl;

    using StyleCop.ReSharper710.BulbItems.Framework;

    #endregion

    /// <summary>
    /// The s a 1400 access modifier must be declared bulb item.
    /// </summary>
    internal class SA1400AccessModifierMustBeDeclaredBulbItem : V5BulbItemImpl
    {
        #region Properties

        /// <summary>
        /// Gets or sets Modifier.
        /// </summary>
        public string Modifier { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// The execute transaction inner.
        /// </summary>
        /// <param name="solution">
        /// The solution.
        /// </param>
        /// <param name="textControl">
        /// The text control.
        /// </param>
        public override void ExecuteTransactionInner(ISolution solution, ITextControl textControl)
        {
            textControl.Document.InsertText(this.DocumentRange.TextRange.StartOffset, this.Modifier + " ");
        }

        #endregion
    }
}