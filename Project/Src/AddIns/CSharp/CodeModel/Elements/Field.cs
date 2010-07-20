//-----------------------------------------------------------------------
// <copyright file="Field.cs" company="Microsoft">
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
namespace Microsoft.StyleCop.CSharp.CodeModel
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Describes a field within a class or struct.
    /// </summary>
    /// <subcategory>element</subcategory>
    public sealed partial class Field : Element
    {
        #region Private Fields

        /// <summary>
        /// The type of the field.
        /// </summary>
        private CodeUnitProperty<TypeToken> fieldType;

        /// <summary>
        /// Indicates whether the item is declared const.
        /// </summary>
        private CodeUnitProperty<bool> isConst;

        /// <summary>
        /// Indicates whether the item is declared readonly.
        /// </summary>
        private CodeUnitProperty<bool> isReadOnly;

        /// <summary>
        /// The statement within the field.
        /// </summary>
        private CodeUnitProperty<VariableDeclarationStatement> statement;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the Field class.
        /// </summary>
        /// <param name="proxy">Proxy object for the field.</param>
        /// <param name="name">The name of the field.</param>
        /// <param name="attributes">The list of attributes attached to this element.</param>
        /// <param name="fieldType">The type of the field.</param>
        /// <param name="unsafeCode">Indicates whether the element resides within a block of unsafe code.</param>
        internal Field(CodeUnitProxy proxy, string name, ICollection<Attribute> attributes, TypeToken fieldType, bool unsafeCode)
            : base(proxy, ElementType.Field, name, attributes, unsafeCode)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertValidString(name, "name");
            Param.Ignore(attributes);
            Param.AssertNotNull(fieldType, "fieldType");
            Param.Ignore(unsafeCode);

            this.fieldType.Value = fieldType;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether the field is declared const.
        /// </summary>
        public bool Const
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.isConst.Initialized)
                {
                    this.isConst.Value = this.ContainsModifier(TokenType.Const);
                }

                return this.isConst.Value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the field is declared readonly.
        /// </summary>
        [SuppressMessage(
            "Microsoft.Naming", 
            "CA1702:CompoundWordsShouldBeCasedCorrectly", 
            MessageId = "Readonly",
            Justification = "API has already been published and should not be changed.")]
        public bool Readonly
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.isReadOnly.Initialized)
                {
                    this.isReadOnly.Value = this.ContainsModifier(TokenType.Readonly);
                }

                return this.isReadOnly.Value;
            }
        }

        /// <summary>
        /// Gets the type of the field.
        /// </summary>
        public TypeToken FieldType
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.fieldType.Initialized)
                {
                    this.fieldType.Value = this.FindFirstChild<TypeToken>();
                }

                return this.fieldType.Value;
            }
        }

        /// <summary>
        /// Gets the variable declaration statement within this field.
        /// </summary>
        public VariableDeclarationStatement VariableDeclarationStatement
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.statement.Initialized)
                {
                    this.statement.Value = this.FindNext<VariableDeclarationStatement>();
                }

                return this.statement.Value;
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
                return CodeParser.FieldModifiers;
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
            // For a field, the name of the first variable declarator is the name of the field.
            VariableDeclaratorExpression declarator = this.FindFirstDescendent<VariableDeclaratorExpression>();
            if (declarator != null)
            {
                return declarator.Identifier.Text;
            }

            throw new SyntaxException(this.Document, this.LineNumber);
        }

        /// <summary>
        /// Resets the contents of the class.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();

            this.fieldType.Reset();
            this.isConst.Reset();
            this.isReadOnly.Reset();
            this.statement.Reset();
        }

        #endregion Protected Override Methods
    }
}
