//-----------------------------------------------------------------------
// <copyright file="EventDeclaratorExpression.cs" company="Microsoft">
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

    /// <summary>
    /// A single declarator within a event.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed partial class EventDeclaratorExpression : Expression
    {
        #region Private Fields

        /// <summary>
        /// The identifier of the event.
        /// </summary>
        private LiteralExpression identifier;

        /// <summary>
        /// The initialization expression for the event.
        /// </summary>
        private Expression initializer;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the EventDeclaratorExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="identifier">The identifier name of the event.</param>
        /// <param name="initializer">The initialization expression for the event.</param>
        internal EventDeclaratorExpression(
            CodeUnitProxy proxy,
            LiteralExpression identifier, 
            Expression initializer)
            : base(proxy, ExpressionType.EventDeclarator)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(identifier, "identifier");
            Param.Ignore(initializer);

            this.identifier = identifier;
            this.initializer = initializer;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the identifier name of the event.
        /// </summary>
        public LiteralExpression Identifier
        {
            get
            {
                return this.identifier;
            }
        }

        /// <summary>
        /// Gets the initialization statement for the event.
        /// </summary>
        public Expression Initializer
        {
            get
            {
                return this.initializer;
            }
        }

        #endregion Public Properties
    }

    /*
    /// <content>
    /// Implements the IVariable interface.
    /// </content>
    public partial class EventDeclaratorExpression //: IVariable
    {
        #region Public Properties 

        /// <summary>
        /// Gets the variable name.
        /// </summary>
        public string VariableName
        {
            get
            {
                return this.identifier == null ? null : this.identifier.Text;
            }
        }

        /// <summary>
        /// Gets the variable type.
        /// </summary>
        public TypeToken VariableType
        {
            get
            {
                Event @event = this.Parent as Event;
                if (@event != null)
                {
                    return @event.EventHandlerType;
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the modifiers applied to this variable.
        /// </summary>
        public VariableModifiers VariableModifiers
        {
            get
            {
                VariableModifiers modifiers = VariableModifiers.None;

                VariableDeclarationStatement parent = this.FindParent<Statement>() as VariableDeclarationStatement;
                if (parent != null && parent.Constant)
                {
                    modifiers = VariableModifiers.Const;
                }

                return modifiers;
            }
        }

        #endregion Public Methods
    }
     * */
}
