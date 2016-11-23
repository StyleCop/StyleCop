// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Rule.cs" company="https://github.com/StyleCop">
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
//   Describes one analysis rule exposed by a StyleCop analyzer or parser.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;

    /// <summary>
    /// Describes one analysis rule exposed by a StyleCop analyzer or parser.
    /// </summary>
    public class Rule
    {
        #region Fields

        /// <summary>
        /// Indicates whether the rule can be disabled.
        /// </summary>
        private readonly bool canDisable;

        /// <summary>
        /// The short ID of the rule.
        /// </summary>
        private readonly string checkId;

        /// <summary>
        /// The context message for the rule.
        /// </summary>
        private readonly string context;

        /// <summary>
        /// The rule description.
        /// </summary>
        private readonly string description;

        /// <summary>
        /// Indicates whether the rule is enabled by default.
        /// </summary>
        private readonly bool enabledByDefault = true;

        /// <summary>
        /// The name of this rule.
        /// </summary>
        private readonly string name;

        /// <summary>
        /// The namespace that the rule is contained within.
        /// </summary>
        private readonly string @namespace;

        /// <summary>
        /// The unique hash ID for the rule namespace.
        /// </summary>
        private readonly int namespaceID;

        /// <summary>
        /// The rule group that contains this rule.
        /// </summary>
        private readonly string ruleGroup;

        /// <summary>
        /// The unique hash ID for the rule.
        /// </summary>
        private readonly int uniqueID;

        /// <summary>
        /// Indicates whether the rule is a warning.
        /// </summary>
        private readonly bool warning;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the Rule class.
        /// </summary>
        /// <param name="name">
        /// The name of this rule.
        /// </param>
        /// <param name="namespace">
        /// The namespace that the rule is contained within.
        /// </param>
        /// <param name="checkId">
        /// The short ID of the rule.
        /// </param>
        /// <param name="context">
        /// The context message for the rule.
        /// </param>
        /// <param name="warning">
        /// Indicates whether the rule is a warning.
        /// </param>
        internal Rule(string name, string @namespace, string checkId, string context, bool warning)
            : this(name, @namespace, checkId, context, warning, string.Empty, null, true, false)
        {
            Param.Ignore(name, @namespace, checkId, context, warning);
        }

        /// <summary>
        /// Initializes a new instance of the Rule class.
        /// </summary>
        /// <param name="name">
        /// The name of this rule.
        /// </param>
        /// <param name="namespace">
        /// The namespace that the rule is contained within.
        /// </param>
        /// <param name="checkId">
        /// The short ID of the rule.
        /// </param>
        /// <param name="context">
        /// The context message for the rule.
        /// </param>
        /// <param name="warning">
        /// Indicates whether the rule is a warning.
        /// </param>
        /// <param name="description">
        /// The description of the rule.
        /// </param>
        /// <param name="ruleGroup">
        /// The rule group that contains this rule.
        /// </param>
        /// <param name="enabledByDefault">
        /// Indicates whether the rule is enabled by default.
        /// </param>
        /// <param name="canDisable">
        /// Indicates whether the rule can be disabled.
        /// </param>
        internal Rule(
            string name, string @namespace, string checkId, string context, bool warning, string description, string ruleGroup, bool enabledByDefault, bool canDisable)
        {
            Param.AssertValidString(name, "name");
            Param.AssertValidString(@namespace, "namespace");
            Param.AssertValidString(checkId, "checkId");
            Param.AssertValidString(context, "context");
            Param.Ignore(warning);
            Param.AssertNotNull(description, "description");
            Param.Ignore(ruleGroup);
            Param.Ignore(enabledByDefault);
            Param.Ignore(canDisable);

            // Perform further validation to ensure that a rule is not set to disabled by default and also can disable = false;
            if (!enabledByDefault && !canDisable)
            {
                throw new ArgumentException(Strings.RuleDisabledByDefaultAndNotCanDisable);
            }

            // Perform further validation on the violation name to ensure that it only contains letters and spaces.
            for (int i = 0; i < name.Length; ++i)
            {
                if (!char.IsLetterOrDigit(name[i]))
                {
                    throw new ArgumentException(Strings.RuleNameInvalid, name);
                }
            }

            // Also ensure that the first character in the rule name is an upper-case letter.
            char firstCharacter = name[0];
            if (!char.IsUpper(firstCharacter))
            {
                throw new ArgumentException(Strings.RuleNameInvalid, name);
            }

            // Perform further validate to ensure that the check ID is six characters long, begins with two upper-case letters and ends with
            // four digits.
            if (checkId.Length != 6 || !char.IsLetter(checkId[0]) || !char.IsUpper(checkId[0]) || !char.IsLetter(checkId[1]) || !char.IsUpper(checkId[1])
                || !char.IsDigit(checkId[2]) || !char.IsDigit(checkId[3]) || !char.IsDigit(checkId[4]) || !char.IsDigit(checkId[5]))
            {
                throw new ArgumentException(Strings.RuleCheckIdInvalid, checkId);
            }

            this.name = name;
            this.@namespace = @namespace;
            this.checkId = checkId;
            this.context = context;
            this.warning = warning;
            this.description = description;
            this.ruleGroup = ruleGroup;
            this.enabledByDefault = enabledByDefault;
            this.canDisable = canDisable;

            this.namespaceID = GenerateUniqueRuleNamespaceID(this.@namespace);
            this.uniqueID = GenerateUniqueRuleID(this.@namespace, this.checkId, this.name);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether the rule can be disabled.
        /// </summary>
        public bool CanDisable
        {
            get
            {
                return this.canDisable;
            }
        }

        /// <summary>
        /// Gets the short identifier of the rule.
        /// </summary>
        public string CheckId
        {
            get
            {
                return this.checkId;
            }
        }

        /// <summary>
        /// Gets the context message for the rule.
        /// </summary>
        public string Context
        {
            get
            {
                return this.context;
            }
        }

        /// <summary>
        /// Gets the description of the rule.
        /// </summary>
        public string Description
        {
            get
            {
                return this.description;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the rule is enabled by default.
        /// </summary>
        public bool EnabledByDefault
        {
            get
            {
                return this.enabledByDefault;
            }
        }

        /// <summary>
        /// Gets the name of this rule.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Gets the namespace that contains the rule.
        /// </summary>
        public string Namespace
        {
            get
            {
                return this.@namespace;
            }
        }

        /// <summary>
        /// Gets the rule group that contains this rule, if any.
        /// </summary>
        public string RuleGroup
        {
            get
            {
                return this.ruleGroup;
            }
        }

        /// <summary>
        /// Gets a unique ID for this specific rule, which can be used as a hash for identifying this rule.
        /// </summary>
        public int UniqueRuleId
        {
            get
            {
                return this.uniqueID;
            }
        }

        /// <summary>
        /// Gets a unique ID for this rule's namespace, which can be used as a hash for identifying the namespace.
        /// </summary>
        public int UniqueRuleNamespaceId
        {
            get
            {
                return this.namespaceID;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the rule is a warning.
        /// </summary>
        public bool Warning
        {
            get
            {
                return this.warning;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Gets a unique ID for identifying a rule.
        /// </summary>
        /// <param name="namespace">
        /// The namespace containing the rule.
        /// </param>
        /// <param name="checkId">
        /// The CheckID code for the rule, or * to match against all rules in the namespace.
        /// </param>
        /// <param name="name">
        /// The rule name, or null if CheckID is *.
        /// </param>
        /// <returns>
        /// Returns the unique ID.
        /// </returns>
        public static int GenerateUniqueId(string @namespace, string checkId, string name)
        {
            Param.RequireValidString(@namespace, "namespace");
            Param.RequireValidString(checkId, "checkID");
            Param.Require(checkId == "*" || !string.IsNullOrEmpty(name), "name", "Rule name is invalid.");

            if (checkId == "*")
            {
                return GenerateUniqueRuleNamespaceID(@namespace);
            }
            else
            {
                return GenerateUniqueRuleID(@namespace, checkId, name);
            }
        }

        /// <summary>
        /// Gets a unique hash code for identifying the rule.
        /// </summary>
        /// <returns>Returns the hash code.</returns>
        public override int GetHashCode()
        {
            return this.uniqueID;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Generates a unique ID for a specific rule, which can be used as a hash for identifying the rule.
        /// </summary>
        /// <param name="namespace">
        /// The rule's namespace.
        /// </param>
        /// <param name="checkID">
        /// The rule's checkID.
        /// </param>
        /// <param name="name">
        /// The rule's name.
        /// </param>
        /// <returns>
        /// Returns the unique ID.
        /// </returns>
        private static int GenerateUniqueRuleID(string @namespace, string checkID, string name)
        {
            Param.AssertValidString(@namespace, "namespace");
            Param.AssertValidString(checkID, "checkID");
            Param.AssertValidString(name, "name");

            return string.Concat(checkID, ":", @namespace, ".", name).GetHashCode();
        }

        /// <summary>
        /// Generates a unique ID for the rule's namespace, which can be used as a hash for identifying the namespace.
        /// </summary>
        /// <param name="namespace">
        /// The rule's namespace.
        /// </param>
        /// <returns>
        /// Returns the unique ID.
        /// </returns>
        private static int GenerateUniqueRuleNamespaceID(string @namespace)
        {
            Param.AssertValidString(@namespace, "namespace");
            return @namespace.GetHashCode();
        }

        #endregion
    }
}