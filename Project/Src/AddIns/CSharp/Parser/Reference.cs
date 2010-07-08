//-----------------------------------------------------------------------
// <copyright file="Reference.cs" company="Microsoft">
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
    using System.Diagnostics;

    /// <summary>
    /// A reference to a code unit.
    /// </summary>
    internal interface ICodeUnitReference
    {
        /// <summary>
        /// Gets the referenced target.
        /// </summary>
        CodeUnit Target
        {
            get;
        }
    }

    /// <summary>
    /// Provides a reference to a code unit.
    /// </summary>
    internal class CodeUnitReference : ICodeUnitReference
    {
        /// <summary>
        /// The referenced item.
        /// </summary>
        private ICodeUnitReference targetRef;

        /// <summary>
        /// Initializes a new instance of the CodeUnitReference class.
        /// </summary>
        public CodeUnitReference()
        {
        }

        /// <summary>
        /// Initializes a new instance of the CodeUnitReference class.
        /// </summary>
        /// <param name="targetRef">The initial item to point the referece to.</param>
        public CodeUnitReference(ICodeUnitReference targetRef)
        {
            Param.AssertNotNull(targetRef, "targetRef");
            this.targetRef = targetRef;
        }

        ///// <summary>
        ///// Event that is fired when the code unit reference changes.
        ///// </summary>
        ////public event EventHandler ReferenceChanged;

        /// <summary>
        /// Gets the referenced target.
        /// </summary>
        public CodeUnit Target
        {
            get
            {
                return this.targetRef == null ? null : this.targetRef.Target;
            }
        }

        /// <summary>
        /// Gets or sets the reference.
        /// </summary>
        public ICodeUnitReference TargetRef
        {
            get
            {
                return this.targetRef;
            }

            set
            {
                Param.AssertNotNull(value, "TargetRef");

                // Check whether there is already another reference pointing back to the same target. If so, 
                // we want to reference that reference rather than referencing the target directly.
                CodeUnit codeUnit = value.Target;
                if (codeUnit != null)
                {
                    CodeUnit child = codeUnit.FindFirstChild<CodeUnit>();
                    if (child != null && child.ParentReference != null && child.ParentReference.Target != null)
                    {
                        Debug.Assert(child.ParentReference.Target == codeUnit, "The child's parent reference is invalid.");
                        this.targetRef = child.ParentReference;
                    }
                }

                if (this.targetRef == null)
                {
                    // Initialize the target reference to the given value.
                    this.targetRef = value;
                }
            }
        }

        /////// <summary>
        /////// Called when the referenced target changes.
        /////// </summary>
        /////// <param name="args">The event arguments.</param>
        ////protected void OnReferenceChanged(EventArgs args)
        ////{
        ////    Param.Ignore(args);

        ////    if (this.ReferenceChanged != null)
        ////    {
        ////        this.ReferenceChanged(this, EventArgs.Empty);
        ////    }
        ////}
    }
}