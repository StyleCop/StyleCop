// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SettingsComparer.cs" company="https://github.com/StyleCop">
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
//   Compares two settings files.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Compares two settings files.
    /// </summary>
    public class SettingsComparer
    {
        #region Fields

        /// <summary>
        /// The local settings.
        /// </summary>
        private readonly Settings localSettings;

        /// <summary>
        /// The parent settings to merge with the local settings.
        /// </summary>
        private readonly Settings parentSettings;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the SettingsComparer class.
        /// </summary>
        /// <param name="localSettings">
        /// The local settings.
        /// </param>
        /// <param name="parentSettings">
        /// The parent setting to merge with the local settings, or null.
        /// </param>
        public SettingsComparer(Settings localSettings, Settings parentSettings)
        {
            Param.RequireNotNull(localSettings, "localSettings");
            Param.Ignore(parentSettings);

            this.localSettings = localSettings;
            this.parentSettings = parentSettings;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the local settings.
        /// </summary>
        public Settings LocalSettings
        {
            get
            {
                return this.localSettings;
            }
        }

        /// <summary>
        /// Gets the parent settings.
        /// </summary>
        public Settings ParentSettings
        {
            get
            {
                return this.parentSettings;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Determines whether the local property overrides the parent property.
        /// </summary>
        /// <param name="localProperty">
        /// The local property.
        /// </param>
        /// <param name="parentProperty">
        /// The parent property.
        /// </param>
        /// <returns>
        /// Returns true if the local property overrides the parent property.
        /// </returns>
        public static bool IsSettingOverwritten(PropertyValue localProperty, PropertyValue parentProperty)
        {
            Param.Ignore(localProperty, parentProperty);

            // If either the parent property or the local property is not set, then the setting is not overwritten.
            if (parentProperty == null || localProperty == null)
            {
                return false;
            }

            // Ensure that the two properties are the same kind of property.
            if (localProperty.PropertyType != parentProperty.PropertyType)
            {
                throw new ArgumentException(Strings.ComparingDifferentPropertyTypes);
            }

            return localProperty.OverridesProperty(parentProperty);
        }

        /// <summary>
        /// Determines whether the given add-in setting overrides the parent setting.
        /// </summary>
        /// <param name="addIn">
        /// The add-in.
        /// </param>
        /// <param name="propertyName">
        /// The name of the property.
        /// </param>
        /// <param name="localProperty">
        /// The local value of the property.
        /// </param>
        /// <returns>
        /// Returns true if the given add-in setting overrides the parent setting.
        /// </returns>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "InSetting", 
            Justification = "InSetting is two words in this context.")]
        public bool IsAddInSettingOverwritten(StyleCopAddIn addIn, string propertyName, PropertyValue localProperty)
        {
            Param.RequireNotNull(addIn, "addIn");
            Param.RequireValidString(propertyName, "propertyName");
            Param.Ignore(localProperty);

            // Try to find this property in the parent settings file.
            PropertyValue parentProperty = null;

            if (this.parentSettings != null)
            {
                PropertyCollection parentParserProperties = this.parentSettings.GetAddInSettings(addIn);
                if (parentParserProperties != null)
                {
                    parentProperty = parentParserProperties[propertyName];
                }
            }

            if (parentProperty == null)
            {
                // If there is no parent setting, then the parent is set to the default. If the local setting
                // is not set to the default, then we consider that the local setting is overriding the parent setting.
                return !localProperty.HasDefaultValue || !localProperty.IsDefault;
            }

            // Compare the local and parent properties.
            return IsSettingOverwritten(localProperty, parentProperty);
        }

        /// <summary>
        /// Determines whether the given global setting overrides the parent setting.
        /// </summary>
        /// <param name="propertyName">
        /// The name of the property.
        /// </param>
        /// <param name="localProperty">
        /// The local value of the property.
        /// </param>
        /// <returns>
        /// Returns true if the given global setting overrides the parent setting.
        /// </returns>
        public bool IsGlobalSettingOverwritten(string propertyName, PropertyValue localProperty)
        {
            Param.RequireValidString(propertyName, "propertyName");
            Param.Ignore(localProperty);

            if (this.parentSettings == null)
            {
                return false;
            }

            // Try to find this property in the parent settings file.
            PropertyValue parentProperty = this.parentSettings.GlobalSettings[propertyName];
            if (parentProperty == null)
            {
                return false;
            }

            return IsSettingOverwritten(localProperty, parentProperty);
        }

        /// <summary>
        /// Determines whether a local global setting overrides the parent setting.
        /// </summary>
        /// <param name="propertyName">
        /// The name of the property.
        /// </param>
        /// <returns>
        /// Returns true if the local global setting overrides the parent setting.
        /// </returns>
        public bool IsGlobalSettingOverwritten(string propertyName)
        {
            Param.RequireValidString(propertyName, "propertyName");

            if (this.localSettings == null)
            {
                return false;
            }

            PropertyValue localProperty = this.localSettings.GlobalSettings[propertyName];
            if (localProperty == null)
            {
                return false;
            }

            return this.IsGlobalSettingOverwritten(propertyName, localProperty);
        }

        /// <summary>
        /// Determines whether a local add-in setting overrides the parent setting.
        /// </summary>
        /// <param name="addIn">
        /// The add-in.
        /// </param>
        /// <param name="propertyName">
        /// The name of the property.
        /// </param>
        /// <returns>
        /// Returns true if the local add-in setting overrides the parent setting.
        /// </returns>
        public bool IsParserSettingOverwritten(StyleCopAddIn addIn, string propertyName)
        {
            Param.RequireNotNull(addIn, "addIn");
            Param.RequireValidString(propertyName, "propertyName");

            if (this.localSettings == null)
            {
                return false;
            }

            PropertyCollection localAddInSettings = this.localSettings.GetAddInSettings(addIn);
            if (localAddInSettings == null)
            {
                return false;
            }

            PropertyValue localProperty = localAddInSettings[propertyName];
            if (localProperty == null)
            {
                return false;
            }

            return this.IsAddInSettingOverwritten(addIn, propertyName, localProperty);
        }

        #endregion
    }
}