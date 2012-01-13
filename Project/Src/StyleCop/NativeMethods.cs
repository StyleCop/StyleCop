// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NativeMethods.cs" company="http://stylecop.codeplex.com">
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
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop
{
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary>
    /// Contains static methods for access to win32 libraries.
    /// </summary>
    public static class NativeMethods
    {
        internal enum EXTENDED_NAME_FORMAT
        {
            NameCanonical = 7,

            NameCanonicalEx = 9,

            NameDisplay = 3,

            NameDnsDomain = 12,

            NameFullyQualifiedDN = 1,

            NameSamCompatible = 2,

            NameServicePrincipal = 10,

            NameUniqueId = 6,

            NameUnknown = 0,

            NameUserPrincipal = 8
        }

        [DllImport("secur32.dll", CharSet = CharSet.Auto)]
        internal static extern int GetUserNameEx(EXTENDED_NAME_FORMAT nameFormat, StringBuilder userName, ref uint userNameSize);
    }
}