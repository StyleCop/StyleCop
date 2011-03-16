//-----------------------------------------------------------------------
// <copyright file="CodeUnitLocationMarker.cs">
//     MS-PL
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
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Represents the location of a code unit within a code model.
    /// </summary>
    /// <remarks>The code location is static. It will not update as changes occur within the code model. It is meant to be created, 
    /// used soon thereafter, and then discarded.</remarks>
    public class CodeUnitLocationMarker
    {
        /// <summary>
        /// Initializes a new instance of the CodeUnitLocationMarker class.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        internal CodeUnitLocationMarker(CodeUnit codeUnit)
        {
            Param.AssertNotNull(codeUnit, "codeUnit");

            this.Parent = codeUnit.Parent;
            this.NextSibling = codeUnit.LinkNode.Next;
            this.PreviousSibling = codeUnit.LinkNode.Previous;

            if (this.Parent == null && this.NextSibling == null && this.PreviousSibling == null)
            {
                throw new ArgumentException("codeUnit");
            }
        }

        /// <summary>
        /// Gets the parent code unit.
        /// </summary>
        internal CodeUnit Parent
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the next sibling code unit.
        /// </summary>
        internal CodeUnit NextSibling
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the previous sibling code unit.
        /// </summary>
        internal CodeUnit PreviousSibling
        {
            get;
            private set;
        }
    }
}
