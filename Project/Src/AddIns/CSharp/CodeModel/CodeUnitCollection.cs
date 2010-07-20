//-----------------------------------------------------------------------
// <copyright file="CodeUnitCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
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
//-----------------------------------------------------------------------
namespace Microsoft.StyleCop.CSharp.CodeModel
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.StyleCop.CSharp.CodeModel.Collections;

    /// <summary>
    /// A collection of code-units.
    /// </summary>
    public class CodeUnitCollection : ICollection<CodeUnit>
    {
        #region Private Fields

        /// <summary>
        /// The inner collection.
        /// </summary>
        private CodeUnitLinkedList items = null;

        /// <summary>
        /// The reference to the parent of the collection.
        /// </summary>
        ////private ICodeUnitReference parentReference;
        private CodeUnitProxy parentReference;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the CodeUnitCollection class.
        /// </summary>
        /// <param name="parentReference">The reference to the parent of the collection.</param>
        internal CodeUnitCollection(CodeUnitProxy parentReference)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            this.parentReference = parentReference;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the number of elements contained in the collection.
        /// </summary>
        public int Count 
        {
            get { return this.items == null ? 0 : this.items.Count; } 
        }

        /// <summary>
        /// Gets the number of lexical elements within the collection.
        /// </summary>
        public int LexicalElementCount
        {
            get { return this.items == null ? 0 : this.items.LexicalElementCount; }
        }

        /// <summary>
        /// Gets the number of expressions within the collection.
        /// </summary>
        public int ExpressionCount
        {
            get { return this.items == null ? 0 : this.items.ExpressionCount; }
        }

        /// <summary>
        /// Gets the number of statements within the collection.
        /// </summary>
        public int StatementCount
        {
            get { return this.items == null ? 0 : this.items.StatementCount; }
        }

        /// <summary>
        /// Gets the number of elements within the collection.
        /// </summary>
        public int ElementCount
        {
            get { return this.items == null ? 0 : this.items.ElementCount; }
        }

        /// <summary>
        /// Gets the number of queries within the collection.
        /// </summary>
        public int QueryClauseCount
        {
            get { return this.items == null ? 0 : this.items.QueryClauseCount; }
        }

        /// <summary>
        /// Gets a value indicating whether the collection is read-only.
        /// </summary>
        public bool IsReadOnly 
        {
            get { return true; }
        }

        /// <summary>
        /// Gets the first item in the collection.
        /// </summary>
        public CodeUnit First
        {
            get { return this.items == null ? null : this.items.First; }
        }

        /// <summary>
        /// Gets the last item in the collection.
        /// </summary>
        public CodeUnit Last
        {
            get { return this.items == null ? null : this.items.Last; }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Determines whether the collection contains a specific value.
        /// </summary>
        /// <param name="item">The item to locate in the collection.</param>
        /// <returns>Returns true if the item is found in the collection; otherwise false.</returns>
        public bool Contains(CodeUnit item)
        {
            Param.Ignore(item);

            return this.items == null ? false : this.items.Contains(item);
        }

        /// <summary>
        /// Copies the entire collection to the given array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The array that is the destination of the nodes copied from the collection.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(CodeUnit[] array, int arrayIndex)
        {
            Param.Ignore(array, arrayIndex);

            if (this.items != null)
            {
                this.items.CopyTo(array, arrayIndex);
            }
        }

        /// <summary>
        /// Gets an enumerator that iterates through the nodes in the collection.
        /// </summary>
        /// <returns>Returns an enumerator that iterates through the nodes in the collection.</returns>
        public IEnumerator<CodeUnit> GetEnumerator()
        {
            return this.items == null ? ((IEnumerable<CodeUnit>)CodeUnit.EmptyCodeUnitArray).GetEnumerator() : this.items.GetEnumerator();
        }

        /// <summary>
        /// Gets an enumerator that iterates through the nodes in the collection.
        /// </summary>
        /// <returns>Returns an enumerator that iterates through the nodes in the collection.</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.items == null ? CodeUnit.EmptyCodeUnitArray.GetEnumerator() : this.items.GetEnumerator();
        }

        /// <summary>
        /// Adds an item to the collection.
        /// </summary>
        /// <param name="item">The item to add to the collection.</param>
        [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Justification = "Does not need to be visible to derived classes.")]
        void ICollection<CodeUnit>.Add(CodeUnit item)
        {
            Param.Ignore(item);
            throw new NotSupportedException(Strings.CodeUnitCollectionIsReadOnly);
        }

        /// <summary>
        /// Removes all items from the collection.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Justification = "Does not need to be visible to derived classes.")]
        void ICollection<CodeUnit>.Clear()
        {
            throw new NotSupportedException(Strings.CodeUnitCollectionIsReadOnly);
        }

        /// <summary>
        /// Removes the given item from the list.
        /// </summary>
        /// <param name="item">The item to remove from the list.</param>
        /// <returns>Return true if the item was removed from the list.</returns>
        /// <remarks>This method is inefficient as it must iterate the list to find the node to remove.</remarks>
        [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Justification = "Does not need to be visible to derived classes.")]
        bool ICollection<CodeUnit>.Remove(CodeUnit item)
        {
            Param.Ignore(item);
            throw new NotSupportedException(Strings.CodeUnitCollectionIsReadOnly);
        }

        #endregion Public Methods

        #region Internal Methods

        /// <summary>
        /// Adds an item to the collection.
        /// </summary>
        /// <param name="item">The item to add to the collection.</param>
        internal void Add(CodeUnit item)
        {
            Param.Ignore(item);
            this.Add(item, true);
        }

        /// <summary>
        /// Adds an item to the collection.
        /// </summary>
        /// <param name="item">The item to add to the collection.</param>
        /// <param name="setParent">Indicates whether to set the item's parent to the parent of this collection.</param>
        internal void Add(CodeUnit item, bool setParent)
        {
            Param.AssertNotNull(item, "item");
            Param.Ignore(setParent);

            Debug.Assert(
                item.ParentReference == null, 
                "The code unit has already been added to a different collection and must be removed from the that collection before it can be added to this one.");

            if (this.items == null)
            {
                this.items = new CodeUnitLinkedList();
            }

            this.items.Add(item);

            if (setParent)
            {
                item.ParentReference = this.parentReference;
            }
        }

        /// <summary>
        /// Replaces the original item in the list with the new item.
        /// </summary>
        /// <param name="originalItem">The original item to remove and replace.</param>
        /// <param name="newItem">The new item to insert into the list.</param>
        internal void Replace(CodeUnit originalItem, CodeUnit newItem)
        {
            Param.AssertNotNull(originalItem, "originalItem");
            Param.AssertNotNull(newItem, "newItem");

            Debug.Assert(
                originalItem.ParentReference == this.parentReference,
                "The original item is not a member of this collection.");

            Debug.Assert(
                newItem.ParentReference == null,
                "The new item has already been added to a different collection and must be removed from the that collection before it can be added to this one.");

            if (this.items == null)
            {
                this.items = new CodeUnitLinkedList();
            }

            this.items.Replace(originalItem, newItem);

            originalItem.ParentReference = null;
            newItem.ParentReference = this.parentReference;
        }

        /*
        /// <summary>
        /// Removes all items from the collection.
        /// </summary>
        internal void Clear()
        {
            foreach (CodeUnit item in this.items)
            {
                item.ParentReference = null;
            }

            if (this.items == null)
            {
                this.items = new CodeUnitLinkedList();
            }
         
            this.items.Clear();
        }
        */

        /// <summary>
        /// Removes the given item from the list.
        /// </summary>
        /// <param name="item">The item to remove from the list.</param>
        /// <returns>Return true if the item was removed from the list.</returns>
        /// <remarks>This method is inefficient as it must iterate the list to find the node to remove.</remarks>
        internal bool Remove(CodeUnit item)
        {
            Param.AssertNotNull(item, "item");

            if (item.ParentReference != this.parentReference || this.items == null || !this.items.Remove(item))
            {
                Debug.Fail("The code unit is not a member of the collection.");
                return false;
            }

            item.ParentReference = null;

            return true;
        }

        /// <summary>
        /// Gets a collection consisting of the elements within this collection.
        /// </summary>
        /// <returns>Returns the collection.</returns>
        internal ICollection<Element> GetElementCollection()
        {
            return new VirtualCodeUnitCollection<Element>(this, c => c.ElementCount);
        }

        /// <summary>
        /// Gets a collection consisting of the statements within this collection.
        /// </summary>
        /// <returns>Returns the collection.</returns>
        internal ICollection<Statement> GetStatementCollection()
        {
            return new VirtualCodeUnitCollection<Statement>(this, c => c.StatementCount);
        }

        /// <summary>
        /// Gets a collection consisting of the expressions within this collection.
        /// </summary>
        /// <returns>Returns the collection.</returns>
        internal ICollection<Expression> GetExpressionCollection()
        {
            return new VirtualCodeUnitCollection<Expression>(this, c => c.ExpressionCount);
        }
        
        /// <summary>
        /// Gets a collection consisting of the query clauses within this collection.
        /// </summary>
        /// <returns>Returns the collection.</returns>
        internal ICollection<QueryClause> GetQueryClauseCollection()
        {
            return new VirtualCodeUnitCollection<QueryClause>(this, c => c.QueryClauseCount);
        }
        
        /// <summary>
        /// Gets a collection consisting of the lexical elements within this collection.
        /// </summary>
        /// <returns>Returns the collection.</returns>
        internal ICollection<LexicalElement> GetLexicalElementCollection()
        {
            return new VirtualCodeUnitCollection<LexicalElement>(this, c => c.LexicalElementCount);
        }

        #endregion Internal Methods

        #region Private Classes

        /// <summary>
        /// A linked list of code units.
        /// </summary>
        private class CodeUnitLinkedList : LinkedItemList<CodeUnit>
        {
            #region Private Fields

            /// <summary>
            /// The number of lexical elements within the collection.
            /// </summary>
            private int lexicalElementCount;

            /// <summary>
            /// The number of expressions within the collection.
            /// </summary>
            private int expressionCount;

            /// <summary>
            /// The number of statements within the collection.
            /// </summary>
            private int statementCount;

            /// <summary>
            /// The number of elements within the collection.
            /// </summary>
            private int elementCount;

            /// <summary>
            /// The number of queries within the collection.
            /// </summary>
            private int queryClauseCount;

            #endregion Private Fields

            #region Public Constructors
            
            /// <summary>
            /// Initializes a new instance of the CodeUnitLinkedList class.
            /// </summary>
            public CodeUnitLinkedList()
            {
            }

            #endregion Public Constructors

            #region Public Properties

            /// <summary>
            /// Gets the number of lexical elements within the collection.
            /// </summary>
            public int LexicalElementCount
            {
                get { return this.lexicalElementCount; }
            }

            /// <summary>
            /// Gets the number of expressions within the collection.
            /// </summary>
            public int ExpressionCount
            {
                get { return this.expressionCount; }
            }

            /// <summary>
            /// Gets the number of statements within the collection.
            /// </summary>
            public int StatementCount
            {
                get { return this.statementCount; }
            }

            /// <summary>
            /// Gets the number of elements within the collection.
            /// </summary>
            public int ElementCount
            {
                get { return this.elementCount; }
            }

            /// <summary>
            /// Gets the number of queries within the collection.
            /// </summary>
            public int QueryClauseCount
            {
                get { return this.queryClauseCount; }
            }

            #endregion Public Properties

            #region Public Override Methods

            /// <summary>
            /// Inserts a item into the list after the given item.
            /// </summary>
            /// <param name="node">The node to insert.</param>
            /// <param name="nodeToInsertAfter">The node to insert the item after.</param>
            public override void InsertAfter(CodeUnit node, CodeUnit nodeToInsertAfter)
            {
                Param.AssertNotNull(node, "node");
                Param.Ignore(nodeToInsertAfter);

                base.InsertAfter(node, nodeToInsertAfter);
                this.IncrementOrDecrementCount(node, 1);
            }

            /// <summary>
            /// Inserts a node into the list before the given item.
            /// </summary>
            /// <param name="node">The node to insert.</param>
            /// <param name="nodeToInsertBefore">The node to insert the item before.</param>
            public override void InsertBefore(CodeUnit node, CodeUnit nodeToInsertBefore)
            {
                Param.AssertNotNull(node, "node");
                Param.Ignore(nodeToInsertBefore);

                this.InsertBefore(node, nodeToInsertBefore);
                this.IncrementOrDecrementCount(node, 1);
            }

            /// <summary>
            /// Adds the range of items to the collection.
            /// </summary>
            /// <param name="nodes">The range of nodes to add.</param>
            public override void AddRange(IEnumerable<CodeUnit> nodes)
            {
                Param.Ignore(nodes);

                this.AddRange(nodes);
                foreach (CodeUnit item in nodes)
                {
                    this.IncrementOrDecrementCount(item, 1);
                }
            }

            /// <summary>
            /// Removes the given node from the list.
            /// </summary>
            /// <param name="node">The node to remove from the list.</param>
            /// <returns>Return true if the node was removed from the list.</returns>
            public override bool Remove(CodeUnit node)
            {
                Param.AssertNotNull(node, "node");

                if (base.Remove(node))
                {
                    this.IncrementOrDecrementCount(node, -1);
                    return true;
                }

                return false;
            }

            /// <summary>
            /// Removes the given range of nodes from the list.
            /// </summary>
            /// <param name="start">The first node to remove.</param>
            /// <param name="end">The last node to remove.</param>
            /// <remarks>This method assumes that both the start node and the end node are nodes in this list,
            /// and that the start node appears before the end node in the list. These assumptions are not
            /// verified, so use this method with care.</remarks>
            public override void RemoveRange(CodeUnit start, CodeUnit end)
            {
                Param.AssertNotNull(start, "start");
                Param.AssertNotNull(end, "end");

                for (CodeUnit node = start; node != null; node = node.LinkNode.Next)
                {
                    this.IncrementOrDecrementCount(node, -1);
                }

                base.RemoveRange(start, end);
            }

            /// <summary>
            /// Removes the given node from the list and replaces it with a different node.
            /// </summary>
            /// <param name="node">The node to remove.</param>
            /// <param name="newNode">The replacement node.</param>
            public override void Replace(CodeUnit node, CodeUnit newNode)
            {
                Param.AssertNotNull(node, "node");
                Param.AssertNotNull(newNode, "newNode");

                base.Replace(node, newNode);
                this.IncrementOrDecrementCount(node, -1);
                this.IncrementOrDecrementCount(newNode, 1);
            }

            /// <summary>
            /// Clears the contents of the list.
            /// </summary>
            public override void Clear()
            {
                base.Clear();

                this.elementCount = 0;
                this.expressionCount = 0;
                this.lexicalElementCount = 0;
                this.queryClauseCount = 0;
                this.statementCount = 0;
            }

            #endregion Public Override Methods

            #region Private Methods

            /// <summary>
            /// Increments or decrements the count based on the type of the item.
            /// </summary>
            /// <param name="item">The item being added.</param>
            /// <param name="amount">The amount to increment or decrement the count.</param>
            private void IncrementOrDecrementCount(CodeUnit item, int amount)
            {
                Param.AssertNotNull(item, "item");
                Param.Ignore(amount);

                switch (item.CodeUnitType)
                {
                    case CodeUnitType.Element:
                        this.elementCount += amount;
                        break;
                    case CodeUnitType.Expression:
                        this.expressionCount += amount;
                        break;
                    case CodeUnitType.QueryClause:
                        this.queryClauseCount += amount;
                        break;
                    case CodeUnitType.Statement:
                        this.statementCount += amount;
                        break;
                    case CodeUnitType.LexicalElement:
                        this.lexicalElementCount += amount;
                        break;
                }
            }

            #endregion Private Methods
        }

        /// <summary>
        /// Represents a virtual collection of code units of a specific type.
        /// </summary>
        /// <typeparam name="T">The type of the item to include in the virtual collection.</typeparam>
        private class VirtualCodeUnitCollection<T> : ICollection<T> where T : CodeUnit
        {
            #region Private Fields

            /// <summary>
            /// The collection of all code units.
            /// </summary>
            private CodeUnitCollection collection;

            /// <summary>
            /// The count handler.
            /// </summary>
            private CountHandler countHandler;

            #endregion Private Fields

            #region Public Constructors

            /// <summary>
            /// Initializes a new instance of the VirtualCodeUnitCollection class.
            /// </summary>
            /// <param name="collection">The collection of all code units.</param>
            /// <param name="countHandler">Retrieves the correct item count from the collection.</param>
            public VirtualCodeUnitCollection(CodeUnitCollection collection, CountHandler countHandler)
            {
                Param.AssertNotNull(collection, "collection");
                Param.AssertNotNull(countHandler, "countHandler");

                this.collection = collection;
                this.countHandler = countHandler;
            }

            #endregion Public Constructors

            #region Public Delegates

            /// <summary>
            /// Used for retrieving the correct count.
            /// </summary>
            /// <param name="collection">The collection.</param>
            /// <returns>Returns the count.</returns>
            public delegate int CountHandler(CodeUnitCollection collection);

            #endregion Public Delegates

            #region Public Properties

            /// <summary>
            /// Gets the number of elements contained in the collection.
            /// </summary>
            public int Count
            {
                get { return this.countHandler(this.collection); }
            }

            /// <summary>
            /// Gets a value indicating whether the is read-only.
            /// </summary>
            public bool IsReadOnly
            {
                get { return true; }
            }

            #endregion Public Properties

            #region Protected Properties

            /// <summary>
            /// Gets the inner collection.
            /// </summary>
            public CodeUnitCollection Collection
            {
                get { return this.collection; }
            }

            #endregion Protected Properties

            #region Public Methods

            /// <summary>
            /// Adds an item to the collection.
            /// </summary>
            /// <param name="item">The item to add to the collection.</param>
            public void Add(T item)
            {
                Param.Ignore(item);
                throw new NotImplementedException();
            }

            /// <summary>
            /// Removes all items from the collection.
            /// </summary>
            public void Clear()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Determines whether the collection contains a specific value.
            /// </summary>
            /// <param name="item">The item to locate in the collection.</param>
            /// <returns>Returns true if the item is found in the collection; otherwise false.</returns>
            public bool Contains(T item)
            {
                Param.Ignore(item);
                return this.collection.Contains(item);
            }

            /// <summary>
            /// Copies the entire collection to the given array, starting at the specified index of the target array.
            /// </summary>
            /// <param name="array">The array that is the destination of the nodes copied from the collection.</param>
            /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
            public void CopyTo(T[] array, int arrayIndex)
            {
                Param.Ignore(array, arrayIndex);

                int index = arrayIndex;
                foreach (T item in this)
                {
                    array[index++] = item;
                }
            }

            /// <summary>
            /// Removes the given item from the list.
            /// </summary>
            /// <param name="item">The item to remove from the list.</param>
            /// <returns>Return true if the item was removed from the list.</returns>
            /// <remarks>This method is inefficient as it must iterate the list to find the node to remove.</remarks>
            public bool Remove(T item)
            {
                Param.AssertNotNull(item, "item");
                throw new NotImplementedException();
            }

            /// <summary>
            /// Gets an enumerator that iterates through the nodes in the collection.
            /// </summary>
            /// <returns>Returns an enumerator that iterates through the nodes in the collection.</returns>
            public IEnumerator<T> GetEnumerator()
            {
                return new VirtualCodeUnitEnumerator<T>(this.collection);
            }

            /// <summary>
            /// Gets an enumerator that iterates through the nodes in the collection.
            /// </summary>
            /// <returns>Returns an enumerator that iterates through the nodes in the collection.</returns>
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return new VirtualCodeUnitEnumerator<T>(this.collection);
            }

            #endregion Public Methods
        }

        /// <summary>
        /// Represents an enumerator of code units of a specific type from within a CodeUnitCollection.
        /// </summary>
        /// <typeparam name="T">The type of the items to return from the enumerator.</typeparam>
        private class VirtualCodeUnitEnumerator<T> : IEnumerator<T> where T : CodeUnit
        {
            #region Private Fields

            /// <summary>
            /// The collection of all code units.
            /// </summary>
            private CodeUnitCollection collection;

            /// <summary>
            /// The current item in the collection.
            /// </summary>
            private T currentItem;

            #endregion Private Fields

            #region Public Constructors

            /// <summary>
            /// Initializes a new instance of the VirtualCodeUnitEnumerator class.
            /// </summary>
            /// <param name="collection">The collection of all code units.</param>
            public VirtualCodeUnitEnumerator(CodeUnitCollection collection)
            {
                Param.AssertNotNull(collection, "collection");
                this.collection = collection;
            }

            #endregion Public Constructors

            #region Public Properties

            /// <summary>
            /// Gets the current item.
            /// </summary>
            public T Current
            {
                get
                {
                    return this.currentItem;
                }
            }

            /// <summary>
            /// Gets the current item.
            /// </summary>
            object System.Collections.IEnumerator.Current
            {
                get
                {
                    return this.Current;
                }
            }

            #endregion Public Properties

            #region Public Methods

            /// <summary>
            /// Disposes the contents of the class.
            /// </summary>
            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }

            /// <summary>
            /// Moves to the next item in the collection.
            /// </summary>
            /// <returns>Returns false if there are no more items in the collection.</returns>
            public bool MoveNext()
            {
                if (this.collection.First == null)
                {
                    return false;
                }

                this.MoveToNextItem();

                return this.currentItem != null;
            }

            /// <summary>
            /// Resets the enumerator back to the beginning of the collection.
            /// </summary>
            public void Reset()
            {
                this.currentItem = null;
            }

            #endregion Public Methods

            #region Private Methods

            /// <summary>
            /// Moves to the next matching item in the collection.
            /// </summary>
            private void MoveToNextItem()
            {
                for (CodeUnit item = this.currentItem == null ? this.collection.First : this.currentItem.LinkNode.Next; item != null; item = item.LinkNode.Next)
                {
                    T convertedItem = item as T;
                    if (convertedItem != null)
                    {
                        this.currentItem = convertedItem;
                        return;
                    }
                }

                this.currentItem = null;
            }

            #endregion Private Methods
        }

        #endregion Private Classes
    }
}