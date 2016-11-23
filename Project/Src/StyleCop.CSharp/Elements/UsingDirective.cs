// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UsingDirective.cs" company="https://github.com/StyleCop">
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
//   Describes the contents of a using directive.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// Describes the contents of a using directive.
    /// </summary>
    /// <subcategory>element</subcategory>
    public sealed class UsingDirective : CsElement
    {
        #region Fields

        /// <summary>
        /// The alias mapped to the namespace type, if any.
        /// </summary>
        private string alias = string.Empty;

        /// <summary>
        /// The namespace type declared by the using element.
        /// </summary>
        private string namespaceType = string.Empty;

        /// <summary>
        /// Indicates whether this using statement is a static using statement.
        /// </summary>
        private bool isStatic = false;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the UsingDirective class.
        /// </summary>
        /// <param name="document">
        /// The document that contains the element.
        /// </param>
        /// <param name="parent">
        /// The parent of the element.
        /// </param>
        /// <param name="declaration">
        /// The declaration code for this element.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the code element was generated or written by hand.
        /// </param>
        /// <param name="isStatic">Indicates whether the using statement is a static using statement.</param>
        /// <param name="namespace">
        /// The namespace being used.
        /// </param>
        /// <param name="alias">
        /// Optional alias for the namespace, if any.
        /// </param>
        internal UsingDirective(CsDocument document, CsElement parent, Declaration declaration, bool generated, bool isStatic, string @namespace, string alias)
            : base(document, parent, ElementType.UsingDirective, "using " + declaration.Name, null, null, declaration, false, generated)
        {
            Param.Ignore(document);
            Param.Ignore(parent);
            Param.Ignore(declaration);
            Param.Ignore(generated);
            Param.AssertValidString(@namespace, "namespace");
            Param.Ignore(alias);

            this.namespaceType = @namespace;
            this.isStatic = isStatic;

            if (alias != null)
            {
                this.alias = alias;
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the alias defined within the using directive, if any.
        /// </summary>
        public string Alias
        {
            get
            {
                return this.alias;
            }
        }

        /// <summary>
        /// Gets the namespace type declared by the using element.
        /// </summary>
        public string NamespaceType
        {
            get
            {
                return this.namespaceType;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this using statement is a static using statement.
        /// </summary>
        public bool IsStatic
        {
            get
            {
                return this.isStatic;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the element.
        /// </summary>
        internal override void Initialize()
        {
            base.Initialize();

            // Find the 'using' keyword.
            Node<CsToken> usingKeywordNode = null;

            for (Node<CsToken> tokenNode = this.Tokens.First; !this.Tokens.OutOfBounds(tokenNode); tokenNode = tokenNode.Next)
            {
                if (tokenNode.Value.CsTokenType == CsTokenType.UsingDirective)
                {
                    usingKeywordNode = tokenNode;
                    break;
                }
            }

            // Make sure we found it.
            if (usingKeywordNode != null)
            {
                // Move past it.
                Node<CsToken> indexNode = usingKeywordNode.Next;
                if (this.Tokens.OutOfBounds(indexNode))
                {
                    indexNode = null;
                }

                if (CodeParser.MoveToNextCodeToken(this.Tokens, ref indexNode))
                {
                    // This word is usually the namespace type, unless an alias is defined.
                    this.namespaceType = CodeParser.TrimType(CodeParser.GetFullName((CsDocument)this.Document, this.Tokens, indexNode, out indexNode));

                    // Now see if the next word is an equals sign.
                    indexNode = indexNode.Next;
                    if (this.Tokens.OutOfBounds(indexNode))
                    {
                        indexNode = null;
                    }

                    if (CodeParser.MoveToNextCodeToken(this.Tokens, ref indexNode))
                    {
                        if (indexNode.Value.Text == "=")
                        {
                            // Get the word after the equals sign, which will be the namespace.
                            indexNode = indexNode.Next;
                            if (this.Tokens.OutOfBounds(indexNode))
                            {
                                indexNode = null;
                            }

                            if (CodeParser.MoveToNextCodeToken(this.Tokens, ref indexNode))
                            {
                                // Set the alias and the namespace.
                                this.alias = this.namespaceType;
                                this.namespaceType = CodeParser.TrimType(indexNode.Value.Text);
                            }
                        }
                    }
                }
            }
        }

        #endregion
    }
}