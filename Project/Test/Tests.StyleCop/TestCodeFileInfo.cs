//-----------------------------------------------------------------------
// <copyright file="TestCodeFileInfo.cs">
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
namespace StyleCop.Test
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Describes one code file to test.
    /// </summary>
    internal struct TestCodeFileInfo
    {
        /// <summary>
        /// The name of the code file.
        /// </summary>
        public string CodeFile;

        /// <summary>
        /// Indicates whether to test the object model produced for this code file.
        /// </summary>
        public bool TestObjectModel;
    }
}