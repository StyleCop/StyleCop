// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollectionProperty.cs" company="https://github.com/StyleCop">
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
//   Contains a collection of strings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Contains a collection of strings.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", 
        Justification = "The name should not end in Collection as it will resuilt in a very confusing name.")]
    public class CollectionProperty : PropertyValue, ICollection<string>
    {
        #region Fields

        /// <summary>
        /// The inner property collection.
        /// </summary>
        private readonly List<string> collection;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the CollectionProperty class.
        /// </summary>
        /// <param name="propertyDescriptor">
        /// The property descriptor that this value represents.
        /// </param>
        public CollectionProperty(CollectionPropertyDescriptor propertyDescriptor)
            : this(propertyDescriptor, null)
        {
            Param.Ignore(propertyDescriptor);
        }

        /// <summary>
        /// Initializes a new instance of the CollectionProperty class.
        /// </summary>
        /// <param name="propertyDescriptor">
        /// The property descriptor that this value represents.
        /// </param>
        /// <param name="innerCollection">
        /// The inner collection.
        /// </param>
        public CollectionProperty(CollectionPropertyDescriptor propertyDescriptor, IEnumerable<string> innerCollection)
            : base(propertyDescriptor)
        {
            Param.RequireNotNull(propertyDescriptor, "propertyDescriptor");
            Param.Ignore(innerCollection);

            if (innerCollection != null)
            {
                this.collection = new List<string>(innerCollection);
            }
            else
            {
                this.collection = new List<string>();
            }
        }

        /// <summary>
        /// Initializes a new instance of the CollectionProperty class.
        /// </summary>
        /// <param name="propertyContainer">
        /// The container of this property.
        /// </param>
        /// <param name="propertyName">
        /// The name of the property.
        /// </param>
        public CollectionProperty(IPropertyContainer propertyContainer, string propertyName)
            : this(propertyContainer, propertyName, null)
        {
            Param.RequireNotNull(propertyContainer, "propertyContainer");
            Param.RequireValidString(propertyName, "propertyName");
        }

        /// <summary>
        /// Initializes a new instance of the CollectionProperty class.
        /// </summary>
        /// <param name="propertyContainer">
        /// The container of this property.
        /// </param>
        /// <param name="propertyName">
        /// The name of the property.
        /// </param>
        /// <param name="innerCollection">
        /// The inner collection.
        /// </param>
        public CollectionProperty(IPropertyContainer propertyContainer, string propertyName, IEnumerable<string> innerCollection)
            : base(propertyContainer, propertyName)
        {
            Param.RequireNotNull(propertyContainer, "propertyContainer");
            Param.RequireValidString(propertyName, "propertyName");
            Param.Ignore(innerCollection);

            if (innerCollection != null)
            {
                this.collection = new List<string>(innerCollection);
            }
            else
            {
                this.collection = new List<string>();
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether to aggregate the collection when merged.
        /// </summary>
        public bool Aggregate
        {
            get
            {
                return ((CollectionPropertyDescriptor)this.PropertyDescriptor).Aggregate;
            }
        }

        /// <summary>
        /// Gets the number of values in the property values collection.
        /// </summary>
        public int Count
        {
            get
            {
                return this.collection.Count;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the property has a default value.
        /// </summary>
        public override bool HasDefaultValue
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the property is currently set to the default value for the property.
        /// </summary>
        public override bool IsDefault
        {
            get
            {
                // Collection properties do not have defaults.
                return false;
            }
        }

        /// <summary>
        /// Gets the collection of property values.
        /// </summary>
        public ICollection<string> Values
        {
            get
            {
                return this.collection;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Adds a value to the property list.
        /// </summary>
        /// <param name="item">
        /// The item to add.
        /// </param>
        public void Add(string item)
        {
            Param.RequireNotNull(item, "item");

            if (this.IsReadOnly)
            {
                throw new StyleCopException(Strings.ReadOnlyProperty);
            }

            this.collection.Add(item);
        }

        /// <summary>
        /// Clears the list of property values.
        /// </summary>
        public void Clear()
        {
            if (this.IsReadOnly)
            {
                throw new StyleCopException(Strings.ReadOnlyProperty);
            }

            this.collection.Clear();
        }

        /// <summary>
        /// Clones the contents of the collection.
        /// </summary>
        /// <returns>Returns the cloned collection.</returns>
        public override PropertyValue Clone()
        {
            return new CollectionProperty((CollectionPropertyDescriptor)this.PropertyDescriptor, this.collection);
        }

        /// <summary>
        /// Determines whether the given value is contained in the property value list.
        /// </summary>
        /// <param name="item">
        /// The item to search for.
        /// </param>
        /// <returns>
        /// Returns true if the item is contained within the list.
        /// </returns>
        public bool Contains(string item)
        {
            Param.RequireNotNull(item, "item");

            return this.collection.Contains(item);
        }

        /// <summary>
        /// Copies values from the list to the given array.
        /// </summary>
        /// <param name="array">
        /// The array to copy the items into.
        /// </param>
        /// <param name="arrayIndex">
        /// The index within the array to begin copying.
        /// </param>
        public void CopyTo(string[] array, int arrayIndex)
        {
            Param.Ignore(array, arrayIndex);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets an enumerator for iterating through the values in the property collection.
        /// </summary>
        /// <returns>Returns the enumerator.</returns>
        public IEnumerator<string> GetEnumerator()
        {
            return this.collection.GetEnumerator();
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

            CollectionProperty parentCollectionProperty = parentProperty as CollectionProperty;
            if (parentCollectionProperty == null || this.Aggregate != parentCollectionProperty.Aggregate)
            {
                throw new ArgumentException(Strings.ComparingDifferentPropertyTypes, "parentProperty");
            }

            return OverridesPropertyCollection(this.collection, parentCollectionProperty.Values, this.Aggregate);
        }

        /// <summary>
        /// Removes the given value from the property list.
        /// </summary>
        /// <param name="item">
        /// The value to remove.
        /// </param>
        /// <returns>
        /// Returns true if the value was removed from the property collection, or
        /// false if it did not exist in the collection.
        /// </returns>
        public bool Remove(string item)
        {
            Param.RequireNotNull(item, "item");

            if (this.IsReadOnly)
            {
                throw new StyleCopException(Strings.ReadOnlyProperty);
            }

            return this.collection.Remove(item);
        }

        #endregion

        #region Explicit Interface Methods

        /// <summary>
        /// Gets an enumerator for iterating through the values in the property collection.
        /// </summary>
        /// <returns>Returns the enumerator.</returns>
        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Determines whether the local values overrides the parent values.
        /// </summary>
        /// <param name="localValues">
        /// The local values.
        /// </param>
        /// <param name="parentValues">
        /// The parent values.
        /// </param>
        /// <param name="aggregate">
        /// Indicates whether the collection is an aggregate collection.
        /// </param>
        /// <returns>
        /// Returns true if the local values overrides the parent values.
        /// </returns>
        private static bool OverridesPropertyCollection(ICollection<string> localValues, ICollection<string> parentValues, bool aggregate)
        {
            Param.Ignore(localValues);
            Param.Ignore(parentValues);
            Param.Ignore(aggregate);

            // If there are no local values, then the local values to not override the parent values.
            if (localValues == null || localValues.Count == 0)
            {
                return false;
            }

            // If there are no parent values, then the local values override since there is at least one local value.
            if (parentValues == null || parentValues.Count == 0)
            {
                return true;
            }

            // Check each local property to see if there is at least one that overrides a parent property.
            foreach (string value in localValues)
            {
                // Determine whether this property exists in the parent property collection.
                if (!parentValues.Contains(value))
                {
                    // This property does not exist in the parent property collection, so the local setting is being added.
                    return true;
                }
            }

            // If this is not an aggregate collection, then the local setting can also override the parent
            // setting if there is a property in the parent settings which is not present in the local settings.
            if (!aggregate)
            {
                foreach (string value in parentValues)
                {
                    if (!localValues.Contains(value))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        #endregion
    }
}