// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Indexer.cs" company="https://github.com/StyleCop">
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
// <summary>
//   Describes an indexer element.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Describes an indexer element.
    /// </summary>
    /// <subcategory>element</subcategory>
    public sealed class Indexer : CsElement, IParameterContainer
    {
        #region Fields

        /// <summary>
        /// The input parameters.
        /// </summary>
        private readonly IList<Parameter> parameters;

        /// <summary>
        /// The return type for the indexer.
        /// </summary>
        private readonly TypeToken returnType;

        /// <summary>
        /// The get accessor for the indexer.
        /// </summary>
        private Accessor get;

        /// <summary>
        /// The set accessor for the indexer.
        /// </summary>
        private Accessor set;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the Indexer class.
        /// </summary>
        /// <param name="document">
        /// The document that contains the element.
        /// </param>
        /// <param name="parent">
        /// The parent of the element.
        /// </param>
        /// <param name="header">
        /// The Xml header for this element.
        /// </param>
        /// <param name="attributes">
        /// The list of attributes attached to this element.
        /// </param>
        /// <param name="declaration">
        /// The declaration code for this element.
        /// </param>
        /// <param name="returnType">
        /// The return type of the indexer.
        /// </param>
        /// <param name="parameters">
        /// The parameters to the indexer.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the element resides within a block of unsafe code.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the code element was generated or written by hand.
        /// </param>
        internal Indexer(
            CsDocument document, 
            CsElement parent, 
            XmlHeader header, 
            ICollection<Attribute> attributes, 
            Declaration declaration, 
            TypeToken returnType, 
            IList<Parameter> parameters, 
            bool unsafeCode, 
            bool generated)
            : base(document, parent, ElementType.Indexer, "indexer " + declaration.Name, header, attributes, declaration, unsafeCode, generated)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(header);
            Param.Ignore(attributes);
            Param.AssertNotNull(declaration, "declaration");
            Param.Ignore(returnType);
            Param.AssertNotNull(parameters, "parameters");
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);

            this.returnType = returnType;
            this.parameters = parameters;

            Debug.Assert(parameters.IsReadOnly, "The parameters collection should be read-only.");

            // Add the qualifications
            this.QualifiedName = CodeParser.AddQualifications(this.parameters, this.QualifiedName);

            // If this is an explicit interface member implementation and our access modifier
            // is currently set to private because we don't have one, then it should be public instead.
            if (this.Declaration.Name.IndexOf(".", StringComparison.Ordinal) > -1 && !this.Declaration.Name.StartsWith("this.", StringComparison.Ordinal))
            {
                this.Declaration.AccessModifierType = AccessModifierType.Public;
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the get accessor for the indexer, if there is one.
        /// </summary>
        public Accessor GetAccessor
        {
            get
            {
                return this.get;
            }
        }

        /// <summary>
        /// Gets the list of input parameters for the indexer.
        /// </summary>
        public IList<Parameter> Parameters
        {
            get
            {
                return this.parameters;
            }
        }

        /// <summary>
        /// Gets the return type for the indexer.
        /// </summary>
        public TypeToken ReturnType
        {
            get
            {
                return this.returnType;
            }
        }

        /// <summary>
        /// Gets the set accessor for the indexer, if there is one.
        /// </summary>
        public Accessor SetAccessor
        {
            get
            {
                return this.set;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the contents of the indexer.
        /// </summary>
        internal override void Initialize()
        {
            base.Initialize();

            // Find the get and set accessors for this indexer, if they exist.
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

        #endregion
    }
}