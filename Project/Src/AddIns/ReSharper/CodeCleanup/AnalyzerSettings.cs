// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnalyzerSettings.cs" company="http://stylecop.codeplex.com">
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
//   Defines the AnalyzerSettings type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper.CodeCleanup
{
    using System.Linq;

    /// <summary>
    /// The analyzer settings.
    /// </summary>
    public class AnalyzerSettings
    {
        private readonly AddInPropertyCollection analyzerSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnalyzerSettings"/> class.
        /// </summary>
        /// <param name="settings">
        /// The settings.
        /// </param>
        /// <param name="analyzerId">
        /// The analyzer id.
        /// </param>
        public AnalyzerSettings(Settings settings, string analyzerId)
        {
            this.analyzerSettings = settings == null ? null : settings.AnalyzerSettings.FirstOrDefault(a => a.AddIn.Id == analyzerId);
        }

        /// <summary>
        /// The is rule enabled.
        /// </summary>
        /// <param name="rule">
        /// The rule.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsRuleEnabled(string rule)
        {
            if (this.analyzerSettings == null)
            {
                return true;
            }

            string propertyName = rule + "#Enabled";

            BooleanProperty property = this.analyzerSettings[propertyName] as BooleanProperty;
            if (property != null)
            {
                return property.Value;
            }

            PropertyDescriptor<bool> defaultPropertyDescriptor = this.analyzerSettings.AddIn.PropertyDescriptors[propertyName] as PropertyDescriptor<bool>;
            if (defaultPropertyDescriptor != null)
            {
                return defaultPropertyDescriptor.DefaultValue;
            }

            return true;
        }
    }
}