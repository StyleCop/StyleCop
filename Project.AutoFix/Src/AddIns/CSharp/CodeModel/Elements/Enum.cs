//-----------------------------------------------------------------------
// <copyright file="Enum.cs">
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
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Describes the contents of an enum element.
    /// </summary>
    /// <subcategory>element</subcategory>
    [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", Justification = "The class describes a C# enum.")]
    [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix", Justification = "The class name does not need any suffix.")]
    public sealed class Enum : Element
    {
        #region Private Fields

        /// <summary>
        /// The derived base type.
        /// </summary>
        private CodeUnitProperty<string> baseType;

        /// <summary>
        /// The list of items in the enum.
        /// </summary>
        private CodeUnitProperty<ICollection<EnumItem>> items;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the Enum class.
        /// </summary>
        /// <param name="proxy">Proxy object for the enum.</param>
        /// <param name="name">The name of the enum.</param>
        /// <param name="attributes">The list of attributes attached to this element.</param>
        /// <param name="unsafeCode">Indicates whether the element resides within a block of unsafe code.</param>
        internal Enum(CodeUnitProxy proxy, string name, ICollection<Attribute> attributes, bool unsafeCode)
            : base(proxy, ElementType.Enum, name, attributes, unsafeCode)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertValidString(name, "name");
            Param.Ignore(attributes, unsafeCode);
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the base type for the enum.
        /// </summary>
        public string BaseType
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.baseType.Initialized)
                {
                    this.baseType.Value = this.GetBaseType();
                }

                return this.baseType.Value;
            }
        }
        
        /// <summary>
        /// Gets the collection of items in the enum.
        /// </summary>
        public ICollection<EnumItem> Items
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.items.Initialized)
                {
                    this.items.Value = new List<EnumItem>(this.GetChildren<EnumItem>()).AsReadOnly();
                }

                return this.items.Value;
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
                return CodeParser.EnumModifiers;
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
            // Get the enum keyword.
            Token enumToken = this.FindFirstChild<EnumToken>();
            if (enumToken != null)
            {
                // The next Token is the name.
                Token nameToken = enumToken.FindNextSiblingToken();
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

            this.baseType.Reset();
            this.items.Reset();
        }

        #endregion Protected Override Methods

        #region Private Methods

        /// <summary>
        /// Gets the base type of the item.
        /// </summary>
        /// <returns>Returns the name of the base type or null if none.</returns>
        private string GetBaseType()
        {
            // Pull out the base type.
            bool foundColon = false;

            for (Token token = this.FindFirstChildToken(); token != null; token = token.FindNextSiblingToken())
            {
                if (foundColon)
                {
                    return token.Text;
                }
                else if (token.Text == ":")
                {
                    foundColon = true;
                }
            }

            return null;
        }

        #endregion Private Methods
    }
}
