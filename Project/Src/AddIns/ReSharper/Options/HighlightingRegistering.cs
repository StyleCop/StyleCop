// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HighlightingRegistering.cs" company="http://stylecop.codeplex.com">
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
//   Registers StyleCop Highlighters to allow their severity to be set.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using JetBrains.ReSharper.Feature.Services.Daemon;

[assembly: RegisterConfigurableHighlightingsGroup("StyleCop", "StyleCop")]

namespace StyleCop.ReSharper.Options
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    using JetBrains.Application;
    using JetBrains.Application.FileSystemTracker;
    using JetBrains.Application.Settings;
    using JetBrains.DataFlow;
    using JetBrains.ReSharper.Feature.Services.Daemon;
    using JetBrains.ReSharper.Psi;
    using JetBrains.ReSharper.Psi.CSharp;

    using StyleCop.ReSharper.Core;

    /// <summary>
    /// Registers StyleCop Highlighters to allow their severity to be set.
    /// </summary>
    [ShellComponent]
    public class HighlightingRegistering : ICustomConfigurableSeverityItemProvider
    {
        /// <summary>
        /// The template to be used for the group title.
        /// </summary>
        private const string GroupTitleTemplate = "StyleCop - {0}";

        /// <summary>
        /// The template to be used for the highlight ID's.
        /// </summary>
        private const string HighlightIdTemplate = "StyleCop.{0}";

        /// <summary>
        /// Initializes a new instance of the HighlightingRegistering class.
        /// </summary>
        /// <param name="settingsStore">The settings store.</param>
        /// <param name="fileSystemTracker">
        /// The file System Tracker.
        /// </param>
        public HighlightingRegistering(ISettingsStore settingsStore, IFileSystemTracker fileSystemTracker)
        {
            // TODO: We shouldn't be doing any of this at runtime, especially not on each load
            // Registering highlightings should happen declaratively
            // Create this instance directly, rather than use the pool, because the pool needs to
            // be per-solution, as it caches settings for files in the solution
            Lifetimes.Using(
                temporaryLifetime =>
                    {
                        // We don't really need the file system tracker - it's only used when we get
                        // settings, which we don't do as part of highlighting initialisation
                        StyleCopCore core = StyleCopCoreFactory.Create(temporaryLifetime, settingsStore, fileSystemTracker);
                        this.Register(core);
                    });
        }

        /// <summary>
        /// Gets the highlight ID for this rule.
        /// </summary>
        /// <param name="ruleID">
        /// The rule ID.
        /// </param>
        /// <returns>
        /// The highlight ID.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// RuleID is null.
        /// </exception>
        public static string GetHighlightID(string ruleID)
        {
            if (string.IsNullOrEmpty(ruleID))
            {
                throw new ArgumentNullException("ruleID");
            }

            return string.Format(HighlightIdTemplate, ruleID);
        }

        private static string SplitCamelCase(string input)
        {
            return Regex.Replace(input, "([A-Z])", " $1", RegexOptions.Compiled).Trim();
        }

        private void Register(StyleCopCore core)
        {
            Dictionary<SourceAnalyzer, List<StyleCopRule>> analyzerRulesDictionary = StyleCopRule.GetRules(core);

            var configurableSeverityItems = new List<Tuple<PsiLanguageType, ConfigurableSeverityItem>>();
            foreach (KeyValuePair<SourceAnalyzer, List<StyleCopRule>> analyzerRule in analyzerRulesDictionary)
            {
                string analyzerName = analyzerRule.Key.Name;
                string compoundItemName = string.Format(GroupTitleTemplate, analyzerName);

                foreach (StyleCopRule rule in analyzerRule.Value)
                {
                    string ruleName = rule.RuleID + ": " + SplitCamelCase(rule.Name);
                    string highlightID = GetHighlightID(rule.RuleID);
                    ConfigurableSeverityItem severityItem = new ConfigurableSeverityItem(
                        highlightID,
                        compoundItemName,
                        "StyleCop",
                        ruleName,
                        rule.Description,
                        Severity.WARNING,
                        false,
                        false,
                        null);
                    configurableSeverityItems.Add(Tuple.Create((PsiLanguageType)CSharpLanguage.Instance, severityItem));
                }
            }
            this.ConfigurableSeverityItems = configurableSeverityItems;
        }

        public IEnumerable<Tuple<PsiLanguageType, ConfigurableSeverityItem>> ConfigurableSeverityItems { get; private set; }
    }
}