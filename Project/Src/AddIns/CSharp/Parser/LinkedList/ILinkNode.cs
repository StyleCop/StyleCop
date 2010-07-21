//--------------------------------------------------------------------------
// <copyright file="ILinkNode.cs" company="Microsoft">
//    Copyright (c) Microsoft Corporation.
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
namespace Microsoft.StyleCop.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Used to link nodes together.
    /// </summary>
    /// <typeparam name="T">The type of nodes to link.</typeparam>
    public interface ILinkNode<T> where T : class, ILinkNode<T>
    {
        /// <summary>
        /// Gets the link data for the node.
        /// </summary>
        LinkNode<T> LinkNode
        {
            get;    
        }
    }
}
