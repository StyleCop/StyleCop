//-----------------------------------------------------------------------
// <copyright file="ICodeUnit.cs" company="Microsoft">
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
    using System.Collections.Generic;
    
    /// <summary>
    /// Describes a single item within an enum element.
    /// </summary>
    /// <subcategory>element</subcategory>
    public sealed class EnumItem : Element
    {
        #region Private Fields

        /// <summary>
        /// The initialization expression, if there is one.
        /// </summary>
        private Expression initialization;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the EnumItem class.
        /// </summary>
        /// <param name="proxy">Proxy object for the enum.</param>
        /// <param name="name">The name of the enum.</param>
        /// <param name="attributes">The list of attributes attached to this element.</param>
        /// <param name="initialization">The initialization expression, if there is one.</param>
        /// <param name="unsafeCode">Indicates whether the element resides within a block of unsafe code.</param>
        internal EnumItem(CodeUnitProxy proxy, string name, ICollection<Attribute> attributes, Expression initialization, bool unsafeCode)
            : base(proxy, ElementType.EnumItem, name, attributes, unsafeCode)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertValidString(name, "name");
            Param.Ignore(attributes, initialization, unsafeCode);

            this.initialization = initialization;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the initialization expression for the enum item, if there is one.
        /// </summary>
        public Expression Initialization
        {
            get
            {
                return this.initialization;
            }
        }

        #endregion Public Properties

        #region Protected Override Properties

        /// <summary>
        /// Gets the collection of modifiers allowed on this element.
        /// </summary>
        protected override IEnumerable<string> AllowedModifiers
        {
            get
            {
                return new string[] { };
            }
        }

        #endregion Protected Override Properties
    }
}
