//------------------------------------------------------------------------------
// <copyright file="ProvideToolboxItemConfigurationAttribute.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {
    
    using System;
    using System.Globalization;
    using Microsoft.VisualStudio.Shell.Interop;

    /// <include file='doc\ProvideToolboxItemConfigurationAttribute.uex' path='docs/doc[@for="ProvideToolboxItemConfigurationAttribute"]' />
    /// <devdoc>
    ///    Registers a confugration object for toolbox items.
    ///    ProvideToolboxItemConfigurationAttribute attached to the package.  This attribute will register 
    ///    the object under the local CLSID hive in the VS registry and also add a reference to the GUID in
    ///    VSREGROOT\ToolboxItemConfiguration.  The data contained in this registry entry
    ///    is as follows:
    /// 
    ///    VSREGROOT\ToolboxItemConfiguration
    ///        AssemblyName
    ///             ConfigurationTypeName={guid}
    /// 
    ///    As an example:
    /// 
    ///    VSREGROOT\ToolboxItemConfiguration
    ///        System, Version=2.0.3500
    ///            CompactFrameworkProvider = {GUID}
    /// 
    /// 
    ///    The assembly name is parsed and the various keys are matched.  Keys can have a
    ///    "*" in them to be taken as wildcards.  So, for example, to cover all versions
    ///    of System.WindowsForms you would specify:
    /// 
    ///    System.Windows.Forms, Version=*, PublicKeyToken=969...
    /// 
    ///    The assembly name may also be a wildcard to load the configuration object
    ///    for all toolbox items (not recommended).  
    /// 
    ///    Place this attribute on your package, and then place one or more ProvideAssemblyFilter attributes
    ///    on the class that implements IConfigureToolboxItem.
    /// </devdoc>
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public sealed class ProvideToolboxItemConfigurationAttribute : RegistrationAttribute {
        private Type _objectType;

        /// <include file='doc\ProvideToolboxItemConfigurationAttribute.uex' path='docs/doc[@for="ProvideToolboxItemConfigurationAttribute.ProvideToolboxItemConfigurationAttribute"]' />
        /// <devdoc>
        ///    Constructor
        /// </devdoc>
        public ProvideToolboxItemConfigurationAttribute(Type objectType) {
            if (objectType == null) {
                throw new ArgumentNullException("objectType");
            }

            _objectType = objectType;
        }

        /// <include file='doc\ProvideToolboxItemConfigurationAttribute.uex' path='docs/doc[@for="ProvideToolboxItemConfigurationAttribute.ConfigurationType"]' />
        /// <devdoc>
        ///    The configuration type to use.
        /// </devdoc>
        public Type ObjectType {
            get {
                return _objectType;
            }
        }

        private string CLSIDRegKey
        {
            get { return string.Format(CultureInfo.InvariantCulture, "CLSID\\{0}", ObjectType.GUID.ToString("B")); }
        }

        private string GetItemCfgFilterKey(string filter)
        {
            return string.Format(CultureInfo.InvariantCulture, "ToolboxItemConfiguration\\{0}", filter);
        }

        /// <include file='doc\ProvideToolboxItemConfigurationAttribute.uex' path='docs/doc[@for="Register"]' />
        /// <devdoc>
        ///     Called to register this attribute with the given context.  The context
        ///     contains the location where the registration inforomation should be placed.
        ///     it also contains such as the type being registered, and path information.
        ///
        ///     This method is called both for registration and unregistration.  The difference is
        ///     that unregistering just uses a hive that reverses the changes applied to it.
        /// </devdoc>
        public override void Register(RegistrationContext context) {
            context.Log.WriteLine(SR.GetString(SR.Reg_NotifyToolboxItemConfiguration, ObjectType.Name));

            using (Key childKey = context.CreateKey(CLSIDRegKey))
            {
                childKey.SetValue(string.Empty, ObjectType.FullName);
                childKey.SetValue("InprocServer32", context.InprocServerPath);
                childKey.SetValue("Class", ObjectType.FullName);
                if (context.RegistrationMethod == RegistrationMethod.CodeBase)
                {
                    childKey.SetValue("Codebase", context.CodeBase);
                }
                else
                {
                    childKey.SetValue("Assembly", ObjectType.Assembly.FullName);
                }
                childKey.SetValue("ThreadingModel", "Both");
            }
            
            string guid = ObjectType.GUID.ToString("B");
            // Now, look up the object type and look for assembly filters.
            foreach (object attr in ObjectType.GetCustomAttributes(typeof(ProvideAssemblyFilterAttribute), true)) {
                ProvideAssemblyFilterAttribute filter = (ProvideAssemblyFilterAttribute)attr;
                context.Log.WriteLine(SR.GetString(SR.Reg_NotifyToolboxItemFilter, filter.AssemblyFilter)); 
                using (Key itemCfgKey = context.CreateKey(GetItemCfgFilterKey(filter.AssemblyFilter)))
                {
                    itemCfgKey.SetValue(ObjectType.FullName, guid);
                }
            }
        }

        /// <include file='doc\ProvideToolboxItemConfigurationAttribute.uex' path='docs/doc[@for="Unregister"]' />
        /// <devdoc>
        /// Called to remove this attribute from the given context.
        /// </devdoc>
        public override void Unregister(RegistrationContext context)
        {
            context.RemoveKey(CLSIDRegKey);

            // Now, look up the object type and remove assembly filters.
            foreach (object attr in ObjectType.GetCustomAttributes(typeof(ProvideAssemblyFilterAttribute), true)) {
                ProvideAssemblyFilterAttribute filter = (ProvideAssemblyFilterAttribute)attr;
                context.RemoveKey(GetItemCfgFilterKey(filter.AssemblyFilter));
            }
        }
    }
}
