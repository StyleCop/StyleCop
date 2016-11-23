// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyDescriptorCollection.cs" company="https://github.com/StyleCop">
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
//   Contains a collection of property descriptors.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Xml;

    /// <summary>
    /// Contains a collection of property descriptors.
    /// </summary>
    public class PropertyDescriptorCollection : ICollection<PropertyDescriptor>
    {
        #region Fields

        /// <summary>
        /// The properties.
        /// </summary>
        private Dictionary<string, PropertyDescriptor> propertyDescriptors;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the PropertyDescriptorCollection class.
        /// </summary>
        internal PropertyDescriptorCollection()
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the number of property descriptors in the collection.
        /// </summary>
        public int Count
        {
            get
            {
                return this.propertyDescriptors.Count;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the collection is read-only.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets the collection of property descriptors.
        /// </summary>
        public ICollection<PropertyDescriptor> PropertyDescriptors
        {
            get
            {
                return this.propertyDescriptors.Values;
            }
        }

        /// <summary>
        /// Gets the collection of property names.
        /// </summary>
        public ICollection<string> PropertyNames
        {
            get
            {
                return this.propertyDescriptors.Keys;
            }
        }

        #endregion

        #region Public Indexers

        /// <summary>
        /// Gets the property descriptor for the given property name.
        /// </summary>
        /// <param name="propertyName">
        /// The name of the property.
        /// </param>
        /// <returns>
        /// Returns the property descriptor or null if there is no property with the given name.
        /// </returns>
        public PropertyDescriptor this[string propertyName]
        {
            get
            {
                Param.Ignore(propertyName);
                return this.GetPropertyDescriptor(propertyName);
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Adds a property descriptor to the collection.
        /// </summary>
        /// <param name="property">
        /// The property descriptor to add.
        /// </param>
        [SuppressMessage("Microsoft.Naming", "CA1725:ParameterNamesShouldMatchBaseDeclaration", MessageId = "0#", 
            Justification = "'Property' is a more appropriate name than 'item' for a property.")]
        public void Add(PropertyDescriptor property)
        {
            Param.Ignore(property);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Clears the collection.
        /// </summary>
        public void Clear()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether the given property descriptor is contained in the collection.
        /// </summary>
        /// <param name="item">
        /// The property descriptor to search for.
        /// </param>
        /// <returns>
        /// Returns true if the property descriptor is contained within the collection.
        /// </returns>
        public bool Contains(PropertyDescriptor item)
        {
            Param.RequireNotNull(item, "item");
            return this.propertyDescriptors.ContainsKey(item.PropertyName);
        }

        /// <summary>
        /// Determines whether the given property descriptor is contained in the collection.
        /// </summary>
        /// <param name="propertyName">
        /// The property name to search for.
        /// </param>
        /// <returns>
        /// Returns true if the property descriptor is contained within the collection.
        /// </returns>
        public bool Contains(string propertyName)
        {
            Param.RequireValidString(propertyName, "propertyName");
            return this.propertyDescriptors.ContainsKey(propertyName);
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
        public void CopyTo(PropertyDescriptor[] array, int arrayIndex)
        {
            Param.Ignore(array, arrayIndex);

            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets an enumerator for iterating through the values in the property descriptor collection.
        /// </summary>
        /// <returns>Returns the enumerator.</returns>
        public IEnumerator<PropertyDescriptor> GetEnumerator()
        {
            return this.propertyDescriptors.Values.GetEnumerator();
        }

        /// <summary>
        /// Gets the property descriptor for the given property.
        /// </summary>
        /// <param name="propertyName">
        /// The name of the property.
        /// </param>
        /// <returns>
        /// Returns the property descriptor for the given property, or null if the property 
        /// is not contained within the collection.
        /// </returns>
        public PropertyDescriptor GetPropertyDescriptor(string propertyName)
        {
            Param.RequireValidString(propertyName, "propertyName");

            PropertyDescriptor propertyDescriptor = null;
            if (this.propertyDescriptors.TryGetValue(propertyName, out propertyDescriptor))
            {
                return propertyDescriptor;
            }

            return null;
        }

        /// <summary>
        /// Removes the given property descriptor from the collection.
        /// </summary>
        /// <param name="property">
        /// The property descriptor to remove.
        /// </param>
        /// <returns>
        /// Returns true if the property descriptor was removed from the collection, or
        /// false if it did not exist in the collection.
        /// </returns>
        [SuppressMessage("Microsoft.Naming", "CA1725:ParameterNamesShouldMatchBaseDeclaration", MessageId = "0#", 
            Justification = "'Property' is a more appropriate name than 'item' for a property.")]
        public bool Remove(PropertyDescriptor property)
        {
            Param.Ignore(property);
            throw new NotImplementedException();
        }

        #endregion

        #region Explicit Interface Methods

        /// <summary>
        /// Gets an enumerator for iterating through the values in the property descriptor collection.
        /// </summary>
        /// <returns>Returns the enumerator.</returns>
        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds the given descriptor to the collection.
        /// </summary>
        /// <param name="descriptor">
        /// The descriptor to add.
        /// </param>
        internal void AddPropertyDescriptor(PropertyDescriptor descriptor)
        {
            Param.AssertNotNull(descriptor, "descriptor");

            if (this.propertyDescriptors == null)
            {
                this.propertyDescriptors = new Dictionary<string, PropertyDescriptor>();
            }

            this.propertyDescriptors.Add(descriptor.PropertyName, descriptor);
        }

        /// <summary>
        /// Initializes the contents of the collection from the given Xml.
        /// </summary>
        /// <param name="propertiesNode">
        /// The properties Xml node.
        /// </param>
        internal void InitializeFromXml(XmlNode propertiesNode)
        {
            Param.AssertNotNull(propertiesNode, "propertiesNode");

            if (propertiesNode.ChildNodes == null || propertiesNode.ChildNodes.Count == 0)
            {
                this.propertyDescriptors = new Dictionary<string, PropertyDescriptor>(0);
            }
            else
            {
                if (this.propertyDescriptors == null)
                {
                    this.propertyDescriptors = new Dictionary<string, PropertyDescriptor>(propertiesNode.ChildNodes.Count);
                }

                foreach (XmlNode propertyNode in propertiesNode.ChildNodes)
                {
                    switch (propertyNode.Name)
                    {
                        case "BooleanProperty":
                            this.AddBooleanPropertyDescriptor(propertyNode);
                            break;

                        case "IntegerProperty":
                            this.AddIntPropertyDescriptor(propertyNode);
                            break;

                        case "StringProperty":
                            this.AddStringPropertyDescriptor(propertyNode);
                            break;

                        case "CollectionProperty":
                            this.AddCollectionPropertyDescriptor(propertyNode);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Extracts and returns the property description from the given node.
        /// </summary>
        /// <param name="propertyNode">
        /// The property node.
        /// </param>
        /// <returns>
        /// Returns the property description.
        /// </returns>
        private static string ExtractDescription(XmlNode propertyNode)
        {
            Param.AssertNotNull(propertyNode, "propertyNode");

            XmlAttribute descriptionAttribute = propertyNode.Attributes["Description"];
            if (descriptionAttribute == null || string.IsNullOrEmpty(descriptionAttribute.Value))
            {
                throw new ArgumentException(Strings.PropertyHasNoDescription);
            }

            return descriptionAttribute.Value;
        }

        /// <summary>
        /// Extracts and returns the display settings value from the given node.
        /// </summary>
        /// <param name="propertyNode">
        /// The property node.
        /// </param>
        /// <returns>
        /// Returns the display settings value.
        /// </returns>
        private static bool ExtractDisplaySettings(XmlNode propertyNode)
        {
            Param.AssertNotNull(propertyNode, "propertyNode");

            XmlAttribute displaySettingsAttribute = propertyNode.Attributes["DisplaySettings"];
            if (displaySettingsAttribute == null || string.IsNullOrEmpty(displaySettingsAttribute.Value))
            {
                return true;
            }

            return bool.Parse(displaySettingsAttribute.Value);
        }

        /// <summary>
        /// Extracts and returns the property friendly name from the given node.
        /// </summary>
        /// <param name="propertyNode">
        /// The property node.
        /// </param>
        /// <returns>
        /// Returns the property friendly name.
        /// </returns>
        private static string ExtractFriendlyName(XmlNode propertyNode)
        {
            Param.AssertNotNull(propertyNode, "propertyNode");

            XmlAttribute friendlyNameAttribute = propertyNode.Attributes["FriendlyName"];
            if (friendlyNameAttribute == null || string.IsNullOrEmpty(friendlyNameAttribute.Value))
            {
                throw new ArgumentException(Strings.PropertyHasNoFriendlyName);
            }

            return friendlyNameAttribute.Value;
        }

        /// <summary>
        /// Extracts and returns the merge value from the given node.
        /// </summary>
        /// <param name="propertyNode">
        /// The property node.
        /// </param>
        /// <returns>
        /// Returns the merge value.
        /// </returns>
        private static bool ExtractMerge(XmlNode propertyNode)
        {
            Param.AssertNotNull(propertyNode, "propertyNode");

            XmlAttribute mergeAttribute = propertyNode.Attributes["Merge"];
            if (mergeAttribute == null || string.IsNullOrEmpty(mergeAttribute.Value))
            {
                return true;
            }

            return bool.Parse(mergeAttribute.Value);
        }

        /// <summary>
        /// Extracts and returns the property name from the given node.
        /// </summary>
        /// <param name="propertyNode">
        /// The property node.
        /// </param>
        /// <returns>
        /// Returns the property name.
        /// </returns>
        private static string ExtractPropertyName(XmlNode propertyNode)
        {
            Param.AssertNotNull(propertyNode, "propertyNode");

            XmlAttribute propertyNameAttribute = propertyNode.Attributes["Name"];
            if (propertyNameAttribute == null || string.IsNullOrEmpty(propertyNameAttribute.Value))
            {
                throw new ArgumentException(Strings.PropertyHasNoName);
            }

            return propertyNameAttribute.Value;
        }

        /// <summary>
        /// Adds a boolean property descriptor from the given Xml node.
        /// </summary>
        /// <param name="propertyNode">
        /// The node containing the property descriptor information.
        /// </param>
        private void AddBooleanPropertyDescriptor(XmlNode propertyNode)
        {
            Param.AssertNotNull(propertyNode, "propertyNode");

            // Get the default value attibute.
            XmlAttribute defaultValueNode = propertyNode.Attributes["DefaultValue"];
            if (defaultValueNode == null || string.IsNullOrEmpty(defaultValueNode.Value))
            {
                throw new ArgumentException(Strings.PropertyDescriptorHasNoDefaultValue);
            }

            // Convert this to a boolean value.
            bool defaultValue = bool.Parse(defaultValueNode.Value);

            // Get the name of the property.
            string propertyName = ExtractPropertyName(propertyNode);

            // Create the property descriptor and add it.
            PropertyDescriptor<bool> propertyDescriptor = new PropertyDescriptor<bool>(
                propertyName, 
                PropertyType.Boolean, 
                ExtractFriendlyName(propertyNode), 
                ExtractDescription(propertyNode), 
                ExtractMerge(propertyNode), 
                ExtractDisplaySettings(propertyNode), 
                defaultValue);

            this.propertyDescriptors.Add(propertyName, propertyDescriptor);
        }

        /// <summary>
        /// Adds a collection property descriptor from the given Xml node.
        /// </summary>
        /// <param name="propertyNode">
        /// The node containing the property descriptor information.
        /// </param>
        private void AddCollectionPropertyDescriptor(XmlNode propertyNode)
        {
            Param.AssertNotNull(propertyNode, "propertyNode");

            bool aggregate = false;
            XmlAttribute aggregateNode = propertyNode.Attributes["Aggregate"];
            if (aggregateNode != null)
            {
                aggregate = bool.Parse(aggregateNode.Value);
            }

            // Get the name of the property.
            string propertyName = ExtractPropertyName(propertyNode);

            // Create the property descriptor and add it.
            CollectionPropertyDescriptor propertyDescriptor = new CollectionPropertyDescriptor(
                propertyName, ExtractFriendlyName(propertyNode), ExtractDescription(propertyNode), ExtractMerge(propertyNode), aggregate);

            this.propertyDescriptors.Add(propertyName, propertyDescriptor);
        }

        /// <summary>
        /// Adds an integer property descriptor from the given Xml node.
        /// </summary>
        /// <param name="propertyNode">
        /// The node containing the property descriptor information.
        /// </param>
        private void AddIntPropertyDescriptor(XmlNode propertyNode)
        {
            Param.AssertNotNull(propertyNode, "propertyNode");

            // Get the default value attibute.
            XmlAttribute defaultValueNode = propertyNode.Attributes["DefaultValue"];
            if (defaultValueNode == null || string.IsNullOrEmpty(defaultValueNode.Value))
            {
                throw new ArgumentException(Strings.PropertyDescriptorHasNoDefaultValue);
            }

            // Convert this to an integer value.
            int defaultValue = int.Parse(defaultValueNode.Value, CultureInfo.InvariantCulture);

            // Get the name of the property.
            string propertyName = ExtractPropertyName(propertyNode);

            // Create the property descriptor and add it.
            PropertyDescriptor<int> propertyDescriptor = new PropertyDescriptor<int>(
                propertyName, 
                PropertyType.Int, 
                ExtractFriendlyName(propertyNode), 
                ExtractDescription(propertyNode), 
                ExtractMerge(propertyNode), 
                ExtractDisplaySettings(propertyNode), 
                defaultValue);

            this.propertyDescriptors.Add(propertyName, propertyDescriptor);
        }

        /// <summary>
        /// Adds a string property descriptor from the given Xml node.
        /// </summary>
        /// <param name="propertyNode">
        /// The node containing the property descriptor information.
        /// </param>
        private void AddStringPropertyDescriptor(XmlNode propertyNode)
        {
            Param.AssertNotNull(propertyNode, "propertyNode");

            // Get the default value attibute.
            XmlAttribute defaultValueNode = propertyNode.Attributes["DefaultValue"];
            if (defaultValueNode == null || defaultValueNode.Value == null)
            {
                throw new ArgumentException(Strings.PropertyDescriptorHasNoDefaultValue);
            }

            // Get the name of the property.
            string propertyName = ExtractPropertyName(propertyNode);

            // Create the property descriptor and add it.
            PropertyDescriptor<string> propertyDescriptor = new PropertyDescriptor<string>(
                propertyName, 
                PropertyType.String, 
                ExtractFriendlyName(propertyNode), 
                ExtractDescription(propertyNode), 
                ExtractMerge(propertyNode), 
                ExtractDisplaySettings(propertyNode), 
                defaultValueNode.Value);

            this.propertyDescriptors.Add(propertyName, propertyDescriptor);
        }

        #endregion
    }
}