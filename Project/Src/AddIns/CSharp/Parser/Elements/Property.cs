//-----------------------------------------------------------------------
// <copyright file="Property.cs" company="Microsoft">
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

    /// <summary>
    /// Describes a property element.
    /// </summary>
    /// <subcategory>element</subcategory>
    [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", Justification = "The class describes a C# property.")]
    public sealed class Property : Element
    {
        #region Private Fields

        /// <summary>
        /// The return type for the property.
        /// </summary>
        private TypeToken returnType;

        /// <summary>
        /// The get accessor for the property.
        /// </summary>
        private Accessor get;

        /// <summary>
        /// The set accessor for the property.
        /// </summary>
        private Accessor set;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the Property class.
        /// </summary>
        /// <param name="proxy">Proxy object for the property.</param>
        /// <param name="name">The name of the property.</param>
        /// <param name="attributes">The list of attributes attached to this element.</param>
        /// <param name="returnType">The property return type.</param>
        /// <param name="unsafeCode">Indicates whether the element resides within a block of unsafe code.</param>
        internal Property(CodeUnitProxy proxy, string name, ICollection<Attribute> attributes, TypeToken returnType, bool unsafeCode)
            : base(proxy, ElementType.Property, name, attributes, unsafeCode)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertValidString(name, "name");
            Param.Ignore(attributes);
            Param.AssertNotNull(returnType, "returnType");
            Param.Ignore(unsafeCode);

            this.returnType = returnType;

            // If this is an explicit interface member implementation and our access modifier
            // is currently set to private because we don't have one, then it should be public instead.
            if (name.IndexOf(".", StringComparison.Ordinal) > -1 && !name.StartsWith("this.", StringComparison.Ordinal))
            {
                this.AccessModifierType = AccessModifierType.Public;
            }
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the return type for the property.
        /// </summary>
        public TypeToken ReturnType
        {
            get
            {
                return this.returnType;
            }
        }

        /// <summary>
        /// Gets the get accessor for the property, if there is one.
        /// </summary>
        public Accessor GetAccessor
        {
            get
            {
                return this.get;
            }
        }

        /// <summary>
        /// Gets the set accessor for the property, if there is one.
        /// </summary>
        public Accessor SetAccessor
        {
            get
            {
                return this.set;
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
                return CodeParser.PropertyModifiers;
            }
        }

        #endregion Protected Override Properties

        #region Internal Override Methods

        /// <summary>
        /// Initializes the contents of the property.
        /// </summary>
        /// <param name="document">The document that contains the element.</param>
        internal override void Initialize(CsDocument document)
        {
            Param.AssertNotNull(document, "document");

            base.Initialize(document);

            // Find the get and set accessors for this property, if they exist.
            for (Element child = this.FindFirstChild<Element>(); child != null; child = child.FindNextSibling<Element>())
            {
                Accessor accessor = child as Accessor;
                if (accessor == null)
                {
                    throw new SyntaxException(document, accessor.LineNumber);
                }

                if (accessor.AccessorType == AccessorType.Get)
                {
                    if (this.get != null)
                    {
                        throw new SyntaxException(document, accessor.LineNumber);
                    }

                    this.get = accessor;
                }
                else if (accessor.AccessorType == AccessorType.Set)
                {
                    if (this.set != null)
                    {
                        throw new SyntaxException(document, accessor.LineNumber);
                    }

                    this.set = accessor;
                }
                else
                {
                    throw new SyntaxException(document, accessor.LineNumber);
                }
            }
        }

        #endregion Internal Override Methods
    }
}
