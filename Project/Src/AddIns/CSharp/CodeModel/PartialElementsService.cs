//-----------------------------------------------------------------------
// <copyright file="PartialElementsService.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation.
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
    using System.Threading;

    /// <summary>
    /// A service which keeps track of associated partial elements of the same type, potentially across multiple source 
    /// code instances.
    /// </summary>
    public interface IPartialElementsService
    {
        /// <summary>
        /// Attempts to add an element to the partial elements service, if that element is partial.
        /// </summary>
        /// <param name="element">The element to add.</param>
        /// <returns>Returns true if the element was added, or false if the element was not partial.</returns>
        bool TryAdd(Element element);

        /// <summary>
        /// Gets the list of partial elements with the same fully qualified name as this element.
        /// </summary>
        /// <param name="element">The element to find partial partners of.</param>
        /// <returns>Returns the collection of partial elements of this type.</returns>
        /// <remarks>If this is not a partial element, this property returns null.</remarks>
        ICollection<Element> GetPartialElements(Element element);
    }

    /// <summary>
    /// A service which keeps track of associated partial elements of the same type, potentially across multiple source 
    /// code instances.
    /// </summary>
    public class PartialElementsService : IPartialElementsService
    {
        /// <summary>
        /// Stores the partial elements.
        /// </summary>
        private Dictionary<string, List<Element>> partialElements = new Dictionary<string, List<Element>>();

        /// <summary>
        /// Locks the dictionary.
        /// </summary>
        private ReaderWriterLockSlim @lock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);

        /// <summary>
        /// Initializes a new instance of the PartialElementsService class.
        /// </summary>
        public PartialElementsService()
        {
        }

        /// <summary>
        /// Attempts to add an element to the partial elements service, if that element is partial.
        /// </summary>
        /// <param name="element">The element to add.</param>
        /// <returns>Returns true if the element was added, or false if the element was not partial.</returns>
        public bool TryAdd(Element element)
        {
            Param.RequireNotNull(element, "element");

            // If the element is partial, add it to the partial elements list.
            if (element.ContainsModifier(TokenType.Partial) && element is ClassBase)
            {
                this.@lock.EnterWriteLock();

                try
                {
                    List<Element> elementList = null;

                    // Get the partial element list for this element.
                    string elementFullyQualifiedName = element.FullyQualifiedName;
                    this.partialElements.TryGetValue(elementFullyQualifiedName, out elementList);

                    if (elementList == null)
                    {
                        // Create a new partial element list for this element name.
                        elementList = new List<Element>();
                        this.partialElements.Add(elementFullyQualifiedName, elementList);
                    }
                    else if (elementList.Count > 0)
                    {
                        // Make sure this elements is the same type as the item(s) already in the list.
                        if (elementList[0].ElementType != element.ElementType)
                        {
                            throw new SyntaxException(element.Document, element.LineNumber);
                        }
                    }

                    // Add the element to the list.
                    elementList.Add(element);
                }
                finally
                {
                    this.@lock.ExitWriteLock();
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets the list of partial elements with the same fully qualified name as this element.
        /// </summary>
        /// <param name="element">The element to find partial partners of.</param>
        /// <returns>Returns the collection of partial elements of this type.</returns>
        /// <remarks>If this is not a partial element, this property returns null.</remarks>
        public ICollection<Element> GetPartialElements(Element element)
        {
            Param.RequireNotNull(element, "element");

            if (element.ContainsModifier(TokenType.Partial))
            {
                this.@lock.EnterReadLock();

                try
                {
                    List<Element> partialElementList;

                    if (this.partialElements.TryGetValue(element.FullyQualifiedName, out partialElementList))
                    {
                        return partialElementList.AsReadOnly();
                    }
                }
                finally
                {
                    this.@lock.ExitReadLock();
                }
            }

            return Element.EmptyElementArray;
        }
    }
}
