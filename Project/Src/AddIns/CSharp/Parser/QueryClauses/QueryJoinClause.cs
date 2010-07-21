//-----------------------------------------------------------------------
// <copyright file="QueryJoinClause.cs" company="Microsoft">
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
    /// Describes a join clause in a query expression.
    /// </summary>
    public sealed class QueryJoinClause : QueryClause
    {
        #region Private Fields

        /// <summary>
        /// The expression after the 'in' keyword.
        /// </summary>
        private CodeUnitProperty<Expression> inExpression;

        /// <summary>
        /// The expression after the 'on' keyword.
        /// </summary>
        private CodeUnitProperty<Expression> onKeyExpression;

        /// <summary>
        /// The expression after the 'equals' keyword.
        /// </summary>
        private CodeUnitProperty<Expression> equalsKeyExpression;

        /// <summary>
        /// The variable.
        /// </summary>
        private CodeUnitProperty<IVariable> rangeVariable;

        /// <summary>
        /// The into variable.
        /// </summary>
        private CodeUnitProperty<IVariable> intoVariable;
        
        /// <summary>
        /// The variables declared within the clause.
        /// </summary>
        private CodeUnitProperty<IList<IVariable>> variables;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the QueryJoinClause class.
        /// </summary>
        /// <param name="proxy">Proxy object for the clause.</param>
        /// <param name="inExpression">The expression after the 'in' keyword.</param>
        /// <param name="onKeyExpression">The expression after the 'on' keyword.</param>
        /// <param name="equalsKeyExpression">The expression after the 'equals' keyword.</param>
        internal QueryJoinClause(
            CodeUnitProxy proxy,
            Expression inExpression, 
            Expression onKeyExpression,
            Expression equalsKeyExpression)
            : base(proxy, QueryClauseType.Join)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(inExpression, "inExpression");
            Param.AssertNotNull(onKeyExpression, "onKeyExpression");
            Param.AssertNotNull(equalsKeyExpression, "equalsKeyExpression");

            this.inExpression.Value = inExpression;
            this.onKeyExpression.Value = onKeyExpression;
            this.equalsKeyExpression.Value = equalsKeyExpression;
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
                    IVariable intoVariable = this.IntoVariable;

                    if (rangeVariable != null)
                    {
                        if (intoVariable != null)
                        {
                            this.variables.Value = new IVariable[] { rangeVariable, intoVariable };
                        }
                        else
                        {
                            this.variables.Value = new IVariable[] { rangeVariable };
                        }
                    }
                    else if (intoVariable != null)
                    {
                        this.variables.Value = new IVariable[] { intoVariable };
                    }
                    else
                    {
                        this.variables.Value = CsParser.EmptyVariableArray;
                    }
                }

                return this.variables.Value;
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
                    Debug.Assert(this.rangeVariable.Value == null, "Failed to initialize");
                }

                return this.rangeVariable.Value;
            }
        }

        /// <summary>
        /// Gets the expression after the 'in' keyword.
        /// </summary>
        public Expression InExpression
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.inExpression.Initialized)
                {
                    this.Initialize();
                    Debug.Assert(this.inExpression.Value == null, "Failed to initialize");
                }

                return this.inExpression.Value;
            }
        }

        /// <summary>
        /// Gets the expression after the 'on' keyword.
        /// </summary>
        public Expression OnKeyExpression
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.onKeyExpression.Initialized)
                {
                    this.Initialize();
                    Debug.Assert(this.onKeyExpression.Value == null, "Failed to initialize");
                }

                return this.onKeyExpression.Value;
            }
        }

        /// <summary>
        /// Gets the expression after the 'equals' keyword.
        /// </summary>
        public Expression EqualsKeyExpression
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.equalsKeyExpression.Initialized)
                {
                    this.Initialize();
                    Debug.Assert(this.equalsKeyExpression.Value == null, "Failed to initialize");
                }

                return this.equalsKeyExpression.Value;
            }
        }

        /// <summary>
        /// Gets the optional variable that the result is placed into.
        /// </summary>
        public IVariable IntoVariable
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.intoVariable.Initialized)
                {
                    this.Initialize();
                    Debug.Assert(this.intoVariable.Value == null, "Failed to initialize");
                }

                return this.intoVariable.Value;
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

            this.inExpression.Reset();
            this.onKeyExpression.Reset();
            this.equalsKeyExpression.Reset();
            this.rangeVariable.Reset();
            this.intoVariable.Reset();
            this.variables.Reset();
        }

        #endregion Protected Override Methods

        #region Private Methods

        /// <summary>
        /// Initializes the contents of the class.
        /// </summary>
        private void Initialize()
        {
            JoinToken @join = this.FindFirstChild<JoinToken>();
            if (@join == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            Token token = @join.FindNextSibling<Token>();
            if (token == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            this.rangeVariable.Value = ExtractQueryVariable(token, true, false);
            if (this.rangeVariable.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            InToken @in = token.FindNextSibling<InToken>();
            if (@in == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            this.inExpression.Value = @in.FindNextSibling<Expression>();
            if (this.inExpression.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }
            
            OnToken @on = this.inExpression.Value.FindNextSibling<OnToken>();
            if (@on == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            this.onKeyExpression.Value = @on.FindNextSibling<Expression>();
            if (this.onKeyExpression.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            EqualsToken equals = this.onKeyExpression.Value.FindNextSibling<EqualsToken>();
            if (equals == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            this.equalsKeyExpression.Value = equals.FindNextSibling<Expression>();
            if (this.equalsKeyExpression.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            this.intoVariable.Value = null;
            for (CodeUnit c = this.equalsKeyExpression.Value.FindNextSibling<CodeUnit>(); c != null; c = c.FindNextSibling<CodeUnit>())
            {
                if (c.Is(TokenType.Into))
                {
                    token = c.FindNextSibling<Token>();
                    if (token == null)
                    {
                        throw new SyntaxException(this.Document, this.LineNumber);
                    }

                    this.intoVariable.Value = ExtractQueryVariable(token, true, false);
                    if (this.intoVariable.Value == null)
                    {
                        throw new SyntaxException(this.Document, this.LineNumber);
                    }

                    break;
                }
                else if (!c.Is(CodeUnitType.LexicalElement) || c.Is(LexicalElementType.Token))
                {
                    break;
                }
            }
        }

        #endregion Private Methods
    }
}
