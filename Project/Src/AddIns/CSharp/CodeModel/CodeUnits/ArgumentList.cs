//-----------------------------------------------------------------------
// <copyright file="ArgumentList.cs" company="Microsoft">
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
    /// Describes an argument list within a method call.
    /// </summary>
    /// <subcategory>codeunit</subcategory>
    public sealed class ArgumentList : CodeUnit
    {
        /// <summary>
        /// The collection of arguments in the list.
        /// </summary>
        private CodeUnitProperty<ICollection<Argument>> arguments;

        /// <summary>
        /// Initializes a new instance of the ArgumentList class.
        /// </summary>
        /// <param name="proxy">The proxy class.</param>
        internal ArgumentList(CodeUnitProxy proxy)
            : base(proxy, CodeUnitType.ArgumentList)
        {
            Param.AssertNotNull(proxy, "proxy");
        }

        /// <summary>
        /// Gets the collection of arguments within the list.
        /// </summary>
        public ICollection<Argument> Arguments
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.arguments.Initialized)
                {
                    this.arguments.Value = new List<Argument>(this.GetChildren<Argument>());
                }

                return this.arguments.Value;
            }
        }

        /// <summary>
        /// Resets the contents of the item.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();
            this.arguments.Reset();
        }
   }
}
