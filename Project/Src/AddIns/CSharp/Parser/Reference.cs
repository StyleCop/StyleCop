//-----------------------------------------------------------------------
// <copyright file="CodeUnitReference.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
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
    /// Provides a reference to an object.
    /// </summary>
    internal class Reference<T> where T : class
    {
        /// <summary>
        /// The referenced item.
        /// </summary>
        private T target;

        /// <summary>
        /// Initializes a new instance of the Reference class.
        /// </summary>
        public Reference()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Reference class.
        /// </summary>
        /// <param name="target">The initial item to point the referece to.</param>
        public Reference(T target)
        {
            Param.AssertNotNull(target, "target");
            this.target = target;
        }

        /// <summary>
        /// Event that is fired when the code unit reference changes.
        /// </summary>
        public event EventHandler ReferenceChanged;

        /// <summary>
        /// Gets or sets the referenced target.
        /// </summary>
        public T Target
        {
            get
            {
                return this.target;
            }

            set
            {
                Param.Ignore(value);

                if (value != this.target)
                {
                    this.target = value;
                    this.OnReferenceChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Called when the referenced target changes.
        /// </summary>
        /// <param name="args">The event arguments.</param>
        protected void OnReferenceChanged(EventArgs args)
        {
            Param.Ignore(args);

            if (this.ReferenceChanged != null)
            {
                this.ReferenceChanged(this, EventArgs.Empty);
            }
        }
    }
}