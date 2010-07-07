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
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    /// <summary>
    /// Describes an attribute declared on an element.
    /// </summary>
    /// <subcategory>token</subcategory>
    [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix", Justification = "The class describes a C# attribute.")]
    public sealed class Attribute : CodeUnit
    {
        #region Private Fields

        /// <summary>
        /// The element that this attribute is attached to.
        /// </summary>
        private Element element;

        /// <summary>
        /// Gets the list of attribute expressions within this attribute.
        /// </summary>
        private ICollection<AttributeExpression> attributeExpressions;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the Attribute class.
        /// </summary>
        /// <param name="proxy">Proxy object for the attribute.</param>
        /// <param name="attributeExpressions">The list of attribute expressions within this attribute.</param>
        /// <param name="generated">Indicates whether the attribute resides within a block of generated code.</param>
        internal Attribute(CodeUnitProxy proxy, ICollection<AttributeExpression> attributeExpressions, bool generated)
            : base(proxy, CodeUnitType.Attribute, generated)
        {
            Param.AssertGreaterThanOrEqualTo(proxy.Children.Count, 2, "childTokens");
            Param.AssertNotNull(attributeExpressions, "attributeExpressions");
            Param.Ignore(generated);

            this.attributeExpressions = attributeExpressions;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the list of attribute expressions within this attribute.
        /// </summary>
        public ICollection<AttributeExpression> AttributeExpressions
        {
            get
            {
                return this.attributeExpressions;
            }
        }

        /// <summary>
        /// Gets the element that this attribute is attached to, if any.
        /// </summary>
        public Element Element
        {
            get
            {
                return this.element;
            }

            internal set
            {
                this.element = value;
            }
        }

        #endregion Public Properties
    }
}
