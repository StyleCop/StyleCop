// --------------------------------------------------------------------------------------------------------------------
// <copyright file="v101Settings.cs" company="https://github.com/StyleCop">
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
//   Loads settings from a pre-version 4.1 settings document.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System.Collections.Generic;
    using System.Xml;

    /// <summary>
    /// Loads settings from a pre-version 4.1 settings document.
    /// </summary>
    public static class V101Settings
    {
        #region Constants

        /// <summary>
        /// The default settings file name.
        /// </summary>
        public const string DefaultFileName = "StyleCop.Settings";

        #endregion

        #region Methods

        /// <summary>
        /// Loads a pre-version 4.1 settings document.
        /// </summary>
        /// <param name="document">
        /// The settings to load.
        /// </param>
        /// <param name="settings">
        /// The object where the settings will be stored.
        /// </param>
        internal static void Load(XmlDocument document, Settings settings)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertNotNull(settings, "settings");

            foreach (XmlNode child in document.DocumentElement.ChildNodes)
            {
                switch (child.Name)
                {
                    case "StyleCopDisabledAnalyzers":
                        EnableDisableAnalyzerRules(child, settings, false);
                        break;

                    case "StyleCopExplicitlyEnabledAnalyzers":
                        EnableDisableAnalyzerRules(child, settings, true);
                        break;

                    case "AnalyzeDesignerFiles":
                        LoadAnalyzeDesignerFilesSetting(settings, child.InnerText);
                        break;

                    case "PublicAndProtectedOnly":
                        LoadAnalyzerSetting(settings, "StyleCop.CSharp.DocumentationRules", "IgnorePrivates", child.InnerText);

                        LoadAnalyzerSetting(settings, "StyleCop.CSharp.DocumentationRules", "IgnoreInternals", child.InnerText);
                        break;

                    case "IncludeFields":
                        LoadAnalyzerSetting(settings, "StyleCop.CSharp.DocumentationRules", "IncludeFields", child.InnerText);
                        break;

                    case "GeneratedCodeElementOrder":
                        LoadAnalyzerSetting(settings, "StyleCop.CSharp.OrderingRules", "GeneratedCodeElementOrder", child.InnerText);
                        break;

                    case "RequireValueTags":
                        LoadLegacyAnalyzerSetting(settings, "StyleCop.CSharp.DocumentationRules", "RequireValueTags", child.InnerText);
                        break;

                    case "GlobalSettingsFilePath":
                        PropertyDescriptor<string> propertyDescriptor =
                            settings.Core.PropertyDescriptors[SettingsMerger.MergeSettingsFilesProperty] as PropertyDescriptor<string>;
                        if (propertyDescriptor != null)
                        {
                            settings.GlobalSettings.Add(new StringProperty(propertyDescriptor, SettingsMerger.MergeStyleLinked));
                        }

                        propertyDescriptor = settings.Core.PropertyDescriptors[SettingsMerger.LinkedSettingsProperty] as PropertyDescriptor<string>;
                        if (propertyDescriptor != null)
                        {
                            settings.GlobalSettings.Add(new StringProperty(propertyDescriptor, child.InnerText));
                        }

                        break;

                    case "StyleCopHungarian":
                        LoadValidPrefixes(child, settings);
                        break;
                }
            }
        }

        /// <summary>
        /// Adds a boolean property to the settings.
        /// </summary>
        /// <param name="propertyName">
        /// The name of the property.
        /// </param>
        /// <param name="value">
        /// The value of the property.
        /// </param>
        /// <param name="properties">
        /// The collection of properties.
        /// </param>
        /// <param name="propertyDescriptors">
        /// The collection of property descriptors.
        /// </param>
        private static void AddBooleanProperty(string propertyName, bool value, PropertyCollection properties, PropertyDescriptorCollection propertyDescriptors)
        {
            Param.AssertValidString(propertyName, "propertyName");
            Param.Ignore(value);
            Param.AssertNotNull(properties, "properties");
            Param.AssertNotNull(propertyDescriptors, "propertyDescriptors");

            // Get the property descriptor.
            PropertyDescriptor<bool> descriptor = propertyDescriptors[propertyName] as PropertyDescriptor<bool>;
            if (descriptor != null)
            {
                // Create and add the property.
                properties.Add(new BooleanProperty(descriptor, value));
            }
        }

        /// <summary>
        /// Adds or updates a property to enable or disable a rule depending on the value of a 
        /// legacy property.
        /// </summary>
        /// <param name="ruleName">
        /// The name of the rule to enable or disable.
        /// </param>
        /// <param name="value">
        /// The value of the legacy property.
        /// </param>
        /// <param name="properties">
        /// The collection of properties.
        /// </param>
        /// <param name="propertyDescriptors">
        /// The collection of property descriptors.
        /// </param>
        private static void AddOrUpdateLegacyBooleanProperty(string ruleName, bool value, PropertyCollection properties, PropertyDescriptorCollection propertyDescriptors)
        {
            Param.AssertValidString(ruleName, "ruleName");
            Param.Ignore(value);
            Param.AssertNotNull(properties, "properties");
            Param.AssertNotNull(propertyDescriptors, "propertyDescriptors");

            // Determine whethere is already an Enabled property for this rule.
            string propertyName = ruleName + "#Enabled";
            BooleanProperty property = properties[propertyName] as BooleanProperty;
            if (property == null)
            {
                // Add a new property which enables or disables this rule depending on the
                // value of the legacy property.
                AddBooleanProperty(propertyName, value, properties, propertyDescriptors);
            }
            else if (!value)
            {
                // The rule has already been explictely enabled or disabled. In this case we
                // never enable the rule, but we may disable it if the legacy property is set to false.
                property.Value = false;
            }
        }

        /// <summary>
        /// Enables or disables all rules for the given analyzers.
        /// </summary>
        /// <param name="disabledAnalyzersNode">
        /// The node representing the analyzer.
        /// </param>
        /// <param name="settings">
        /// The settings.
        /// </param>
        /// <param name="enabled">
        /// Indicates whether to enable or disable the rules.
        /// </param>
        private static void EnableDisableAnalyzerRules(XmlNode disabledAnalyzersNode, Settings settings, bool enabled)
        {
            Param.AssertNotNull(disabledAnalyzersNode, "disabledAnalyzersNode");
            Param.AssertNotNull(settings, "settings");
            Param.Ignore(enabled);

            string[] ids = disabledAnalyzersNode.InnerText.Split(',');

            foreach (string id in ids)
            {
                string analyzerId43 = MapAnalyzerId(id);

                if (analyzerId43 != null)
                {
                    SourceAnalyzer analyzer = settings.Core.GetAnalyzer(analyzerId43);
                    if (analyzer != null)
                    {
                        ICollection<string> rules = MapAnalyzerToRules(id);
                        if (rules != null)
                        {
                            AddInPropertyCollection settingsForAnalyzer = settings.GetAddInSettings(analyzer);

                            if (settingsForAnalyzer == null)
                            {
                                settingsForAnalyzer = new AddInPropertyCollection(analyzer);
                                settings.SetAddInSettings(settingsForAnalyzer);
                            }

                            foreach (string rule in rules)
                            {
                                AddBooleanProperty(rule + "#Enabled", enabled, settingsForAnalyzer, analyzer.PropertyDescriptors);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sets the AnalyzeDesignerFiles property on the C# parser.
        /// </summary>
        /// <param name="settings">
        /// The settings collection.
        /// </param>
        /// <param name="nodeText">
        /// The text of the setting from the settings file.
        /// </param>
        private static void LoadAnalyzeDesignerFilesSetting(Settings settings, string nodeText)
        {
            Param.AssertNotNull(settings, "settings");
            Param.AssertValidString(nodeText, "nodeText");

            SourceParser parser = settings.Core.GetParser("StyleCop.CSharp.CsParser");
            if (parser != null)
            {
                PropertyDescriptor<bool> propertyDescriptor = parser.PropertyDescriptors["AnalyzeDesignerFiles"] as PropertyDescriptor<bool>;
                if (propertyDescriptor != null)
                {
                    settings.SetAddInSettingInternal(parser, new BooleanProperty(propertyDescriptor, nodeText != "0"));
                }
            }
        }

        /// <summary>
        /// Sets the given property on the given parser.
        /// </summary>
        /// <param name="settings">
        /// The settings collection.
        /// </param>
        /// <param name="analyzerId">
        /// The ID of the analyzer.
        /// </param>
        /// <param name="propertyName">
        /// The name of the property to set.
        /// </param>
        /// <param name="nodeText">
        /// The text of the setting from the settings file.
        /// </param>
        private static void LoadAnalyzerSetting(Settings settings, string analyzerId, string propertyName, string nodeText)
        {
            Param.AssertNotNull(settings, "settings");
            Param.AssertValidString(analyzerId, "analyzerId");
            Param.AssertValidString(propertyName, "propertyName");
            Param.AssertValidString(nodeText, "nodeText");

            SourceAnalyzer analyzer = settings.Core.GetAnalyzer(analyzerId);
            if (analyzer != null)
            {
                PropertyDescriptor<bool> propertyDescriptor = analyzer.PropertyDescriptors[propertyName] as PropertyDescriptor<bool>;
                if (propertyDescriptor != null)
                {
                    settings.SetAddInSettingInternal(analyzer, new BooleanProperty(propertyDescriptor, nodeText != "0"));
                }
            }
        }

        /// <summary>
        /// Loads a property which no longer exists, and translates it into an enabled or
        /// disabled rule.
        /// </summary>
        /// <param name="settings">
        /// The settings.
        /// </param>
        /// <param name="analyzerId">
        /// The ID of the analyzer owning the property.
        /// </param>
        /// <param name="propertyName">
        /// The name of legacy property.
        /// </param>
        /// <param name="nodeText">
        /// The property value.
        /// </param>
        private static void LoadLegacyAnalyzerSetting(Settings settings, string analyzerId, string propertyName, string nodeText)
        {
            Param.AssertNotNull(settings, "settings");
            Param.AssertValidString(analyzerId, "analyzerId");
            Param.AssertValidString(propertyName, "propertyName");
            Param.AssertNotNull(nodeText, "nodeText");

            switch (analyzerId)
            {
                case "StyleCop.CSharp.DocumentationRules":
                    if (propertyName == "RequireValueTags")
                    {
                        SourceAnalyzer analyzer = settings.Core.GetAnalyzer(analyzerId);
                        if (analyzer != null)
                        {
                            AddInPropertyCollection settingsForAnalyzer = settings.GetAddInSettings(analyzer);

                            if (settingsForAnalyzer == null)
                            {
                                settingsForAnalyzer = new AddInPropertyCollection(analyzer);
                                settings.SetAddInSettings(settingsForAnalyzer);
                            }

                            bool enabled = nodeText != "0";

                            AddOrUpdateLegacyBooleanProperty("PropertyDocumentationMustHaveValue", enabled, settingsForAnalyzer, analyzer.PropertyDescriptors);

                            AddOrUpdateLegacyBooleanProperty("PropertyDocumentationMustHaveValueText", enabled, settingsForAnalyzer, analyzer.PropertyDescriptors);
                        }
                    }

                    break;
            }
        }

        /// <summary>
        /// Loads the valid prefixes from the given node..
        /// </summary>
        /// <param name="validPrefixesNode">
        /// The node containing the prefixes.
        /// </param>
        /// <param name="settings">
        /// The settings collection.
        /// </param>
        private static void LoadValidPrefixes(XmlNode validPrefixesNode, Settings settings)
        {
            Param.AssertNotNull(validPrefixesNode, "validPrefixesNode");
            Param.AssertNotNull(settings, "settings");

            string[] prefixes = validPrefixesNode.InnerText.Split(',');

            // Get the analyzer.
            SourceAnalyzer analyzer = settings.Core.GetAnalyzer("StyleCop.CSharp.NamingRules");
            if (analyzer != null)
            {
                // Get the property descriptor.
                CollectionPropertyDescriptor propertyDescriptor = analyzer.PropertyDescriptors["Hungarian"] as CollectionPropertyDescriptor;
                if (propertyDescriptor != null)
                {
                    settings.SetAddInSettingInternal(analyzer, new CollectionProperty(propertyDescriptor, prefixes));
                }
            }
        }

        /// <summary>
        /// Maps a 4.0 analyzer ID to a 4.3 analyzer ID.
        /// </summary>
        /// <param name="analyzerId">
        /// The ID of the 4.0 analyzer.
        /// </param>
        /// <returns>
        /// Returns the 4.3 analyzer ID.
        /// </returns>
        private static string MapAnalyzerId(string analyzerId)
        {
            Param.AssertValidString(analyzerId, "analyzerId");

            switch (analyzerId.ToUpperInvariant())
            {
                case "E508A3D4-B487-4D5F-8386-5827FA1334CD":

                    // Variable names
                    return "StyleCop.CSharp.NamingRules";

                case "C0F8B61A-DC6C-4550-8652-1074C95520B6":

                    // Field underscores
                    return "StyleCop.CSharp.NamingRules";

                case "F3EA01DF-3F2F-42AF-865D-84768B8CF4B0":

                    // Element name case
                    return "StyleCop.CSharp.NamingRules";

                case "25474DA2-9B71-48A9-BA76-A4726EC8C48E":

                    // Interface names
                    return "StyleCop.CSharp.NamingRules";

                case "C17BFE16-544B-11DA-8BDE-F66BAD1E3F3A":

                    // Statements
                    return "StyleCop.CSharp.ReadabilityRules";

                case "8DE5A506-0BD9-478B-95AF-2B3EC20C2093":

                    // Method parameter placement
                    return "StyleCop.CSharp.ReadabilityRules";

                case "3B74A427-6D8D-4808-9FCD-520F15E8517C":

                    // Comments
                    return "StyleCop.CSharp.ReadabilityRules";

                case "2771D7CA-F585-4832-B2C2-88DA370EBAC1":

                    // Class members
                    return "StyleCop.CSharp.ReadabilityRules";

                case "64C9DA50-FC1A-4F20-986E-72AAA00B8ED4":

                    // Spacing
                    return "StyleCop.CSharp.SpacingRules";

                case "19F875BA-368A-40D8-B70A-5D26DF5BEBDD":

                    // Tabs
                    return "StyleCop.CSharp.SpacingRules";

                case "9ADAF7F0-E57D-4DF7-9885-ABAB2A9149FC":

                    // Field access modifiers
                    return "StyleCop.CSharp.MaintainabilityRules";

                case "C0FC9515-97A4-4D61-89CD-9D87FEDD5B24":

                    // Parenthesis
                    return "StyleCop.CSharp.MaintainabilityRules";

                case "F6912B0F-C5FC-453D-BA02-183C3C9A2A8B":

                    // Access modifiers
                    return "StyleCop.CSharp.LayoutRules";

                case "5937033A-122C-492E-9C08-6F1AE80D1710":

                    // Line spacing
                    return "StyleCop.CSharp.LayoutRules";

                case "305C458B-4CEC-4E49-96A9-E8012B333C7B":

                    // Bracket placement
                    return "StyleCop.CSharp.LayoutRules";

                case "31B0AB2A-8EED-4815-9F2D-C5A439EA9809":

                    // File headers
                    return "StyleCop.CSharp.DocumentationRules";

                case "A2B149D9-1F5E-4D79-8E8B-2273E956B9DD":

                    // Xml headers
                    return "StyleCop.CSharp.DocumentationRules";

                case "E2283402-D0B2-468D-81BC-DE32B48B7A4C":

                    // Element order
                    return "StyleCop.CSharp.OrderingRules";

                case "6D18499A-AA21-4BE5-9590-7C8BEC56C1F8":

                    // Declaration keyword order
                    return "StyleCop.CSharp.OrderingRules";
            }

            return null;
        }

        /// <summary>
        /// Maps the given 4.1 analyzer name to a list of 4.3 rules.
        /// </summary>
        /// <param name="analyzerId">
        /// The ID of the 4.1 analyzer.
        /// </param>
        /// <returns>
        /// Returns the collection of 4.3 rules mapping to the analyzer.
        /// </returns>
        private static ICollection<string> MapAnalyzerToRules(string analyzerId)
        {
            Param.AssertValidString(analyzerId, "analyzerId");

            switch (analyzerId.ToUpperInvariant())
            {
                case "E508A3D4-B487-4D5F-8386-5827FA1334CD":
                    return new[]
                               {
                                   "ConstFieldNamesMustBeginWithUpperCaseLetter", "NonPrivateReadonlyFieldsMustBeginWithUpperCaseLetter", 
                                   "FieldNamesMustNotUseHungarianNotation", "FieldNamesMustBeginWithLowerCaseLetter", "AccessibleFieldsMustBeginWithUpperCaseLetter"
                               };

                case "C0F8B61A-DC6C-4550-8652-1074C95520B6":
                    return new[] { "VariableNamesMustNotBePrefixed", "FieldNamesMustNotBeginWithUnderscore", "FieldNamesMustNotContainUnderscore" };

                case "F3EA01DF-3F2F-42AF-865D-84768B8CF4B0":
                    return new[] { "ElementMustBeginWithUpperCaseLetter", "ElementMustBeginWithLowerCaseLetter" };

                case "25474DA2-9B71-48A9-BA76-A4726EC8C48E":
                    return new[] { "InterfaceNamesMustBeginWithI" };

                case "C17BFE16-544B-11DA-8BDE-F66BAD1E3F3A":
                    return new[] { "CodeMustNotContainEmptyStatements", "CodeMustNotContainMultipleStatementsOnOneLine", };

                case "C0FC9515-97A4-4D61-89CD-9D87FEDD5B24":
                    return new[] { "StatementMustNotUseUnnecessaryParenthesis" };

                case "8DE5A506-0BD9-478B-95AF-2B3EC20C2093":
                    return new[]
                               {
                                   "OpeningParenthesisMustBeOnDeclarationLine", "ClosingParenthesisMustBeOnLineOfLastParameter", 
                                   "ClosingParenthesisMustBeOnLineOfOpeningParenthesis", "CommaMustBeOnSameLineAsPreviousParameter", "ParameterListMustFollowDeclaration", 
                                   "ParameterMustFollowComma", "SplitParametersMustStartOnLineAfterDeclaration", "ParametersMustBeOnSameLineOrSeparateLines", 
                                   "ParameterMustNotSpanMultipleLines"
                               };

                case "2771D7CA-F585-4832-B2C2-88DA370EBAC1":
                    return new[] { "DoNotPrefixCallsWithBaseUnlessLocalImplementationExists", "PrefixLocalCallsWithThis" };

                case "64C9DA50-FC1A-4F20-986E-72AAA00B8ED4":
                    return new[]
                               {
                                   "KeywordsMustBeSpacedCorrectly", "CommasMustBeSpacedCorrectly", "SemicolonsMustBeSpacedCorrectly", "SymbolsMustBeSpacedCorrectly", 
                                   "DocumentationLinesMustBeginWithSingleSpace", "SingleLineCommentsMustBeginWithSingleSpace", 
                                   "PreprocessorKeywordsMustNotBePrecededBySpace", "OperatorKeywordMustBeFollowedBySpace", "OpeningParenthesisMustBeSpacedCorrectly", 
                                   "ClosingParenthesisMustBeSpacedCorrectly", "OpeningSquareBracketsMustBeSpacedCorrectly", "ClosingSquareBracketsMustBeSpacedCorrectly", 
                                   "OpeningCurlyBracketsMustBeSpacedCorrectly", "ClosingCurlyBracketsMustBeSpacedCorrectly", "OpeningGenericBracketsMustBeSpacedCorrectly", 
                                   "ClosingGenericBracketsMustBeSpacedCorrectly", "OpeningAttributeBracketsMustBeSpacedCorrectly", 
                                   "ClosingAttributeBracketsMustBeSpacedCorrectly", "NullableTypeSymbolsMustNotBePrecededBySpace", 
                                   "MemberAccessSymbolsMustBeSpacedCorrectly", "IncrementDecrementSymbolsMustBeSpacedCorrectly", "NegativeSignsMustBeSpacedCorrectly", 
                                   "PositiveSignsMustBeSpacedCorrectly", "DereferenceAndAccessOfSymbolsMustBeSpacedCorrectly", "ColonsMustBeSpacedCorrectly", 
                                   "CodeMustNotContainMultipleWhitespaceInARow", "CodeMustNotContainSpaceAfterNewKeywordInImplicitlyTypedArrayAllocation"
                               };

                case "19F875BA-368A-40D8-B70A-5D26DF5BEBDD":
                    return new[] { "TabsMustNotBeUsed" };

                case "9ADAF7F0-E57D-4DF7-9885-ABAB2A9149FC":
                    return new[] { "FieldsMustBePrivate" };

                case "F6912B0F-C5FC-453D-BA02-183C3C9A2A8B":
                    return new[] { "AccessModifierMustBeDeclared", "FieldsMustBePrivate" };

                case "5937033A-122C-492E-9C08-6F1AE80D1710":
                    return new[]
                               {
                                   "OpeningCurlyBracketsMustNotBeFollowedByBlankLine", "ElementDocumentationHeadersMustNotBeFollowedByBlankLine", 
                                   "CodeMustNotContainMultipleBlankLinesInARow", "ClosingCurlyBracketsMustNotBePrecededByBlankLine", 
                                   "OpeningCurlyBracketsMustNotBePrecededByBlankLine", "ChainedStatementBlocksMustNotBePrecededByBlankLine", 
                                   "WhileDoFooterMustNotBePrecededByBlankLine", "SingleLineCommentsMustNotBeFollowedByBlankLine", 
                                   "ClosingCurlyBracketMustBeFollowedByBlankLine", "ElementDocumentationHeaderMustBePrecededByBlankLine", 
                                   "SingleLineCommentMustBePrecededByBlankLine"
                               };

                case "305C458B-4CEC-4E49-96A9-E8012B333C7B":
                    return new[]
                               {
                                   "CurlyBracketsForMultiLineStatementsMustNotShareLine", "StatementMustNotBeOnSingleLine", "ElementMustNotBeOnSingleLine", 
                                   "CurlyBracketsMustNotBeOmitted", "AllAccessorsMustBeMultiLineOrSingleLine"
                               };

                case "31B0AB2A-8EED-4815-9F2D-C5A439EA9809":
                    return new[]
                               {
                                   "FileMustHaveHeader", "FileHeaderMustShowCopyright", "FileHeaderMustHaveCopyrightText", "FileHeaderMustContainFileName", 
                                   "FileHeaderFileNameDocumentationMustMatchFileName", "FileHeaderMustHaveSummary", "FileHeaderMustHaveValidCompanyText"
                               };

                case "A2B149D9-1F5E-4D79-8E8B-2273E956B9DD":
                    return new[]
                               {
                                   "ElementsMustBeDocumented", "PartialElementsMustBeDocumented", "EnumerationItemsMustBeDocumented", "DocumentationMustContainValidXml", 
                                   "ElementDocumentationMustHaveSummary", "PartialElementDocumentationMustHaveSummary", "ElementDocumentationMustHaveSummaryText", 
                                   "PartialElementDocumentationMustHaveSummaryText", "ElementDocumentationMustNotHaveDefaultSummary", "PropertyDocumentationMustHaveValue", 
                                   "PropertyDocumentationMustHaveValueText", "ElementParametersMustBeDocumented", "ElementParameterDocumentationMustMatchElementParameters", 
                                   "ElementParameterDocumentationMustDeclareParameterName", "ElementParameterDocumentationMustHaveText", 
                                   "ElementReturnValueMustBeDocumented", "ElementReturnValueDocumentationMustHaveText", "VoidReturnValueMustNotBeDocumented", 
                                   "GenericTypeParametersMustBeDocumented", "GenericTypeParametersMustBeDocumentedPartialClass", 
                                   "GenericTypeParameterDocumentationMustMatchTypeParameters", "GenericTypeParameterDocumentationMustDeclareParameterName", 
                                   "GenericTypeParameterDocumentationMustHaveText", "PropertySummaryDocumentationMustMatchAccessors", 
                                   "PropertySummaryDocumentationMustOmitSetAccessorWithRestrictedAccess", "ElementDocumentationMustNotBeCopiedAndPasted", 
                                   "SingleLineCommentsMustNotUseDocumentationStyleSlashes", "DocumentationTextMustNotBeEmpty", 
                                   "DocumentationTextMustBeginWithACapitalLetter", "DocumentationTextMustEndWithAPeriod", "DocumentationTextMustContainWhitespace", 
                                   "DocumentationMustMeetCharacterPercentage", "DocumentationTextMustMeetMinimumCharacterLength"
                               };

                case "E2283402-D0B2-468D-81BC-DE32B48B7A4C":
                    return new[]
                               {
                                   "UsingDirectivesMustBePlacedWithinNamespace", "ElementsMustAppearInTheCorrectOrder", "ElementsMustBeOrderedByAccess", 
                                   "ConstantsMustAppearBeforeFields", "StaticElementsMustAppearBeforeInstanceElements", "PartialElementsMustDeclareAccess"
                               };

                case "6D18499A-AA21-4BE5-9590-7C8BEC56C1F8":
                    return new[] { "DeclarationKeywordsMustFollowOrder", "ProtectedMustComeBeforeInternal" };

                case "3B74A427-6D8D-4808-9FCD-520F15E8517C":
                    return new[] { "CommentsMustContainText" };
            }

            return new string[] { };
        }

        #endregion
    }
}