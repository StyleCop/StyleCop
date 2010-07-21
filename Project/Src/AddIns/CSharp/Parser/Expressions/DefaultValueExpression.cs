//-----------------------------------------------------------------------
// <copyright file="DefaultValueExpression.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
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
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// An expression representing a default value operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class DefaultValueExpression : Expression
    {
        #region Private Fields

        /// <summary>
        /// The type to obtain the default value of.
        /// </summary>
        private TypeToken type;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the DefaultValueExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="type">The type to obtain the default value of.</param>
        internal DefaultValueExpression(CodeUnitProxy proxy, LiteralExpression type)
            : base(proxy, ExpressionType.DefaultValue)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(type, "type");

            this.type = CodeParser.ExtractTypeTokenFromLiteralExpression(type);
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the type to obtain the default value of.
        /// </summary>
        [SuppressMessage(
            "Microsoft.Naming", 
            "CA1721:PropertyNamesShouldNotMatchGetMethods",
            Justification = "API has already been published and should not be changed.")]
        public TypeToken Type
        {
            get
            {
                return this.type;
            }
        }

        #endregion Public Properties
    }
}
