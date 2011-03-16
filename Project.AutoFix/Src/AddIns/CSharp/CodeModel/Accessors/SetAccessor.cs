//-----------------------------------------------------------------------
// <copyright file="SetAccessor.cs">
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
    using System.Collections.Generic;

    /// <summary>
    /// Describes a set accessor.
    /// </summary>
    public sealed class SetAccessor : Accessor
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the SetAccessor class.
        /// </summary>
        /// <param name="proxy">Proxy object for the accessor.</param>
        /// <param name="unsafeCode">Indicates whether the element resides within a block of unsafe code.</param>
        internal SetAccessor(CodeUnitProxy proxy, bool unsafeCode)
            : base(proxy, "set", AccessorType.Set, unsafeCode)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.Ignore(unsafeCode);
        }

        #endregion Internal Constructors
    }
}