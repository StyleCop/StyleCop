// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Field.cs" company="https://github.com/StyleCop">
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
//   Describes a field within a class or struct.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Describes a field within a class or struct.
    /// </summary>
    /// <subcategory>element</subcategory>
    public sealed class Field : CsElement
    {
        #region Fields

        /// <summary>
        /// Indicates whether the item is declared as a constant.
        /// </summary>
        private readonly bool isConst;

        /// <summary>
        /// Indicates whether the item is declared read only.
        /// </summary>
        private readonly bool isReadOnly;

        /// <summary>
        /// Indicates whether the item is declared static.
        /// </summary>
        private readonly bool isStatic;

        /// <summary>
        /// The type of the field.
        /// </summary>
        private readonly TypeToken type;

        /// <summary>
        /// The variable declaration statement within this field.
        /// </summary>
        private VariableDeclarationStatement declaration;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the Field class.
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
        /// <param name="fieldType">
        /// The type of the field.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the element resides within a block of unsafe code.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the code element was generated or written by hand.
        /// </param>
        internal Field(
            CsDocument document, 
            CsElement parent, 
            XmlHeader header, 
            ICollection<Attribute> attributes, 
            Declaration declaration, 
            TypeToken fieldType, 
            bool unsafeCode, 
            bool generated)
            : base(document, parent, ElementType.Field, "field " + declaration.Name, header, attributes, declaration, unsafeCode, generated)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(header);
            Param.Ignore(attributes);
            Param.AssertNotNull(declaration, "declaration");
            Param.AssertNotNull(fieldType, "fieldType");
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);

            this.type = fieldType;

            // Determine whether the item is const /readonly / static.
            this.isConst = this.Declaration.ContainsModifier(CsTokenType.Const);
            this.isReadOnly = this.Declaration.ContainsModifier(CsTokenType.Readonly);
            this.isStatic = this.Declaration.ContainsModifier(CsTokenType.Static);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether the field is declared as a constant.
        /// </summary>
        public bool Const
        {
            get
            {
                return this.isConst;
            }
        }

        /// <summary>
        /// Gets the type of the field.
        /// </summary>
        public TypeToken FieldType
        {
            get
            {
                return this.type;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the field is declared read only.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "Readonly", 
            Justification = "API has already been published and should not be changed.")]
        public bool Readonly
        {
            get
            {
                return this.isReadOnly;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the field is declared static.
        /// </summary>
        public bool Static
        {
            get
            {
                return this.isStatic;
            }
        }

        /// <summary>
        /// Gets the variable declaration statement within this field.
        /// </summary>
        public VariableDeclarationStatement VariableDeclarationStatement
        {
            get
            {
                return this.declaration;
            }

            internal set
            {
                this.declaration = value;
                if (this.declaration != null)
                {
                    this.AddStatement(this.declaration);
                }
            }
        }

        #endregion
    }
}