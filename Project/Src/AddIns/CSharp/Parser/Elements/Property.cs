//-----------------------------------------------------------------------
// <copyright file="Property.cs">
//   MS-PL
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
namespace StyleCop.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Describes a property element.
    /// </summary>
    /// <subcategory>element</subcategory>
    [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", Justification = "The class describes a C# property.")]
    public sealed class Property : CsElement
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
        /// <param name="document">The documenent that contains the element.</param>
        /// <param name="parent">The parent of the element.</param>
        /// <param name="header">The Xml header for this element.</param>
        /// <param name="attributes">The list of attributes attached to this element.</param>
        /// <param name="declaration">The declaration code for this element.</param>
        /// <param name="returnType">The property return type.</param>
        /// <param name="unsafeCode">Indicates whether the element resides within a block of unsafe code.</param>
        /// <param name="generated">Indicates whether the code element was generated or written by hand.</param>
        internal Property(
            CsDocument document,
            CsElement parent,
            XmlHeader header,
            ICollection<Attribute> attributes,
            Declaration declaration,
            TypeToken returnType,
            bool unsafeCode,
            bool generated)
            : base(
            document, 
            parent, 
            ElementType.Property, 
            "property " + declaration.Name, 
            header, 
            attributes,
            declaration, 
            unsafeCode,
            generated)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(header);
            Param.Ignore(attributes);
            Param.AssertNotNull(declaration, "declaration");
            Param.AssertNotNull(returnType, "returnType");
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);

            this.returnType = returnType;

            // If this is an explicit interface member implementation and our access modifier
            // is currently set to private because we don't have one, then it should be public instead.
            if (this.Declaration.Name.IndexOf(".", StringComparison.Ordinal) > -1 &&
                !this.Declaration.Name.StartsWith("this.", StringComparison.Ordinal))
            {
                this.Declaration.AccessModifierType = AccessModifierType.Public;
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

        #region Internal Override Methods

        /// <summary>
        /// Initializes the contents of the property.
        /// </summary>
        internal override void Initialize()
        {
            base.Initialize();

            // Find the get and set accessors for this property, if they exist.
            foreach (CsElement child in this.ChildElements)
            {
                Accessor accessor = child as Accessor;
                if (accessor == null)
                {
                    throw new SyntaxException(this.Document.SourceCode, accessor.LineNumber);
                }

                if (accessor.AccessorType == AccessorType.Get)
                {
                    if (this.get != null)
                    {
                        throw new SyntaxException(this.Document.SourceCode, accessor.LineNumber);
                    }

                    this.get = accessor;
                }
                else if (accessor.AccessorType == AccessorType.Set)
                {
                    if (this.set != null)
                    {
                        throw new SyntaxException(this.Document.SourceCode, accessor.LineNumber);
                    }

                    this.set = accessor;
                }
                else
                {
                    throw new SyntaxException(this.Document.SourceCode, accessor.LineNumber);
                }
            }
        }

        #endregion Internal Override Methods
    }
}
