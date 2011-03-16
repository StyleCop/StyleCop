//-----------------------------------------------------------------------
// <copyright file="VariableCollection.cs">
//     MS-PL
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
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Represents a collection of variables.
    /// </summary>
    public partial class VariableCollection
    {
        /// <summary>
        /// The variables in the collection.
        /// </summary>
        private ConcurrentDictionary<string, IVariable> variables = new ConcurrentDictionary<string, IVariable>();

        /// <summary>
        /// Initializes a new instance of the VariableCollection class.
        /// </summary>
        internal VariableCollection()
        {
        }

        /// <summary>
        /// Gets the number of variables in the collection.
        /// </summary>
        public int Count
        {
            get
            {
                return this.variables.Count;
            }
        }

        /// <summary>
        /// Gets or sets the variable with the specified name.
        /// </summary>
        /// <param name="name">The name of the variable.</param>
        /// <returns>Returns the variable with the specified name or null if none exists.</returns>
        public IVariable this[string name]
        {
            get
            {
                IVariable value;
                if (this.variables.TryGetValue(name, out value))
                {
                    return value;
                }

                return null;
            }
        }

        /// <summary>
        /// Determines whether the collection contains a variable with the given name.
        /// </summary>
        /// <param name="name">The name of the variable to discover.</param>
        /// <returns>Returns true if the variable is contained within the collection; false otherwise.</returns>
        public bool ContainsVariable(string name)
        {
            Param.Ignore(name);
            return this.variables.ContainsKey(name);
        }

        /// <summary>
        /// Returns an enumerator for the collection.
        /// </summary>
        /// <returns>Returns the enumerator.</returns>
        public IEnumerator<IVariable> GetEnumerator()
        {
            return this.variables.Values.GetEnumerator();
        }

        /// <summary>
        /// Adds a new variable to the collection.
        /// </summary>
        /// <param name="variable">The variable to add.</param>
        internal void Add(IVariable variable)
        {
            Param.AssertNotNull(variable, "variable");
            this.variables.AddOrUpdate(variable.VariableName, variable, (s, v) => { return v; });
        }

        /// <summary>
        /// Adds a range of variables to the collection.
        /// </summary>
        /// <param name="variables">The variables to add.</param>
        internal void AddRange(IEnumerable<IVariable> variables)
        {
            Param.Ignore(variables);

            if (variables != null)
            {
                foreach (IVariable v in variables)
                {
                    this.Add(v);
                }
            }
        }
    }

    /// <content>
    /// Implements the ICollection interface.
    /// </content>
    public partial class VariableCollection : ICollection<IVariable>
    {
        /// <summary>
        /// Gets the number of elements contained in the.
        /// </summary>
        int ICollection<IVariable>.Count
        {
            get
            {
                return this.variables.Count;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the collection is read-only.
        /// </summary>
        bool ICollection<IVariable>.IsReadOnly
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Adds an item to the collection.
        /// </summary>
        /// <param name="item">The item to add.</param>
        void ICollection<IVariable>.Add(IVariable item)
        {
            Param.Ignore(item);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes all items from the collection.
        /// </summary>
        void ICollection<IVariable>.Clear()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether the collection contains a specific value.
        /// </summary>
        /// <param name="item">The value to locate in the collection.</param>
        /// <returns>Returns true if the item was found; false otherwise.</returns>
        bool ICollection<IVariable>.Contains(IVariable item)
        {
            Param.Ignore(item);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Copies the elements of the collection to an array.
        /// </summary>
        /// <param name="array">The array to copy into.</param>
        /// <param name="arrayIndex">The start index.</param>
        void ICollection<IVariable>.CopyTo(IVariable[] array, int arrayIndex)
        {
            Param.Ignore(array, arrayIndex);

            foreach (IVariable variable in this.variables.Values)
            {
                array[arrayIndex++] = variable;
            }
        }

        /// <summary>
        /// Removes an item from the collection.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        /// <returns>Returns true if the item was removed; false otherwise.</returns>
        bool ICollection<IVariable>.Remove(IVariable item)
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
            return this.variables.Values.GetEnumerator();
        }
    }
}
