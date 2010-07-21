//-----------------------------------------------------------------------
// <copyright file="ParamTokens.cs" company="Microsoft">
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
namespace Microsoft.StyleCop.Internal
{
    using System;
    using System.Collections.Generic;
    using Microsoft.StyleCop.CSharp;

    /// <summary>
    /// Contains tokens inside of a Param statement.
    /// </summary>
    internal class ParamTokens
    {
        #region Private Fields

        /// <summary>
        /// The parameter check token.
        /// </summary>
        private Node<CsToken> paramTokenNode;

        /// <summary>
        /// The tokens that make up the parameter.
        /// </summary>
        private ICollection<Node<CsToken>> tokenNodes;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the ParamTokens class.
        /// </summary>
        /// <param name="paramTokenNode">The param check token node.</param>
        /// <param name="tokenNodes">The token node collection.</param>
        public ParamTokens(Node<CsToken> paramTokenNode, ICollection<Node<CsToken>> tokenNodes)
        {
            Param.AssertNotNull(paramTokenNode, "paramToken");
            Param.AssertNotNull(tokenNodes, "tokenNodes");

            this.paramTokenNode = paramTokenNode;
            this.tokenNodes = tokenNodes;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets the param token node.
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

        #endregion Public Properties
    }
}
