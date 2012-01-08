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

namespace StyleCop.ReSharper61.CodeCleanup.Rules
{
    #region Using Directives

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Security.Permissions;
    using System.Text;

    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.Feature.Services.CSharp.CodeCleanup;
    using JetBrains.ReSharper.Feature.Services.LiveTemplates.Macros;
    using JetBrains.ReSharper.LiveTemplates;
    using JetBrains.ReSharper.LiveTemplates.CSharp.Macros;
    using JetBrains.ReSharper.Psi;
    using JetBrains.ReSharper.Psi.CSharp;

    using StyleCop.ReSharper61.Core;

    #endregion
    
    /// <summary>
    /// A class that exposes the current Documentation configuration for the file provided.
    /// </summary>
    public class DocumentationRulesConfiguration
    {
        #region Constants and Fields

        private const string AnalyzerName = "StyleCop.CSharp.DocumentationRules";

        private readonly Settings settings;

        private readonly IPsiSourceFile file;

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
            var property = this.GetStyleCopRuleProperty<BooleanProperty>("IgnorePrivates");
            this.IgnorePrivates = property == null ? false : property.Value;

            // Default for this property is true
            property = this.GetStyleCopRuleProperty<BooleanProperty>("IncludeFields");
            this.RequireFields = property == null ? true : property.Value;

            // Default for this property is false
            property = this.GetStyleCopRuleProperty<BooleanProperty>("IgnoreInternals");
            this.IgnoreInternals = property == null ? false : property.Value;

            var stringProperty = this.GetStyleCopRuleProperty<StringProperty>("CompanyName");
            this.CompanyName = stringProperty != null ? stringProperty.Value : string.Empty;

            stringProperty = this.GetStyleCopRuleProperty<StringProperty>("Copyright");
            this.Copyright = stringProperty != null ? this.ReplaceTokenVariables(stringProperty.Value) : string.Empty;
        }

        #endregion

        #region Properties

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

        #region Public Methods

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
            var returnValue = false;

            if (this.settings != null)
            {
                var analyzerSettings = this.settings.AnalyzerSettings;
                foreach (var addInPropertyCollection in analyzerSettings)
                {
                    if (addInPropertyCollection.AddIn.Id == AnalyzerName)
                    {
                        var property = addInPropertyCollection[ruleId + "#Enabled"] as BooleanProperty;

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
            var propertyValue = this.GetSetting(propertyName);
            return (TProperty)propertyValue;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Replaces any tokenised strings and returns the expanded result.
        /// </summary>
        /// <param name="value">The tokenised string to expand.</param>
        /// <returns>The expanded string.</returns>
        private string ReplaceTokenVariables(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            var creationTime = DateTime.Now;
            var projectName = string.Empty;
            var nowDate = DateTime.Now.Date;

            var projectFile = this.file.ToProjectFile();

            if (projectFile != null)
            {
                creationTime = projectFile.Location.ToFileInfo().CreationTime;
                var project = projectFile.GetProject();
                if (project != null)
                {
                    projectName = project.Name;
                }
            }
            
            var stringDictionary = new Dictionary<string, string>
                {
                    { "$USER_LOGIN$", Environment.UserName },
                    { "$USER_NAME$", FullUserNameMacro.GetDisplayUserName() },
                    { "$SOLUTION$", this.file.GetSolution().Name },
                    { "$PROJECT$", projectName },
                    { "$FILENAME$", this.file.Name },
                    { "$CURRENT_YEAR$", nowDate.ToString("yyyy") },
                    { "$CURRENT_MONTH$", nowDate.ToString("MM") },
                    { "$CURRENT_DAY$", nowDate.ToString("dd") },
                    { "$CURRENT_TIME$", nowDate.ToString("t") },
                    { "$CREATED_YEAR$", creationTime.ToString("yyyy") },
                    { "$CREATED_MONTH$", creationTime.ToString("MM") },
                    { "$CREATED_DAY$", creationTime.ToString("dd") },
                    { "$CREATED_TIME$", creationTime.ToString("t") },
                };

            return Environment.ExpandEnvironmentVariables(stringDictionary.Keys.Aggregate(value, (current, key) => current.Replace(key, stringDictionary[key])));
        }

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
            return this.settings != null ? (from addInProperty in this.settings.AnalyzerSettings where addInProperty.AddIn.Id == AnalyzerName select addInProperty[propertyName]).FirstOrDefault() : null;
        }

        #endregion
    }
}