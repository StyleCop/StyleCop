// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExternAliasDirective.cs" company="https://github.com/StyleCop">
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
//   Describes the contents of an extern alias directive.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// Describes the contents of an extern alias directive.
    /// </summary>
    /// <subcategory>element</subcategory>
    public sealed class ExternAliasDirective : CsElement
    {
        #region Fields

        /// <summary>
        /// The identifier name of the alias.
        /// </summary>
        private string identifier = string.Empty;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the ExternAliasDirective class.
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
        internal ExternAliasDirective(CsDocument document, CsElement parent, Declaration declaration, bool generated)
            : base(document, parent, ElementType.ExternAliasDirective, "extern alias " + declaration.Name, null, null, declaration, false, generated)
        {
            Param.Ignore(document, parent, declaration, generated);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the identifier of the alias.
        /// </summary>
        public string Identifier
        {
            get
            {
                return this.identifier;
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

            // Find the 'alias' keyword.
            Node<CsToken> aliasTokenNode = null;

            for (Node<CsToken> tokenNode = this.Tokens.First; !this.Tokens.OutOfBounds(tokenNode); tokenNode = tokenNode.Next)
            {
                if (tokenNode.Value.CsTokenType == CsTokenType.Alias)
                {
                    aliasTokenNode = tokenNode;
                    break;
                }
            }

            // Make sure we found it.
            if (aliasTokenNode != null && aliasTokenNode != this.Tokens.Last)
            {
                Node<CsToken> temp = aliasTokenNode.Next;
                if (!this.Tokens.OutOfBounds(temp))
                {
                    // Move past it.
                    aliasTokenNode = temp;
                    if (CodeParser.MoveToNextCodeToken(this.Tokens, ref aliasTokenNode))
                    {
                        // This word is the identifier
                        this.identifier = CodeParser.TrimType(CodeParser.GetFullName((CsDocument)this.Document, this.Tokens, aliasTokenNode, out aliasTokenNode));
                    }
                }
            }
        }

        #endregion
    }
}