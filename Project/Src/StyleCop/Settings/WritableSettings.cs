// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WritableSettings.cs" company="https://github.com/StyleCop">
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
//   Represents a single StyleCop settings file in read-write mode.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Xml;

    /// <summary>
    /// Represents a single StyleCop settings file in read-write mode.
    /// </summary>
    public sealed class WritableSettings : Settings
    {
        #region Constants

        /// <summary>
        /// This is the StyleCop.Settings file version number written into files.
        /// </summary>
        private const string CurrentSettingsVersion = "105";

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the WritableSettings class.
        /// </summary>
        /// <param name="core">
        /// The StyleCop core instance.
        /// </param>
        /// <param name="location">
        /// The location of the settings document.
        /// </param>
        /// <param name="contents">
        /// The initial contents of the settings document.
        /// </param>
        /// <param name="writeTime">
        /// The time when the settings were last updated.
        /// </param>
        public WritableSettings(StyleCopCore core, string location, XmlDocument contents, DateTime writeTime)
            : base(core, location, contents, writeTime)
        {
            Param.Ignore(core, location, contents, writeTime);
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Creates a new settings document.
        /// </summary>
        /// <returns>Returns the new document.</returns>
        [SuppressMessage("Microsoft.Design", "CA1059:MembersShouldNotExposeCertainConcreteTypes", MessageId = "System.Xml.XmlNode", 
            Justification = "Compliance would break the well-defined public API.")]
        public static XmlDocument NewDocument()
        {
            XmlDocument document = new XmlDocument();
            XmlElement root = document.CreateElement("StyleCopSettings");
            document.AppendChild(root);

            XmlAttribute version = document.CreateAttribute("Version");

            version.Value = CurrentSettingsVersion;

            root.Attributes.Append(version);

            return document;
        }

        /// <summary>
        /// Clears a setting for the given add-in.
        /// </summary>
        /// <param name="addIn">
        /// The add-in.
        /// </param>
        /// <param name="propertyName">
        /// The name of the property to clear.
        /// </param>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "InSetting", 
            Justification = "InSetting is two words in this context.")]
        public void ClearAddInSetting(StyleCopAddIn addIn, string propertyName)
        {
            Param.RequireNotNull(addIn, "addIn");
            Param.RequireValidString(propertyName, "propertyName");

            this.ClearAddInSettingInternal(addIn, propertyName);
        }

        /// <summary>
        /// Sets a setting for the given add-in.
        /// </summary>
        /// <param name="addIn">
        /// The add-in.
        /// </param>
        /// <param name="property">
        /// The setting property to set.
        /// </param>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "InSetting", 
            Justification = "InSetting is two words in this context.")]
        public void SetAddInSetting(StyleCopAddIn addIn, PropertyValue property)
        {
            Param.RequireNotNull(addIn, "addIn");
            Param.RequireNotNull(property, "property");

            this.SetAddInSettingInternal(addIn, property);
        }

        /// <summary>
        /// Writes the settings into the given document.
        /// </summary>
        /// <param name="environment">
        /// The environment that StyleCop is running under, if any.
        /// </param>
        /// <returns>
        /// Returns the new settings document.
        /// </returns>
        [SuppressMessage("Microsoft.Design", "CA1059:MembersShouldNotExposeCertainConcreteTypes", MessageId = "System.Xml.XmlNode", 
            Justification = "Compliance would break the well-defined public API.")]
        public XmlDocument WriteSettingsToDocument(StyleCopEnvironment environment)
        {
            Param.RequireNotNull(environment, "environment");

            // Create a new document for the settings.
            XmlDocument document = WritableSettings.NewDocument();

            this.SaveSettingsIntoXmlDocument(document, environment, document.DocumentElement, this);

            return document;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Saves the given boolean property into the given node.
        /// </summary>
        /// <param name="rootNode">
        /// The node under which to store the new property node.
        /// </param>
        /// <param name="property">
        /// The property to save.
        /// </param>
        /// <param name="propertyName">
        /// The name of the property.
        /// </param>
        /// <returns>
        /// Returns true if the property was written.
        /// </returns>
        private static bool SaveBooleanProperty(XmlNode rootNode, BooleanProperty property, string propertyName)
        {
            Param.AssertNotNull(rootNode, "rootNode");
            Param.AssertNotNull(property, "property");
            Param.AssertValidString(propertyName, "propertyName");

            // Create and append the root node for this property.
            XmlNode propertyNode = rootNode.OwnerDocument.CreateElement("BooleanProperty");
            rootNode.AppendChild(propertyNode);

            XmlAttribute propertyNameAttribute = rootNode.OwnerDocument.CreateAttribute("Name");
            propertyNameAttribute.Value = propertyName;
            propertyNode.Attributes.Append(propertyNameAttribute);

            // Add the value.
            propertyNode.InnerText = property.Value.ToString();

            return true;
        }

        /// <summary>
        /// Saves the given collection property into the given node.
        /// </summary>
        /// <param name="rootNode">
        /// The node under which to store the new property node.
        /// </param>
        /// <param name="property">
        /// The property to save.
        /// </param>
        /// <param name="propertyName">
        /// The name of the property.
        /// </param>
        /// <returns>
        /// Returns true if the property was written.
        /// </returns>
        private static bool SaveCollectionProperty(XmlNode rootNode, CollectionProperty property, string propertyName)
        {
            Param.AssertNotNull(rootNode, "rootNode");
            Param.AssertNotNull(property, "property");
            Param.AssertValidString(propertyName, "propertyName");

            if (property.Values.Count > 0)
            {
                // Create and append the root node for this property.
                XmlNode propertyNode = rootNode.OwnerDocument.CreateElement("CollectionProperty");
                rootNode.AppendChild(propertyNode);

                XmlAttribute propertyNameAttribute = rootNode.OwnerDocument.CreateAttribute("Name");
                propertyNameAttribute.Value = propertyName;
                propertyNode.Attributes.Append(propertyNameAttribute);

                // Add sub-nodes for each property value.
                foreach (string value in property.Values)
                {
                    XmlNode valueNode = rootNode.OwnerDocument.CreateElement("Value");
                    valueNode.InnerText = value;
                    propertyNode.AppendChild(valueNode);
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Saves the given <see cref="int"/> property into the given node.
        /// </summary>
        /// <param name="rootNode">
        /// The node under which to store the new property node.
        /// </param>
        /// <param name="property">
        /// The property to save.
        /// </param>
        /// <param name="propertyName">
        /// The name of the property.
        /// </param>
        /// <returns>
        /// Returns true if the property was written.
        /// </returns>
        private static bool SaveIntProperty(XmlNode rootNode, IntProperty property, string propertyName)
        {
            Param.AssertNotNull(rootNode, "rootNode");
            Param.AssertNotNull(property, "property");
            Param.AssertValidString(propertyName, "propertyName");

            // Create and append the root node for this property.
            XmlNode propertyNode = rootNode.OwnerDocument.CreateElement("IntegerProperty");
            rootNode.AppendChild(propertyNode);

            XmlAttribute propertyNameAttribute = rootNode.OwnerDocument.CreateAttribute("Name");
            propertyNameAttribute.Value = propertyName;
            propertyNode.Attributes.Append(propertyNameAttribute);

            // Add the value.
            int propertyValue = property.Value;
            propertyNode.InnerText = propertyValue.ToString(CultureInfo.InvariantCulture);

            return true;
        }

        /// <summary>
        /// Saves the given property collection.
        /// </summary>
        /// <param name="rootNode">
        /// The node to store the property collection beneath.
        /// </param>
        /// <param name="nodeName">
        /// The name of the new property collection node.
        /// </param>
        /// <param name="properties">
        /// The property collection to store.
        /// </param>
        /// <param name="parentProperties">
        /// The corresponding property collection from the parent settings, if any.
        /// </param>
        /// <param name="aggregate">
        /// Indicates whether the collection is aggregated with the parent collection.
        /// </param>
        /// <param name="nodeNameAttribute">
        /// An optional name attribute value for the new property node.
        /// </param>
        /// <returns>
        /// Returns true if at least one property was saved.
        /// </returns>
        private static bool SavePropertyCollection(
            XmlNode rootNode, string nodeName, PropertyCollection properties, PropertyCollection parentProperties, bool aggregate, string nodeNameAttribute)
        {
            Param.AssertNotNull(rootNode, "rootNode");
            Param.AssertValidString(nodeName, "nodeName");
            Param.AssertNotNull(properties, "properties");
            Param.Ignore(parentProperties);
            Param.Ignore(aggregate);
            Param.Ignore(nodeNameAttribute);

            // If there are no properties in the collection, don't save anything.
            if (properties.Count == 0)
            {
                return false;
            }

            bool propertyWritten = false;

            // Create the root node for this property collection.
            Debug.Assert(rootNode.OwnerDocument != null, "The root node has not been attached to a document.");
            XmlElement rootCollectionNode = rootNode.OwnerDocument.CreateElement(nodeName);

            if (!string.IsNullOrEmpty(nodeNameAttribute))
            {
                XmlAttribute rootCollectionNodeNameAttribute = rootNode.OwnerDocument.CreateAttribute("Name");
                rootCollectionNodeNameAttribute.Value = nodeNameAttribute;
                rootCollectionNode.Attributes.Append(rootCollectionNodeNameAttribute);
            }

            // Add each property in the collection.
            foreach (PropertyValue property in properties)
            {
                bool skip = false;
                PropertyValue parentProperty = null;

                if (parentProperties != null)
                {
                    parentProperty = parentProperties[property.PropertyName];

                    // If the property also exists in the parent collection, determine whether the local property
                    // is an override. If not, there is no need to add it.
                    if (aggregate && parentProperty != null)
                    {
                        if (!SettingsComparer.IsSettingOverwritten(property, parentProperty))
                        {
                            skip = true;
                        }
                    }
                    else if (property.IsDefault)
                    {
                        skip = true;
                    }
                }
                else if (property.IsDefault)
                {
                    skip = true;
                }

                if (!skip)
                {
                    // If the property is a rule setting, then add it under the rules section.
                    int index = property.PropertyName.IndexOf('#');
                    if (index > 0)
                    {
                        propertyWritten |= SaveRuleProperty(
                            rootNode, 
                            property, 
                            property.PropertyName.Substring(0, index), 
                            property.PropertyName.Substring(index + 1, property.PropertyName.Length - index - 1));
                    }
                    else
                    {
                        // Just save the property value under this add-in's settings since it is
                        // not a rule property.
                        propertyWritten |= SavePropertyValue(rootCollectionNode, property, property.PropertyName);
                    }
                }
            }

            // If at least one property was saved, add the property collection node into the document.
            if (propertyWritten)
            {
                rootNode.AppendChild(rootCollectionNode);
            }

            return propertyWritten;
        }

        /// <summary>
        /// Saves a single property value.
        /// </summary>
        /// <param name="rootCollectionNode">
        /// The collection node containing the property.
        /// </param>
        /// <param name="property">
        /// The property to save.
        /// </param>
        /// <param name="propertyName">
        /// The name of the property.
        /// </param>
        /// <returns>
        /// Returns true if the property was saved; otherwise false.
        /// </returns>
        private static bool SavePropertyValue(XmlNode rootCollectionNode, PropertyValue property, string propertyName)
        {
            Param.AssertNotNull(rootCollectionNode, "rootCollectionNode");
            Param.AssertNotNull(property, "property");
            Param.AssertValidString(propertyName, "propertyName");

            bool propertyWritten = false;

            switch (property.PropertyType)
            {
                case PropertyType.Boolean:
                    propertyWritten |= SaveBooleanProperty(rootCollectionNode, property as BooleanProperty, propertyName);
                    break;

                case PropertyType.Int:
                    propertyWritten |= SaveIntProperty(rootCollectionNode, property as IntProperty, propertyName);
                    break;

                case PropertyType.String:
                    propertyWritten |= SaveStringProperty(rootCollectionNode, property as StringProperty, propertyName);
                    break;

                case PropertyType.Collection:
                    propertyWritten |= SaveCollectionProperty(rootCollectionNode, property as CollectionProperty, propertyName);
                    break;

                default:
                    Debug.Fail("Unexpected property type.");
                    break;
            }

            return propertyWritten;
        }

        /// <summary>
        /// Saves a rule property.
        /// </summary>
        /// <param name="rootNode">
        /// The node to store the property collection beneath.
        /// </param>
        /// <param name="property">
        /// The property to save.
        /// </param>
        /// <param name="ruleName">
        /// The name of the rule.
        /// </param>
        /// <param name="propertyName">
        /// The name of the property.
        /// </param>
        /// <returns>
        /// Returns true if the property was saved; otherwise false.
        /// </returns>
        private static bool SaveRuleProperty(XmlNode rootNode, PropertyValue property, string ruleName, string propertyName)
        {
            Param.AssertNotNull(rootNode, "rootNode");
            Param.AssertNotNull(property, "property");
            Param.AssertValidString(ruleName, "ruleName");
            Param.AssertValidString(propertyName, "propertyName");

            // Get or create the Rules node under the root.
            XmlNode rulesNode = rootNode.SelectSingleNode("Rules");
            if (rulesNode == null)
            {
                rulesNode = rootNode.OwnerDocument.CreateElement("Rules");
                rootNode.AppendChild(rulesNode);
            }

            // Get or create the Rule node.
            XmlNode ruleNode = rulesNode.SelectSingleNode("Rule[@Name=\"" + ruleName + "\"]");
            if (ruleNode == null)
            {
                ruleNode = rootNode.OwnerDocument.CreateElement("Rule");
                rulesNode.AppendChild(ruleNode);

                XmlAttribute attrib = rootNode.OwnerDocument.CreateAttribute("Name");
                attrib.Value = ruleName;
                ruleNode.Attributes.Append(attrib);
            }

            // Get or create the RuleSettings node.
            XmlNode ruleSettings = ruleNode.SelectSingleNode("RuleSettings");
            if (ruleSettings == null)
            {
                ruleSettings = rootNode.OwnerDocument.CreateElement("RuleSettings");
                ruleNode.AppendChild(ruleSettings);
            }

            // Save the setting.
            return SavePropertyValue(ruleSettings, property, propertyName);
        }

        /// <summary>
        /// Saves the given string property into the given node.
        /// </summary>
        /// <param name="rootNode">
        /// The node under which to store the new property node.
        /// </param>
        /// <param name="property">
        /// The property to save.
        /// </param>
        /// <param name="propertyName">
        /// The name of the property.
        /// </param>
        /// <returns>
        /// Returns true if the property was written.
        /// </returns>
        private static bool SaveStringProperty(XmlNode rootNode, StringProperty property, string propertyName)
        {
            Param.AssertNotNull(rootNode, "rootNode");
            Param.AssertNotNull(property, "property");
            Param.AssertValidString(propertyName, "propertyName");

            // Create and append the root node for this property.
            XmlNode propertyNode = rootNode.OwnerDocument.CreateElement("StringProperty");
            rootNode.AppendChild(propertyNode);

            XmlAttribute propertyNameAttribute = rootNode.OwnerDocument.CreateAttribute("Name");
            propertyNameAttribute.Value = propertyName;
            propertyNode.Attributes.Append(propertyNameAttribute);

            // Add the value.
            propertyNode.InnerText = property.Value;

            return true;
        }

        /// <summary>
        /// Saves the Settings provided into the XmlDocument.
        /// </summary>
        /// <param name="document">
        /// The root document.
        /// </param>
        /// <param name="environment">
        /// The environment that StyleCop is running under, if any.
        /// </param>
        /// <param name="rootElement">
        /// The element to save our settings to.
        /// </param>
        /// <param name="settingsToSave">
        /// The settings to save.
        /// </param>
        private void SaveSettingsIntoXmlDocument(XmlDocument document, StyleCopEnvironment environment, XmlElement rootElement, Settings settingsToSave)
        {
            // Get the parent settings if there are any.
            SettingsMerger merger = new SettingsMerger(settingsToSave, environment);
            Settings parentSettings = merger.ParentMergedSettings;

            // Add the global settings if there are any.
            if (settingsToSave.GlobalSettings != null && settingsToSave.GlobalSettings.Count > 0)
            {
                // Get the global settings from the parent.
                PropertyCollection parentGlobalSettings = null;
                if (parentSettings != null)
                {
                    parentGlobalSettings = parentSettings.GlobalSettings;
                }

                SavePropertyCollection(rootElement, "GlobalSettings", settingsToSave.GlobalSettings, parentGlobalSettings, true, null);
            }

            // Add the parser settings if there are any.
            if (settingsToSave.ParserSettings.Count > 0)
            {
                bool parserSettingsAdded = false;
                XmlElement parsersNode = document.CreateElement("Parsers");

                foreach (AddInPropertyCollection parserSettings in settingsToSave.ParserSettings)
                {
                    // Add the settings for this parser if there are any.
                    if (parserSettings.Count > 0)
                    {
                        // Create a node for this parser.
                        XmlElement parserNode = document.CreateElement("Parser");
                        XmlAttribute parserIdAttribute = document.CreateAttribute("ParserId");
                        parserIdAttribute.Value = parserSettings.AddIn.Id;
                        parserNode.Attributes.Append(parserIdAttribute);

                        // Get the parser settings from the parent.
                        PropertyCollection parentParserSettings = null;
                        if (parentSettings != null)
                        {
                            parentParserSettings = parentSettings.GetAddInSettings(parserSettings.AddIn);
                        }

                        if (SavePropertyCollection(parserNode, "ParserSettings", parserSettings, parentParserSettings, true, null))
                        {
                            parsersNode.AppendChild(parserNode);
                            parserSettingsAdded = true;
                        }
                    }
                }

                if (parserSettingsAdded)
                {
                    rootElement.AppendChild(parsersNode);
                }
            }

            // Add the analyzer settings if there are any.
            if (settingsToSave.AnalyzerSettings.Count > 0)
            {
                bool analyzerSettingsAdded = false;
                XmlElement analyzersNode = document.CreateElement("Analyzers");

                foreach (AddInPropertyCollection analyzerSettings in settingsToSave.AnalyzerSettings)
                {
                    // Add the settings for this analyzer if there are any.
                    if (analyzerSettings.Count > 0)
                    {
                        // Create a node for this analzyer.
                        XmlElement analyzerNode = document.CreateElement("Analyzer");
                        XmlAttribute analyzerIdAttribute = document.CreateAttribute("AnalyzerId");
                        analyzerIdAttribute.Value = analyzerSettings.AddIn.Id;
                        analyzerNode.Attributes.Append(analyzerIdAttribute);

                        // Get the analyzer settings from the parent.
                        PropertyCollection parentAnalyzerSettings = null;
                        if (parentSettings != null)
                        {
                            parentAnalyzerSettings = parentSettings.GetAddInSettings(analyzerSettings.AddIn);
                        }

                        if (SavePropertyCollection(analyzerNode, "AnalyzerSettings", analyzerSettings, parentAnalyzerSettings, true, null))
                        {
                            analyzersNode.AppendChild(analyzerNode);
                            analyzerSettingsAdded = true;
                        }
                    }
                }

                if (analyzerSettingsAdded)
                {
                    rootElement.AppendChild(analyzersNode);
                }
            }

            // Add the sourcefilelists settings if there are any.
            if (settingsToSave.SourceFileLists.Count > 0)
            {
                foreach (SourceFileListSettings sourceFileListSettings in settingsToSave.SourceFileLists)
                {
                    XmlElement sourceFileListNode = document.CreateElement("SourceFileList");

                    foreach (string sourceFileListSetting in sourceFileListSettings.SourceFiles)
                    {
                        XmlElement sourceFileNode = document.CreateElement("SourceFile");
                        sourceFileNode.InnerText = sourceFileListSetting;
                        sourceFileListNode.AppendChild(sourceFileNode);
                    }

                    XmlElement settingsNode = document.CreateElement("Settings");

                    this.SaveSettingsIntoXmlDocument(document, environment, settingsNode, sourceFileListSettings.Settings);

                    sourceFileListNode.AppendChild(settingsNode);
                    rootElement.AppendChild(sourceFileListNode);
                }
            }
        }

        #endregion
    }
}