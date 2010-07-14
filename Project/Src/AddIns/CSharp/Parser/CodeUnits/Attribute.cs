//-----------------------------------------------------------------------
// <copyright file="Attribute.cs" company="Microsoft">
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
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    /// <summary>
    /// Describes an attribute declared on an element.
    /// </summary>
    /// <subcategory>token</subcategory>
    [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix", Justification = "The class describes a C# attribute.")]
    public sealed class Attribute : CodeUnit
    {
        #region Internal Static Readonly Fields

        /// <summary>
        /// An empty array of attributes.
        /// </summary>
        internal static readonly Attribute[] EmptyAttributeArray = new Attribute[] { };

        #endregion Internal Static Readonly Fields

        #region Private Fields

        /// <summary>
        /// Gets the list of attribute expressions within this attribute.
        /// </summary>
        private CodeUnitProperty<ICollection<AttributeExpression>> attributeExpressions;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the Attribute class.
        /// </summary>
        /// <param name="proxy">Proxy object for the attribute.</param>
        /// <param name="attributeExpressions">The list of attribute expressions within this attribute.</param>
        internal Attribute(CodeUnitProxy proxy, ICollection<AttributeExpression> attributeExpressions)
            : base(proxy, CodeUnitType.Attribute)
        {
            Param.AssertGreaterThanOrEqualTo(proxy.Children.Count, 2, "childTokens");
            Param.AssertNotNull(attributeExpressions, "attributeExpressions");

            this.attributeExpressions.Value = attributeExpressions;
            Debug.Assert(attributeExpressions.IsReadOnly, "Must be a read-only collection.");
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
                this.ValidateEditVersion();

                if (!this.attributeExpressions.Initialized)
                {
                    this.attributeExpressions.Value = new List<AttributeExpression>(this.GetChildren<AttributeExpression>()).AsReadOnly();
                }
                
                return this.attributeExpressions.Value;
            }
        }

        #endregion Public Properties

        #region Protected Override Methods

        /// <summary>
        /// Resets the contents of the item.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();

            this.attributeExpressions.Reset();
        }

        #endregion Protected Override Methods
    }
}
