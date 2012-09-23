// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SA1650QuickFix.cs" company="http://stylecop.codeplex.com">
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

namespace StyleCop.ReSharper700.QuickFixes.Documentation
{
    #region Using Directives

    using System;
    using System.Collections.Generic;

    using JetBrains.ReSharper.Feature.Services.Bulbs;
    using JetBrains.ReSharper.Intentions.Extensibility;

    using StyleCop.ReSharper700.BulbItems.Documentation;
    using StyleCop.ReSharper700.QuickFixes.Framework;
    using StyleCop.ReSharper700.Violations;
    using StyleCop.Spelling;

    #endregion

    /// <summary>
    /// QuickFix for SA1650 : ElementDocumentationMustBeSpelledCorrectly.
    /// </summary>
    [QuickFix]
    public class SA1650QuickFix : StyleCopQuickFixBase
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the SA1650QuickFix class that can 
        /// handle <see cref="StyleCopViolationError"/>.
        /// </summary>
        /// <param name="highlight">
        /// <see cref="StyleCopViolationError"/>that has been detected.
        /// </param>
        public SA1650QuickFix(StyleCopViolationError highlight)
            : base(highlight)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SA1650QuickFix class that can handle
        /// <see cref="StyleCopViolationHint"/>.
        /// </summary>
        /// <param name="highlight">
        /// <see cref="StyleCopViolationHint"/>that has been detected.
        /// </param>
        public SA1650QuickFix(StyleCopViolationHint highlight)
            : base(highlight)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SA1650QuickFix class that can handle
        /// <see cref="StyleCopViolationInfo"/>.
        /// </summary>
        /// <param name="highlight">
        /// <see cref="StyleCopViolationInfo"/>that has been detected.
        /// </param>
        public SA1650QuickFix(StyleCopViolationInfo highlight)
            : base(highlight)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SA1650QuickFix class that can handle
        /// <see cref="StyleCopViolationSuggestion"/>.
        /// </summary>
        /// <param name="highlight">
        /// <see cref="StyleCopViolationSuggestion"/>that has been detected.
        /// </param>
        public SA1650QuickFix(StyleCopViolationSuggestion highlight)
            : base(highlight)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SA1650QuickFix class that can handle
        /// <see cref="StyleCopViolationWarning"/>.
        /// </summary>
        /// <param name="highlight">
        /// <see cref="StyleCopViolationWarning"/>that has been detected.
        /// </param>
        public SA1650QuickFix(StyleCopViolationWarning highlight)
            : base(highlight)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the QuickFix with all the available BulbItems that can fix the current
        /// StyleCop Violation.
        /// </summary>
        protected override void InitialiseBulbItems()
        { 
            var namingService = NamingService.DefaultNamingService;
            if (!namingService.SupportsSpelling)
            {
                return;
            }

            var words = this.Violation.ToolTip.SubstringAfter(':').SubstringBeforeLast('[').Split(',');

            if (words.Length > 0)
            {
                this.BulbItems = new List<IBulbAction>();
                foreach (var word in words)
                {
                    var trimmedWord = word.Trim();
                    var preferredAlternateForDeprecatedWord = namingService.GetPreferredAlternateForDeprecatedWord(trimmedWord);

                    if (!string.IsNullOrEmpty(preferredAlternateForDeprecatedWord))
                    {
                        var description = string.Format(
                            "Change spelling of '{0}' to '{1}' [StyleCop Rule: {2}]", trimmedWord, preferredAlternateForDeprecatedWord, this.Violation.CheckId);
                        this.BulbItems.Add(
                            new SA1650ElementDocumentationMustBeSpelledCorrectlyBulbItem
                                {
                                    Description = description, DeprecatedWord = trimmedWord, AlternateWord = preferredAlternateForDeprecatedWord
                                });
                    }
                }
            }
        }

        #endregion
    }
}