// --------------------------------------------------------------------------------------------------------------------
// <copyright file="v102Settings.cs" company="https://github.com/StyleCop">
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
//   Loads settings from a version 4.1 settings document.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Xml;

    /// <summary>
    /// Loads settings from a version 4.1 settings document.
    /// </summary>
    internal static class V102Settings
    {
        #region Public Methods and Operators

        /// <summary>
        /// Changes the name of an analyzer setting property, if it exists.
        /// </summary>
        /// <param name="document">
        /// The settings document.
        /// </param>
        /// <param name="analyzerName">
        /// The analyzer name.
        /// </param>
        /// <param name="legacyPropertyName">
        /// The legacy name of the property.
        /// </param>
        /// <param name="newPropertyName">
        /// The new name of the property.
        /// </param>
        public static void ChangeAnalyzerSettingName(XmlDocument document, string analyzerName, string legacyPropertyName, string newPropertyName)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertValidString(analyzerName, "analyzerName");
            Param.AssertValidString(legacyPropertyName, "legacyPropertyName");
            Param.AssertValidString(newPropertyName, "newPropertyName");

            XmlNode analyzersNode = document.DocumentElement.SelectSingleNode("Analyzers");
            if (analyzersNode != null)
            {
                XmlNode analyzerNode = analyzersNode.SelectSingleNode("Analyzer[@AnalyzerId=\"" + analyzerName + "\"]");

                if (analyzerNode != null)
                {
                    XmlNode analyzerSettingsNode = analyzerNode.SelectSingleNode("AnalyzerSettings");
                    if (analyzerSettingsNode != null)
                    {
                        // This rule node must be moved under the new analyzer section.
                        // Check whether this section already exists.
                        XmlNode propertyNode = analyzerSettingsNode.SelectSingleNode("*[@Name=\"" + legacyPropertyName + "\"]");

                        if (propertyNode != null)
                        {
                            XmlAttribute attribute = propertyNode.Attributes["Name"];
                            if (attribute != null)
                            {
                                attribute.Value = newPropertyName;
                            }
                        }
                    }
                }
            }
        }

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

            // If the PublicAndProtectedOnly property exists on the Documentation analyzer, rename it to IgnorePrivates.
            V102Settings.ChangeAnalyzerSettingName(document, "StyleCop.CSharp.Documentation", "PublicAndProtectedOnly", "IgnorePrivates");

            // Add the global settings if there are any.
            XmlNode globalSettingsNode = document.DocumentElement["GlobalSettings"];
            if (globalSettingsNode != null)
            {
                LoadPropertyCollection(globalSettingsNode, settings.GlobalSettings, settings.Core.PropertyDescriptors, null);
            }

            // Load the parser settings.
            LoadParserSettings(document, settings);

            // Load the analyzers under this parser.
            LoadAnalyzerSettings(document, settings);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a boolean property.
        /// </summary>
        /// <param name="propertyName">
        /// The name of the property.
        /// </param>
        /// <param name="value">
        /// The property value.
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
        /// Loads analyzer settings from the document.
        /// </summary>
        /// <param name="document">
        /// The settings document.
        /// </param>
        /// <param name="settings">
        /// Stores the settings.
        /// </param>
        private static void LoadAnalyzerSettings(XmlDocument document, Settings settings)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertNotNull(settings, "settings");

            XmlNodeList analyzerNodes = document.DocumentElement.SelectNodes("Analyzers/Analyzer");
            if (analyzerNodes != null && analyzerNodes.Count > 0)
            {
                foreach (XmlNode analyzerNode in analyzerNodes)
                {
                    XmlAttribute analyzerId = analyzerNode.Attributes["AnalyzerId"];
                    if (analyzerId != null && !string.IsNullOrEmpty(analyzerId.Value))
                    {
                        string analyzerId43 = MapAnalyzerId(analyzerId.Value);

                        // Get the analyzer instance for this mapped analyzer ID.
                        SourceAnalyzer analyzerInstance = settings.Core.GetAnalyzer(analyzerId43);
                        if (analyzerInstance != null)
                        {
                            // Get the analyzer settings object for this analyzer or create a new one.
                            AddInPropertyCollection settingsForAnalyzer = settings.GetAddInSettings(analyzerInstance);

                            if (settingsForAnalyzer == null)
                            {
                                settingsForAnalyzer = new AddInPropertyCollection(analyzerInstance);
                                settings.SetAddInSettings(settingsForAnalyzer);
                            }

                            // Load the settings for this analyzer.
                            XmlNode analyzerSettingsNode = analyzerNode["AnalyzerSettings"];
                            if (analyzerSettingsNode != null)
                            {
                                LoadPropertyCollection(analyzerSettingsNode, settingsForAnalyzer, analyzerInstance.PropertyDescriptors, analyzerId.Value);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Loads and stores a boolean property.
        /// </summary>
        /// <param name="propertyName">
        /// The name of the property to load.
        /// </param>
        /// <param name="propertyNode">
        /// The node containing the property.
        /// </param>
        /// <param name="properties">
        /// The collection in which to store the property.
        /// </param>
        /// <param name="propertyDescriptors">
        /// The collection of property descriptors.
        /// </param>
        /// <param name="legacyAnalyzerId">
        /// If the settings node comes from a legacy, pre-4.2 analyzer,
        /// this parameter contains the ID of the legacy analyzer.
        /// </param>
        private static void LoadBooleanProperty(
            string propertyName, XmlNode propertyNode, PropertyCollection properties, PropertyDescriptorCollection propertyDescriptors, string legacyAnalyzerId)
        {
            Param.AssertValidString(propertyName, "propertyName");
            Param.AssertNotNull(propertyNode, "propertyNode");
            Param.AssertNotNull(properties, "properties");
            Param.AssertNotNull(propertyDescriptors, "propertyDescriptors");
            Param.Ignore(legacyAnalyzerId);

            // Skip corrupted properties.
            bool value;
            if (bool.TryParse(propertyNode.InnerText, out value))
            {
                if (string.IsNullOrEmpty(legacyAnalyzerId))
                {
                    AddBooleanProperty(propertyName, value, properties, propertyDescriptors);
                }
                else
                {
                    if (propertyName == "Enabled")
                    {
                        // Enable or disable all rules mapping to the legacy analyzer.
                        ICollection<string> rules = MapAnalyzerToRules(legacyAnalyzerId);
                        if (rules != null)
                        {
                            foreach (string rule in rules)
                            {
                                AddBooleanProperty(rule + "#Enabled", value, properties, propertyDescriptors);
                            }
                        }
                    }
                    else if (legacyAnalyzerId == "Microsoft.SourceAnalysis.CSharp.Documentation")
                    {
                        if (propertyName == "PublicAndProtectedOnly")
                        {
                            AddBooleanProperty("IgnorePrivates", value, properties, propertyDescriptors);
                            AddBooleanProperty("IgnoreInternals", value, properties, propertyDescriptors);
                        }
                        else if (propertyName == "RequireValueTags")
                        {
                            AddOrUpdateLegacyBooleanProperty("PropertyDocumentationMustHaveValue", value, properties, propertyDescriptors);
                            AddOrUpdateLegacyBooleanProperty("PropertyDocumentationMustHaveValueText", value, properties, propertyDescriptors);
                        }
                        else if (propertyName == "RequireCapitalLetter")
                        {
                            AddOrUpdateLegacyBooleanProperty("DocumentationTextMustBeginWithACapitalLetter", value, properties, propertyDescriptors);
                        }
                        else if (propertyName == "RequirePeriod")
                        {
                            AddOrUpdateLegacyBooleanProperty("DocumentationTextMustEndWithAPeriod", value, properties, propertyDescriptors);
                        }
                        else if (propertyName == "RequireProperFormatting")
                        {
                            AddOrUpdateLegacyBooleanProperty("DocumentationTextMustContainWhitespace", value, properties, propertyDescriptors);
                            AddOrUpdateLegacyBooleanProperty("DocumentationMustMeetCharacterPercentage", value, properties, propertyDescriptors);
                            AddOrUpdateLegacyBooleanProperty("DocumentationTextMustMeetMinimumCharacterLength", value, properties, propertyDescriptors);

                            if (!value)
                            {
                                AddOrUpdateLegacyBooleanProperty("DocumentationTextMustEndWithAPeriod", value, properties, propertyDescriptors);
                                AddOrUpdateLegacyBooleanProperty("DocumentationTextMustBeginWithACapitalLetter", value, properties, propertyDescriptors);
                            }
                        }
                        else
                        {
                            AddBooleanProperty(propertyName, value, properties, propertyDescriptors);
                        }
                    }
                    else if (legacyAnalyzerId == "Microsoft.SourceAnalysis.CSharp.FileHeaders")
                    {
                        if (propertyName == "RequireSummary")
                        {
                            AddOrUpdateLegacyBooleanProperty("FileHeaderMustHaveSummary", value, properties, propertyDescriptors);
                        }
                        else
                        {
                            AddBooleanProperty(propertyName, value, properties, propertyDescriptors);
                        }
                    }
                    else
                    {
                        AddBooleanProperty(propertyName, value, properties, propertyDescriptors);
                    }
                }
            }
        }

        /// <summary>
        /// Loads and stores a collection property.
        /// </summary>
        /// <param name="propertyName">
        /// The name of the property to load.
        /// </param>
        /// <param name="propertyNode">
        /// The node containing the property.
        /// </param>
        /// <param name="properties">
        /// The collection in which to store the property.
        /// </param>
        /// <param name="propertyDescriptors">
        /// The collection of property descriptors.
        /// </param>
        private static void LoadCollectionProperty(
            string propertyName, XmlNode propertyNode, PropertyCollection properties, PropertyDescriptorCollection propertyDescriptors)
        {
            Param.AssertValidString(propertyName, "propertyName");
            Param.AssertNotNull(propertyNode, "propertyNode");
            Param.AssertNotNull(properties, "properties");
            Param.AssertNotNull(propertyDescriptors, "propertyDescriptors");

            // Create and load the inner property collection.
            List<string> innerCollection = new List<string>();

            // Load the value list.
            XmlNodeList valueNodes = propertyNode.SelectNodes("Value");
            if (valueNodes != null && valueNodes.Count > 0)
            {
                foreach (XmlNode valueNode in valueNodes)
                {
                    if (!string.IsNullOrEmpty(valueNode.InnerText))
                    {
                        innerCollection.Add(valueNode.InnerText);
                    }
                }
            }

            // If at least one value was loaded, save the proeprty.
            if (innerCollection.Count > 0)
            {
                // Get the property descriptor.
                CollectionPropertyDescriptor descriptor = propertyDescriptors[propertyName] as CollectionPropertyDescriptor;

                // Create the collection node and pass in the inner collection.
                CollectionProperty collectionProperty = new CollectionProperty(descriptor, innerCollection);

                // Add this property to the parent collection.
                properties.Add(collectionProperty);
            }
        }

        /// <summary>
        /// Loads and stores an integer property.
        /// </summary>
        /// <param name="propertyName">
        /// The name of the property to load.
        /// </param>
        /// <param name="propertyNode">
        /// The node containing the property.
        /// </param>
        /// <param name="properties">
        /// The collection in which to store the property.
        /// </param>
        /// <param name="propertyDescriptors">
        /// The collection of property descriptors.
        /// </param>
        private static void LoadIntProperty(string propertyName, XmlNode propertyNode, PropertyCollection properties, PropertyDescriptorCollection propertyDescriptors)
        {
            Param.AssertValidString(propertyName, "propertyName");
            Param.AssertNotNull(propertyNode, "propertyNode");
            Param.AssertNotNull(properties, "properties");
            Param.AssertNotNull(propertyDescriptors, "propertyDescriptors");

            // Skip corrupted properties.
            int value;
            if (int.TryParse(propertyNode.InnerText, NumberStyles.Any, CultureInfo.InvariantCulture, out value))
            {
                // Get the property descriptor.
                PropertyDescriptor<int> descriptor = propertyDescriptors[propertyName] as PropertyDescriptor<int>;

                // Create and add the property.
                properties.Add(new IntProperty(descriptor, value));
            }
        }

        /// <summary>
        /// Loads parser settings from the document.
        /// </summary>
        /// <param name="document">
        /// The settings document.
        /// </param>
        /// <param name="settings">
        /// Stores the settings.
        /// </param>
        private static void LoadParserSettings(XmlDocument document, Settings settings)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertNotNull(settings, "settings");

            XmlNodeList parsersNodes = document.DocumentElement.SelectNodes("Parsers/Parser");
            if (parsersNodes != null && parsersNodes.Count > 0)
            {
                foreach (XmlNode parserNode in parsersNodes)
                {
                    XmlAttribute parserId = parserNode.Attributes["ParserId"];
                    if (parserId != null && !string.IsNullOrEmpty(parserId.Value))
                    {
                        string parserName = parserId.Value;
                        if (parserName.Equals("Microsoft.SourceAnalysis.CSharp.CsParser", StringComparison.Ordinal))
                        {
                            parserName = "StyleCop.CSharp.CsParser";
                        }

                        // Get the parser instance.
                        SourceParser parserInstance = settings.Core.GetParser(parserName);
                        if (parserInstance != null)
                        {
                            // Get the parser settings object for this parser or create a new one.
                            AddInPropertyCollection settingsForParser = settings.GetAddInSettings(parserInstance);

                            if (settingsForParser == null)
                            {
                                settingsForParser = new AddInPropertyCollection(parserInstance);
                                settings.SetAddInSettings(settingsForParser);
                            }

                            // Load the settings for this parser.
                            XmlNode parserSettingsNode = parserNode["ParserSettings"];
                            if (parserSettingsNode != null)
                            {
                                LoadPropertyCollection(parserSettingsNode, settingsForParser, parserInstance.PropertyDescriptors, null);
                            }

                            // Load any rule settings for the parser.
                            LoadRulesSettings(parserNode, settingsForParser, parserInstance.PropertyDescriptors);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Loads a property collection from the settings file.
        /// </summary>
        /// <param name="propertyCollectionNode">
        /// The node containing the property collection.
        /// </param>
        /// <param name="properties">
        /// The property collection storage object.
        /// </param>
        /// <param name="propertyDescriptors">
        /// The collection of property descriptors.
        /// </param>
        /// <param name="legacyAnalyzerId">
        /// If the settings node comes from a legacy, pre-4.2 analyzer,
        /// this parameter contains the ID of the legacy analyzer.
        /// </param>
        private static void LoadPropertyCollection(
            XmlNode propertyCollectionNode, PropertyCollection properties, PropertyDescriptorCollection propertyDescriptors, string legacyAnalyzerId)
        {
            Param.AssertNotNull(propertyCollectionNode, "settingsNode");
            Param.AssertNotNull(properties, "properties");
            Param.AssertNotNull(propertyDescriptors, "propertyDescriptors");
            Param.Ignore(legacyAnalyzerId);

            foreach (XmlNode propertyNode in propertyCollectionNode.ChildNodes)
            {
                // Get the property name.
                XmlAttribute propertyName = propertyNode.Attributes["Name"];
                if (propertyName != null && !string.IsNullOrEmpty(propertyName.Value))
                {
                    // Load the property.
                    switch (propertyNode.Name)
                    {
                        case "BooleanProperty":
                            LoadBooleanProperty(propertyName.InnerText, propertyNode, properties, propertyDescriptors, legacyAnalyzerId);
                            break;

                        case "IntegerProperty":
                            LoadIntProperty(propertyName.InnerText, propertyNode, properties, propertyDescriptors);
                            break;

                        case "StringProperty":
                            LoadStringProperty(propertyName.InnerText, propertyNode, properties, propertyDescriptors);
                            break;

                        case "CollectionProperty":
                            LoadCollectionProperty(propertyName.InnerText, propertyNode, properties, propertyDescriptors);
                            break;

                        default:

                            // Ignore any unexpected settings.
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Loads settings for rules.
        /// </summary>
        /// <param name="addInNode">
        /// The add-in containing the rules.
        /// </param>
        /// <param name="properties">
        /// The collection of properties to add the rules settings into.
        /// </param>
        /// <param name="propertyDescriptors">
        /// The collection of property descriptors for the add-in.
        /// </param>
        private static void LoadRulesSettings(XmlNode addInNode, PropertyCollection properties, PropertyDescriptorCollection propertyDescriptors)
        {
            Param.AssertNotNull(addInNode, "addInNode");
            Param.AssertNotNull(properties, "properties");
            Param.AssertNotNull(propertyDescriptors, "propertyDescriptors");

            XmlNode rulesNode = addInNode["Rules"];
            if (rulesNode != null)
            {
                foreach (XmlNode child in rulesNode.ChildNodes)
                {
                    if (string.Equals(child.Name, "Rule", StringComparison.Ordinal))
                    {
                        XmlAttribute name = child.Attributes["Name"];
                        if (name != null && !string.IsNullOrEmpty(name.Value))
                        {
                            string ruleName = name.Value;

                            XmlNode ruleSettings = child["RuleSettings"];
                            if (ruleSettings != null)
                            {
                                LoadPropertyCollection(ruleSettings, properties, propertyDescriptors, ruleName);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Loads and stores a string property.
        /// </summary>
        /// <param name="propertyName">
        /// The name of the property to load.
        /// </param>
        /// <param name="propertyNode">
        /// The node containing the property.
        /// </param>
        /// <param name="properties">
        /// The collection in which to store the property.
        /// </param>
        /// <param name="propertyDescriptors">
        /// The collection of property descriptors.
        /// </param>
        private static void LoadStringProperty(string propertyName, XmlNode propertyNode, PropertyCollection properties, PropertyDescriptorCollection propertyDescriptors)
        {
            Param.AssertValidString(propertyName, "propertyName");
            Param.AssertNotNull(propertyNode, "propertyNode");
            Param.AssertNotNull(properties, "properties");
            Param.AssertNotNull(propertyDescriptors, "propertyDescriptors");

            // Get the property descriptor.
            PropertyDescriptor<string> descriptor = propertyDescriptors[propertyName] as PropertyDescriptor<string>;

            // Create and add the property.
            properties.Add(new StringProperty(descriptor, propertyNode.InnerText));
        }

        /// <summary>
        /// Maps a 4.1 analyzer ID to a 4.3 analyzer ID.
        /// </summary>
        /// <param name="analyzerId">
        /// The ID of the 4.1 analyzer.
        /// </param>
        /// <returns>
        /// Returns the 4.3 analyzer ID.
        /// </returns>
        private static string MapAnalyzerId(string analyzerId)
        {
            Param.AssertValidString(analyzerId, "analyzerId");

            if (string.Equals(analyzerId, "Microsoft.SourceAnalysis.CSharp.AccessModifiers", StringComparison.OrdinalIgnoreCase))
            {
                return "StyleCop.CSharp.MaintainabilityRules";
            }
            else if (string.Equals(analyzerId, "Microsoft.SourceAnalysis.CSharp.ClassMembers", StringComparison.OrdinalIgnoreCase))
            {
                return "StyleCop.CSharp.ReadabilityRules";
            }
            else if (string.Equals(analyzerId, "Microsoft.SourceAnalysis.CSharp.Comments", StringComparison.OrdinalIgnoreCase))
            {
                return "StyleCop.CSharp.ReadabilityRules";
            }
            else if (string.Equals(analyzerId, "Microsoft.SourceAnalysis.CSharp.CurlyBrackets", StringComparison.OrdinalIgnoreCase))
            {
                return "StyleCop.CSharp.LayoutRules";
            }
            else if (string.Equals(analyzerId, "Microsoft.SourceAnalysis.CSharp.DeclarationKeywordOrder", StringComparison.OrdinalIgnoreCase))
            {
                return "StyleCop.CSharp.OrderingRules";
            }
            else if (string.Equals(analyzerId, "Microsoft.SourceAnalysis.CSharp.Documentation", StringComparison.OrdinalIgnoreCase))
            {
                return "StyleCop.CSharp.DocumentationRules";
            }
            else if (string.Equals(analyzerId, "Microsoft.SourceAnalysis.CSharp.ElementOrder", StringComparison.OrdinalIgnoreCase))
            {
                return "StyleCop.CSharp.OrderingRules";
            }
            else if (string.Equals(analyzerId, "Microsoft.SourceAnalysis.CSharp.FileHeaders", StringComparison.OrdinalIgnoreCase))
            {
                return "StyleCop.CSharp.DocumentationRules";
            }
            else if (string.Equals(analyzerId, "Microsoft.SourceAnalysis.CSharp.LineSpacing", StringComparison.OrdinalIgnoreCase))
            {
                return "StyleCop.CSharp.LayoutRules";
            }
            else if (string.Equals(analyzerId, "Microsoft.SourceAnalysis.CSharp.MethodParameters", StringComparison.OrdinalIgnoreCase))
            {
                return "StyleCop.CSharp.ReadabilityRules";
            }
            else if (string.Equals(analyzerId, "Microsoft.SourceAnalysis.CSharp.Naming", StringComparison.OrdinalIgnoreCase))
            {
                return "StyleCop.CSharp.NamingRules";
            }
            else if (string.Equals(analyzerId, "Microsoft.SourceAnalysis.CSharp.Parenthesis", StringComparison.OrdinalIgnoreCase))
            {
                return "StyleCop.CSharp.MaintainabilityRules";
            }
            else if (string.Equals(analyzerId, "Microsoft.SourceAnalysis.CSharp.Spacing", StringComparison.OrdinalIgnoreCase))
            {
                return "StyleCop.CSharp.SpacingRules";
            }
            else if (string.Equals(analyzerId, "Microsoft.SourceAnalysis.CSharp.Statements", StringComparison.OrdinalIgnoreCase))
            {
                return "StyleCop.CSharp.ReadabilityRules";
            }
            else if (string.Equals(analyzerId, "Microsoft.SourceAnalysis.CSharp.Tabs", StringComparison.OrdinalIgnoreCase))
            {
                return "StyleCop.CSharp.SpacingRules";
            }

            return analyzerId;
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

            if (string.Equals(analyzerId, "Microsoft.SourceAnalysis.CSharp.AccessModifiers", StringComparison.OrdinalIgnoreCase))
            {
                return new[] { "AccessModifierMustBeDeclared", "FieldsMustBePrivate" };
            }
            else if (string.Equals(analyzerId, "Microsoft.SourceAnalysis.CSharp.ClassMembers", StringComparison.OrdinalIgnoreCase))
            {
                return new[] { "DoNotPrefixCallsWithBaseUnlessLocalImplementationExists", "PrefixLocalCallsWithThis" };
            }
            else if (string.Equals(analyzerId, "Microsoft.SourceAnalysis.CSharp.Comments", StringComparison.OrdinalIgnoreCase))
            {
                return new[] { "CommentsMustContainText" };
            }
            else if (string.Equals(analyzerId, "Microsoft.SourceAnalysis.CSharp.CurlyBrackets", StringComparison.OrdinalIgnoreCase))
            {
                return new[]
                           {
                               "CurlyBracketsForMultiLineStatementsMustNotShareLine", "StatementMustNotBeOnSingleLine", "ElementMustNotBeOnSingleLine", 
                               "CurlyBracketsMustNotBeOmitted", "AllAccessorsMustBeMultiLineOrSingleLine"
                           };
            }
            else if (string.Equals(analyzerId, "Microsoft.SourceAnalysis.CSharp.DeclarationKeywordOrder", StringComparison.OrdinalIgnoreCase))
            {
                return new[] { "DeclarationKeywordsMustFollowOrder", "ProtectedMustComeBeforeInternal" };
            }
            else if (string.Equals(analyzerId, "Microsoft.SourceAnalysis.CSharp.Documentation", StringComparison.OrdinalIgnoreCase))
            {
                return new[]
                           {
                               "ElementsMustBeDocumented", "PartialElementsMustBeDocumented", "EnumerationItemsMustBeDocumented", "DocumentationMustContainValidXml", 
                               "ElementDocumentationMustHaveSummary", "PartialElementDocumentationMustHaveSummary", "ElementDocumentationMustHaveSummaryText", 
                               "PartialElementDocumentationMustHaveSummaryText", "ElementDocumentationMustNotHaveDefaultSummary", "PropertyDocumentationMustHaveValue", 
                               "PropertyDocumentationMustHaveValueText", "ElementParametersMustBeDocumented", "ElementParameterDocumentationMustMatchElementParameters", 
                               "ElementParameterDocumentationMustDeclareParameterName", "ElementParameterDocumentationMustHaveText", "ElementReturnValueMustBeDocumented", 
                               "ElementReturnValueDocumentationMustHaveText", "VoidReturnValueMustNotBeDocumented", "GenericTypeParametersMustBeDocumented", 
                               "GenericTypeParametersMustBeDocumentedPartialClass", "GenericTypeParameterDocumentationMustMatchTypeParameters", 
                               "GenericTypeParameterDocumentationMustDeclareParameterName", "GenericTypeParameterDocumentationMustHaveText", 
                               "PropertySummaryDocumentationMustMatchAccessors", "PropertySummaryDocumentationMustOmitSetAccessorWithRestrictedAccess", 
                               "ElementDocumentationMustNotBeCopiedAndPasted", "SingleLineCommentsMustNotUseDocumentationStyleSlashes", "DocumentationTextMustNotBeEmpty", 
                               "DocumentationTextMustBeginWithACapitalLetter", "DocumentationTextMustEndWithAPeriod", "DocumentationTextMustContainWhitespace", 
                               "DocumentationMustMeetCharacterPercentage", "DocumentationTextMustMeetMinimumCharacterLength"
                           };
            }
            else if (string.Equals(analyzerId, "Microsoft.SourceAnalysis.CSharp.ElementOrder", StringComparison.OrdinalIgnoreCase))
            {
                return new[]
                           {
                               "UsingDirectivesMustBePlacedWithinNamespace", "ElementsMustAppearInTheCorrectOrder", "ElementsMustBeOrderedByAccess", 
                               "ConstantsMustAppearBeforeFields", "StaticElementsMustAppearBeforeInstanceElements", "PartialElementsMustDeclareAccess"
                           };
            }
            else if (string.Equals(analyzerId, "Microsoft.SourceAnalysis.CSharp.FileHeaders", StringComparison.OrdinalIgnoreCase))
            {
                return new[]
                           {
                               "FileMustHaveHeader", "FileHeaderMustShowCopyright", "FileHeaderMustHaveCopyrightText", "FileHeaderMustContainFileName", 
                               "FileHeaderFileNameDocumentationMustMatchFileName", "FileHeaderMustHaveSummary", "FileHeaderMustHaveValidCompanyText"
                           };
            }
            else if (string.Equals(analyzerId, "Microsoft.SourceAnalysis.CSharp.LineSpacing", StringComparison.OrdinalIgnoreCase))
            {
                return new[]
                           {
                               "OpeningCurlyBracketsMustNotBeFollowedByBlankLine", "ElementDocumentationHeadersMustNotBeFollowedByBlankLine", 
                               "CodeMustNotContainMultipleBlankLinesInARow", "ClosingCurlyBracketsMustNotBePrecededByBlankLine", 
                               "OpeningCurlyBracketsMustNotBePrecededByBlankLine", "ChainedStatementBlocksMustNotBePrecededByBlankLine", 
                               "WhileDoFooterMustNotBePrecededByBlankLine", "SingleLineCommentsMustNotBeFollowedByBlankLine", "ClosingCurlyBracketMustBeFollowedByBlankLine",
                               "ElementDocumentationHeaderMustBePrecededByBlankLine", "SingleLineCommentMustBePrecededByBlankLine"
                           };
            }
            else if (string.Equals(analyzerId, "Microsoft.SourceAnalysis.CSharp.MethodParameters", StringComparison.OrdinalIgnoreCase))
            {
                return new[]
                           {
                               "OpeningParenthesisMustBeOnDeclarationLine", "ClosingParenthesisMustBeOnLineOfLastParameter", 
                               "ClosingParenthesisMustBeOnLineOfOpeningParenthesis", "CommaMustBeOnSameLineAsPreviousParameter", "ParameterListMustFollowDeclaration", 
                               "ParameterMustFollowComma", "SplitParametersMustStartOnLineAfterDeclaration", "ParametersMustBeOnSameLineOrSeparateLines", 
                               "ParameterMustNotSpanMultipleLines"
                           };
            }
            else if (string.Equals(analyzerId, "Microsoft.SourceAnalysis.CSharp.Naming", StringComparison.OrdinalIgnoreCase))
            {
                return new[]
                           {
                               "ElementMustBeginWithUpperCaseLetter", "ElementMustBeginWithLowerCaseLetter", "InterfaceNamesMustBeginWithI", 
                               "ConstFieldNamesMustBeginWithUpperCaseLetter", "NonPrivateReadonlyFieldsMustBeginWithUpperCaseLetter", 
                               "FieldNamesMustNotUseHungarianNotation", "FieldNamesMustBeginWithLowerCaseLetter", "AccessibleFieldsMustBeginWithUpperCaseLetter", 
                               "VariableNamesMustNotBePrefixed", "FieldNamesMustNotBeginWithUnderscore", "FieldNamesMustNotContainUnderscore"
                           };
            }
            else if (string.Equals(analyzerId, "Microsoft.SourceAnalysis.CSharp.Parenthesis", StringComparison.OrdinalIgnoreCase))
            {
                return new[] { "StatementMustNotUseUnnecessaryParenthesis" };
            }
            else if (string.Equals(analyzerId, "Microsoft.SourceAnalysis.CSharp.Spacing", StringComparison.OrdinalIgnoreCase))
            {
                return new[]
                           {
                               "KeywordsMustBeSpacedCorrectly", "CommasMustBeSpacedCorrectly", "SemicolonsMustBeSpacedCorrectly", "SymbolsMustBeSpacedCorrectly", 
                               "DocumentationLinesMustBeginWithSingleSpace", "SingleLineCommentsMustBeginWithSingleSpace", "PreprocessorKeywordsMustNotBePrecededBySpace", 
                               "OperatorKeywordMustBeFollowedBySpace", "OpeningParenthesisMustBeSpacedCorrectly", "ClosingParenthesisMustBeSpacedCorrectly", 
                               "OpeningSquareBracketsMustBeSpacedCorrectly", "ClosingSquareBracketsMustBeSpacedCorrectly", "OpeningCurlyBracketsMustBeSpacedCorrectly", 
                               "ClosingCurlyBracketsMustBeSpacedCorrectly", "OpeningGenericBracketsMustBeSpacedCorrectly", "ClosingGenericBracketsMustBeSpacedCorrectly", 
                               "OpeningAttributeBracketsMustBeSpacedCorrectly", "ClosingAttributeBracketsMustBeSpacedCorrectly", 
                               "NullableTypeSymbolsMustNotBePrecededBySpace", "MemberAccessSymbolsMustBeSpacedCorrectly", "IncrementDecrementSymbolsMustBeSpacedCorrectly", 
                               "NegativeSignsMustBeSpacedCorrectly", "PositiveSignsMustBeSpacedCorrectly", "DereferenceAndAccessOfSymbolsMustBeSpacedCorrectly", 
                               "ColonsMustBeSpacedCorrectly", "CodeMustNotContainMultipleWhitespaceInARow", 
                               "CodeMustNotContainSpaceAfterNewKeywordInImplicitlyTypedArrayAllocation", "TabsMustNotBeUsed"
                           };
            }
            else if (string.Equals(analyzerId, "Microsoft.SourceAnalysis.CSharp.Statements", StringComparison.OrdinalIgnoreCase))
            {
                return new[]
                           {
                               "CodeMustNotContainEmptyStatements", "CodeMustNotContainMultipleStatementsOnOneLine", "BlockStatementsMustNotContainEmbeddedComments", 
                               "BlockStatementsMustNotContainEmbeddedRegions"
                           };
            }
            else if (string.Equals(analyzerId, "Microsoft.SourceAnalysis.CSharp.Tabs", StringComparison.OrdinalIgnoreCase))
            {
                return new[] { "TabsMustNotBeUsed" };
            }

            return new string[] { };
        }

        #endregion
    }
}