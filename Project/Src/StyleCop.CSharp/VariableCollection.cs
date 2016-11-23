// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VariableCollection.cs" company="https://github.com/StyleCop">
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
//   A collection of variables for an element or code scope.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// A collection of variables for an element or code scope.
    /// </summary>
    public sealed class VariableCollection : ICollection<Variable>
    {
        #region Static Fields

        /// <summary>
        /// An empty array of variables.
        /// </summary>
        private static readonly Variable[] EmptyVariableArray = new Variable[0];

        /// <summary>
        /// Adapts the enumerator for the empty variable array to a generic type enumerator.
        /// </summary>
        private static LegacyEnumeratorAdapter<Variable> emptyVariableArrayEnumerator;

        #endregion

        #region Fields

        /// <summary>
        /// The variable collection.
        /// </summary>
        private Dictionary<string, Variable> variables;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the VariableCollection class.
        /// </summary>
        internal VariableCollection()
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the number of variables in the collection.
        /// </summary>
        public int Count
        {
            get
            {
                if (this.variables == null)
                {
                    return 0;
                }

                return this.variables.Count;
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

        #endregion

        #region Public Indexers

        /// <summary>
        /// Gets the variable with the given name.
        /// </summary>
        /// <param name="name">
        /// The name of the variable to get.
        /// </param>
        /// <returns>
        /// Returns the variable.
        /// </returns>
        public Variable this[string name]
        {
            get
            {
                return this.GetVariable(name);
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Determines whether a variable with the given name is contained within the collection.
        /// </summary>
        /// <param name="name">
        /// The name of the variable.
        /// </param>
        /// <returns>
        /// Returns true if the item is contained within the collection.
        /// </returns>
        public bool Contains(string name)
        {
            Param.RequireNotNull(name, "name");

            if (this.variables == null)
            {
                return false;
            }

            return this.variables.ContainsKey(name);
        }

        /// <summary>
        /// Copies the variable to the given array.
        /// </summary>
        /// <param name="array">
        /// The array to copy the variables into.
        /// </param>
        /// <param name="arrayIndex">
        /// The index in the array at which to begin copying.
        /// </param>
        public void CopyTo(Variable[] array, int arrayIndex)
        {
            Param.RequireNotNull(array, "array");
            Param.RequireGreaterThanOrEqualToZero(arrayIndex, "arrayIndex");

            if (this.variables != null)
            {
                int i = arrayIndex;
                foreach (Variable variable in this.variables.Values)
                {
                    array[i++] = variable;
                }
            }
        }

        /// <summary>
        /// Gets an enumerator for iterating through the variables in the collection.
        /// </summary>
        /// <returns>Returns the enumerator.</returns>
        public IEnumerator<Variable> GetEnumerator()
        {
            if (this.variables == null)
            {
                if (emptyVariableArrayEnumerator == null)
                {
                    emptyVariableArrayEnumerator = new LegacyEnumeratorAdapter<Variable>(EmptyVariableArray.GetEnumerator());
                }

                return emptyVariableArrayEnumerator;
            }

            return this.variables.Values.GetEnumerator();
        }

        /// <summary>
        /// Gets the variable with the given name.
        /// </summary>
        /// <param name="name">
        /// The name of the variable to get.
        /// </param>
        /// <returns>
        /// Returns the variable.
        /// </returns>
        public Variable GetVariable(string name)
        {
            Param.RequireValidString(name, "name");

            if (this.variables != null)
            {
                Variable variable;
                if (this.variables.TryGetValue(name, out variable))
                {
                    return variable;
                }
            }

            return null;
        }

        #endregion

        #region Explicit Interface Methods

        /// <summary>
        /// Adds the given variable.
        /// </summary>
        /// <param name="variable">
        /// The variable to add.
        /// </param>
        /// <remarks>
        /// This method is not supported.
        /// </remarks>
        void ICollection<Variable>.Add(Variable variable)
        {
            Param.Ignore(variable);
            throw new NotSupportedException();
        }

        /// <summary>
        /// Clears the contents of the collection.
        /// </summary>
        /// <remarks>This method is not supported.</remarks>
        void ICollection<Variable>.Clear()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Determines whether the given variable is contained within the collection.
        /// </summary>
        /// <param name="variable">
        /// The variable.
        /// </param>
        /// <returns>
        /// Returns true if the item is contained within the collection.
        /// </returns>
        /// <remarks>
        /// This method is not supported.
        /// </remarks>
        bool ICollection<Variable>.Contains(Variable variable)
        {
            Param.Ignore(variable);
            throw new NotSupportedException();
        }

        /// <summary>
        /// Gets an enumerator for iterating through the variables in the collection.
        /// </summary>
        /// <returns>Gets the enumerator.</returns>
        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            if (this.variables == null)
            {
                return EmptyVariableArray.GetEnumerator();
            }

            return this.variables.Values.GetEnumerator();
        }

        /// <summary>
        /// Removes the given variable.
        /// </summary>
        /// <param name="variable">
        /// The variable to remove.
        /// </param>
        /// <returns>
        /// Returns true if the item was removed from the collection.
        /// </returns>
        /// <remarks>
        /// This method is not supported.
        /// </remarks>
        bool ICollection<Variable>.Remove(Variable variable)
        {
            Param.Ignore(variable);
            throw new NotSupportedException();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a variable to the collection.
        /// </summary>
        /// <param name="variable">
        /// The variable to add.
        /// </param>
        internal void Add(Variable variable)
        {
            Param.AssertNotNull(variable, "variable");

            if (this.variables == null)
            {
                this.variables = new Dictionary<string, Variable>();
            }

            if (!this.variables.ContainsKey(variable.Name))
            {
                this.variables.Add(variable.Name, variable);
            }
        }

        /// <summary>
        /// Adds a range of variables to the collection.
        /// </summary>
        /// <param name="items">
        /// The variables to add.
        /// </param>
        internal void AddRange(IEnumerable<Variable> items)
        {
            Param.AssertNotNull(items, "items");

            foreach (Variable variable in items)
            {
                this.Add(variable);
            }
        }

        #endregion
    }
}