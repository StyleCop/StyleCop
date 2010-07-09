//-----------------------------------------------------------------------
// <copyright file="DocumentRoot.cs" company="Microsoft">
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
////    using System.Collections.Generic;
////    using System.Text;

////    /// <summary>
////    /// An element which represents the root level of a document.
////    /// </summary>
////    /// <subcategory>element</subcategory>
////    public sealed class DocumentRoot : Namespace
////    {
////        #region Private Fields

////        /// <summary>
////        /// The document that contains this element.
////        /// </summary>
////        private CsDocument document;

////        #endregion Private Fields

////        #region Internal Constructors

////        /// <summary>
////        /// Initializes a new instance of the DocumentRoot class.
////        /// </summary>
////        /// <param name="proxy">Proxy object for the DocumentRoot.</param>
////        /// <param name="document">The document that contains this element.</param>
////        internal DocumentRoot(CodeUnitProxy proxy, CsDocument document) 
////            : base(proxy, ElementType.Root, Strings.DocumentRoot, null, false)
////        {
////            Param.AssertNotNull(proxy, "proxy");
////            Param.AssertNotNull(document, "document");

////            this.document = document;

////            if (document.FileHeader != null)
////            {
////                this.Generated |= document.FileHeader.Generated;
////            }

////            this.AccessModifierType = AccessModifierType.Public;
////        }

////        #endregion Internal Constructors

////        #region Public Override Properties

////        /// <summary>
////        /// Gets the document that contains this element.
////        /// </summary>
////        public override ICodeDocument Document
////        {
////            get
////            {
////                return this.document;
////            }
////        }

////        #endregion Public Override Properties
////    }
////}
