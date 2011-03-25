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

extern alias JB;

namespace StyleCop.ReSharper.QuickFixes.Framework
{
    #region Using Directives

    using System.Collections.Generic;

    using JetBrains.ReSharper.Feature.Services.Bulbs;
    using JetBrains.Util;

    using StyleCop.ReSharper.Violations;

    #endregion

    /// <summary>
    /// Basic Textual Quick Fix Example for rule SA1400QuickFix.
    /// </summary>
    public abstract class QuickFixBase : IQuickFix
    {
        #region Constants and Fields

        /// <summary>
        /// Instance of the StyleCop violation the QuickFix can deal with.
        /// </summary>
        protected readonly StyleCopViolationBase Violation;

        /// <summary>
        /// List of available actions to be displayed in the IDE.
        /// </summary>
        private List<IBulbItem> bulbItems = new List<IBulbItem>();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the QuickFixBase class that can 
        /// handle <see cref="StyleCopViolationError"/>.
        /// </summary>
        /// <param name="highlight">
        /// <see cref="StyleCopViolationError"/>that has been detected.
        /// </param>
        protected QuickFixBase(StyleCopViolationError highlight) : this(highlight, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the QuickFixBase class that can handle
        /// <see cref="StyleCopViolationHint"/>.
        /// </summary>
        /// <param name="highlight">
        /// <see cref="StyleCopViolationHint"/>that has been detected.
        /// </param>
        protected QuickFixBase(StyleCopViolationHint highlight) : this(highlight, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the QuickFixBase class that can handle
        /// <see cref="StyleCopViolationInfo"/>.
        /// </summary>
        /// <param name="highlight">
        /// <see cref="StyleCopViolationInfo"/>that has been detected.
        /// </param>
        protected QuickFixBase(StyleCopViolationInfo highlight) : this(highlight, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the QuickFixBase class that can handle
        /// <see cref="StyleCopViolationSuggestion"/>.
        /// </summary>
        /// <param name="highlight">
        /// <see cref="StyleCopViolationSuggestion"/>that has been detected.
        /// </param>
        protected QuickFixBase(StyleCopViolationSuggestion highlight) : this(highlight, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the QuickFixBase class that can handle
        /// <see cref="StyleCopViolationWarning"/>.
        /// </summary>
        /// <param name="highlight">
        /// <see cref="StyleCopViolationWarning"/>that has been detected.
        /// </param>
        protected QuickFixBase(StyleCopViolationWarning highlight) : this(highlight, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the QuickFixBase class that can handle
        /// <see cref="StyleCopViolationBase"/>.
        /// </summary>
        /// <param name="highlight">
        /// <see cref="StyleCopViolationBase"/>that has been detected.
        /// </param>
        /// <param name="initialise">
        /// This value is not used, its only purpose is to differentiate 
        /// the method signature.
        /// </param>
        protected QuickFixBase(StyleCopViolationBase highlight, bool initialise)
        {
            this.Violation = highlight;

            this.InitialiseIfRequired();
        }

        #endregion

        /// <summary>
        /// Gets a list of BulbItems to display in the IDE.
        /// </summary>
        public IBulbItem[] Items
        {
            get { return this.BulbItems.ToArray(); }
        }

        /// <summary>
        /// Gets or sets a list of BulbItems to be Displayed.
        /// </summary>
        /// <remarks>
        /// An internal representation of the BulbItems used for
        /// initialisation and filtering.
        /// </remarks>
        protected List<IBulbItem> BulbItems
        {
            get { return this.bulbItems; }
            set { this.bulbItems = value; }
        }

        /// <summary>
        /// Determines whether the current QuickFix is available for the violation.
        /// </summary>
        /// <remarks>
        /// Essentially to display the bulb item in the IDE the current ViolationID
        /// must match the name of the QuickFix Class.
        /// </remarks>
        /// <param name="cache">
        /// Current Data Cache.
        /// </param>
        /// <returns>
        /// Whether the current QuickFix is available for the violation.
        /// </returns>
        public bool IsAvailable(JB::JetBrains.Util.IUserDataHolder cache)
        {
            // use a more resiliant matching method - this caught me out
            // quite a bit while I was refactoring and debugging and wondering
            // why no bulb items were appearing
            if (this.Violation.CheckId.StartsWith("SA") || this.Violation.CheckId.StartsWith("BB"))
            {
                return this.GetType().Name.Substring(2).StartsWith(this.Violation.CheckId.Substring(2));
            }

            return this.GetType().Name.StartsWith(this.Violation.CheckId);
        }

        /// <summary>
        /// Ensures that the QF are only shown is they are applicable for the current violation.
        /// </summary>
        protected void InitialiseIfRequired()
        {
            if (this.IsAvailable(null))
            {
                this.InitialiseBulbItems();
            }
        }

        /// <summary>
        /// Abstract Initialisation method that must be called by all
        /// derived types.
        /// </summary>
        protected abstract void InitialiseBulbItems();
    }
}