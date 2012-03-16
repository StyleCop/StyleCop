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

extern alias JB;

namespace StyleCop.ReSharper610.Options
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text.RegularExpressions;

    using JetBrains.Application;
    using JetBrains.Application.Components;
    using JetBrains.ReSharper.Daemon;
    using JetBrains.ReSharper.Psi;

    using StyleCop.ReSharper610.Core;

    #endregion

    /// <summary>
    /// Registers StyleCop Highlighters to allow their severity to be set.
    /// </summary>
    [ShellComponent(ProgramConfigurations.ALL)]
    public class HighlightingRegistering : IDisposable
    {
        #region Constants and Fields

        /// <summary>
        /// The ID to be used for the default severity configuration element.
        /// </summary>
        private const string DefaultSeverityId = "StyleCop.DefaultSeverity";

        /// <summary>
        /// The template to be used for the group title.
        /// </summary>
        private const string GroupTitleTemplate = "StyleCop - {0}";

        /// <summary>
        /// The template to be used for the highlight ID's.
        /// </summary>
        private const string HighlightIdTemplate = "StyleCop.{0}";

        #endregion

        /// <summary>
        /// Initializes a new instance of the HighlightingRegistering class.
        /// </summary>
        public HighlightingRegistering()
        {
            this.Init();
        }

        #region Public Methods

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

            var highlighID = string.Format(HighlightIdTemplate, ruleID);

            return highlighID;
        }

        #endregion

        #region Implemented Interfaces

        #region IComponent

        /// <summary>
        /// Inits this instance.
        /// </summary>
        public void Init()
        {
            if (StyleCopReferenceHelper.StyleCopIsAvailable())
            {
                this.AddHighlights();
            }
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }

        #endregion

        #endregion

        #region Methods

        /// <summary>
        /// Adds the default option for highlights - currently set to SUGGESTION.
        /// </summary>
        private static void AddDefaultOption()
        {
            const string RuleName = "Default Violation Severity";
            const string GroupName = "StyleCop - Defaults (Requires VS Restart)";
            const string Description =
                "Sets the default severity for StyleCop violations. This will be used for any Violation where you have not explicitly set a severity. <strong>Changes to this setting will not take effect until the next time you start Visual Studio.</strong>";
            const string HighlightID = DefaultSeverityId;
        }

        /// <summary>
        /// Checks if the highlight setting already exists in the HighlightingSettingsManager.
        /// </summary>
        /// <param name="highlightManager">
        /// The highlight manager.
        /// </param>
        /// <param name="highlightID">
        /// The highlight ID.
        /// </param>
        /// <returns>
        /// Boolean to say if this setting already exists in the HighlightingSettingsManager.
        /// </returns>
        private static bool SettingExists(HighlightingSettingsManager highlightManager, string highlightID)
        {
            var item = highlightManager.GetSeverityItem(highlightID);
            return item != null;
        }

        /// <summary>
        /// Splits the camel case.
        /// </summary>
        /// <param name="input">
        /// The text to split.
        /// </param>
        /// <returns>
        /// The split text.
        /// </returns>
        private static string SplitCamelCase(string input)
        {
            var output = Regex.Replace(input, "([A-Z])", " $1", RegexOptions.Compiled).Trim();

            return output;
        }

        private static void RegisterConfigurableGroup(HighlightingSettingsManager highlightManager, string groupId, string groupName)
        {
            var item = new HighlightingSettingsManager.ConfigurableGroupDescriptor(groupId, groupName);
            
            var field = highlightManager.GetType().GetField("myConfigurableGroups", BindingFlags.Instance | BindingFlags.NonPublic);

            if (field != null)
            {
                var items = field.GetValue(highlightManager) as Dictionary<string, HighlightingSettingsManager.ConfigurableGroupDescriptor>;

                if (items != null)
                {
                    if (!items.ContainsKey(groupId))
                    {
                        items.Add(groupId, item);
                    }
                }
            }
        }

        private static void RegisterConfigurableSeverity(HighlightingSettingsManager highlightManager, string highlightId, string groupName, string ruleName, string description, Severity defaultSeverity)
        {
            var allConfigurableSeverityItems = highlightManager.GetType().GetField("myConfigurableSeverityItem", BindingFlags.Instance | BindingFlags.NonPublic);

            if (allConfigurableSeverityItems != null)
            {
                var configurableSeverityItems = allConfigurableSeverityItems.GetValue(highlightManager) as Dictionary<string, HighlightingSettingsManager.ConfigurableSeverityItem>;

                if (configurableSeverityItems != null)
                {
                    if (!configurableSeverityItems.ContainsKey(highlightId))
                    {
                        var item = new HighlightingSettingsManager.ConfigurableSeverityItem(
                            highlightId, null, groupName, ruleName, description, defaultSeverity, false, false);
                        configurableSeverityItems.Add(highlightId, item);
                    }
                }
            }
            
            var configurableSeverityImplementation = highlightManager.GetType().GetField("myConfigurableSeverityImplementation", BindingFlags.Instance | BindingFlags.NonPublic);

            if (configurableSeverityImplementation != null)
            {
                var mapToLanguage = configurableSeverityImplementation.GetValue(highlightManager) as JB::JetBrains.Util.OneToListMap<string, PsiLanguageType>;

                if (mapToLanguage != null)
                {
                    if (!mapToLanguage.ContainsKey(highlightId))
                    {
                        var languageType = Languages.Instance.GetLanguageByName("CSHARP");
                        mapToLanguage.Add(highlightId, languageType);
                    }
                }
            }
        }

        /// <summary>
        /// Adds the highlights.
        /// </summary>
        private void AddHighlights()
        {
            var core = StyleCopReferenceHelper.GetStyleCopCore();
            core.Initialize(new List<string>(), true);

            var analyzerRulesDictionary = StyleCopRule.GetRules(core);

            var highlightManager = HighlightingSettingsManager.Instance;

            AddDefaultOption();

            var defaultSeverity = highlightManager.GetConfigurableSeverity(DefaultSeverityId, null);
            
            this.RegisterRuleConfigurations(highlightManager, analyzerRulesDictionary, defaultSeverity);
        }

        /// <summary>
        /// Registers the rule configurations.
        /// </summary>
        /// <param name="highlightManager">
        /// The highlight manager.
        /// </param>
        /// <param name="analyzerRulesDictionary">
        /// The analyzer rules dictionary.
        /// </param>
        /// <param name="defaultSeverity">
        /// The default severity.
        /// </param>
        private void RegisterRuleConfigurations(HighlightingSettingsManager highlightManager, Dictionary<SourceAnalyzer, List<StyleCopRule>> analyzerRulesDictionary, Severity defaultSeverity)
        {
            foreach (var analyzerRule in analyzerRulesDictionary)
            {
                var analyzerName = SplitCamelCase(analyzerRule.Key.Name);
                var groupName = string.Format(GroupTitleTemplate, analyzerName);
                var analyzerRules = analyzerRule.Value;

                RegisterConfigurableGroup(highlightManager, groupName, groupName);
                
                foreach (var rule in analyzerRules)
                {
                    var ruleName = rule.RuleID + ":" + " " + SplitCamelCase(rule.Name);
                    var highlightID = GetHighlightID(rule.RuleID);

                    if (!SettingExists(highlightManager, highlightID))
                    {
                        RegisterConfigurableSeverity(highlightManager, highlightID, groupName, ruleName, rule.Description, defaultSeverity);
                    }
                }
            }
        }

        #endregion
    }
}