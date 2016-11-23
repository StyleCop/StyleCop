// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyDescriptor{T}.cs" company="https://github.com/StyleCop">
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
//   A property descriptor for a simple property.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    /// <summary>
    /// A property descriptor for a simple property.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the property value described by the property descriptor.
    /// </typeparam>
    public class PropertyDescriptor<T> : PropertyDescriptor
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyDescriptor{T}"/> class. 
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
        /// Indicates whether to display the property on the settings dialog by default.
        /// </param>
        /// <param name="defaultValue">
        /// The default value of the property.
        /// </param>
        internal PropertyDescriptor(
            string propertyName, PropertyType propertyType, string friendlyName, string description, bool merge, bool displaySettings, T defaultValue)
            : base(propertyName, propertyType, friendlyName, description, merge, displaySettings)
        {
            Param.Ignore(propertyName);
            Param.Ignore(propertyType);
            Param.Ignore(friendlyName);
            Param.Ignore(description);
            Param.Ignore(merge);
            Param.Ignore(defaultValue);
            Param.Ignore(displaySettings);

            this.DefaultValue = defaultValue;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the default value of the property.
        /// </summary>
        public T DefaultValue { get; internal set; }

        #endregion
    }
}