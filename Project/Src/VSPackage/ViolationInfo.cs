//-----------------------------------------------------------------------
// <copyright file="ViolationInfo.cs" company="Microsoft">
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
namespace Microsoft.StyleCop.VisualStudio
{
    using System;

    /// <summary>
    /// Stores information about a single violation in a code file.
    /// </summary>
    internal struct ViolationInfo
    {
        /// <summary>
        /// The line number that the violation appears on in the code.
        /// </summary>
        public int LineNumber;

        /// <summary>
        /// The description for the violation.
        /// </summary>
        public string Description;

        /// <summary>
        /// The file that the violation appears in.
        /// </summary>
        public string File;

        /// <summary>
        /// The rule that that was violated.
        /// </summary>
        public Rule Rule;
        
        /////// <summary>
        /////// Gets a value indicating whether the violation is a warning.
        /////// </summary>
        ////public bool Warning
        ////{
        ////    get { return this.Rule == null ? false : this.Rule.Warning; }
        ////}
    }
}
