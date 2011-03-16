//-----------------------------------------------------------------------
// <copyright file="Statement.cs">
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
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// A single statement within a code file or element.
    /// </summary>
    public abstract class Statement : CodeUnit
    {
        #region Internal Static Fields

        /// <summary>
        /// An empty array of statements.
        /// </summary>
        internal static readonly Statement[] EmptyStatementArray = new Statement[] { };

        #endregion Internal Static Fields
        
        #region Private Static Fields

        /// <summary>
        /// An empty array of statements.
        /// </summary>
        private static Statement[] emptyStatementArray = new Statement[0];

        #endregion Private Static Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the Statement class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        /// <param name="type">The type of the statement.</param>
        internal Statement(CodeUnitProxy proxy, StatementType type) 
            : base(proxy, (int)type)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.Ignore(type);
            CsLanguageService.Debug.Assert(System.Enum.IsDefined(typeof(StatementType), this.StatementType), "The type is invalid.");
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the type of the statement.
        /// </summary>
        public StatementType StatementType
        {
            get
            {
                return (StatementType)(this.FundamentalType & (int)FundamentalTypeMasks.Statement);
            }
        }

        /// <summary>
        /// Gets the friendly name of the element type, which can be used in user output.
        /// </summary>
        public string FriendlyTypeText
        {
            get
            {
                return this.FriendlyTypeTextBase;
            }
        }

        /// <summary>
        /// Gets the pluralized friendly name of the element type, which can be used in user output.
        /// </summary>
        public string FriendlyPluralTypeText
        {
            get
            {
                return this.FriendlyPluralTypeTextBase;
            }
        }

        #endregion Public Properties

        #region Public Virtual Properties

        /// <summary>
        /// Gets the collection of statements which are attached to the end of this statement.
        /// </summary>
        /// <remarks>Examples of attached statements are the else-statements
        /// attached to an if-statement, or the catch statements attached to a try-statement.</remarks>
        public virtual ICollection<Statement> AttachedStatements
        {
            get
            {
                return emptyStatementArray;
            }
        }

        #endregion Public Virtual Properties
    }
}
