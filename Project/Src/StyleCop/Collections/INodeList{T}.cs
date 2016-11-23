// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INodeList{T}.cs" company="https://github.com/StyleCop">
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
//   Implemented by lists of <see cref="Node{T}" /> items.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Implemented by lists of <see cref="Node{T}"/> items.
    /// </summary>
    /// <typeparam name="T">
    /// The type of item stored in the list.
    /// </typeparam>
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "The interface is implemented by lists.")]
    public interface INodeList<T> : IEnumerable<T>
        where T : class
    {
        #region Public Properties

        /// <summary>
        /// Gets the first item in the list.
        /// </summary>
        Node<T> First { get; }

        /// <summary>
        /// Gets the last item in the list.
        /// </summary>
        Node<T> Last { get; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Gets an iterator for enumerating forward through the items in the list.
        /// </summary>
        /// <returns>Returns the enumerable object.</returns>
        IEnumerable<T> ForwardIterator();

        /// <summary>
        /// Gets an iterator for enumerating forward through the items in the list.
        /// </summary>
        /// <param name="start">
        /// The start position of the iterator.
        /// </param>
        /// <returns>
        /// Returns the enumerable object.
        /// </returns>
        IEnumerable<T> ForwardIterator(Node<T> start);

        /// <summary>
        /// Gets an iterator for enumerating forward through the nodes in the list.
        /// </summary>
        /// <returns>Returns the enumerable object.</returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "The use of IEnumerable<T> is consistent with standards.")]
        IEnumerable<Node<T>> ForwardNodeIterator();

        /// <summary>
        /// Gets an iterator for enumerating forward through the nodes in the list.
        /// </summary>
        /// <param name="start">
        /// The start position of the iterator.
        /// </param>
        /// <returns>
        /// Returns the enumerable object.
        /// </returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "The use of IEnumerable<T> is consistent with standards.")]
        IEnumerable<Node<T>> ForwardNodeIterator(Node<T> start);

        /// <summary>
        /// Determines whether the given node is beyond the bounds of the list.
        /// </summary>
        /// <param name="node">
        /// The node to check.
        /// </param>
        /// <returns>
        /// Returns true if the node is beyond the bounds of the list.
        /// </returns>
        bool OutOfBounds(Node<T> node);

        /// <summary>
        /// Gets an iterator for enumerating backwards through the items in the list.
        /// </summary>
        /// <returns>Returns the enumerable object.</returns>
        IEnumerable<T> ReverseIterator();

        /// <summary>
        /// Gets an iterator for enumerating backwards through the items in the list.
        /// </summary>
        /// <param name="start">
        /// The start position of the iterator.
        /// </param>
        /// <returns>
        /// Returns the enumerable object.
        /// </returns>
        IEnumerable<T> ReverseIterator(Node<T> start);

        /// <summary>
        /// Gets an iterator for enumerating backwards through the nodes in the list.
        /// </summary>
        /// <returns>Returns the enumerable object.</returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "The use of IEnumerable<T> is consistent with standards.")]
        IEnumerable<Node<T>> ReverseNodeIterator();

        /// <summary>
        /// Gets an iterator for enumerating backwards through the nodes in the list.
        /// </summary>
        /// <param name="start">
        /// The start position of the iterator.
        /// </param>
        /// <returns>
        /// Returns the enumerable object.
        /// </returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "The use of IEnumerable<T> is consistent with standards.")]
        IEnumerable<Node<T>> ReverseNodeIterator(Node<T> start);

        #endregion
    }
}