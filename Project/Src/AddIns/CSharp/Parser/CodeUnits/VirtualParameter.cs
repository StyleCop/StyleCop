//-----------------------------------------------------------------------
// <copyright file="ICodeUnit.cs" company="Microsoft">
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
////namespace Microsoft.StyleCop.CSharp
////{
////    using System;
////    using System.Diagnostics.CodeAnalysis;

////    /// <summary>
////    /// Describes a parameter which does not actually exist in the code.
////    /// </summary>
////    internal class VirtualParameter : Parameter
////    {
////        #region Private Fields

////        /// <summary>
////        /// The type of the parameter.
////        /// </summary>
////        private string type;

////        /// <summary>
////        /// The name of the parameter.
////        /// </summary>
////        private string name;

////        #endregion Private Fields

////        #region Internal Constructors

////        /// <summary>
////        /// Initializes a new instance of the VirtualParameter class.
////        /// </summary>
////        /// <param name="type">The type of the parameter.</param>
////        /// <param name="name">The name of the parameter.</param>
////        internal VirtualParameter(string type, string name) : base(null)
////        {
////            Param.Ignore(type, name);
            
////            this.type = type;
////            this.name = name;
////        }

////        #endregion Internal Constructors

////        #region Public Properties

////        /// <summary>
////        /// Gets the parameter name.
////        /// </summary>
////        public override string Name
////        {
////            get
////            {
////                if (this.name == null)
////                {
////                    return base.Name;
////                }

////                return this.name;
////            }
////        }

////        /// <summary>
////        /// Gets the parameter name token.
////        /// </summary> 
////        public override Token NameToken
////        {
////            get
////            {
////                if (this.name == null)
////                {
////                    return base.NameToken;
////                }

////                return null;
////            }
////        }

////        /// <summary>
////        /// Gets the parameter type.
////        /// </summary>
////        public override string ParameterType
////        {
////            get
////            {
////                if (this.type == null)
////                {
////                    return base.ParameterType;
////                }

////                return this.type;
////            }
////        }

////        /// <summary>
////        /// Gets the parameter type token.
////        /// </summary>
////        public override TypeToken ParameterTypeToken
////        {
////            get
////            {
////                if (this.type == null)
////                {
////                    return base.ParameterTypeToken;
////                }

////                return null;
////            }
////        }

////        /// <summary>
////        /// Gets the modifiers applied to this parameter.
////        /// </summary>
////        public override ParameterModifiers Modifiers
////        {
////            get
////            {
////                return ParameterModifiers.None;
////            }
////        }

////        #endregion Public Properties
////    }
////}
