//-----------------------------------------------------------------------
// <copyright file="Indexer.cs" company="Microsoft">
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
    using System.Collections.ObjectModel;
    using System.Diagnostics;

    /// <summary>
    /// Describes an indexer element.
    /// </summary>
    /// <subcategory>element</subcategory>
    public sealed class Indexer : Element, IParameterContainer
    {
        #region Private Fields

        /// <summary>
        /// The return type for the indexer.
        /// </summary>
        private TypeToken returnType;

        /// <summary>
        /// The input parameters.
        /// </summary>
        private IList<Parameter> parameters;

        /// <summary>
        /// The get accessor for the indexer.
        /// </summary>
        private Accessor get;

        /// <summary>
        /// The set accessor for the indexer.
        /// </summary>
        private Accessor set;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the Indexer class.
        /// </summary>
        /// <param name="proxy">Proxy object for the indexer.</param>
        /// <param name="name">The name of the indexer.</param>
        /// <param name="attributes">The list of attributes attached to this element.</param>
        /// <param name="returnType">The return type of the indexer.</param>
        /// <param name="unsafeCode">Indicates whether the element resides within a block of unsafe code.</param>
        internal Indexer(CodeUnitProxy proxy, string name, ICollection<Attribute> attributes, TypeToken returnType, bool unsafeCode)
            : base(proxy, ElementType.Indexer, name, attributes, unsafeCode)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertValidString(name, "name");
            Param.Ignore(attributes);
            Param.Ignore(returnType);
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

        #region Public Override Properties

        /// <summary>
        /// Gets the fully qualified name of the element.
        /// </summary>
        public override string FullyQualifiedName
        {
            get
            {
                return CodeParser.AddQualifications(this.Parameters, base.FullyQualifiedName);
            }
        }

        #endregion Public Override Properties

        #region Public Properties

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
        /// Gets the list of input parameters for the indexer.
        /// </summary>
        public IList<Parameter> Parameters
        {
            get
            {
                if (this.parameters == null)
                {
                    this.parameters = this.CollectFormalParameters(this.FirstDeclarationToken, TokenType.CloseSquareBracket);
                }

                return this.parameters;
            }
        }

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
        /// Gets the set accessor for the indexer, if there is one.
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
                return CodeParser.IndexerModifiers;
            }
        }

        #endregion Protected Override Properties

        #region Public Override Methods

        /// <summary>
        /// Gets the variables defined within this element.
        /// </summary>
        /// <returns>Returns the collection of variables.</returns>
        public override IList<IVariable> GetVariables()
        {
            IList<Parameter> parameters = this.Parameters;
            if (parameters != null && parameters.Count > 0)
            {
                IVariable[] variables = new IVariable[parameters.Count];

                for (int i = 0; i < parameters.Count; ++i)
                {
                    variables[i] = parameters[i];
                }

                return variables;
            }

            return CsParser.EmptyVariableArray;
        }

        #endregion Public Override Methods

        #region Internal Override Methods

        /// <summary>
        /// Initializes the contents of the indexer.
        /// </summary>
        /// <param name="document">The document that contains the element.</param>
        internal override void Initialize(CsDocument document)
        {
            Param.AssertNotNull(document, "document");
            base.Initialize(document);

            // Find the get and set accessors for this indexer, if they exist.
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
