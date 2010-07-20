//-----------------------------------------------------------------------
// <copyright file="QueryClause.cs" company="Microsoft">
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

    /// <summary>
    /// The base class for all query clauses.
    /// </summary>
    public abstract class QueryClause : CodeUnit
    {
        #region Internal Static Fields

        /// <summary>
        /// An empty array of query clauses.
        /// </summary>
        internal static readonly QueryClause[] EmptyQueryClauseArray = new QueryClause[] { };

        #endregion Internal Static Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the QueryClause class.
        /// </summary>
        /// <param name="proxy">Proxy object for the query clause.</param>
        /// <param name="type">The type of the clause.</param>
        internal QueryClause(CodeUnitProxy proxy,  QueryClauseType type) 
            : base(proxy, (int)type)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.Ignore(type);
            Debug.Assert(System.Enum.IsDefined(typeof(QueryClauseType), this.QueryClauseType), "The type is invalid.");
        }

        #endregion Internal Constructors

        #region Public Virtual Properties

        /// <summary>
        /// Gets the variables defined within this code unit.
        /// </summary>
        public virtual IList<IVariable> Variables
        {
            get
            {
                return CsLanguageService.EmptyVariableArray;
            }
        }

        #endregion Public Virtual Properties

        #region Public Properties

        /// <summary>
        /// Gets the type of the query clause.
        /// </summary>
        public QueryClauseType QueryClauseType
        {
            get
            {
                return (QueryClauseType)(this.FundamentalType & (int)FundamentalTypeMasks.QueryClause);
            }
        }

        #endregion Public Properties

        #region Protected Static Methods

        /// <summary>
        /// Extracts a variable from the clause.
        /// </summary>
        /// <param name="firstToken">The first token of the variable.</param>
        /// <param name="allowTypelessVariable">Indicates whether to allow a variable with no type defined.</param>
        /// <param name="onlyTypelessVariable">Indicates whether to only get a typeless variable.</param>
        /// <returns>Returns the variable.</returns>
        protected static QueryClauseVariable ExtractQueryVariable(Token firstToken, bool allowTypelessVariable, bool onlyTypelessVariable)
        {
            Param.RequireNotNull(firstToken, "firstToken");
            Param.Ignore(allowTypelessVariable);
            Param.Ignore(onlyTypelessVariable);

            if (onlyTypelessVariable || !firstToken.Is(TokenType.Type))
            {
                // In this case there is no type, only an identifier.
                return new QueryClauseVariable(null, firstToken.Text, firstToken.Location, firstToken.Generated);
            }
            else
            {
                TypeToken type = (TypeToken)firstToken;

                // Attempt to get the identifier token coming after the type token.
                Token identifier = firstToken.FindNextSibling<Token>();
                if (identifier == null || identifier.TokenType != TokenType.Literal)
                {
                    Debug.Assert(allowTypelessVariable, "The clause does not allow typeless variables. The parser should have thrown syntax exception already.");
                    return new QueryClauseVariable(null, type.Text, type.Location, type.Generated);
                }
                else
                {
                    // There is a type and an identifier.
                    return new QueryClauseVariable(type, identifier.Text, CodeUnit.JoinLocations(type, identifier), type.Generated || identifier.Generated);
                }
            }
        }

        #endregion Protected Static Methods

        #region Protected Classes

        /// <summary>
        /// A variable defined within a query clause.
        /// </summary>
        protected class QueryClauseVariable : IVariable
        {
            #region Private Fields

            /// <summary>
            /// The variable type.
            /// </summary>
            private TypeToken type;

            /// <summary>
            /// The variable name.
            /// </summary>
            private string name;

            /// <summary>
            /// The location of the variable.
            /// </summary>
            private CodeLocation location;

            /// <summary>
            /// Indicates whether the variable is located within a block of generated code.
            /// </summary>
            private bool generated;

            #endregion Private Fields

            #region Internal Constructors

            /// <summary>
            /// Initializes a new instance of the QueryClauseVariable class.
            /// </summary>
            /// <param name="type">The type of the variable.</param>
            /// <param name="name">The name of the variable.</param>
            /// <param name="location">The location of the variable.</param>
            /// <param name="generated">Indicates whethre the variable is located within a block of generated code.</param>
            internal QueryClauseVariable(TypeToken type, string name, CodeLocation location, bool generated)
            {
                Param.Ignore(type);
                Param.RequireValidString(name, "name");
                Param.RequireNotNull(location, "location");
                Param.Ignore(generated);

                this.type = type;
                this.name = name;
                this.location = location;
                this.generated = generated;
            }

            #endregion Internal Constructors

            #region Public Properties

            /// <summary>
            /// Gets the variable name.
            /// </summary>
            public string VariableName
            {
                get { return this.name; }
            }

            /// <summary>
            /// Gets the variable type.
            /// </summary>
            public TypeToken VariableType
            {
                get { return this.type; }
            }

            /// <summary>
            /// Gets the modifiers applied to this variable.
            /// </summary>
            public VariableModifiers VariableModifiers
            {
                get { return VariableModifiers.None; }
            }

            /// <summary>
            /// Gets the location of the variable.
            /// </summary>
            public CodeLocation Location
            {
                get { return this.location; }
            }

            /// <summary>
            /// Gets a value indicating whether the variable is located within a block of generated code.
            /// </summary>
            public bool Generated
            {
                get { return this.generated; }
            }

            #endregion Public Properties
        }

        #endregion Protected Classes
    }
}
