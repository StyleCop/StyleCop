//-----------------------------------------------------------------------
// <copyright file="NativeMethods.cs">
//   MS-PL
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
namespace StyleCop.VisualStudio
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Imported Win32 functionality.
    /// </summary>
    internal sealed class NativeMethods
    {
        /// <summary>
        /// Prevents a default instance of the NativeMethods class from being created.
        /// </summary>
        private NativeMethods()
        {
        }

        /// <summary>
        /// The VSENUMPROJFLAGS.
        /// </summary>
        public enum VSENUMPROJFLAGS
        {
            /// <summary>
            /// See the MSDN documentation.
            /// </summary>
            EPF_LOADEDINSOLUTION = 0x1,

            /// <summary>
            /// See the MSDN documentation.
            /// </summary>
            EPF_UNLOADEDINSOLUTION = 0x2,

            /// <summary>
            /// See the MSDN documentation.
            /// </summary>
            EPF_ALLINSOLUTION = EPF_LOADEDINSOLUTION | EPF_UNLOADEDINSOLUTION,

            /// <summary>
            /// See the MSDN documentation.
            /// </summary>
            EPF_MATCHTYPE = 0x4,

            /// <summary>
            /// See the MSDN documentation.
            /// </summary>
            EPF_VIRTUALVISIBLEPROJECT = 0x8,

            /// <summary>
            /// See the MSDN documentation.
            /// </summary>
            EPF_VIRTUALNONVISIBLEPROJECT = 0x10,

            /// <summary>
            /// See the MSDN documentation.
            /// </summary>
            EPF_ALLVIRTUAL = EPF_VIRTUALVISIBLEPROJECT | EPF_VIRTUALNONVISIBLEPROJECT,

            /// <summary>
            /// See the MSDN documentation.
            /// </summary>
            EPF_ALLPROJECTS = EPF_ALLINSOLUTION | EPF_ALLVIRTUAL
        }
    }
}