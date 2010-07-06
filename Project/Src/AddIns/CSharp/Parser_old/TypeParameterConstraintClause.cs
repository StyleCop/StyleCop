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
namespace Microsoft.StyleCop.CSharp_old
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Describes a type constraint clause within a C# file.
    /// </summary>
    /// <subcategory>other</subcategory>
    public class TypeParameterConstraintClause : ICodePart
    {
        #region Private Fields

        /// <summary>
        /// The parent element that contains this constraint.
        /// </summary>
        private CsElement parentElement;

        /// <summary>
        /// The token list for the constraint.
        /// </summary>
        private CsTokenList tokens;

        /// <summary>
        /// The type being constrainted.
        /// </summary>
        private CsToken type;

        /// <summary>
        /// The list of constraints on the type.
        /// </summary>
        private ICollection<CsToken> constraints;

        /// <summary>
        /// The parent of the constraint clause.
        /// </summary>
        private Reference<ICodePart> parent;

        #endregion Private Fields

        #region Internal Contructors

        /// <summary>
        /// Initializes a new instance of the TypeParameterConstraintClause class.
        /// </summary>
        /// <param name="tokens">The list of tokens that form the constraint.</param>
        /// <param name="type">The type being constrainted.</param>
        /// <param name="constraints">The list of constraints on the type, if any.</param>
        /// <param name="parent">The parent of the constraint clause.</param>
        internal TypeParameterConstraintClause(CsTokenList tokens, CsToken type, ICollection<CsToken> constraints, Reference<ICodePart> parent)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(type, "type");
            Param.Ignore(constraints);
            Param.AssertNotNull(parent, "parent");
            
            this.tokens = tokens;
            this.type = type;
            this.constraints = constraints;
            this.parent = parent;

            Debug.Assert(this.constraints == null || this.constraints.IsReadOnly, "Constraints must be read-only");

            this.tokens.Trim();
            Debug.Assert(this.tokens.First != null, "The type parameter constraint claus should not be empty.");
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the list of tokens that form the constraint.
        /// </summary>
        public CsTokenList Tokens
        {
            get
            {
                return this.tokens;
            }
        }

        /// <summary>
        /// Gets the type of this code part.
        /// </summary>
        public CodePartType CodePartType
        {
            get
            {
                return CodePartType.ConstraintClause;
            }
        }

        /// <summary>
        /// Gets the type being constrainted.
        /// </summary>
        [SuppressMessage(
            "Microsoft.Naming", 
            "CA1721:PropertyNamesShouldNotMatchGetMethods",
            Justification = "API has already been published and should not be changed.")]
        public CsToken Type
        {
            get
            {
                return this.type;
            }
        }

        /// <summary>
        /// Gets the list of constraints on the type, if any.
        /// </summary>
        public ICollection<CsToken> Constraints
        {
            get
            {
                return this.constraints;
            }
        }

        /// <summary>
        /// Gets the parent element that contains this type constraint.
        /// </summary>
        public CsElement ParentElement
        {
            get
            {
                return this.parentElement;
            }

            internal set
            {
                this.parentElement = value;
            }
        }

        /// <summary>
        /// Gets the parent of the constraint clause.
        /// </summary>
        public ICodePart Parent
        {
            get
            {
                return this.parent.Target;
            }
        }

        /// <summary>
        /// Gets the line number that the clause begins on.
        /// </summary>
        public int LineNumber
        {
            get
            {
                if (this.tokens.First != null)
                {
                    return this.tokens.First.Value.LineNumber;
                }

                return 0;
            }
        }

        /// <summary>
        /// Gets the location of the clause.
        /// </summary>
        public CodeLocation Location
        {
            get
            {
                return CsToken.JoinLocations(this.tokens.First, this.tokens.Last);
            }
        }

        #endregion Public Properties
    }
}
