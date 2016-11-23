// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NativeMethods.cs" company="https://github.com/StyleCop">
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
//   Contains static methods for access to win32 libraries.
// </summary>
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
            /// <summary>
            /// The canonical name.
            /// </summary>
            NameCanonical = 7, 

            /// <summary>
            /// The canonical extended name.
            /// </summary>
            NameCanonicalEx = 9, 

            /// <summary>
            /// The display name.
            /// </summary>
            NameDisplay = 3, 

            /// <summary>
            /// The domain name service domain name.
            /// </summary>
            NameDnsDomain = 12, 

            /// <summary>
            /// The fully qualified name.
            /// </summary>
            NameFullyQualifiedDN = 1, 

            /// <summary>
            /// The sam compatible name.
            /// </summary>
            NameSamCompatible = 2, 

            /// <summary>
            /// The service principal name.
            /// </summary>
            NameServicePrincipal = 10, 

            /// <summary>
            /// The unique identifier.
            /// </summary>
            NameUniqueId = 6, 

            /// <summary>
            /// The unknown name.
            /// </summary>
            NameUnknown = 0, 

            /// <summary>
            /// The user principal name.
            /// </summary>
            NameUserPrincipal = 8
        }

        [DllImport("secur32.dll", CharSet = CharSet.Auto)]
        internal static extern int GetUserNameEx(EXTENDED_NAME_FORMAT nameFormat, StringBuilder userName, ref uint userNameSize);
    }
}