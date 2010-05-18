//-----------------------------------------------------------------------
// <copyright file="RegistryUtils.Permissions.cs" company="Microsoft">
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
namespace Microsoft.StyleCop
{
    using System;
    using System.Security.Permissions;

    /// <content>
    /// Performs operations in the registry.
    /// </content>
    public partial class RegistryUtils
    {
        /// <summary>
        /// Demands permissions on behalf of the RegistryUtils class.
        /// </summary>
        internal sealed class Permissions
        {
            #region Private Constructors

            /// <summary>
            /// Prevents a default instance of the Permissions class from being created.
            /// </summary>
            private Permissions()
            {
            }

            #endregion Private Constructors

            #region Public Static Methods

            /// <summary>
            /// Call this function before creating the RegistryUtils class in order to make sure that
            /// you (the caller) will have permissions to access the class.
            /// </summary>
            public static void Demand()
            {
                // Create permission objects for the registry keys we're about to use.
                string fullRegistryPath = @"HKEY_CURRENT_USER\Software\Microsoft\" + ApplicationAcronym;
                RegistryPermission fullPermissions = 
                    new RegistryPermission(RegistryPermissionAccess.AllAccess, fullRegistryPath);
            
                // Now force this function to throw a SecurityException if we don't already have these permissions.
                fullPermissions.Demand();
            }

            #endregion Public Static Methods
        }
    }
}
