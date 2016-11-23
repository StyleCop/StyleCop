// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyValue.cs" company="https://github.com/StyleCop">
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
//   A single property.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Globalization;

    /// <summary>
    /// A single property.
    /// </summary>
    public abstract class PropertyValue
    {
        #region Fields

        /// <summary>
        /// The property descriptor.
        /// </summary>
        private readonly PropertyDescriptor propertyDescriptor;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the PropertyValue class.
        /// </summary>
        /// <param name="propertyDescriptor">
        /// The property descriptor that this value represents.
        /// </param>
        protected PropertyValue(PropertyDescriptor propertyDescriptor)
        {
            Param.RequireNotNull(propertyDescriptor, "propertyDescriptor");
            this.propertyDescriptor = propertyDescriptor;
        }

        /// <summary>
        /// Initializes a new instance of the PropertyValue class.
        /// </summary>
        /// <param name="propertyContainer">
        /// The container of this property.
        /// </param>
        /// <param name="propertyName">
        /// The name of the property.
        /// </param>
        protected PropertyValue(IPropertyContainer propertyContainer, string propertyName)
        {
            Param.RequireNotNull(propertyContainer, "propertyContainer");
            Param.RequireValidString(propertyName, "propertyName");

            PropertyDescriptor descriptor = propertyContainer.PropertyDescriptors[propertyName];
            if (descriptor == null)
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Strings.PropertyDescriptorDoesNotExist, propertyName));
            }

            this.propertyDescriptor = descriptor;
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
                return this.propertyDescriptor.Description;
            }
        }

        /// <summary>
        /// Gets the friendly name of the property.
        /// </summary>
        public string FriendlyName
        {
            get
            {
                return this.propertyDescriptor.FriendlyName;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the property has a default value.
        /// </summary>
        public abstract bool HasDefaultValue { get; }

        /// <summary>
        /// Gets a value indicating whether the property is currently set to the default value for the property.
        /// </summary>
        public abstract bool IsDefault { get; }

        /// <summary>
        /// Gets a value indicating whether the property is read-only.
        /// </summary>
        public virtual bool IsReadOnly { get; internal set; }

        /// <summary>
        /// Gets the property descriptor that this value represents.
        /// </summary>
        public PropertyDescriptor PropertyDescriptor
        {
            get
            {
                return this.propertyDescriptor;
            }
        }

        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        public string PropertyName
        {
            get
            {
                return this.propertyDescriptor.PropertyName;
            }
        }

        /// <summary>
        /// Gets the type of the property.
        /// </summary>
        public PropertyType PropertyType
        {
            get
            {
                return this.propertyDescriptor.PropertyType;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Clones the contents of the property.
        /// </summary>
        /// <returns>Returns the cloned property.</returns>
        public abstract PropertyValue Clone();

        /// <summary>
        /// Determines whether this property overrides the given property.
        /// </summary>
        /// <param name="parentProperty">
        /// The parent property to compare with.
        /// </param>
        /// <returns>
        /// Returns true if this property overrides the given property.
        /// </returns>
        public abstract bool OverridesProperty(PropertyValue parentProperty);

        #endregion
    }
}