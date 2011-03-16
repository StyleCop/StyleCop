//-----------------------------------------------------------------------
// <copyright file="ExternAliasDirective.cs">
//   MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
//-----------------------------------------------------------------------
namespace StyleCop.CSharp.CodeModel
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Describes the contents of an extern alias directive.
    /// </summary>
    /// <subcategory>element</subcategory>
    public sealed class ExternAliasDirective : Element
    {
        #region Private Fields

        /// <summary>
        /// The identifier name of the alias.
        /// </summary>
        private CodeUnitProperty<string> identifier;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the ExternAliasDirective class.
        /// </summary>
        /// <param name="proxy">Proxy object for the extern alias.</param>
        /// <param name="name">The name of the extern alias.</param>
        internal ExternAliasDirective(CodeUnitProxy proxy, string name)
            : base(proxy,  ElementType.ExternAliasDirective, name, null, false)
        {
            Param.Ignore(proxy);
            Param.AssertValidString(name, "name");
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the identifier of the alias.
        /// </summary>
        public string Identifier
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.identifier.Initialized)
                {
                    this.identifier.Value = null;

                    // Find the 'alias' keyword.
                    Token aliasToken = this.FindFirstChild<AliasToken>();
                    if (aliasToken != null && aliasToken != this.FindLastChildToken())
                    {
                        Token temp = aliasToken.FindNextSiblingToken();
                        if (temp != null)
                        {
                            // This word is the identifier
                            this.identifier.Value = CodeParser.TrimType(CodeParser.GetFullName(this.Document, this, temp, out temp));
                        }
                    }

                    if (this.identifier.Value == null)
                    {
                        throw new SyntaxException(this.Document, this.LineNumber);   
                    }
                }

                return this.identifier.Value;
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
            // Get the alias keyword.
            Token aliasToken = this.FindFirstChild<AliasToken>();
            if (aliasToken != null)
            {
                // The next Token is the name.
                Token nameToken = aliasToken.FindNextSiblingToken();
                if (nameToken != null)
                {
                    return nameToken.Text;
                }
            }

            throw new SyntaxException(this.Document, this.LineNumber);
        }

        /// <summary>
        /// Resets the contents of the class.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();

            this.identifier.Reset();
        }

        #endregion Protected Override Methods
    }
}
