// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentationRulesConfiguration.cs" company="http://stylecop.codeplex.com">
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
//   A class that exposes the current Documentation configuration for the file provided.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.ReSharper800.CodeCleanup.Rules
{
    #region Using Directives

    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using JetBrains.ReSharper.Psi;

    using StyleCop.ReSharper800.Core;

    #endregion

    /// <summary>
    /// A class that exposes the current Documentation configuration for the file provided.
    /// </summary>
    public class DocumentationRulesConfiguration
    {
        #region Constants

        private const string AnalyzerName = "StyleCop.CSharp.DocumentationRules";

        #endregion

        #region Fields

        private readonly IPsiSourceFile file;

        private readonly Settings settings;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentationRulesConfiguration"/> class. 
        /// </summary>
        /// <param name="file">
        /// The file to get the configuration for.
        /// </param>
        public DocumentationRulesConfiguration(IPsiSourceFile file)
        {
            this.settings = new StyleCopSettings(StyleCopCoreFactory.Create()).GetSettings(file.ToProjectFile());

            this.file = file;

            // Default for this property is false
            BooleanProperty property = this.GetStyleCopRuleProperty<BooleanProperty>("IgnorePrivates");
            this.IgnorePrivates = property == null ? false : property.Value;

            // Default for this property is true
            property = this.GetStyleCopRuleProperty<BooleanProperty>("IncludeFields");
            this.RequireFields = property == null ? true : property.Value;

            // Default for this property is false
            property = this.GetStyleCopRuleProperty<BooleanProperty>("IgnoreInternals");
            this.IgnoreInternals = property == null ? false : property.Value;

            StringProperty stringProperty = this.GetStyleCopRuleProperty<StringProperty>("CompanyName");
            this.CompanyName = stringProperty != null ? stringProperty.Value : string.Empty;

            stringProperty = this.GetStyleCopRuleProperty<StringProperty>("Copyright");

            FileInfo fileInfo = new FileInfo(file.ToProjectFile().Location.FullPath);
            this.Copyright = stringProperty != null ? StyleCop.Utils.ReplaceTokenVariables(stringProperty.Value, fileInfo) : string.Empty;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the company name setting for this file.
        /// </summary>
        public string CompanyName { get; private set; }

        /// <summary>
        /// Gets the copyright text for this file.
        /// </summary>
        public string Copyright { get; private set; }

        /// <summary>
        /// Gets a value indicating whether 'internals' are to be ignored.
        /// </summary>
        public bool IgnoreInternals { get; private set; }

        /// <summary>
        /// Gets a value indicating whether 'privates' are to be ignored.
        /// </summary>
        public bool IgnorePrivates { get; private set; }

        /// <summary>
        /// Gets a value indicating whether fields are required to be documented.
        /// </summary>
        public bool RequireFields { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Gets whether the stylecop rule specified is enabled.
        /// </summary>
        /// <param name="ruleId">
        /// The Rule.Id, this is its qualified name.
        /// </param>
        /// <returns>
        /// True if the rule is enabled in the Settings.StyleCop file otherwise false.
        /// </returns>
        public bool GetStyleCopRuleEnabled(string ruleId)
        {
            bool returnValue = false;

            if (this.settings != null)
            {
                ICollection<AddInPropertyCollection> analyzerSettings = this.settings.AnalyzerSettings;
                foreach (AddInPropertyCollection addInPropertyCollection in analyzerSettings)
                {
                    if (addInPropertyCollection.AddIn.Id == AnalyzerName)
                    {
                        BooleanProperty property = addInPropertyCollection[ruleId + "#Enabled"] as BooleanProperty;

                        if (property != null)
                        {
                            returnValue = property.Value;
                            break;
                        }
                    }
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Gets the property specified.
        /// </summary>
        /// <typeparam name="TProperty">
        /// The property to get the value for.
        /// </typeparam>
        /// <param name="propertyName">
        /// The property to get.
        /// </param>
        /// <returns>
        /// The property or null if not specified.
        /// </returns>
        public TProperty GetStyleCopRuleProperty<TProperty>(string propertyName) where TProperty : PropertyValue
        {
            PropertyValue propertyValue = this.GetSetting(propertyName);
            return (TProperty)propertyValue;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the PropertyValue for the PropertyName passed in.
        /// </summary>
        /// <param name="propertyName">
        /// The property name to get the value for.
        /// </param>
        /// <returns>
        /// The PropertyValue for this id.
        /// </returns>
        private PropertyValue GetSetting(string propertyName)
        {
            return this.settings != null
                       ? (from addInProperty in this.settings.AnalyzerSettings where addInProperty.AddIn.Id == AnalyzerName select addInProperty[propertyName])
                             .FirstOrDefault()
                       : null;
        }

        #endregion
    }
}