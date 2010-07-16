//-----------------------------------------------------------------------
// <copyright file="QueryFromClause.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
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

    /// <summary>
    /// Describes a from clause in a query expression.
    /// </summary>
    public sealed class QueryFromClause : QueryClause
    {
        #region Private Fields

        /// <summary>
        /// The variable defined in the clause.
        /// </summary>
        private CodeUnitProperty<IVariable> rangeVariable;

        /// <summary>
        /// The variables within the clause.
        /// </summary>
        private CodeUnitProperty<IList<IVariable>> variables;

        /// <summary>
        /// The range expression.
        /// </summary>
        private CodeUnitProperty<Expression> expression;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the QueryFromClause class.
        /// </summary>
        /// <param name="proxy">Proxy object for the clause.</param>
        /// <param name="expression">The range expression.</param>
        internal QueryFromClause(CodeUnitProxy proxy, Expression expression) 
            : base(proxy, QueryClauseType.From)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(expression, "expression");

            this.expression.Value = expression;
        }

        #endregion Internal Constructors

        #region Public Override Properties

        /// <summary>
        /// Gets the variables defined within this clause.
        /// </summary>
        public override IList<IVariable> Variables
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.variables.Initialized)
                {
                    IVariable rangeVariable = this.RangeVariable;
                    if (rangeVariable != null)
                    {
                        this.variables.Value = new IVariable[] { rangeVariable };
                    }
                    else
                    {
                        this.variables.Value = CsParser.EmptyVariableArray;
                    }
                }

                return this.variables.Value;
            }
        }

        /// <summary>
        /// Gets the range expression.
        /// </summary>
        public Expression Expression
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.expression.Initialized)
                {
                    this.Initialize();
                    Debug.Assert(this.expression.Value != null, "Failed to initialize");
                }

                return this.expression.Value;
            }
        }

        #endregion Public Override Properties

        #region Public Properties

        /// <summary>
        /// Gets the variable that ranges over the values in the query result.
        /// </summary>
        public IVariable RangeVariable
        {
            get 
            {
                this.ValidateEditVersion();

                if (!this.rangeVariable.Initialized)
                {
                    this.Initialize();
                    Debug.Assert(this.rangeVariable.Value != null, "Failed to initialize");
                }

                return this.rangeVariable.Value;
            }
        }

        #endregion Public Properties

        #region Protected Override Methods

        /// <summary>
        /// Resets the contents of the class.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();

            this.rangeVariable.Reset();
            this.variables.Reset();
        }

        #endregion Protected Override Methods

        #region Private Methods

        /// <summary>
        /// Initializes the contents of the class.
        /// </summary>
        private void Initialize()
        {
            FromToken fromToken = this.FindFirstChild<FromToken>();
            if (fromToken == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            this.rangeVariable.Value = ExtractQueryVariable(fromToken.FindNextSibling<Token>(), true, false);
            if (this.rangeVariable.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            InToken @in = fromToken.FindNextSibling<InToken>();
            if (@in == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            this.expression.Value = @in.FindNextSibling<Expression>();
            if (this.expression.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }
        }

        #endregion Private Methods
    }
}
