//-----------------------------------------------------------------------
// <copyright file="StyleCopAddIn.cs">
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
namespace StyleCop
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Text;
    using System.Xml;

    /// <summary>
    /// An add-in to the StyleCop engine.
    /// </summary>
    [StyleCopAddIn]
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "StyleCop", Justification = "This is the correct casing.")]
    public abstract class StyleCopAddIn : IPropertyContainer
    {
        #region Private Constants

        /// <summary>
        /// The default CheckId prefix for rules.
        /// </summary>
        private const string DefaultCheckIdPrefix = "SA";

        #endregion Private Constants

        #region Private Fields

        /// <summary>
        /// Stores the list of rules for the add-in.
        /// </summary>
        private Dictionary<string, Rule> rules = new Dictionary<string, Rule>();

        /// <summary>
        /// The unique ID of the add-in.
        /// </summary>
        private string id;

        /// <summary>
        /// The user-friendly name of the add-in.
        /// </summary>
        private string name;

        /// <summary>
        /// The user-friendly description of the add-in.
        /// </summary>
        private string description;

        /// <summary>
        /// The StyleCop core instance.
        /// </summary>
        private StyleCopCore core;

        /// <summary>
        /// The property descriptors for the add-in.
        /// </summary>
        private PropertyDescriptorCollection propertyDescriptors = new PropertyDescriptorCollection();

        #endregion Private Fields

        #region Protected Constructors

        /// <summary>
        /// Initializes a new instance of the StyleCopAddIn class.
        /// </summary>
        protected StyleCopAddIn()
        {
            this.id = GetIdFromAddInType(this.GetType());
        }

        #endregion Protected Constructors

        #region Public Virtual Properties

        /// <summary>
        /// Gets the collection of property descriptors exposed by the add-in.
        /// </summary>
        public virtual PropertyDescriptorCollection PropertyDescriptors
        {
            get
            {
                return this.propertyDescriptors;
            }
        }

        /// <summary>
        /// Gets the property pages to expose on the StyleCop settings dialog for this add-in.
        /// </summary>
        public virtual ICollection<IPropertyControlPage> SettingsPages
        {
            get
            {
                return null;
            }
        }

        #endregion Public Virtual Properties

        #region Public Properties

        /// <summary>
        /// Gets the unique ID of the add-in.
        /// </summary>
        public string Id
        {
            get
            {
                return this.id;
            }
        }

        /// <summary>
        /// Gets the name of the add-in.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Gets the description of the add-in.
        /// </summary>
        public string Description
        {
            get
            {
                return this.description;
            }
        }

        /// <summary>
        /// Gets the StyleCop core instance.
        /// </summary>
        public StyleCopCore Core
        {
            get
            {
                return this.core;
            }
        }

        #endregion Public Properties

        #region Internal Properties

        /// <summary>
        /// Gets the collection of rules exposed by this analyzer.
        /// </summary>
        internal IEnumerable<Rule> AddInRules
        {
            get
            {
                return this.rules.Values;
            }
        }

        #endregion Internal Properties

        #region Public Virtual Methods

        /// <summary>
        /// Called when the user opens a new solution.
        /// </summary>
        public virtual void SolutionOpened()
        {
        }

        /// <summary>
        /// Called when the user closes the solution.
        /// </summary>
        public virtual void SolutionClosing()
        {
        }

        /// <summary>
        /// Allows the add-in to initialize itself, after all initialization documents have been processed.
        /// </summary>
        public virtual void InitializeAddIn()
        {
        }

        /// <summary>
        /// Gets a value indicating whether the given rule is enabled for the given document.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="ruleName">The rule to check.</param>
        /// <returns>Returns true if the rule is enabled; otherwise false.</returns>
        public virtual bool IsRuleEnabled(CodeDocument document, string ruleName)
        {
            Param.Ignore(document, ruleName);
            return true;
        }

        /// <summary>
        /// Gets a value indicating whether the given rule is suppressed for the given element.
        /// </summary>
        /// <param name="element">The element to check.</param>
        /// <param name="ruleCheckId">The Id of the rule to check.</param>
        /// <param name="ruleName">The Name of the rule to check.</param>
        /// <param name="ruleNamespace">The Namespace of the rule to check.</param>
        /// <returns>Returns true if the rule is suppressed; otherwise false.</returns>
        public virtual bool IsRuleSuppressed(ICodeElement element, string ruleCheckId, string ruleName, string ruleNamespace)
        {
            Param.Ignore(element, ruleCheckId, ruleName, ruleNamespace);
            return false;
        }

        #endregion Public Virtual Methods

        #region Public Methods

        /// <summary>
        /// Gets a setting for the add-in.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="propertyName">The name of the setting property.</param>
        /// <returns>Returns the setting or null if it does not exist.</returns>
        public PropertyValue GetSetting(Settings settings, string propertyName)
        {
            Param.Ignore(settings);
            Param.RequireValidString(propertyName, "propertyName");

            if (settings == null)
            {
                return null;
            }

            return settings.GetAddInSetting(this, propertyName);
        }

        /// <summary>
        /// Gets a setting for a rule exposed by the add-in.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="ruleName">The name of the rule.</param>
        /// <param name="propertyName">The name of the setting property.</param>
        /// <returns>Returns the setting or null if it does not exist.</returns>
        public PropertyValue GetRuleSetting(Settings settings, string ruleName, string propertyName)
        {
            Param.Ignore(settings);
            Param.RequireValidString(ruleName, "ruleName");
            Param.RequireValidString(propertyName, "propertyName");

            if (settings == null)
            {
                return null;
            }

            return settings.GetAddInSetting(this, ruleName + "#" + propertyName);
        }

        /// <summary>
        /// Sets the given property on the add-in.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="property">The property to set.</param>
        public void SetSetting(WritableSettings settings, PropertyValue property)
        {
            Param.RequireNotNull(settings, "settings");
            Param.RequireNotNull(property, "property");

            settings.SetAddInSetting(this, property);
        }

        /// <summary>
        /// Clears the given property for the add-in.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="propertyName">The name of the property to clear.</param>
        public void ClearSetting(WritableSettings settings, string propertyName)
        {
            Param.RequireNotNull(settings, "settings");
            Param.RequireValidString(propertyName, "propertyName");

            settings.ClearAddInSetting(this, propertyName);
        }

        /// <summary>
        /// Adds one violation to the given code element.
        /// </summary>
        /// <param name="element">The element that the violation appears in.</param>
        /// <param name="ruleName">The name of the rule that triggered the violation.</param>
        /// <param name="values">String parameters to insert into the violation context string.</param>
        public void AddViolation(ICodeElement element, string ruleName, params object[] values)
        {
            Param.Ignore(element, ruleName, values);

            int lineNumber = 0;
            if (element != null)
            {
                lineNumber = element.LineNumber;
            }

            this.AddViolation(element, lineNumber, ruleName, values);
        }

        /// <summary>
        /// Adds one violation to the given code element.
        /// </summary>
        /// <param name="element">The element that the violation appears in.</param>
        /// <param name="ruleName">The name of the rule that triggered the violation.</param>
        /// <param name="values">String parameters to insert into the violation context string.</param>
        public void AddViolation(ICodeElement element, Enum ruleName, params object[] values)
        {
            Param.Ignore(element);
            Param.RequireNotNull(ruleName, "ruleName");
            Param.Ignore(values);

            this.AddViolation(element, ruleName.ToString(), values);
        }

        /// <summary>
        /// Adds one violation to the given code element.
        /// </summary>
        /// <param name="element">The element that the violation appears in.</param>
        /// <param name="location">The location in the code where the violation occurs.</param>
        /// <param name="ruleName">The name of the rule that triggered the violation.</param>
        /// <param name="values">String parameters to insert into the violation string.</param>
        public void AddViolation(ICodeElement element, CodeLocation location, string ruleName, params object[] values)
        {
            Param.RequireNotNull(element, "element");
            Param.RequireNotNull(location, "location");
            Param.RequireValidString(ruleName, "ruleName");
            Param.Ignore(values);

            // If the rule is disabled or suppressed, skip it.
            if (this.IsRuleEnabled(element.Document, ruleName))
            {
                Rule rule = this.GetRule(ruleName);
                if (rule == null)
                {
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Strings.RuleDoesNotExist, ruleName), "ruleName");
                }

                if (!this.IsRuleSuppressed(element, rule.CheckId, ruleName, rule.Namespace))
                {
                    // Look up this violation type.
                    this.core.AddViolation(element, rule, location, values);
                }
            }
        }

        /// <summary>
        /// Adds one violation to the given code element.
        /// </summary>
        /// <param name="element">The element that the violation appears in.</param>
        /// <param name="line">The line in the code where the violation occurs.</param>
        /// <param name="ruleName">The name of the rule that triggered the violation.</param>
        /// <param name="values">String parameters to insert into the violation string.</param>
        public void AddViolation(ICodeElement element, int line, string ruleName, params object[] values)
        {
            Param.RequireNotNull(element, "element");
            Param.Ignore(line);
            Param.RequireValidString(ruleName, "ruleName");
            Param.Ignore(values);

            // If the rule is disabled or suppressed, skip it.
            if (this.IsRuleEnabled(element.Document, ruleName))
            {
                Rule rule = this.GetRule(ruleName);
                if (rule == null)
                {
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Strings.RuleDoesNotExist, ruleName), "ruleName");
                }

                if (!this.IsRuleSuppressed(element, rule.CheckId, ruleName, rule.Namespace))
                {
                    // Look up this violation type.
                    this.core.AddViolation(element, rule, line, values);
                }
            }
        }

        /// <summary>
        /// Adds one violation to the given code element.
        /// </summary>
        /// <param name="element">The element that the violation appears in.</param>
        /// <param name="location">The location in the code where the violation occurs.</param>
        /// <param name="ruleName">The name of the rule that triggered the violation.</param>
        /// <param name="values">String parameters to insert into the violation string.</param>
        public void AddViolation(ICodeElement element, CodeLocation location, Enum ruleName, params object[] values)
        {
            Param.Ignore(element);
            Param.RequireNotNull(location, "location");
            Param.RequireNotNull(ruleName, "ruleName");
            Param.Ignore(values);

            this.AddViolation(element, location, ruleName.ToString(), values);
        }

        /// <summary>
        /// Adds one violation to the given code element.
        /// </summary>
        /// <param name="element">The element that the violation appears in.</param>
        /// <param name="line">The line in the code where the violation occurs.</param>
        /// <param name="ruleName">The name of the rule that triggered the violation.</param>
        /// <param name="values">String parameters to insert into the violation string.</param>
        public void AddViolation(ICodeElement element, int line, Enum ruleName, params object[] values)
        {
            Param.Ignore(element);
            Param.Ignore(line);
            Param.RequireNotNull(ruleName, "ruleName");
            Param.Ignore(values);

            this.AddViolation(element, line, ruleName.ToString(), values);
        }

        /// <summary>
        /// Gets the rule with the given name.
        /// </summary>
        /// <param name="ruleName">The name of the rule to retrieve.</param>
        /// <returns>Returns the rule or null if there is no rule with the given name.</returns>
        public Rule GetRule(string ruleName)
        {
            Param.RequireValidString(ruleName, "ruleName");

            Rule rule;
            if (this.rules.TryGetValue(ruleName, out rule))
            {
                return rule;
            }

            return null;
        }

        #endregion Public Methods

        #region Internal Static Methods

        /// <summary>
        /// Gets the ID of an add-in given the type of that add-in.
        /// </summary>
        /// <param name="addInType">The type of the add-in.</param>
        /// <returns>Returns the ID of the add-in.</returns>
        internal static string GetIdFromAddInType(Type addInType)
        {
            Param.AssertNotNull(addInType, "addInType");
            return addInType.FullName;
        }

        #endregion Internal Static Methods

        #region Internal Methods

        /// <summary>
        /// Initializes the add-in.
        /// </summary>
        /// <param name="styleCopCore">The StyleCop core instance.</param>
        /// <param name="initializationXml">The add-in's XML initialization document.</param>
        /// <param name="topMostType">Indicates whether the xml document comes from the top-most type in the 
        /// add-in's type hierarchy.</param>
        /// <param name="isKnownAssembly">Indicates whether the add-in comes from a known assembly.</param>
        internal void Initialize(
            StyleCopCore styleCopCore, XmlDocument initializationXml, bool topMostType, bool isKnownAssembly)
        {
            Param.AssertNotNull(styleCopCore, "styleCopCore");
            Param.AssertNotNull(initializationXml, "parserXml");
            Param.Ignore(topMostType);
            Param.Ignore(isKnownAssembly);

            // Set the reference to the core instance.
            this.core = styleCopCore;

            // Parse the parser Xml.
            this.ImportInitializationXml(initializationXml, topMostType, isKnownAssembly);
        }

        #endregion Internal Methods

        #region Protected Virtual Methods

        /// <summary>
        /// Parses the Xml document which initializes the add-in.
        /// </summary>
        /// <param name="document">The xml document to load.</param>
        /// <param name="topmostType">Indicates whether the xml document comes from the top-most type in the 
        /// add-in's type hierarchy.</param>
        /// <param name="isKnownAssembly">Indicates whether the add-in comes from a known assembly.</param>
        [SuppressMessage(
            "Microsoft.Design", 
            "CA1059:MembersShouldNotExposeCertainConcreteTypes", 
            MessageId = "System.Xml.XmlNode", 
            Justification = "Compliance would break well-defined public API.")]
        protected virtual void ImportInitializationXml(XmlDocument document, bool topmostType, bool isKnownAssembly)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(document.DocumentElement, "xml.DocumentElement");
            Param.Ignore(topmostType);
            Param.Ignore(isKnownAssembly);

            if (topmostType)
            {
                // Get the name attribute and store it.
                XmlAttribute addInName = document.DocumentElement.Attributes["Name"];
                if (addInName == null || addInName.Value.Length == 0)
                {
                    throw new ArgumentException(Strings.MissingNameAttributeOnRootNode);
                }

                this.name = addInName.Value;

                // Get the description element and store the value.
                XmlElement addInDescription = document.DocumentElement["Description"];
                if (addInDescription == null)
                {
                    throw new ArgumentException(Strings.MissingAddInDescription);
                }

                string trimmedDescription = addInDescription.InnerText.Trim();
                if (trimmedDescription.Length == 0)
                {
                    throw new ArgumentException(Strings.MissingAddInDescription);
                }

                this.description = trimmedDescription;
            }

            // Go through all the child nodes of the root analyzer node.
            foreach (XmlNode item in document.DocumentElement.ChildNodes)
            {
                if (item.Name == "Rules")
                {
                    this.AddRulesFromXml(item, null, isKnownAssembly);
                }
                else if (item.Name == "Properties")
                {
                    this.propertyDescriptors.InitializeFromXml(item);
                }
            }
        }

        #endregion Protected Virtual Methods

        #region Private Static Methods

        /// <summary>
        /// Trims extra whitespace and newlines out of Xml text data.
        /// </summary>
        /// <param name="content">The original Xml content.</param>
        /// <returns>Returns the trimmed content.</returns>
        private static string TrimXmlContent(string content)
        {
            Param.Ignore(content);

            if (content == null)
            {
                return null;
            }

            int index = 0;
            char[] chars = new char[content.Length];

            bool start = false;
            for (int i = 0; i < content.Length; ++i)
            {
                char character = content[i];

                if (start)
                {
                    if (char.IsWhiteSpace(character) && i < content.Length - 1)
                    {
                        if (!char.IsWhiteSpace(content[i + 1]))
                        {
                            chars[index++] = ' ';
                        }
                    }
                    else
                    {
                        chars[index++] = character;
                    }
                }
                else
                {
                    if (!char.IsWhiteSpace(character))
                    {
                        chars[index++] = character;
                        start = true;
                    }
                }
            }

            // If nothing was trimmed, just return the original string.
            if (index == chars.Length)
            {
                return content;
            }

            return new string(chars, 0, index);
        }

        #endregion Private Static Methods

        #region Private Methods

        /// <summary>
        /// Parses the given Xml document and loads the rules.
        /// </summary>
        /// <param name="rulesNode">The rules node.</param>
        /// <param name="ruleGroup">The optional rule group name.</param>
        /// <param name="isKnownAssembly">Indicates whether the add-in comes from a known assembly.</param>
        private void AddRulesFromXml(XmlNode rulesNode, string ruleGroup, bool isKnownAssembly)
        {
            Param.AssertNotNull(rulesNode, "rulesNode");
            Param.Ignore(ruleGroup);
            Param.Ignore(isKnownAssembly);

            foreach (XmlNode rule in rulesNode.ChildNodes)
            {
                // Look for the Rule nodes.
                if (rule.Name == "RuleGroup")
                {
                    // This is a rule group containing child rules. Extract the name of the group.
                    XmlAttribute groupName = rule.Attributes["Name"];
                    if (groupName == null || groupName.Value.Length == 0)
                    {
                        throw new ArgumentException(Strings.RuleGroupHasNoNameAttribute);
                    }

                    // Extract the rules under this group.
                    this.AddRulesFromXml(rule, groupName.Value, isKnownAssembly);
                }
                else if (rule.Name == "Rule")
                {
                    // Get the name, check-id, and context and throw an exception if any of these doesn't exist.
                    XmlNode ruleName = rule.Attributes["Name"];
                    if (ruleName == null || ruleName.Value.Length == 0)
                    {
                        throw new ArgumentException(Strings.RuleHasNoNameAttribute);
                    }

                    XmlNode ruleCheckId = rule.Attributes["CheckId"];
                    if (ruleCheckId == null || ruleCheckId.Value.Length == 0)
                    {
                        throw new ArgumentException(string.Format(
                            CultureInfo.CurrentCulture, Strings.RuleHasNoCheckIdAttribute, ruleName.Value));
                    }

                    // Validate the check-id to determine whether it uses the default prefix code.
                    if (ruleCheckId.Value.StartsWith(DefaultCheckIdPrefix, StringComparison.Ordinal) && !isKnownAssembly)
                    {
                        throw new ArgumentException(
                            string.Format(CultureInfo.CurrentCulture, Strings.UnknownAssemblyUsingDefaultCheckIdPrefix, ruleCheckId.Value));
                    }

                    XmlNode ruleContext = rule["Context"];
                    if (ruleContext == null || ruleContext.InnerText.Length == 0)
                    {
                        throw new ArgumentException(
                            string.Format(CultureInfo.CurrentCulture, Strings.RuleHasNoContextElement, ruleName.Value));
                    }

                    string context = TrimXmlContent(ruleContext.InnerText);
                    if (string.IsNullOrEmpty(context))
                    {
                        throw new ArgumentException(string.Format(
                            CultureInfo.CurrentCulture, Strings.RuleHasNoContextElement, ruleName.Value));
                    }

                    // Get the optional description node.
                    XmlNode ruleDescription = rule["Description"];

                    // Get the optional warning attribute.
                    XmlAttribute warning = rule.Attributes["Warning"];

                    // Get the optional disabledByDefault attribute.
                    XmlAttribute disabledByDefault = rule.Attributes["DisabledByDefault"];

                    // Get the optional can disable attribute.
                    XmlAttribute canDisable = rule.Attributes["CanDisable"];

                    // Disabled by default defaults to false.
                    bool disabledByDefaultValue = disabledByDefault == null ? false : Convert.ToBoolean(disabledByDefault.Value, CultureInfo.InvariantCulture);

                    // Can disable defaults to true.
                    bool canDisableValue = canDisable == null ? true : Convert.ToBoolean(canDisable.Value, CultureInfo.InvariantCulture);

                    // Warning defaults to false.
                    bool warningValue = warning == null ? false : Convert.ToBoolean(warning.Value, CultureInfo.InvariantCulture);

                    // Add the rule.
                    if (this.rules.ContainsKey(ruleName.Value))
                    {
                        throw new ArgumentException(Strings.RuleWithSameNameExists);
                    }

                    Rule type = new Rule(
                        ruleName.Value,
                        this.id,
                        ruleCheckId.Value,
                        context,
                        warningValue,
                        ruleDescription == null ? string.Empty : TrimXmlContent(ruleDescription.InnerText),
                        ruleGroup,
                        !disabledByDefaultValue,
                        canDisableValue);

                    this.rules.Add(ruleName.Value, type);
                }
            }
        }

        #endregion Private Methods
    }
}