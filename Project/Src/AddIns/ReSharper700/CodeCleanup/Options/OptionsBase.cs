// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OptionsBase.cs" company="http://stylecop.codeplex.com">
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
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper700.CodeCleanup.Options
{
    #region Using Directives

    using System.Linq;
    using System.Reflection;

    using StyleCop.ReSharper700.Core;

    #endregion

    /// <summary>
    /// Defines the base options class.
    /// </summary>
    public abstract class OptionsBase
    {
        #region Constants and Fields

        private AddInPropertyCollection analyzerSettingsProperties;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the name of the analyzer as defined in StyleCop settings. 
        /// </summary>
        /// <value>
        /// The name of the analyzer.
        /// </value>
        protected abstract string AnalyzerName { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the properties defaults from StyleCop settings.
        /// It assumes that the first 6 chars of each property are the code (ie: SA1600) and the rest matches the name as defined in StyleCop settings
        /// (ex: SA1500CurlyBracketsForMultiLineStatementsMustNotShareLine =&gt;  CurlyBracketsForMultiLineStatementsMustNotShareLine should be the name in StyleCop settings). 
        /// </summary>
        protected void InitPropertiesDefaults()
        {
            var styleCopSettings = Utils.GetStyleCopSettings();

            if (styleCopSettings != null)
            {
                this.analyzerSettingsProperties = styleCopSettings.AnalyzerSettings.FirstOrDefault(n => n.AddIn.Id == this.AnalyzerName);
            }

            var propertyInfos = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var propertyInfo in propertyInfos)
            {
                if (propertyInfo.PropertyType == typeof(bool))
                {
                    var settingsProperty = propertyInfo.Name.Substring(6);
                    var propertyValue = this.IsPropertyEnabled(settingsProperty);
                    propertyInfo.SetValue(this, propertyValue, null);
                }
            }
        }

        /// <summary>
        /// Determines whether a property is enabled in StyleCop settings. 
        /// Default to true if property isn't defined in StyleCop settings. 
        /// </summary>
        /// <param name="propertyName">
        /// The property.
        /// </param>
        /// <returns>
        /// <c>true</c> if the property is enabled; otherwise, <c>false</c>.
        /// </returns>
        protected bool IsPropertyEnabled(string propertyName)
        {
            if (this.analyzerSettingsProperties == null)
            {
                return true;
            }

            var property = this.analyzerSettingsProperties[propertyName + "#Enabled"] as BooleanProperty;

            if (property != null)
            {
                return property.Value;
            }

            var defaultPropertyDecriptor = this.analyzerSettingsProperties.AddIn.PropertyDescriptors[propertyName + "#Enabled"] as PropertyDescriptor<bool>;

            if (defaultPropertyDecriptor != null)
            {
                return defaultPropertyDecriptor.DefaultValue;
            }

            return true;
        }

        #endregion
    }
}