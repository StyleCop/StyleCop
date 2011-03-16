//-----------------------------------------------------------------------
// <copyright file="Delegate.cs">
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
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Describes a delegate element.
    /// </summary>
    /// <subcategory>element</subcategory>
    [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", Justification = "The class describes a C# delegate.")]
    [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix", Justification = "The class should not have any suffix.")]
    public sealed class Delegate : Element, ITypeConstraintContainer
    {
        #region Private Fields

        /// <summary>
        /// The delegate's return type.
        /// </summary>
        private CodeUnitProperty<TypeToken> returnType;

        /// <summary>
        /// The delegate's input parameters.
        /// </summary>
        private CodeUnitProperty<ParameterList> parameterList;

        /// <summary>
        /// The list if type constraints on the item, if any.
        /// </summary>
        private CodeUnitProperty<ICollection<TypeParameterConstraintClause>> typeConstraints;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the Delegate class.
        /// </summary>
        /// <param name="proxy">Proxy object for the delegate.</param>
        /// <param name="name">The name of the delegate.</param>
        /// <param name="attributes">The list of attributes attached to this element.</param>
        /// <param name="returnType">The return type.</param>
        /// <param name="typeConstraints">The list of type constraints on the element.</param>
        /// <param name="unsafeCode">Indicates whether the element resides within a block of unsafe code.</param>
        internal Delegate(CodeUnitProxy proxy, string name, ICollection<Attribute> attributes, TypeToken returnType, ICollection<TypeParameterConstraintClause> typeConstraints, bool unsafeCode)
            : base(proxy, ElementType.Delegate, name, attributes, unsafeCode)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertValidString(name, "name");
            Param.Ignore(attributes);
            Param.AssertNotNull(returnType, "returnType");
            Param.Ignore(typeConstraints);
            Param.Ignore(unsafeCode);

            this.returnType.Value = returnType;

            this.typeConstraints.Value = typeConstraints ?? TypeParameterConstraintClause.EmptyTypeParameterConstraintClause;
            CsLanguageService.Debug.Assert(typeConstraints == null || typeConstraints.IsReadOnly, "Must be a read-only collection.");
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
                return CodeParser.AddQualifications(this.ParameterList.Parameters, base.FullyQualifiedName);
            }
        }

        #endregion Public Override Properties

        #region Public Properties

        /// <summary>
        /// Gets the delegate's return type.
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
        /// Gets the list of input parameters in the delegate's declaration.
        /// </summary>
        public ParameterList ParameterList
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.parameterList.Initialized)
                {
                    this.parameterList.Value = this.FindFirstChild<ParameterList>();
                }

                return this.parameterList.Value;
            }
        }

        /// <summary>
        /// Gets the list of type constraints on the delegate, if any.
        /// </summary>
        public ICollection<TypeParameterConstraintClause> TypeConstraints
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.typeConstraints.Initialized)
                {
                    this.typeConstraints.Value = new List<TypeParameterConstraintClause>(this.GetChildren<TypeParameterConstraintClause>()).AsReadOnly();
                }

                return this.typeConstraints.Value;
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
                return CodeParser.DelegateModifiers;
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
            // Get the return type.
            TypeToken returnType = this.FindFirstChild<TypeToken>();
            if (returnType != null)
            {
                // The next Token is the name.
                Token nameToken = returnType.FindNextSiblingToken();
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

            this.returnType.Reset();
            this.parameterList.Reset();
            this.typeConstraints.Reset();
        }

        #endregion Protected Override Methods
    }
}
