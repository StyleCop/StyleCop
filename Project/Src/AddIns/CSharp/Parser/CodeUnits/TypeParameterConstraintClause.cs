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
    using System;
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
        internal TypeParameterConstraintClause(CodeUnitProxy proxy) 
            : base(proxy, CodeUnitType.TypeParameterConstraintClause)
        {
            Param.Ignore(proxy);
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
                this.ValidateEditVersion();
                if (this.type == null)
                {
                    // Find the where token.
                    Token where = this.FindFirstChild<WhereToken>();
                    if (where != null)
                    {
                        this.type = where.FindNextSibling<TypeToken>();
                    }

                    if (this.type == null)
                    {
                        throw new SyntaxException(this.Document, this.LineNumber);
                    }
                }
                
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
                this.ValidateEditVersion();
                if (this.constraints == null)
                {
                    List<Token> constraints = new List<Token>(2);

                    // Find the colon.
                    CodeUnit colon = this.FindFirstChild<WhereColonToken>();
                    if (colon != null)
                    {
                        for (Token constraint = colon.FindNextSibling<Token>(); constraint != null; constraint = constraint.FindNextSibling<Token>())
                        {
                            constraints.Add(constraint);
                        }

                        if (constraints.Count > 0)
                        {
                            this.constraints = constraints.AsReadOnly();
                        }
                    }

                    if (this.constraints == null)
                    {
                        throw new SyntaxException(this.Document, this.LineNumber);
                    }
                }

                return this.constraints;
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

            this.type = null;
            this.constraints = null;
        }

        #endregion Protected Override Methods
    }
}
