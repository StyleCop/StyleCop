// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SuppressStyleCopQuickFix.cs" company="http://stylecop.codeplex.com">
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
//   QuickFix - SuppressStyleCopQuickFix. Priority set to 0 to push it down the list.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper.QuickFixes.Framework
{
    using System.Collections.Generic;

    using JetBrains.ReSharper.Feature.Services.Bulbs;
    using JetBrains.ReSharper.Feature.Services.Intentions;
    using JetBrains.ReSharper.Feature.Services.QuickFixes;

    using StyleCop.ReSharper.BulbItems.Framework;
    using StyleCop.ReSharper.Violations;

    /// <summary>
    ///   QuickFix - SuppressStyleCopQuickFix. Priority set to 0 to push it down the list.
    /// </summary>
    //// [SuppressQuickFix]
    [QuickFix]
    public class SuppressStyleCopQuickFix : IQuickFix
    {
        /// <summary>
        ///   Instance of the StyleCop violation the QuickFix can deal with.
        /// </summary>
        private readonly StyleCopHighlightingBase highlighting;

        /// <summary>
        ///   List of available actions to be displayed in the IDE.
        /// </summary>
        private List<IBulbAction> bulbItems = new List<IBulbAction>();

        /// <summary>
        /// Initializes a new instance of the SuppressStyleCopQuickFix class that can handle.
        /// </summary>
        /// <param name="highlight">
        /// <see cref="StyleCopHighlightingBase"/> that has been detected. 
        /// </param>
        /// <param name="initialise">
        /// True to initialize. 
        /// </param>
        public SuppressStyleCopQuickFix(StyleCopHighlightingBase highlight, bool initialise)
        {
            this.highlighting = highlight;
            this.InitialiseBulbItems();
        }

        /// <summary>
        /// Arranges the BulbItems in the correct section.
        /// </summary>
        /// <returns>The QuickFix actions.</returns>
        public IEnumerable<IntentionAction> CreateBulbItems()
        {
           return this.bulbItems.ToQuickFixIntentions(IntentionsAnchors.ConfigureActionsAnchor);
        }

        /// <summary>
        /// True if this QuickFix is available.
        /// </summary>
        /// <param name="cache">
        /// The cache object to use. 
        /// </param>
        /// <returns>
        /// The is available. 
        /// </returns>
        public bool IsAvailable(JetBrains.Util.IUserDataHolder cache)
        {
            // TODO Not all StyleCop issues can be suppressed. We should check here and return false for those that cannot be handled.
            return true;
        }

        /// <summary>
        ///   Initializes the QuickFix with all the available BulbItems that can fix the current StyleCop Violation.
        /// </summary>
        private void InitialiseBulbItems()
        {
            this.bulbItems = new List<IBulbAction>
                                 {
                                     new SuppressMessageBulbItem
                                         {
                                             Description = "Suppress : " + this.highlighting.ToolTip, 
                                             Rule = this.highlighting.Rule
                                         }
                                 };
        }
    }
}