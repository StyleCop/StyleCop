//-----------------------------------------------------------------------
// <copyright file="CodeUnitProperty.cs" company="Microsoft">
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
    using System.Linq;
    using System.Text;

    /// <summary>
    /// A wrapper for a property within a <see cref="CodeUnit" />
    /// </summary>
    /// <typeparam name="T">The property type.</typeparam>
    internal struct CodeUnitProperty<T>
    {
        /// <summary>
        /// Indicates whether the property has been initialized.
        /// </summary>
        private bool initialized;

        /// <summary>
        /// The property value.
        /// </summary>
        private T value;

        /// <summary>
        /// Gets a value indicating whether the property has been initialized.
        /// </summary>
        public bool Initialized
        {
            get
            {
                return this.initialized;
            }
        }

        /// <summary>
        /// Gets or sets the property value.
        /// </summary>
        public T Value
        {
            get
            {
                return this.value;
            }

            set
            {
                Param.Ignore(value);
                this.initialized = true;
                this.value = value;
            }
        }

        /// <summary>
        /// Resets the property so that it appears as uninitialized.
        /// </summary>
        public void Reset()
        {
            this.initialized = false;
            this.value = default(T);
        }
    }
}
