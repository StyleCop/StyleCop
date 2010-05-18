//-----------------------------------------------------------------------
// <copyright file="Reference.cs" company="Microsoft">
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
namespace Microsoft.StyleCop.CSharp
{
    using System;

    /// <summary>
    /// Provides a reference to another object.
    /// </summary>
    /// <typeparam name="T">The type of object to reference.</typeparam>
    internal class Reference<T>
    {
        /// <summary>
        /// Initializes a new instance of the Reference class.
        /// </summary>
        public Reference()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Reference class.
        /// </summary>
        /// <param name="target">The referenced target.</param>
        public Reference(T target)
        {
            Param.Ignore(target);
            this.Target = target;
        }

        /// <summary>
        /// Gets or sets the referenced target.
        /// </summary>
        public T Target
        {
            get;
            set;
        }
    }
}
