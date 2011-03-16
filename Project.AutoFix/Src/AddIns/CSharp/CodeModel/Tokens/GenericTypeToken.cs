//-----------------------------------------------------------------------
// <copyright file="GenericTypeToken.cs">
//     MS-PL
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
    using System.Text;

    /// <summary>
    /// Describes a generic type token.
    /// </summary>
    /// <subcategory>token</subcategory>
    [SuppressMessage("Microsoft.Maintainability", "CA1501:AvoidExcessiveInheritance", Justification = "C# syntax is deeply hierarchical")]
    public sealed class GenericTypeToken : TypeToken
    {
        #region Private Fields

        /// <summary>
        /// The types within the generic type.
        /// </summary>
        private CodeUnitProperty<GenericTypeParameterList> types;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the GenericTypeToken class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        internal GenericTypeToken(CodeUnitProxy proxy)
            : base(proxy)
        {
            Param.AssertGreaterThanOrEqualTo(proxy.Children.Count, 3, "childTokens");

            this.IsGeneric = true;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the types within the generic type.
        /// </summary>
        public ICollection<GenericTypeParameter> GenericTypes
        {
            get
            {
                GenericTypeParameterList list = this.GenericTypeList;
                if (list == null)
                {
                    return GenericTypeParameter.EmptyGenericTypeParameterArray;
                }

                return list.Parameters;
            }
        }

        /// <summary>
        /// Gets the generic type list within this token.
        /// </summary>
        public GenericTypeParameterList GenericTypeList
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.types.Initialized)
                {
                    this.types.Value = this.FindFirstChild<GenericTypeParameterList>();
                }

                return this.types.Value;
            }
        }

        #endregion Public Properties

        #region Protected Override Methods

        /// <summary>
        /// Resets the contents of the item.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();

            this.types.Reset();
        }

        #endregion Protected Override Methods
    }
}
