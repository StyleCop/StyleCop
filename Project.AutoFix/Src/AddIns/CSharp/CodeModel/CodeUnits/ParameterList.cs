//-----------------------------------------------------------------------
// <copyright file="ParameterList.cs">
//   MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
//-----------------------------------------------------------------------
namespace StyleCop.CSharp.CodeModel
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    /// <summary>
    /// Describes a formal parameter list within a method, constructor, or indexer declaration.
    /// </summary>
    /// <subcategory>token</subcategory>
    public sealed partial class ParameterList : CodeUnit, IList<Parameter>
    {
        /// <summary>
        /// The collection of parameters in the list.
        /// </summary>
        private CodeUnitProperty<IList<Parameter>> parameters;

        /// <summary>
        /// Initializes a new instance of the ParameterList class.
        /// </summary>
        /// <param name="proxy">The proxy class.</param>
        internal ParameterList(CodeUnitProxy proxy)
            : base(proxy, CodeUnitType.ParameterList)
        {
            Param.AssertNotNull(proxy, "proxy");
        }

        /// <summary>
        /// Gets the collection of parameters within the list.
        /// </summary>
        public IList<Parameter> Parameters
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.parameters.Initialized)
                {
                    this.parameters.Value = new List<Parameter>(this.GetChildren<Parameter>()).AsReadOnly();
                }

                return this.parameters.Value;
            }
        }

        /// <summary>
        /// Gets the number of parameters in the list.
        /// </summary>
        public int Count
        {
            get
            {
                var p = this.Parameters;
                if (p != null)
                {
                    return p.Count;
                }

                return 0;
            }
        }

        /// <summary>
        /// Gets the parameter at the given index.
        /// </summary>
        /// <param name="index">The index of the parameter to retrieve.</param>
        /// <returns>Returns the parameter at the given index.</returns>
        public Parameter this[int index]
        {
            get
            {
                return this.Parameters[index];
            }
        }

        /// <summary>
        /// Returns an enumerator for the collection.
        /// </summary>
        /// <returns>Returns the enumerator.</returns>
        public IEnumerator<Parameter> GetEnumerator()
        {
            return this.Parameters.GetEnumerator();
        }

        /// <summary>
        /// Resets the contents of the item.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();
            this.parameters.Reset();
        }
    }

    /// <content>
    /// Implements the IList interface.
    /// </content>
    public partial class ParameterList : IList<Parameter>
    {
        /// <summary>
        /// Gets the number of items in the collection.
        /// </summary>
        int ICollection<Parameter>.Count 
        {
            get 
            { 
                return this.Parameters.Count; 
            }
        }

        /// <summary>
        /// Gets a value indicating whether the collection is read-only.
        /// </summary>
        bool ICollection<Parameter>.IsReadOnly 
        { 
            get 
            { 
                return true; 
            }
        }

        /// <summary>
        /// Gets or sets the elements at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>Returns the element.</returns>
        Parameter IList<Parameter>.this[int index]
        {
            get
            {
                return this.Parameters[index];
            }

            set
            {
                Param.Ignore(index, value);
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Determines the index of a specified item in the list.
        /// </summary>
        /// <param name="item">The item to locate.</param>
        /// <returns>Returns the index of the item.</returns>
        int IList<Parameter>.IndexOf(Parameter item)
        {
            Param.Ignore(item);
            return this.Parameters.IndexOf(item);
        }

        /// <summary>
        /// Inserts an item into the list.
        /// </summary>
        /// <param name="index">The index at which to insert the item.</param>
        /// <param name="item">The item to insert.</param>
        void IList<Parameter>.Insert(int index, Parameter item)
        {
            Param.Ignore(index, item);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes an item from the list.
        /// </summary>
        /// <param name="index">The index of the item to remove.</param>
        void IList<Parameter>.RemoveAt(int index)
        {
            Param.Ignore(index);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds an item to the collection.
        /// </summary>
        /// <param name="item">The item to add.</param>
        void ICollection<Parameter>.Add(Parameter item)
        {
            Param.Ignore(item);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes all items from the collection.
        /// </summary>
        void ICollection<Parameter>.Clear()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether the collection contains a specific value.
        /// </summary>
        /// <param name="item">The value to locate in the collection.</param>
        /// <returns>Returns true if the item was found; false otherwise.</returns>
        bool ICollection<Parameter>.Contains(Parameter item)
        {
            Param.Ignore(item);
            return this.Parameters.Contains(item);
        }

        /// <summary>
        /// Copies the elements of the collection to an array.
        /// </summary>
        /// <param name="array">The array to copy into.</param>
        /// <param name="arrayIndex">The start index.</param>
        void ICollection<Parameter>.CopyTo(Parameter[] array, int arrayIndex)
        {
            Param.Ignore(array, arrayIndex);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes an item from the collection.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        /// <returns>Returns true if the item was removed; false otherwise.</returns>
        bool ICollection<Parameter>.Remove(Parameter item)
        {
            Param.Ignore(item);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns an enumerator for the collection.
        /// </summary>
        /// <returns>Returns the enumerator.</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.Parameters.GetEnumerator();
        }
    }
}
