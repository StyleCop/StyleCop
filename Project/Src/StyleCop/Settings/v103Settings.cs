// --------------------------------------------------------------------------------------------------------------------
// <copyright file="v103Settings.cs" company="https://github.com/StyleCop">
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
//   Loads settings from a version 4.2 settings document.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System.Xml;

    /// <summary>
    /// Loads settings from a version 4.2 settings document.
    /// </summary>
    internal static class V103Settings
    {
        #region Public Methods and Operators

        /// <summary>
        /// Loads the settings from the document.
        /// </summary>
        /// <param name="document">
        /// The settings document.
        /// </param>
        /// <param name="settings">
        /// Stores the settings.
        /// </param>
        public static void Load(XmlDocument document, Settings settings)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertNotNull(settings, "settings");

            // Move the StatementMustNotUseUnnecessaryParenthesis rule from the ReadabilityRules analyzer to the MaintainabilityRules analyzer
            // if it exists.
            MoveRuleToNewAnalyzer(
                document, 
                "Microsoft.SourceAnalysis.CSharp.ReadabilityRules", 
                "Microsoft.SourceAnalysis.CSharp.MaintainabilityRules", 
                "StatementMustNotUseUnnecessaryParenthesis");

            // If the PublicAndProtectedOnly property exists on the DocumentationRules analyzer, rename it to IgnorePrivates.
            V102Settings.ChangeAnalyzerSettingName(document, "Microsoft.SourceAnalysis.CSharp.DocumentationRules", "PublicAndProtectedOnly", "IgnorePrivates");

            // Forward this call to the V4.3 rule class for parsing.
            V104Settings.Load(document, settings);
        }

        /// <summary>
        /// Moves a rule from one analyzer node to a different analyzer node.
        /// </summary>
        /// <param name="document">
        /// The settings document.
        /// </param>
        /// <param name="legacyAnalyzerName">
        /// The legacy analyzer name.
        /// </param>
        /// <param name="newAnalyzerName">
        /// The new analyzer name.
        /// </param>
        /// <param name="ruleName">
        /// The name of the rule to move.
        /// </param>
        public static void MoveRuleToNewAnalyzer(XmlDocument document, string legacyAnalyzerName, string newAnalyzerName, string ruleName)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertValidString(legacyAnalyzerName, "legacyAnalyzerName");
            Param.AssertValidString(newAnalyzerName, "newAnalyzerName");
            Param.AssertValidString(ruleName, "ruleName");

            XmlNode analyzersNode = document.DocumentElement.SelectSingleNode("Analyzers");
            if (analyzersNode != null)
            {
                XmlNode legacyAnalyzerNode = analyzersNode.SelectSingleNode("Analyzer[@AnalyzerId=\"" + legacyAnalyzerName + "\"]");

                if (legacyAnalyzerNode != null)
                {
                    XmlNode legacyAnalyzerRulesNode = legacyAnalyzerNode.SelectSingleNode("Rules");
                    if (legacyAnalyzerRulesNode != null)
                    {
                        XmlNode legacyRuleNode = legacyAnalyzerRulesNode.SelectSingleNode("Rule[@Name=\"" + ruleName + "\"]");

                        if (legacyRuleNode != null)
                        {
                            // This rule node must be moved under the new analyzer section.
                            // Check whether this section already exists.
                            XmlNode newRulesNode = analyzersNode.SelectSingleNode("Analyzer[@AnalyzerId=\"" + newAnalyzerName + "\"]");

                            if (newRulesNode == null)
                            {
                                // Create an add the new analyzer section.
                                newRulesNode = document.CreateElement("Analyzer");
                                XmlAttribute type = document.CreateAttribute("AnalyzerId");
                                type.Value = newAnalyzerName;
                                newRulesNode.Attributes.Append(type);

                                analyzersNode.AppendChild(newRulesNode);
                            }

                            XmlNode newAnalyzerRulesNode = newRulesNode.SelectSingleNode("Rules");
                            if (newAnalyzerRulesNode == null)
                            {
                                newAnalyzerRulesNode = document.CreateElement("Rules");
                                newRulesNode.AppendChild(newAnalyzerRulesNode);
                            }

                            // Move the rule node from the old rules node to the new rules node.
                            legacyAnalyzerRulesNode.RemoveChild(legacyRuleNode);
                            newAnalyzerRulesNode.AppendChild(legacyRuleNode);
                        }
                    }
                }
            }
        }

        #endregion
    }
}