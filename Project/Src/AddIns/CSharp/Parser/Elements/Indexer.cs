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
        private CodeUnitProperty<TypeToken> returnType;

        /// <summary>
        /// The input parameters.
        /// </summary>
        private CodeUnitProperty<IList<Parameter>> parameters;

        /// <summary>
        /// The get accessor for the indexer.
        /// </summary>
        private CodeUnitProperty<Accessor> get;

        /// <summary>
        /// The set accessor for the indexer.
        /// </summary>
        private CodeUnitProperty<Accessor> set;

        /// <summary>
        /// The fully qualified name of the item.
        /// </summary>
        private CodeUnitProperty<string> fullyQualifiedName;

        /// <summary>
        /// The variables on the item.
        /// </summary>
        private CodeUnitProperty<IList<IVariable>> variables;

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
            Param.AssertNotNull(returnType, "returnType");
            Param.Ignore(unsafeCode);

            this.returnType.Value = returnType;
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
                this.ValidateEditVersion();

                if (!this.fullyQualifiedName.Initialized)
                {
                    this.fullyQualifiedName.Value = CodeParser.AddQualifications(this.Parameters, base.FullyQualifiedName);
                }

                return this.fullyQualifiedName.Value;
            }
        }

        /// <summary>
        /// Gets the variables defined within this element.
        /// </summary>
        public override IList<IVariable> Variables
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.variables.Initialized)
                {
                    IList<Parameter> p = this.Parameters;
                    if (p != null && p.Count > 0)
                    {
                        this.variables.Value = new List<IVariable>(p).AsReadOnly();
                    }
                    else
                    {
                        this.variables.Value = CsParser.EmptyVariableArray;
                    }
                }

                return this.variables.Value;
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
                this.ValidateEditVersion();

                if (!this.returnType.Initialized)
                {
                    this.returnType.Value = this.FindFirstChild<TypeToken>();
                }

                return this.returnType.Value;
            }
        }

        /// <summary>
        /// Gets the list of input parameters for the indexer.
        /// </summary>
        public IList<Parameter> Parameters
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.parameters.Initialized)
                {
                    this.parameters.Value = this.CollectFormalParameters(this.FirstDeclarationToken, TokenType.CloseSquareBracket);
                }

                return this.parameters.Value;
            }
        }

        /// <summary>
        /// Gets the get accessor for the indexer, if there is one.
        /// </summary>
        public Accessor GetAccessor
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.get.Initialized)
                {
                    // todo: create acccessor classes for each accessor type
                    this.get.Value = null;

                    for (Accessor child = this.FindFirstChild<Accessor>(); child != null; child = child.FindNextSibling<Accessor>())
                    {
                        if (child.AccessorType == AccessorType.Get)
                        {
                            this.get.Value = child;
                        }
                    }
                }

                return this.get.Value;
            }
        }

        /// <summary>
        /// Gets the set accessor for the indexer, if there is one.
        /// </summary>
        public Accessor SetAccessor
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.set.Initialized)
                {
                    this.set.Value = null;

                    for (Accessor child = this.FindFirstChild<Accessor>(); child != null; child = child.FindNextSibling<Accessor>())
                    {
                        if (child.AccessorType == AccessorType.Set)
                        {
                            this.set.Value = child;
                        }
                    }
                }

                return this.set.Value;
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

        /// <summary>
        /// Gets the default access modifier for this type.
        /// </summary>
        protected override AccessModifierType DefaultAccessModifierType
        {
            get
            {
                string name = this.Name;

                // If this is an explicit interface member implementation and our access modifier
                // is currently set to private because we don't have one, then it should be public instead.
                if (name.IndexOf(".", StringComparison.Ordinal) > -1 && !name.StartsWith("this.", StringComparison.Ordinal))
                {
                    return AccessModifierType.Public;
                }

                return base.DefaultAccessModifierType;
            }
        }

        #endregion Protected Override Properties

        #region Protected Override Methods

        /// <summary>
        /// Gets the name of the element.
        /// </summary>
        /// <returns>The name of the element.</returns>
        protected override string GetElementName()
        {
            Token thisToken = this.FindFirstChild<ThisToken>();
            if (thisToken != null)
            {
                return thisToken.Text;
            }

            throw new SyntaxException(this.Document, this.LineNumber);
        }

        /// <summary>
        /// Resets the contents of the class.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();

            this.returnType.Reset();
            this.parameters.Reset();
            this.get.Reset();
            this.set.Reset();
            this.fullyQualifiedName.Reset();
            this.variables.Reset();
        }

        #endregion Protected Override Methods
    }
}
