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
// <summary>
//   QuickFix for SA1650 : ElementDocumentationMustBeSpelledCorrectly.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.ReSharper.QuickFixes.Documentation
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    using JetBrains.ReSharper.Feature.Services.Bulbs;
    using JetBrains.ReSharper.Feature.Services.QuickFixes;

    using StyleCop.ReSharper.BulbItems.Documentation;
    using StyleCop.ReSharper.QuickFixes.Framework;
    using StyleCop.ReSharper.Violations;
    using StyleCop.Spelling;

    /// <summary>
    /// QuickFix for SA1650 : ElementDocumentationMustBeSpelledCorrectly.
    /// </summary>
    [QuickFix]
    public class SA1650QuickFix : StyleCopQuickFixBase
    {
        /// <summary>
        /// Initializes a new instance of the SA1650QuickFix class that can 
        /// handle <see cref="StyleCopHighlighting"/>.
        /// </summary>
        /// <param name="highlight">
        /// <see cref="StyleCopHighlighting"/>that has been detected.
        /// </param>
        public SA1650QuickFix(StyleCopHighlighting highlight)
            : base(highlight)
        {
        }

        /// <summary>
        /// Initializes the QuickFix with all the available BulbItems that can fix the current
        /// StyleCop Violation.
        /// </summary>
        protected override void InitialiseBulbItems()
        {
            CultureInfo culture = this.Highlighting.Violation.SourceCode.Project.Culture;

            NamingService namingService = NamingService.GetNamingService(culture);

            if (!namingService.SupportsSpelling)
            {
                return;
            }

            string[] words = this.Highlighting.ToolTip.SubstringAfter(':').SubstringBeforeLast('[').Split(',');

            if (words.Length > 0)
            {
                this.BulbItems = new List<IBulbAction>();
                foreach (string word in words)
                {
                    string trimmedWord = word.Trim();
                    string preferredAlternateForDeprecatedWord = namingService.GetPreferredAlternateForDeprecatedWord(trimmedWord);

                    if (!string.IsNullOrEmpty(preferredAlternateForDeprecatedWord))
                    {
                        string description = string.Format(
                            "Change spelling of '{0}' to '{1}' [StyleCop Rule: {2}]", trimmedWord, preferredAlternateForDeprecatedWord, this.Highlighting.CheckId);
                        this.BulbItems.Add(
                            new SA1650ElementDocumentationMustBeSpelledCorrectlyBulbItem
                                {
                                    Description = description, 
                                    DeprecatedWord = trimmedWord, 
                                    AlternateWord = preferredAlternateForDeprecatedWord
                                });
                    }
                }
            }
        }
    }
}