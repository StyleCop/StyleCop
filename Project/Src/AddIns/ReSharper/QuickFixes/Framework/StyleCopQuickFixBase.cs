// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopQuickFixBase.cs" company="http://stylecop.codeplex.com">
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
//   Basic Textual Quick Fix Example for rule SA1400QuickFix.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper.QuickFixes.Framework
{
    using System.Collections.Generic;

    using JetBrains.ReSharper.Feature.Services.Bulbs;
    using JetBrains.ReSharper.Feature.Services.Intentions;
    using JetBrains.ReSharper.Feature.Services.QuickFixes;

    using StyleCop.ReSharper.Violations;

    /// <summary>
    ///   Basic Textual Quick Fix Example for rule SA1400QuickFix.
    /// </summary>
    public abstract class StyleCopQuickFixBase : IQuickFix
    {
        /// <summary>
        ///   Instance of the StyleCop violation the QuickFix can deal with.
        /// </summary>
        protected readonly StyleCopHighlightingBase Highlighting;

        /// <summary>
        ///   List of available actions to be displayed in the IDE.
        /// </summary>
        private List<IBulbAction> bulbItems = new List<IBulbAction>();

        /// <summary>
        /// Initializes a new instance of the StyleCopQuickFixBase class that can handle <see cref="StyleCopHighlightingBase"/> .
        /// </summary>
        /// <param name="highlight">
        /// <see cref="StyleCopHighlightingBase"/> that has been detected. 
        /// </param>
        protected StyleCopQuickFixBase(StyleCopHighlightingBase highlight)
        {
            this.Highlighting = highlight;

            this.InitialiseIfRequired();
        }

        /// <summary>
        ///   Gets or sets a list of BulbItems to be Displayed.
        /// </summary>
        /// <remarks>
        ///   An internal representation of the BulbItems used for initialization and filtering.
        /// </remarks>
        protected List<IBulbAction> BulbItems
        {
            get
            {
                return this.bulbItems;
            }
            set
            {
                this.bulbItems = value;
            }
        }

        /// <summary>
        /// Arranges the BulbItems in the correct section.
        /// </summary>
        /// <returns>The QuickFix actions.</returns>
        public IEnumerable<IntentionAction> CreateBulbItems()
        {
            return this.BulbItems.ToQuickFixIntentions();
        }

        /// <summary>
        /// Determines whether the current QuickFix is available for the violation.
        /// </summary>
        /// <remarks>
        /// Essentially to display the bulb item in the IDE the current ViolationID must match the name of the QuickFix Class.
        /// </remarks>
        /// <param name="cache">
        /// Current Data Cache. 
        /// </param>
        /// <returns>
        /// Whether the current QuickFix is available for the violation. 
        /// </returns>
        public bool IsAvailable(JetBrains.Util.IUserDataHolder cache)
        {
            // use a more resiliant matching method - this caught me out
            // quite a bit while I was refactoring and debugging and wondering
            // why no bulb items were appearing
            if (this.Highlighting.CheckId.StartsWith("SA") || this.Highlighting.CheckId.StartsWith("BB"))
            {
                return this.GetType().Name.Substring(2).StartsWith(this.Highlighting.CheckId.Substring(2));
            }

            return this.GetType().Name.StartsWith(this.Highlighting.CheckId);
        }

        /// <summary>
        ///   Abstract initialization method that must be called by all derived types.
        /// </summary>
        protected abstract void InitialiseBulbItems();

        /// <summary>
        ///   Ensures that the QF are only shown is they are applicable for the current violation.
        /// </summary>
        protected void InitialiseIfRequired()
        {
            if (this.IsAvailable(null))
            {
                this.InitialiseBulbItems();
            }
        }
    }
}