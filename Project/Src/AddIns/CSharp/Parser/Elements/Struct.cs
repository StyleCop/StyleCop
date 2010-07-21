//-----------------------------------------------------------------------
// <copyright file="Struct.cs" company="Microsoft">
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
    using System.Threading;

    /// <summary>
    /// Describes a struct element.
    /// </summary>
    /// <subcategory>element</subcategory>
    public sealed class Struct : ClassBase
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the Struct class.
        /// </summary>
        /// <param name="proxy">Proxy object for the struct.</param>
        /// <param name="name">The name of the struct.</param>
        /// <param name="attributes">The list of attributes attached to this element.</param>
        /// <param name="typeConstraints">The list of type constraints on the class, if any.</param>
        /// <param name="unsafeCode">Indicates whether the element resides within a block of unsafe code.</param>
        internal Struct(CodeUnitProxy proxy, string name, ICollection<Attribute> attributes, ICollection<TypeParameterConstraintClause> typeConstraints, bool unsafeCode)
            : base(proxy, ElementType.Struct, name, attributes, typeConstraints, unsafeCode)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertValidString(name, "name");
            Param.Ignore(attributes, typeConstraints, unsafeCode);
        }

        #endregion Internal Constructors

        #region Protected Override Properties

        /// <summary>
        /// Gets the collection of modifiers allowed on this element.
        /// </summary>
        protected override IEnumerable<string> AllowedModifiers
        {
            get
            {
                return CodeParser.ClassModifiers;
            }
        }

        #endregion Protected Override Properties

        #region Internal Override Methods

        /// <summary>
        /// Initializes the struct object.
        /// </summary>
        /// <param name="document">The document that contains the element.</param>
        internal override void Initialize(CsDocument document)
        {
            Param.Ignore(document);

            // Gather the inheritance from the declaration.
            this.SetInheritedItems();
        }

        #endregion Internal Override Methods

        #region Protected Override Methods

        /// <summary>
        /// Gets the name of the element.
        /// </summary>
        /// <returns>The name of the element.</returns>
        protected override string GetElementName()
        {
            // Get the struct keyword.
            Token structToken = this.FindFirstChild<StructToken>();
            if (structToken != null)
            {
                // The next Token is the name.
                Token nameToken = structToken.FindNextSibling<Token>();
                if (nameToken != null)
                {
                    return nameToken.Text;
                }
            }

            throw new SyntaxException(this.Document, this.LineNumber);
        }

        #endregion Protected Override Methods
    }
}
