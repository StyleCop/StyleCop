//-----------------------------------------------------------------------
// <copyright file="CodeUnitProxy.cs" company="Microsoft">
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
    using System.Text;
    using Microsoft.StyleCop.Collections;

    /// <summary>
    /// A proxy object used to stand in for a <see cref="CodeUnit" /> while it is being created.
    /// </summary>
    internal class CodeUnitProxy
    {
        /// <summary>
        /// The collection of children under the CodeUnit.
        /// </summary>
        private CodeUnitCollection children;

        /// <summary>
        /// The parent document.
        /// </summary>
        private CsDocument document;

        /// <summary>
        /// The target code that this object is a proxy for.
        /// </summary>
        private CodeUnit target;

        /// <summary>
        /// Initializes a new instance of the CodeUnitProxy class.
        /// </summary>
        /// <param name="document">The parent document.</param>
        public CodeUnitProxy(CsDocument document)
        {
            Param.Ignore(document);

            this.document = document;
            this.children = new CodeUnitCollection(this);
        }

        /// <summary>
        /// Gets the collection of children collected within the proxy.
        /// </summary>
        public CodeUnitCollection Children
        {
            get 
            { 
                return this.children; 
            }
        }

        /// <summary>
        /// Gets the code unit that this object is a proxy for.
        /// </summary>
        public CodeUnit Target
        {
            get
            {
                return this.target;
            }
        }

        /// <summary>
        /// Gets the parent document.
        /// </summary>
        public CsDocument Document
        {
            get
            {
                if (this.document == null)
                {
                    Debug.Assert(this.target == null || this.target.Is(ElementType.Document), "Document has not been set properly.");
                    return this.target as CsDocument;
                }

                return this.document;
            }
        }

        /// <summary>
        /// Attaches this proxy to its code unit.
        /// </summary>
        /// <param name="codeUnit">The code unit to attach to.</param>
        public void Attach(CodeUnit codeUnit)
        {
            Param.AssertNotNull(codeUnit, "codeUnit");
            this.target = codeUnit;

            Debug.Assert(this.document != null || codeUnit.Is(ElementType.Document), "Only a document element can have a proxy with a null document property.");
        }
    }
}