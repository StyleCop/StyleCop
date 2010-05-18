//------------------------------------------------------------------------------
// <copyright file="ProvideAutomationObjectAttribute.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {

    using System;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using Microsoft.Win32;
    
    /// <include file='doc\ProvideAutomationObjectAttribute.uex' path='docs/doc[@for="ProvideAutomationObjectAttribute"]' />
    /// <devdoc>
    ///     This attribute declares that a package provides a particular automation object.  The attributes on a 
    ///     package do not control the behavior of the package, but they can be used by registration 
    ///     tools to register the proper information with Visual Studio.
    /// </devdoc>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=true, Inherited=true)]
    public sealed class ProvideAutomationObjectAttribute : RegistrationAttribute {

        private string name;
        private string description;

        /// <include file='doc\ProvideAutomationObjectAttribute.uex' path='docs/doc[@for="ProvideAutomationAttribute.ProvideAutomationObjectAttribute"]' />
        /// <devdoc>
        ///     Creates a new ProvideAutomationObjectAttribute.
        /// </devdoc>
        public ProvideAutomationObjectAttribute(string objectName)
        {
            if (objectName == null) {
                throw new ArgumentNullException("ObjectName");
            }

            name = objectName;
        }

        /// <include file='doc\ProvideAutomationAttribute.uex' path='docs/doc[@for="ProvideAutomationObjectAttribute.Name"]' />
        /// <devdoc>
        ///     Returns the name of the automation object declared in this attribute.
        /// </devdoc>
        public string Name {
            get {
                return name;
            }
        }

        /// <include file='doc\ProvideAutomationObjectAttribute.uex' path='docs/doc[@for="ProvideAutomationObjectAttribute.Description"]' />
        /// <devdoc>
        ///     The description of the automation object declared in this attribute.
        /// </devdoc>
        public string Description 
        {
            get {
                return description;
            }
            set {
                description = value;
            }
         }

        private string GetAutomationRegKey(Guid packageGuid)
        {
            return string.Format(CultureInfo.InvariantCulture, "Packages\\{0}\\Automation", packageGuid.ToString("B"));
        }

        /// <include file='doc\ProvideAutomationObjectAttribute.uex' path='docs/doc[@for="Register"]' />
        /// <devdoc>
        ///     Called to register this attribute with the given context.  The context
        ///     contains the location where the registration inforomation should be placed.
        ///     it also contains information such as the type being registered, and path information.
        ///
        ///     This method is called both for registration and unregistration.  The difference is
        ///     that unregistering just uses a hive that reverses the changes applied to it.
        /// </devdoc>
        public override void Register(RegistrationContext context) 
        {
            using (Key childKey = context.CreateKey(GetAutomationRegKey(context.ComponentType.GUID)))
            {
                string descValue = (Description == null) ? "" : Description;
                childKey.SetValue(Name, descValue);
            }
        }

        /// <include file='doc\ProvideAutomationObjectAttribute.uex' path='docs/doc[@for="ProvideAutomationObjectAttribute.Unregister"]' />
        /// <devdoc>
        /// Removes the registration information from the registration context.
        /// </devdoc>
        public override void Unregister(RegistrationContext context)
        {
            context.RemoveKey(GetAutomationRegKey(context.ComponentType.GUID));
        }
    }
}

