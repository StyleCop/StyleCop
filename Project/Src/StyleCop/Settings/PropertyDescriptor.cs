// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyDescriptor.cs" company="https://github.com/StyleCop">
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
//   A property descriptor.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    /// <summary>
    /// A property descriptor.
    /// </summary> 
    public abstract class PropertyDescriptor
    {
        #region Fields

        /// <summary>
        /// The description of the property.
        /// </summary>
        private readonly string description;

        /// <summary>
        /// Indicates whether to display the property on the settings dialog by default.
        /// </summary>
        private readonly bool displaySettings;

        /// <summary>
        /// The friendly name of the property.
        /// </summary>
        private readonly string friendlyName;

        /// <summary>
        /// Indicates whether to merge the property with parent properties.
        /// </summary>
        private readonly bool merge;

        /// <summary>
        /// The name of the property.
        /// </summary>
        private readonly string propertyName;

        /// <summary>
        /// The type of the property.
        /// </summary>
        private readonly PropertyType propertyType;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the PropertyDescriptor class.
        /// </summary>
        /// <param name="propertyName">
        /// The name of the property.
        /// </param>
        /// <param name="propertyType">
        /// The type of the property.
        /// </param>
        /// <param name="friendlyName">
        /// The friendly name of the property.
        /// </param>
        /// <param name="description">
        /// The property description.
        /// </param>
        /// <param name="merge">
        /// Indicates whether to merge the property with parent properties.
        /// </param>
        /// <param name="displaySettings">
        /// Indicates whether to display the property on the settings dialog.
        /// </param>
        protected PropertyDescriptor(string propertyName, PropertyType propertyType, string friendlyName, string description, bool merge, bool displaySettings)
        {
            Param.RequireValidString(propertyName, "propertyName");
            Param.Ignore(propertyType);
            Param.RequireNotNull(friendlyName, "friendlyName");
            Param.RequireNotNull(description, "description");
            Param.Ignore(merge);
            Param.Ignore(displaySettings);

            this.propertyName = propertyName;
            this.propertyType = propertyType;
            this.friendlyName = friendlyName;
            this.description = description;
            this.merge = merge;
            this.displaySettings = displaySettings;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the description of the property.
        /// </summary>
        public string Description
        {
            get
            {
                return this.description;
            }
        }

        /// <summary>
        /// Gets a value indicating whether to display the property on the settings dialog by default.
        /// </summary>
        public bool DisplaySettings
        {
            get
            {
                return this.displaySettings;
            }
        }

        /// <summary>
        /// Gets the friendly name of the property.
        /// </summary>
        public string FriendlyName
        {
            get
            {
                return this.friendlyName;
            }
        }

        /// <summary>
        /// Gets a value indicating whether to merge the property with parent properties.
        /// </summary>
        public bool Merge
        {
            get
            {
                return this.merge;
            }
        }

        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        public string PropertyName
        {
            get
            {
                return this.propertyName;
            }
        }

        /// <summary>
        /// Gets the type of the property.
        /// </summary>
        public PropertyType PropertyType
        {
            get
            {
                return this.propertyType;
            }
        }

        #endregion
    }
}