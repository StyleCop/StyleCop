// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnixNativeMethods.cs" company="https://github.com/StyleCop">
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
// <summary>
//   Contains static methods for access to unix libraries.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Contains static methods for access to unix libraries.
    /// </summary>
    public static class UnixNativeMethods
    {
        /// <summary>
        /// Gets the unix kernel name by p/invoking uname.
        /// </summary>
        /// <returns>The name of the unix kernel. </returns>
        internal static string GetUnixKernelName()
        {
            UnixNameStruct result = new UnixNameStruct();

            try
            {
                UnixKernelName(out result);
            }
            catch
            {
                result.SystemName = string.Empty;
            }

            return result.SystemName;
        }

        [DllImport("libc", EntryPoint = "uname")]
        private static extern void UnixKernelName(out UnixNameStruct unixKernelStruct);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        private struct UnixNameStruct
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string SystemName;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string NodeName;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string Release;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string Version;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string Machine;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
            public string ExtraJustInCase;
        }
    }
}