//-----------------------------------------------------------------------
// <copyright file="TypeParameterConstraintClause.cs" company="Microsoft">
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
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Describes a type constraint clause within a C# file.
    /// </summary>
    /// <subcategory>other</subcategory>
    public sealed class TypeParameterConstraintClause : CodeUnit
    {
        #region Private Fields

        /// <summary>
        /// The type being constrainted.
        /// </summary>
        private Token type;

        /// <summary>
        /// The list of constraints on the type.
        /// </summary>
        private ICollection<Token> constraints;

        #endregion Private Fields

        #region Internal Contructors

        /// <summary>
        /// Initializes a new instance of the TypeParameterConstraintClause class.
        /// </summary>
        /// <param name="proxy">Proxy object for the query clause.</param>
        /// <param name="type">The type being constrainted.</param>
        /// <param name="constraints">The list of constraints on the type, if any.</param>
        internal TypeParameterConstraintClause(CodeUnitProxy proxy, Token type, ICollection<Token> constraints) 
            : base(proxy, CodeUnitType.TypeParameterConstraintClause)
        {
            Param.Ignore(proxy);
            Param.AssertNotNull(type, "type");
            Param.Ignore(constraints);
            
            this.type = type;
            this.constraints = constraints;
            Debug.Assert(this.constraints == null || this.constraints.IsReadOnly, "Constraints must be read-only");
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the type being constrainted.
        /// </summary>
        [SuppressMessage(
            "Microsoft.Naming", 
            "CA1721:PropertyNamesShouldNotMatchGetMethods",
            Justification = "API has already been published and should not be changed.")]
        public Token Type
        {
            get
            {
                return this.type;
            }
        }

        /// <summary>
        /// Gets the list of constraints on the type, if any.
        /// </summary>
        public ICollection<Token> Constraints
        {
            get
            {
                return this.constraints;
            }
        }

        #endregion Public Properties
    }
}
