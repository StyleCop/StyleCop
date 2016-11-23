// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyCollection.cs" company="https://github.com/StyleCop">
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
//   Contains a collection of properties.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Contains a collection of properties.
    /// </summary>
    public class PropertyCollection : ICollection<PropertyValue>
    {
        #region Fields

        /// <summary>
        /// The properties.
        /// </summary>
        private readonly Dictionary<string, PropertyValue> properties = new Dictionary<string, PropertyValue>();

        /// <summary>
        /// Indicates whether the collection is read-only.
        /// </summary>
        private bool readOnly;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the PropertyCollection class.
        /// </summary>
        internal PropertyCollection()
        {
            this.properties = new Dictionary<string, PropertyValue>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the number of properties in the collection.
        /// </summary>
        public int Count
        {
            get
            {
                return this.properties.Count;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the collection is read-only.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return this.readOnly;
            }

            internal set
            {
                if (this.readOnly != value)
                {
                    this.readOnly = value;

                    foreach (PropertyValue property in this.properties.Values)
                    {
                        property.IsReadOnly = value;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the collection of properties.
        /// </summary>
        public ICollection<PropertyValue> Properties
        {
            get
            {
                return this.properties.Values;
            }
        }

        #endregion

        #region Public Indexers

        /// <summary>
        /// Gets the property with the given name.
        /// </summary>
        /// <param name="propertyName">
        /// The name of the property.
        /// </param>
        /// <returns>
        /// Returns the property or null if there is no property with the given name.
        /// </returns>
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "propertyName", 
            Justification = "The set accessor does not use the propertyName parameter since the name of the property is built-in to the PropertyValue object.")]
        public PropertyValue this[string propertyName]
        {
            get
            {
                Param.Ignore(propertyName);
                return this.GetProperty(propertyName);
            }

            set
            {
                Param.Ignore(propertyName);
                Param.Ignore(value);
                this.SetProperty(value);
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Adds a property to the collection.
        /// </summary>
        /// <param name="property">
        /// The property to add.
        /// </param>
        [SuppressMessage("Microsoft.Naming", "CA1725:ParameterNamesShouldMatchBaseDeclaration", MessageId = "0#", 
            Justification = "'Property' is a more appropriate name than 'item' for a property.")]
        public void Add(PropertyValue property)
        {
            Param.RequireNotNull(property, "property");
            this.SetProperty(property);
        }

        /// <summary>
        /// Clears the list of property values.
        /// </summary>
        public void Clear()
        {
            if (this.readOnly)
            {
                throw new StyleCopException(Strings.ReadOnlyProperty);
            }

            this.properties.Clear();
        }

        /// <summary>
        /// Clones the contents of the collection.
        /// </summary>
        /// <returns>Returns the cloned collection.</returns>
        public virtual PropertyCollection Clone()
        {
            PropertyCollection clone = new PropertyCollection();
            foreach (KeyValuePair<string, PropertyValue> item in this.properties)
            {
                clone.Add(item.Value.Clone());
            }

            return clone;
        }

        /// <summary>
        /// Determines whether the given property is contained in the collection.
        /// </summary>
        /// <param name="property">
        /// The property to search for.
        /// </param>
        /// <returns>
        /// Returns true if the property is contained within the collection.
        /// </returns>
        [SuppressMessage("Microsoft.Naming", "CA1725:ParameterNamesShouldMatchBaseDeclaration", MessageId = "0#", 
            Justification = "'Property' is a more appropriate name than 'item' for a property.")]
        public bool Contains(PropertyValue property)
        {
            Param.RequireNotNull(property, "property");
            return this.properties.ContainsKey(property.PropertyName);
        }

        /// <summary>
        /// Determines whether the given property is contained in the collection.
        /// </summary>
        /// <param name="propertyName">
        /// The name of the property to search for.
        /// </param>
        /// <returns>
        /// Returns true if the property is contained within the collection.
        /// </returns>
        public bool Contains(string propertyName)
        {
            Param.RequireValidString(propertyName, "propertyName");
            return this.properties.ContainsKey(propertyName);
        }

        /// <summary>
        /// Copies values from the collection to the given array.
        /// </summary>
        /// <param name="array">
        /// The array to copy the items into.
        /// </param>
        /// <param name="arrayIndex">
        /// The index within the array to begin copying.
        /// </param>
        public void CopyTo(PropertyValue[] array, int arrayIndex)
        {
            Param.Ignore(array, arrayIndex);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets an enumerator for iterating through the values in the property collection.
        /// </summary>
        /// <returns>Returns the enumerator.</returns>
        public IEnumerator<PropertyValue> GetEnumerator()
        {
            return this.properties.Values.GetEnumerator();
        }

        /// <summary>
        /// Gets the property values collection for the given property.
        /// </summary>
        /// <param name="propertyName">
        /// The name of the property.
        /// </param>
        /// <returns>
        /// Returns the values collection for the property or null if the property is not contained within the collection.
        /// </returns>
        public PropertyValue GetProperty(string propertyName)
        {
            Param.RequireValidString(propertyName, "propertyName");

            PropertyValue property = null;
            if (this.properties.TryGetValue(propertyName, out property))
            {
                return property;
            }

            return null;
        }

        /// <summary>
        /// Removes the given property from the collection.
        /// </summary>
        /// <param name="property">
        /// The property to remove.
        /// </param>
        /// <returns>
        /// Returns true if the property was removed from the property collection, or
        /// false if it did not exist in the collection.
        /// </returns>
        [SuppressMessage("Microsoft.Naming", "CA1725:ParameterNamesShouldMatchBaseDeclaration", MessageId = "0#", 
            Justification = "'Property' is a more appropriate name than 'item' for a property.")]
        public bool Remove(PropertyValue property)
        {
            Param.RequireNotNull(property, "property");

            if (this.readOnly)
            {
                throw new StyleCopException(Strings.ReadOnlyProperty);
            }

            return this.properties.Remove(property.PropertyName);
        }

        /// <summary>
        /// Removes the given property from the collection.
        /// </summary>
        /// <param name="propertyName">
        /// The name of the property to remove.
        /// </param>
        /// <returns>
        /// Returns true if the property was removed from the property collection, or
        /// false if it did not exist in the collection.
        /// </returns>
        public bool Remove(string propertyName)
        {
            Param.RequireValidString(propertyName, "propertyName");

            if (this.readOnly)
            {
                throw new StyleCopException(Strings.ReadOnlyProperty);
            }

            return this.properties.Remove(propertyName);
        }

        /// <summary>
        /// Sets the given property.
        /// </summary>
        /// <param name="property">
        /// The property to set.
        /// </param>
        public void SetProperty(PropertyValue property)
        {
            Param.RequireNotNull(property, "property");

            if (this.readOnly)
            {
                throw new StyleCopException(Strings.ReadOnlyProperty);
            }

            if (this.properties.ContainsKey(property.PropertyName))
            {
                this.properties[property.PropertyName] = property;
            }
            else
            {
                this.properties.Add(property.PropertyName, property);
            }
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
    }
}