//-----------------------------------------------------------------------
// <copyright file="ArgumentList.cs">
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
    /// Describes an argument list within a method call.
    /// </summary>
    /// <subcategory>codeunit</subcategory>
    public sealed partial class ArgumentList : CodeUnit
    {
        /// <summary>
        /// The collection of arguments in the list.
        /// </summary>
        private CodeUnitProperty<IList<Argument>> arguments;

        /// <summary>
        /// Initializes a new instance of the ArgumentList class.
        /// </summary>
        /// <param name="proxy">The proxy class.</param>
        internal ArgumentList(CodeUnitProxy proxy)
            : base(proxy, CodeUnitType.ArgumentList)
        {
            Param.AssertNotNull(proxy, "proxy");
        }

        /// <summary>
        /// Initializes a new instance of the ArgumentList class.
        /// </summary>
        /// <param name="proxy">The proxy class.</param>
        /// <param name="arguments">The collection of arguments within the list.</param>
        internal ArgumentList(CodeUnitProxy proxy, IEnumerable<Argument> arguments)
            : base(proxy, CodeUnitType.ArgumentList)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(arguments, "arguments");

            this.arguments.Value = new List<Argument>(arguments);
        }

        /// <summary>
        /// Gets the collection of arguments within the list.
        /// </summary>
        public IList<Argument> Arguments
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.arguments.Initialized)
                {
                    this.arguments.Value = new List<Argument>(this.GetChildren<Argument>()).AsReadOnly();
                }

                return this.arguments.Value;
            }
        }

        /// <summary>
        /// Gets the number of arguments in the list.
        /// </summary>
        public int Count
        {
            get
            {
                var a = this.Arguments;
                if (a != null)
                {
                    return a.Count;
                }

                return 0;
            }
        }

        /// <summary>
        /// Gets the argument at the given index.
        /// </summary>
        /// <param name="index">The index of the argument to retrieve.</param>
        /// <returns>Returns the argument at the given index.</returns>
        public Argument this[int index]
        {
            get
            {
                return this.Arguments[index];
            }
        }

        /// <summary>
        /// Returns an enumerator for the collection.
        /// </summary>
        /// <returns>Returns the enumerator.</returns>
        public IEnumerator<Argument> GetEnumerator()
        {
            return this.Arguments.GetEnumerator();
        }

        /// <summary>
        /// Resets the contents of the item.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();
            this.arguments.Reset();
        }
    }

    /// <content>
    /// Implements the IList interface.
    /// </content>
    public partial class ArgumentList : IList<Argument>
    {
        /// <summary>
        /// Gets the number of items in the collection.
        /// </summary>
        int ICollection<Argument>.Count
        {
            get 
            { 
                return this.Arguments.Count; 
            }
        }

        /// <summary>
        /// Gets a value indicating whether the collection is read-only.
        /// </summary>
        bool ICollection<Argument>.IsReadOnly
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
        Argument IList<Argument>.this[int index]
        {
            get
            {
                return this.Arguments[index];
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
        int IList<Argument>.IndexOf(Argument item)
        {
            Param.Ignore(item);
            return this.Arguments.IndexOf(item);
        }

        /// <summary>
        /// Inserts an item into the list.
        /// </summary>
        /// <param name="index">The index at which to insert the item.</param>
        /// <param name="item">The item to insert.</param>
        void IList<Argument>.Insert(int index, Argument item)
        {
            Param.Ignore(index, item);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes an item from the list.
        /// </summary>
        /// <param name="index">The index of the item to remove.</param>
        void IList<Argument>.RemoveAt(int index)
        {
            Param.Ignore(index);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds an item to the collection.
        /// </summary>
        /// <param name="item">The item to add.</param>
        void ICollection<Argument>.Add(Argument item)
        {
            Param.Ignore(item);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes all items from the collection.
        /// </summary>
        void ICollection<Argument>.Clear()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether the collection contains a specific value.
        /// </summary>
        /// <param name="item">The value to locate in the collection.</param>
        /// <returns>Returns true if the item was found; false otherwise.</returns>
        bool ICollection<Argument>.Contains(Argument item)
        {
            Param.Ignore(item);
            return this.Arguments.Contains(item);
        }

        /// <summary>
        /// Copies the elements of the collection to an array.
        /// </summary>
        /// <param name="array">The array to copy into.</param>
        /// <param name="arrayIndex">The start index.</param>
        void ICollection<Argument>.CopyTo(Argument[] array, int arrayIndex)
        {
            Param.Ignore(array, arrayIndex);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes an item from the collection.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        /// <returns>Returns true if the item was removed; false otherwise.</returns>
        bool ICollection<Argument>.Remove(Argument item)
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
            return this.Arguments.GetEnumerator();
        }
    }
}
