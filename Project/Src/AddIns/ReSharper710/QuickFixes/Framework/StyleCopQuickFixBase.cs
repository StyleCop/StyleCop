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
extern alias JB;

namespace StyleCop.ReSharper710.QuickFixes.Framework
{
    #region Using Directives

    using System.Collections.Generic;
    using System.Linq;

    using JetBrains.ReSharper.Daemon;
    using JetBrains.ReSharper.Intentions.Extensibility;
    using JetBrains.ReSharper.Intentions.Extensibility.Menu;

    using StyleCop.ReSharper710.Violations;

    #endregion

    /// <summary>
    ///   Basic Textual Quick Fix Example for rule SA1400QuickFix.
    /// </summary>
    public abstract class StyleCopQuickFixBase : IQuickFix
    {
        #region Fields

        /// <summary>
        ///   Instance of the StyleCop violation the QuickFix can deal with.
        /// </summary>
        protected readonly StyleCopHighlightingBase Highlighting;

        /// <summary>
        ///   List of available actions to be displayed in the IDE.
        /// </summary>
        private List<IBulbAction> bulbItems = new List<IBulbAction>();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the StyleCopQuickFixBase class that can handle <see cref="StyleCopHighlightingError"/> .
        /// </summary>
        /// <param name="highlight">
        /// <see cref="StyleCopHighlightingError"/> that has been detected. 
        /// </param>
        protected StyleCopQuickFixBase(StyleCopHighlightingError highlight)
            : this(highlight, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the StyleCopQuickFixBase class that can handle <see cref="StyleCopHighlightingHint"/> .
        /// </summary>
        /// <param name="highlight">
        /// <see cref="StyleCopHighlightingHint"/> that has been detected. 
        /// </param>
        protected StyleCopQuickFixBase(StyleCopHighlightingHint highlight)
            : this(highlight, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the StyleCopQuickFixBase class that can handle <see cref="StyleCopHighlightingInfo"/> .
        /// </summary>
        /// <param name="highlight">
        /// <see cref="StyleCopHighlightingInfo"/> that has been detected. 
        /// </param>
        protected StyleCopQuickFixBase(StyleCopHighlightingInfo highlight)
            : this(highlight, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the StyleCopQuickFixBase class that can handle <see cref="StyleCopHighlightingSuggestion"/> .
        /// </summary>
        /// <param name="highlight">
        /// <see cref="StyleCopHighlightingSuggestion"/> that has been detected. 
        /// </param>
        protected StyleCopQuickFixBase(StyleCopHighlightingSuggestion highlight)
            : this(highlight, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the StyleCopQuickFixBase class that can handle <see cref="StyleCopHighlightingWarning"/> .
        /// </summary>
        /// <param name="highlight">
        /// <see cref="StyleCopHighlightingWarning"/> that has been detected. 
        /// </param>
        protected StyleCopQuickFixBase(StyleCopHighlightingWarning highlight)
            : this(highlight, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the StyleCopQuickFixBase class that can handle <see cref="StyleCopHighlightingBase"/> .
        /// </summary>
        /// <param name="highlight">
        /// <see cref="StyleCopHighlightingBase"/> that has been detected. 
        /// </param>
        /// <param name="initialise">
        /// This value is not used, its only purpose is to differentiate the method signature. 
        /// </param>
        protected StyleCopQuickFixBase(StyleCopHighlightingBase highlight, bool initialise)
        {
            this.Highlighting = highlight;

            this.InitialiseIfRequired();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///   Gets a list of BulbActions to display in the IDE.
        /// </summary>
        public IBulbAction[] Items
        {
            get
            {
                return this.BulbItems.ToArray();
            }
        }

        #endregion

        #region Properties

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

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Arranges the BulbItems in the correct section.
        /// </summary>
        /// <param name="menu">
        /// The BulbMenu to add the items too. 
        /// </param>
        /// <param name="severity">
        /// The severity to set the items too. 
        /// </param>
        public void CreateBulbItems(BulbMenu menu, Severity severity)
        {
            menu.ArrangeQuickFixes(from bulbItem in this.Items select JB::JetBrains.Util.Pair.Of(bulbItem, severity));
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
        public bool IsAvailable(JB::JetBrains.Util.IUserDataHolder cache)
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

        #endregion

        #region Methods

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

        #endregion
    }
}