//-----------------------------------------------------------------------
// <copyright file="RunContext.cs">
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
namespace StyleCop
{
    using System;

    /// <summary>
    /// Context related to the current analysis run.
    /// </summary>
    public class RunContext
    {
        /// <summary>
        /// Initializes a new instance of the RunContext class.
        /// </summary>
        /// <param name="autoFix">Indicates whether to automatically fix violations.</param>
        internal RunContext(bool autoFix)
        {
            Param.Ignore(autoFix);
            this.AutoFix = autoFix;
        }

        /// <summary>
        /// Gets a value indicating whether to automatically fix violations if possible.
        /// </summary>
        public bool AutoFix
        {
            get;
            private set;
        }
    }
}
