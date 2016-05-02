// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SA1210QuickFix.cs" company="http://stylecop.codeplex.com">
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
//   QuickFix for StyleCop Rule 1210.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.ReSharper.QuickFixes.Ordering
{
    using System.Collections.Generic;

    using JetBrains.ReSharper.Feature.Services.Bulbs;
    using JetBrains.ReSharper.Feature.Services.QuickFixes;

    using StyleCop.ReSharper.BulbItems.Ordering;
    using StyleCop.ReSharper.QuickFixes.Framework;
    using StyleCop.ReSharper.Violations;

    /// <summary>
    /// QuickFix for StyleCop Rule 1210.
    /// </summary>
    //// [ShowQuickFix]
    [QuickFix]
    public class SA1210QuickFix : StyleCopQuickFixBase
    {
        /// <summary>
        /// Initializes a new instance of the SA1210QuickFix class that can 
        /// handle <see cref="StyleCopHighlighting"/>.
        /// </summary>
        /// <param name="highlight">
        /// <see cref="StyleCopHighlighting"/> that has been detected.
        /// </param>
        public SA1210QuickFix(StyleCopHighlighting highlight)
            : base(highlight)
        {
        }

        /// <summary>
        /// Initializes the QuickFix with all the available BulbItems that can fix the current
        /// StyleCop Violation.
        /// </summary>
        protected override void InitialiseBulbItems()
        {
            this.BulbItems = new List<IBulbAction> { new OrderUsingsBulbItem { Description = "Order Usings : " + this.Highlighting.ToolTip } };
        }
    }
}