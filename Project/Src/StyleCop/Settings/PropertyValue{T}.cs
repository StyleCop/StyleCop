// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyValue{T}.cs" company="https://github.com/StyleCop">
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
//   A simple property.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// A simple property.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the property value.
    /// </typeparam>
    public abstract class PropertyValue<T> : PropertyValue
    {
        #region Fields

        /// <summary>
        /// The value of the property.
        /// </summary>
        private T value;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyValue{T}"/> class. 
        /// Initializes a new instance of the PropertyValue class.
        /// </summary>
        /// <param name="propertyDescriptor">
        /// The property descriptor that this value represents.
        /// </param>
        /// <param name="value">
        /// The value of the property.
        /// </param>
        protected PropertyValue(PropertyDescriptor<T> propertyDescriptor, T value)
            : base(propertyDescriptor)
        {
            Param.RequireNotNull(propertyDescriptor, "propertyDescriptor");
            Param.Ignore(value);

            this.value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyValue{T}"/> class. 
        /// Initializes a new instance of the PropertyValue class.
        /// </summary>
        /// <param name="propertyContainer">
        /// The container of this property.
        /// </param>
        /// <param name="propertyName">
        /// The name of the property.
        /// </param>
        /// <param name="value">
        /// The value of the property.
        /// </param>
        protected PropertyValue(IPropertyContainer propertyContainer, string propertyName, T value)
            : base(propertyContainer, propertyName)
        {
            Param.RequireNotNull(propertyContainer, "propertyContainer");
            Param.RequireValidString(propertyName, "propertyName");
            Param.Ignore(value);

            this.value = value;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the default value of the property.
        /// </summary>
        public T DefaultValue
        {
            get
            {
                PropertyDescriptor<T> propertyDescriptor = (PropertyDescriptor<T>)this.PropertyDescriptor;
                return propertyDescriptor.DefaultValue;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the property has a default value.
        /// </summary>
        public override bool HasDefaultValue
        {
            get
            {
                return this.DefaultValue != null;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the property is currently set to the default value for the property.
        /// </summary>
        public override bool IsDefault
        {
            get
            {
                T defaultValue = this.DefaultValue;
                return defaultValue != null && defaultValue.Equals(this.value);
            }
        }

        /// <summary>
        /// Gets or sets the value of the property.
        /// </summary>
        [SuppressMessage("Microsoft.Maintainability", "CA1500:VariableNamesShouldNotMatchFieldNames", MessageId = "value", 
            Justification = "It is not possible to change the name")]
        public T Value
        {
            get
            {
                return this.value;
            }

            set
            {
                Param.Ignore(value);

                if (this.IsReadOnly)
                {
                    throw new StyleCopException(Strings.ReadOnlyProperty);
                }

                this.value = value;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Clones the contents of the property.
        /// </summary>
        /// <returns>Returns the cloned property.</returns>
        public override PropertyValue Clone()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether this property overrides the given property.
        /// </summary>
        /// <param name="parentProperty">
        /// The parent property to compare with.
        /// </param>
        /// <returns>
        /// Returns true if this property overrides the given property.
        /// </returns>
        public override bool OverridesProperty(PropertyValue parentProperty)
        {
            Param.RequireNotNull(parentProperty, "parentProperty");

            PropertyValue<T> parentBooleanProperty = parentProperty as PropertyValue<T>;
            if (parentBooleanProperty == null || !this.DefaultValue.Equals(parentBooleanProperty.DefaultValue))
            {
                throw new ArgumentException(Strings.ComparingDifferentPropertyTypes, "parentProperty");
            }

            return !this.value.Equals(parentBooleanProperty.Value);
        }

        #endregion
    }
}