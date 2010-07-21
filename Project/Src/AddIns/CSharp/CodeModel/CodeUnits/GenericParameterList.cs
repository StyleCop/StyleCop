//-----------------------------------------------------------------------
// <copyright file="GenericParameterList.cs" company="Microsoft">
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
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    /// <summary>
    /// Describes a list of generic parameters within a generic type definition.
    /// </summary>
    /// <subcategory>token</subcategory>
    public sealed class GenericTypeParameterList : CodeUnit
    {
        /// <summary>
        /// The collection of parameters in the list.
        /// </summary>
        private CodeUnitProperty<ICollection<GenericTypeParameter>> parameters;

        /// <summary>
        /// Initializes a new instance of the GenericTypeParameterList class.
        /// </summary>
        /// <param name="proxy">The proxy class.</param>
        internal GenericTypeParameterList(CodeUnitProxy proxy)
            : base(proxy, CodeUnitType.GenericTypeParameterList)
        {
            Param.AssertNotNull(proxy, "proxy");
        }

        /// <summary>
        /// Gets the collection of parameters within the list.
        /// </summary>
        public ICollection<GenericTypeParameter> Parameters
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.parameters.Initialized)
                {
                    this.parameters.Value = new List<GenericTypeParameter>(this.GetChildren<GenericTypeParameter>());
                }

                return this.parameters.Value;
            }
        }

        /// <summary>
        /// Resets the contents of the item.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();
            this.parameters.Reset();
        }
    }
}
