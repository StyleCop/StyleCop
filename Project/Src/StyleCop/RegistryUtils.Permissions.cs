// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegistryUtils.Permissions.cs" company="https://github.com/StyleCop">
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
//   The registry utils.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System.Security.Permissions;

    /// <summary>
    /// The registry utils.
    /// </summary>
    /// <content>
    /// Performs operations in the registry.
    /// </content>
    public partial class RegistryUtils
    {
        /// <summary>
        /// Demands permissions on behalf of the RegistryUtils class.
        /// </summary>
        internal static class Permissions
        {
            #region Public Methods and Operators

            /// <summary>
            /// Call this function before creating the RegistryUtils class in order to make sure that
            /// you (the caller) will have permissions to access the class.
            /// </summary>
            /// <param name="subKey">
            /// The sub key to demand permissions for.
            /// </param>
            public static void DemandCurrentUserAccess(string subKey)
            {
                // Create permission objects for the registry keys we're about to use.
                RegistryPermission fullPermissions = new RegistryPermission(RegistryPermissionAccess.AllAccess, @"HKEY_CURRENT_USER\" + subKey);

                // Now force this function to throw a SecurityException if we don't already have these permissions.
                fullPermissions.Demand();
            }

            /// <summary>
            /// Call this function before creating the RegistryUtils class in order to make sure that
            /// you (the caller) will have permissions to access the class.
            /// </summary>
            /// <param name="subKey">
            /// The sub key to demand permissions for.
            /// </param>
            public static void DemandLocalMachineAccess(string subKey)
            {
                // Create permission objects for the registry keys we're about to use.
                RegistryPermission readPermissions = new RegistryPermission(RegistryPermissionAccess.Read, @"HKEY_LOCAL_MACHINE\" + subKey);

                // Now force this function to throw a SecurityException if we don't already have these permissions.
                readPermissions.Demand();
            }

            #endregion
        }
    }
}