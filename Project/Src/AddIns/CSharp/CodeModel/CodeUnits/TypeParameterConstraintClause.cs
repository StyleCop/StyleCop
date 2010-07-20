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
namespace Microsoft.StyleCop.CSharp.CodeModel
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
        #region Internal Static Readonly Fields

        /// <summary>
        /// An empty array of type constraint clauses.
        /// </summary>
        internal static readonly TypeParameterConstraintClause[] EmptyTypeParameterConstraintClause = new TypeParameterConstraintClause[] { };

        #endregion Internal Static Readonly Fields

        #region Private Fields

        /// <summary>
        /// The type being constrainted.
        /// </summary>
        private CodeUnitProperty<Token> type;

        /// <summary>
        /// The list of constraints on the type.
        /// </summary>
        private CodeUnitProperty<ICollection<Token>> constraints;

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
                
                if (!this.type.Initialized)
                {
                    // Find the where token.
                    Token where = this.FindFirstChild<WhereToken>();
                    if (where != null)
                    {
                        this.type.Value = where.FindNextSibling<TypeToken>();
                    }

                    if (this.type.Value == null)
                    {
                        throw new SyntaxException(this.Document, this.LineNumber);
                    }
                }
                
                return this.type.Value;
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

                if (!this.constraints.Initialized)
                {
                    this.constraints.Value = null;

                    List<Token> c = new List<Token>(2);

                    // Find the colon.
                    CodeUnit colon = this.FindFirstChild<WhereColonToken>();
                    if (colon != null)
                    {
                        for (Token constraint = colon.FindNextSibling<Token>(); constraint != null; constraint = constraint.FindNextSibling<Token>())
                        {
                            c.Add(constraint);
                        }

                        if (c.Count > 0)
                        {
                            this.constraints.Value = c.AsReadOnly();
                        }
                    }

                    if (this.constraints.Value == null)
                    {
                        throw new SyntaxException(this.Document, this.LineNumber);
                    }
                }

                return this.constraints.Value;
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

            this.type.Reset();
            this.constraints.Reset();
        }

        #endregion Protected Override Methods
    }
}
