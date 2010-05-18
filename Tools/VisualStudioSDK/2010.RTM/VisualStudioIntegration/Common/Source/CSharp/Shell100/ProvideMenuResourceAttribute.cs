//------------------------------------------------------------------------------
// <copyright file="ProvideMenuResourceAttribute.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {

    using System;
    using System.Globalization;

    /// <include file='doc\ProvideMenuResourceAttribute.uex' path='docs/doc[@for="ProvideMenuResourceAttribute"]' />
    /// <devdoc>
    ///     This attribute declares that a package offers menu resources.  When Visual Studio encounters 
    ///     such a package it will merge the menu resource information in its menus.  The attributes on a 
    ///     package do not control the behavior of the package, but they can be used by registration 
    ///     tools to register the proper information with Visual Studio.
    /// </devdoc>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=true, Inherited=true)]
    public sealed class ProvideMenuResourceAttribute : RegistrationAttribute {

        private string _resourceID;
        private int   _version;
    
        /// <include file='doc\ProvideMenuResourceAttribute.uex' path='docs/doc[@for="ProvideMenuResourceAttribute.ProvideMenuResourceAttribute"]' />
        /// <devdoc>
        ///     Creates a new ProvideMenuResourceAttribute.
        /// </devdoc>
        public ProvideMenuResourceAttribute (short resourceID, int version) {
            _resourceID = resourceID.ToString();
            _version = version;
        }
        
        /// <include file='doc\ProvideMenuResourceAttribute.uex' path='docs/doc[@for="ProvideMenuResourceAttribute.ProvideMenuResourceAttribute"]' />
        /// <devdoc>
        ///     Creates a new ProvideMenuResourceAttribute.
        /// </devdoc>
        public ProvideMenuResourceAttribute (string resourceID, int version) {
            if (string.IsNullOrEmpty(resourceID)) {
                throw new ArgumentNullException("resourceID");
            }
            _resourceID = resourceID;
            _version = version;
        }

        /// <include file='doc\ProvideMenuResourceAttribute.uex' path='docs/doc[@for="ProvideMenuResourceAttribute.ResourceID"]' />
        /// <devdoc>
        ///     Returns the native resource ID for the menu resource.
        /// </devdoc>
        public string ResourceID {
            get {
                return _resourceID;
            }
        }
        
        /// <include file='doc\ProvideMenuResourceAttribute.uex' path='docs/doc[@for="ProvideMenuResourceAttribute.Version"]' />
        /// <devdoc>
        ///     Returns the version of this menu resource.
        /// </devdoc>
        public int Version {
            get {
                return _version;
            }
        }

        /// <include file='doc\ProvideMenuResourceAttribute.uex' path='docs/doc[@for="Register"]' />
        /// <devdoc>
        ///     Called to register this attribute with the given context.  The context
        ///     contains the location where the registration inforomation should be placed.
        ///     it also contains such as the type being registered, and path information.
        ///
        ///     This method is called both for registration and unregistration.  The difference is
        ///     that unregistering just uses a hive that reverses the changes applied to it.
        /// </devdoc>
        public override void Register(RegistrationContext context) {
            context.Log.WriteLine(string.Format(Resources.Culture, Resources.Reg_NotifyMenuResource, ResourceID, Version));

            using (Key childKey = context.CreateKey("Menus"))
            {
                childKey.SetValue(context.ComponentType.GUID.ToString("B"), string.Format(CultureInfo.InvariantCulture, ", {0}, {1}", ResourceID, Version));
            }
        }

        /// <summary>
        ///     Called to unregister this attribute with the given context.
        /// </summary>
        /// <param name="context">
        ///     Contains the location where the registration inforomation should be placed.
        ///     It also contains other informations as the type being registered and path information.
        /// </param>
        public override void Unregister(RegistrationContext context) {
            context.RemoveValue("Menus", context.ComponentType.GUID.ToString("B"));
        }
    }
}

