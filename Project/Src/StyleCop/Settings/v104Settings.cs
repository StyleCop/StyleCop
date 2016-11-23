// --------------------------------------------------------------------------------------------------------------------
// <copyright file="v104Settings.cs" company="https://github.com/StyleCop">
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
//   Loads settings from a version 4.3 settings document.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Xml;

    /// <summary>
    /// Loads settings from a version 4.3 settings document.
    /// </summary>
    internal static class V104Settings
    {
        #region Enums

        /// <summary>
        /// The types of settings properties.
        /// </summary>
        private enum PropertyType
        {
            /// <summary>
            /// A property containing a boolean value.
            /// </summary>
            Boolean, 

            /// <summary>
            /// A property containing an integer value.
            /// </summary>
            Integer, 

            /// <summary>
            /// A property containing a string value.
            /// </summary>
            String, 

            /// <summary>
            /// A property containing a collection of properties.
            /// </summary>
            Collection, 

            /// <summary>
            /// Not a valid property.
            /// </summary>
            None
        }

        #endregion

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

            Load(document.DocumentElement, settings);
        }

        /// <summary>
        /// Loads the settings from the document.
        /// </summary>
        /// <param name="documentRoot">
        /// The root node of the settings document.
        /// </param>
        /// <param name="settings">
        /// Stores the settings.
        /// </param>
        public static void Load(XmlNode documentRoot, Settings settings)
        {
            Param.AssertNotNull(documentRoot, "documentRoot");
            Param.AssertNotNull(settings, "settings");

            // Add the global settings if there are any.
            XmlNode globalSettingsNode = documentRoot["GlobalSettings"];
            if (globalSettingsNode != null)
            {
                LoadPropertyCollection(globalSettingsNode, settings.GlobalSettings, settings.Core.PropertyDescriptors, null);
            }

            // Load the parser settings.
            LoadParserSettings(documentRoot, settings);

            // Load the analyzers under this parser.
            LoadAnalyzerSettings(documentRoot, settings);

            // Load the collection of excluded files.
            LoadFileLists(documentRoot, settings);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Converts a legacy "Microsoft.SourceAnalysis" or "Microsoft.StyleCop" AddIn name to the new name.
        /// </summary>
        /// <param name="addInName">
        /// The original name.
        /// </param>
        /// <returns>
        /// Returns the converted name.
        /// </returns>
        private static string ConvertLegacyAddInName(string addInName)
        {
            Param.AssertNotNull(addInName, "addInName");

            string[] legacyPrefixes = new[] { "Microsoft.SourceAnalysis", "Microsoft.StyleCop" };

            foreach (string legacyPrefix in legacyPrefixes)
            {
                if (addInName.StartsWith(legacyPrefix, StringComparison.Ordinal))
                {
                    return "StyleCop" + addInName.Substring(legacyPrefix.Length, addInName.Length - legacyPrefix.Length);
                }
            }

            return addInName;
        }

        /// <summary>
        /// Determines the type of property represented by the property type name.
        /// </summary>
        /// <param name="propertyType">
        /// The property type name.
        /// </param>
        /// <returns>
        /// Returns the well-known property type.
        /// </returns>
        private static PropertyType DeterminePropertyNodeType(string propertyType)
        {
            Param.Ignore(propertyType);

            if (string.IsNullOrEmpty(propertyType))
            {
                return PropertyType.None;
            }

            switch (propertyType)
            {
                case "BooleanProperty":
                    return PropertyType.Boolean;

                case "IntegerProperty":
                    return PropertyType.Integer;

                case "StringProperty":
                    return PropertyType.String;

                case "CollectionProperty":
                    return PropertyType.Collection;

                default:
                    return PropertyType.None;
            }
        }

        /// <summary>
        /// Loads analyzer settings from the document.
        /// </summary>
        /// <param name="documentRoot">
        /// The root node of the settings document.
        /// </param>
        /// <param name="settings">
        /// Stores the settings.
        /// </param>
        private static void LoadAnalyzerSettings(XmlNode documentRoot, Settings settings)
        {
            Param.AssertNotNull(documentRoot, "documentRoot");
            Param.AssertNotNull(settings, "settings");

            XmlNodeList analyzerNodes = documentRoot.SelectNodes("Analyzers/Analyzer");
            if (analyzerNodes != null && analyzerNodes.Count > 0)
            {
                foreach (XmlNode analyzerNode in analyzerNodes)
                {
                    XmlAttribute analyzerId = analyzerNode.Attributes["AnalyzerId"];
                    if (analyzerId != null && !string.IsNullOrEmpty(analyzerId.Value))
                    {
                        string analyzerName = ConvertLegacyAddInName(analyzerId.Value);

                        // Get the analyzer instance.
                        SourceAnalyzer analyzerInstance = settings.Core.GetAnalyzer(analyzerName);
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
                                LoadPropertyCollection(analyzerSettingsNode, settingsForAnalyzer, analyzerInstance.PropertyDescriptors, null);
                            }

                            // Load any rule settings for the analyzer.
                            LoadRulesSettings(analyzerNode, settingsForAnalyzer, analyzerInstance.PropertyDescriptors);
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
        private static void LoadBooleanProperty(
            string propertyName, XmlNode propertyNode, PropertyCollection properties, PropertyDescriptorCollection propertyDescriptors)
        {
            Param.AssertValidString(propertyName, "propertyName");
            Param.AssertNotNull(propertyNode, "propertyNode");
            Param.AssertNotNull(properties, "properties");
            Param.AssertNotNull(propertyDescriptors, "propertyDescriptors");

            // Skip corrupted properties.
            bool value;
            if (bool.TryParse(propertyNode.InnerText, out value))
            {
                // Get the property descriptor.
                PropertyDescriptor<bool> descriptor = propertyDescriptors[propertyName] as PropertyDescriptor<bool>;

                if (descriptor != null)
                {
                    // Create and add the property.
                    properties.Add(new BooleanProperty(descriptor, value));
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

                if (descriptor != null)
                {
                    // Create the collection node and pass in the inner collection.
                    CollectionProperty collectionProperty = new CollectionProperty(descriptor, innerCollection);

                    // Add this property to the parent collection.
                    properties.Add(collectionProperty);
                }
            }
        }

        /// <summary>
        /// Loads files specified in file lists.
        /// </summary>
        /// <param name="documentRoot">
        /// The root node of the settings document.
        /// </param>
        /// <param name="settings">
        /// Stores the settings.
        /// </param>
        private static void LoadFileLists(XmlNode documentRoot, Settings settings)
        {
            Param.AssertNotNull(documentRoot, "documentRoot");
            Param.AssertNotNull(settings, "settings");

            XmlNodeList fileListNodes = documentRoot.SelectNodes("SourceFileList");
            foreach (XmlNode fileListNode in fileListNodes)
            {
                XmlNodeList fileNodes = fileListNode.SelectNodes("SourceFile");
                if (fileNodes.Count > 0)
                {
                    Settings settingsForFileList = new Settings(settings.Core);

                    XmlNode settingsNode = fileListNode.SelectSingleNode("Settings");
                    if (settingsNode != null)
                    {
                        V104Settings.Load(settingsNode, settingsForFileList);
                    }

                    SourceFileListSettings sourceFileListSettings = new SourceFileListSettings(settingsForFileList);

                    foreach (XmlNode fileNode in fileNodes)
                    {
                        if (!string.IsNullOrEmpty(fileNode.InnerText))
                        {
                            sourceFileListSettings.AddFile(fileNode.InnerText);
                        }
                    }

                    settings.AddSourceFileList(sourceFileListSettings);
                }
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

                if (descriptor != null)
                {
                    // Create and add the property.
                    properties.Add(new IntProperty(descriptor, value));
                }
            }
        }

        /// <summary>
        /// Loads parser settings from the document.
        /// </summary>
        /// <param name="documentRoot">
        /// The root node of the settings document.
        /// </param>
        /// <param name="settings">
        /// Stores the settings.
        /// </param>
        private static void LoadParserSettings(XmlNode documentRoot, Settings settings)
        {
            Param.AssertNotNull(documentRoot, "documentRoot");
            Param.AssertNotNull(settings, "settings");

            XmlNodeList parsersNodes = documentRoot.SelectNodes("Parsers/Parser");
            if (parsersNodes != null && parsersNodes.Count > 0)
            {
                foreach (XmlNode parserNode in parsersNodes)
                {
                    XmlAttribute parserId = parserNode.Attributes["ParserId"];
                    if (parserId != null && !string.IsNullOrEmpty(parserId.Value))
                    {
                        string parserName = ConvertLegacyAddInName(parserId.Value);

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
        /// <param name="ruleName">
        /// An optional rule name to prepend the each property name.
        /// </param>
        private static void LoadPropertyCollection(
            XmlNode propertyCollectionNode, PropertyCollection properties, PropertyDescriptorCollection propertyDescriptors, string ruleName)
        {
            Param.AssertNotNull(propertyCollectionNode, "settingsNode");
            Param.AssertNotNull(properties, "properties");
            Param.AssertNotNull(propertyDescriptors, "propertyDescriptors");
            Param.Ignore(ruleName);

            foreach (XmlNode propertyNode in propertyCollectionNode.ChildNodes)
            {
                PropertyType type = DeterminePropertyNodeType(propertyNode.Name);
                if (type != PropertyType.None)
                {
                    // Get the property name.
                    XmlAttribute propertyName = propertyNode.Attributes["Name"];
                    if (propertyName != null && !string.IsNullOrEmpty(propertyName.Value))
                    {
                        // Prepend the rule name to the property name if necessary.
                        string adjustedPropertyName = propertyName.InnerText;

                        if (!string.IsNullOrEmpty(ruleName))
                        {
                            adjustedPropertyName = ruleName + "#" + propertyName.InnerText;
                        }

                        // Load the property.
                        switch (type)
                        {
                            case PropertyType.Boolean:
                                LoadBooleanProperty(adjustedPropertyName, propertyNode, properties, propertyDescriptors);
                                break;

                            case PropertyType.Integer:
                                LoadIntProperty(adjustedPropertyName, propertyNode, properties, propertyDescriptors);
                                break;

                            case PropertyType.String:
                                LoadStringProperty(adjustedPropertyName, propertyNode, properties, propertyDescriptors);
                                break;

                            case PropertyType.Collection:
                                LoadCollectionProperty(adjustedPropertyName, propertyNode, properties, propertyDescriptors);
                                break;

                            default:

                                // Ignore any unexpected settings.
                                break;
                        }
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

            if (descriptor != null)
            {
                // Create and add the property.
                properties.Add(new StringProperty(descriptor, propertyNode.InnerText));
            }
        }

        #endregion
    }
}