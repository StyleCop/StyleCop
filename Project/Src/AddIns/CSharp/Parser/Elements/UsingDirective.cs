//-----------------------------------------------------------------------
// <copyright file="UsingDirective.cs" company="Microsoft">
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
    using System.Text;

    /// <summary>
    /// Describes the contents of a using directive.
    /// </summary>
    /// <subcategory>element</subcategory>
    public sealed class UsingDirective : Element
    {
        #region Private Fields

        /// <summary>
        /// The namespace type declared by the using element.
        /// </summary>
        private CodeUnitProperty<string> namespaceType;

        /// <summary>
        /// The alias mapped to the namespace type, if any.
        /// </summary>
        private CodeUnitProperty<string> alias;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the UsingDirective class.
        /// </summary>
        /// <param name="proxy">Proxy object for the using directive.</param>
        /// <param name="name">The name of the using directive.</param>
        /// <param name="namespace">The namespace being used.</param>
        /// <param name="alias">Optional alias for the namespace, if any.</param>
        internal UsingDirective(CodeUnitProxy proxy, string name, string @namespace, string alias) 
            : base(proxy, ElementType.UsingDirective, name, null, false)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertValidString(name, "name");
            Param.AssertValidString(@namespace, "namespace");
            Param.Ignore(alias);

            this.namespaceType.Value = @namespace;
            this.alias.Value = alias ?? string.Empty;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the alias defined within the using directive, if any.
        /// </summary>
        public string Alias
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.alias.Initialized)
                {
                    this.Init();
                }

                return this.alias.Value;
            }
        }

        /// <summary>
        /// Gets the namespace type declared by the using element.
        /// </summary>
        public string NamespaceType
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.namespaceType.Initialized)
                {
                    this.Init();
                }

                return this.namespaceType.Value;
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

        #region Protected Override Methods

        /// <summary>
        /// Gets the name of the element.
        /// </summary>
        /// <returns>The name of the element.</returns>
        protected override string GetElementName()
        {
            string alias = this.Alias;
            if (alias != null)
            {
                return alias;
            }

            return this.NamespaceType;
        }

        /// <summary>
        /// Resets the contents of the class.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();

            this.namespaceType.Reset();
            this.alias.Reset();
        }

        #endregion Protected Override Methods

        #region Private Methods

        /// <summary>
        /// Initializes the element.
        /// </summary>
        private void Init()
        {
            this.namespaceType.Value = this.alias.Value = string.Empty;

            // Find the 'using' keyword.
            Token usingKeyword = this.FindFirstChild<UsingDirectiveToken>();
            if (usingKeyword != null)
            {
                // Move past it.
                Token index = usingKeyword.FindNextSibling<Token>();
                if (index != null)
                {
                    // This word is usually the namespace type, unless an alias is defined.
                    this.namespaceType.Value = CodeParser.TrimType(CodeParser.GetFullName(this.Document, this, index, out index));

                    // Now see if the next word is an equals sign.
                    index = index.FindNextSibling<Token>();

                    if (index != null)
                    {
                        if (index.Text == "=")
                        {
                            // Get the word after the equals sign, which will be the namespace.
                            index = index.FindNextSibling<Token>();

                            if (index != null)
                            {
                                // Set the alias and the namespace.
                                this.alias.Value = this.namespaceType.Value;
                                this.namespaceType.Value = CodeParser.TrimType(index.Text);
                            }
                        }
                    }
                }
            }
        }

        #endregion Private Methods
    }
}
