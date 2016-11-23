// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccessorType.cs" company="https://github.com/StyleCop">
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
//   The various types of accessors for properties, indexers and events.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// The various types of accessors for properties, indexers and events.
    /// </summary>
    /// <subcategory>element</subcategory>
    public enum AccessorType
    {
        /// <summary>
        /// A get accessor within a property or indexer.
        /// </summary>
        Get, 

        /// <summary>
        /// A set accessor within a property or indexer.
        /// </summary>
        Set, 

        /// <summary>
        /// An add accessor within an event.
        /// </summary>
        Add, 

        /// <summary>
        /// A remove accessor within an event.
        /// </summary>
        Remove
    }
}