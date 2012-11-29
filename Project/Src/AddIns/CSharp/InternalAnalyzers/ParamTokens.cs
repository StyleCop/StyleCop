// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParamTokens.cs" company="http://stylecop.codeplex.com">
//   MS-PL
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
// <summary>
//   Contains tokens inside of a <c>Param</c> statement.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.Internal
{
    using System.Collections.Generic;

    using StyleCop.CSharp;

    /// <summary>
    /// Contains tokens inside of a <c>Param</c> statement.
    /// </summary>
    internal class ParamTokens
    {
        #region Fields

        /// <summary>
        /// The parameter check token.
        /// </summary>
        private readonly Node<CsToken> paramTokenNode;

        /// <summary>
        /// The tokens that make up the parameter.
        /// </summary>
        private readonly ICollection<Node<CsToken>> tokenNodes;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ParamTokens"/> class.
        /// </summary>
        /// <param name="paramTokenNode">
        /// The check token node.
        /// </param>
        /// <param name="tokenNodes">
        /// The token node collection.
        /// </param>
        public ParamTokens(Node<CsToken> paramTokenNode, ICollection<Node<CsToken>> tokenNodes)
        {
            Param.AssertNotNull(paramTokenNode, "paramToken");
            Param.AssertNotNull(tokenNodes, "tokenNodes");

            this.paramTokenNode = paramTokenNode;
            this.tokenNodes = tokenNodes;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the node.
        /// </summary>
        public Node<CsToken> ParamTokenNode
        {
            get
            {
                return this.paramTokenNode;
            }
        }

        /// <summary>
        /// Gets the token nodes collection.
        /// </summary>
        public ICollection<Node<CsToken>> TokenNodes
        {
            get
            {
                return this.tokenNodes;
            }
        }

        #endregion
    }
}