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

namespace StyleCop.ReSharper.QuickFixes.Documentation
{
    #region Using Directives

    using System.Collections.Generic;

    using JetBrains.ReSharper.Feature.Services.Bulbs;

    using StyleCop.ReSharper.BulbItems.Documentation;
    using StyleCop.ReSharper.QuickFixes.Framework;
    using StyleCop.ReSharper.Violations;

    #endregion

    /// <summary>
    /// QuickFix - SA1612: ElementParameterDocumentationMustMatchElementParameters.
    /// </summary>
    [ShowQuickFix]
    [QuickFix]
    public class SA1612QuickFix : QuickFixBase
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the SA1612QuickFix class that can 
        /// handle <see cref="StyleCopViolationError"/>.
        /// </summary>
        /// <param name="highlight">
        /// <see cref="StyleCopViolationError"/>that has been detected.
        /// </param>
        public SA1612QuickFix(StyleCopViolationError highlight)
            : base(highlight)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SA1612QuickFix class that can handle
        /// <see cref="StyleCopViolationHint"/>.
        /// </summary>
        /// <param name="highlight">
        /// <see cref="StyleCopViolationHint"/>that has been detected.
        /// </param>
        public SA1612QuickFix(StyleCopViolationHint highlight)
            : base(highlight)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SA1612QuickFix class that can handle
        /// <see cref="StyleCopViolationInfo"/>.
        /// </summary>
        /// <param name="highlight">
        /// <see cref="StyleCopViolationInfo"/>that has been detected.
        /// </param>
        public SA1612QuickFix(StyleCopViolationInfo highlight)
            : base(highlight)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SA1612QuickFix class that can handle
        /// <see cref="StyleCopViolationSuggestion"/>.
        /// </summary>
        /// <param name="highlight">
        /// <see cref="StyleCopViolationSuggestion"/>that has been detected.
        /// </param>
        public SA1612QuickFix(StyleCopViolationSuggestion highlight)
            : base(highlight)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SA1612QuickFix class that can handle
        /// <see cref="StyleCopViolationWarning"/>.
        /// </summary>
        /// <param name="highlight">
        /// <see cref="StyleCopViolationWarning"/>that has been detected.
        /// </param>
        public SA1612QuickFix(StyleCopViolationWarning highlight)
            : base(highlight)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initialises the QuickFix with all the available BulbItems that can fix the current
        /// StyleCop Violation.
        /// </summary>
        protected override void InitialiseBulbItems()
        {
            this.BulbItems = new List<IBulbItem>
                {
                    new SA1611ElementParametersMustBeDocumentedBulbItem
                        {
                            Description = "Fix <param> in header : " + this.Violation.ToolTip
                        }
                };
        }

        #endregion
    }
}