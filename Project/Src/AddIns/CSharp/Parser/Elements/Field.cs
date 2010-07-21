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
namespace Microsoft.StyleCop.CSharp
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
        private TypeToken type;

        /// <summary>
        /// Indicates whether the item is declared const.
        /// </summary>
        private bool isConst;

        /// <summary>
        /// Indicates whether the item is declared readonly.
        /// </summary>
        private bool isReadOnly;

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

            this.type = fieldType;

            // Determine whether the item is const or readonly.
            this.isConst = this.ContainsModifier(TokenType.Const);
            this.isReadOnly = this.ContainsModifier(TokenType.Readonly);
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
                return this.isConst;
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
                return this.isReadOnly;
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
        /// Gets the variable declaration statement within this field.
        /// </summary>
        public VariableDeclarationStatement VariableDeclarationStatement
        {
            get
            {
                return this.FindNext<VariableDeclarationStatement>();
            }

            /*
            internal set
            {
                this.declaration = value;
            }
             */
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

        #region Public Override Methods

        /// <summary>
        /// Gets the variables defined within this element.
        /// </summary>
        /// <returns>Returns the collection of variables.</returns>
        public override IList<IVariable> GetVariables()
        {
            VariableDeclarationStatement declarationStatement = this.VariableDeclarationStatement;
            if (declarationStatement == null)
            {
                return CsParser.EmptyVariableArray;
            }

            return declarationStatement.GetVariables();
        }

        #endregion Public Override Methods
    }
}
