// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SA1400QuickFix.cs" company="http://stylecop.codeplex.com">
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
//   QuickFix for StyleCop Rule SA1400.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.ReSharper.QuickFixes.Maintainability
{
    using System.Collections.Generic;

    using JetBrains.ReSharper.Feature.Services.Bulbs;
    using JetBrains.ReSharper.Feature.Services.QuickFixes;

    using StyleCop.ReSharper.BulbItems.Maintainability;
    using StyleCop.ReSharper.QuickFixes.Framework;
    using StyleCop.ReSharper.Violations;

    /// <summary>
    /// QuickFix for StyleCop Rule SA1400.
    /// </summary>
    //// [ShowQuickFix]
    [QuickFix]
    public class SA1400QuickFix : StyleCopQuickFixBase
    {
        /// <summary>
        /// Initializes a new instance of the SA1400QuickFix class that can 
        /// handle <see cref="StyleCopHighlighting"/>.
        /// </summary>
        /// <param name="highlight">
        /// <see cref="StyleCopHighlighting"/>that has been detected.
        /// </param>
        public SA1400QuickFix(StyleCopHighlighting highlight)
            : base(highlight)
        {
        }

        /// <summary>
        /// Initializes the QuickFix with all the available BulbItems that can fix the current
        /// StyleCop Violation.
        /// </summary>
        protected override void InitialiseBulbItems()
        {
            this.BulbItems = new List<IBulbAction>
                                 {
                                     new SA1400AccessModifierMustBeDeclaredBulbItem
                                         {
                                             Modifier = "public", 
                                             DocumentRange = this.Highlighting.CalculateRange(), 
                                             Description = "Make Public : " + this.Highlighting.ToolTip
                                         }, 
                                     new SA1400AccessModifierMustBeDeclaredBulbItem
                                         {
                                             Modifier = "private", 
                                             DocumentRange = this.Highlighting.CalculateRange(), 
                                             Description = "Make Private : " + this.Highlighting.ToolTip
                                         }, 
                                     new SA1400AccessModifierMustBeDeclaredBulbItem
                                         {
                                             Modifier = "protected", 
                                             DocumentRange = this.Highlighting.CalculateRange(), 
                                             Description = "Make Protected : " + this.Highlighting.ToolTip
                                         }, 
                                     new SA1400AccessModifierMustBeDeclaredBulbItem
                                         {
                                             Modifier = "internal", 
                                             DocumentRange = this.Highlighting.CalculateRange(), 
                                             Description = "Make Internal : " + this.Highlighting.ToolTip
                                         }, 
                                 };
        }
    }
}