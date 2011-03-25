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

namespace StyleCop.ReSharper.CodeIssues
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    using JetBrains.Application;
    using JetBrains.ComponentModel;
    using JetBrains.ReSharper.Daemon;

    using StyleCop;

    using StyleCop.ReSharper.Core;
    using StyleCop.ReSharper.Options;

    #endregion

    [ShellComponentImplementation(ProgramConfigurations.ALL)]
    public class DocumentationIssues : IShellComponent
    {
        private const string GroupTitleTemplate = "StyleCop - {0}";
        private const string HighlightIdTemplate = "StyleCop.{0}";

        public void Init()        
        {
           //var core = StyleCopReferenceHelper.GetStyleCopCore();

           //core.Initialize(new List<string>(), true);

           //var rules = StyleCopRule.GetRules(core);

           //this.RegisterRuleConfigurations(rules, Severity.SUGGESTION);
        }

        public void Dispose()
        {
        }


        private void RegisterRuleConfigurations(Dictionary<SourceAnalyzer, List<StyleCopRule>> rulesDictionary, Severity defaultSeverity)
        {
            var sb = new StringBuilder();

            foreach (var analyzerRule in rulesDictionary)
            {
                var analyzerName = SplitCamelCase(analyzerRule.Key.Name);
                var groupName = string.Format(GroupTitleTemplate, analyzerName);
                var analyzerRules = analyzerRule.Value;

                foreach (var rule in analyzerRules)
                {
                    var ruleName = rule.RuleID + ":" + " " + SplitCamelCase(rule.Name);

                    sb.Append(rule.RuleID);
                    sb.Append("|");
                    sb.Append(groupName);
                    sb.Append("|");
                    sb.Append(ruleName);
                    sb.Append("|");
                    sb.Append(rule.Description);
                    sb.AppendLine();

                    HighlightingSettingsManager.Instance.RegisterConfigurableSeverity(rule.RuleID, null, groupName, ruleName, rule.Description, Severity.SUGGESTION, false);
                }
            }

            File.WriteAllText(@"c:\temp\rules.txt", sb.ToString());
        }

        private static string SplitCamelCase(string input)
        {
            var output = Regex.Replace(input, "([A-Z])", " $1", RegexOptions.Compiled).Trim();

            return output;
        }
    }
}