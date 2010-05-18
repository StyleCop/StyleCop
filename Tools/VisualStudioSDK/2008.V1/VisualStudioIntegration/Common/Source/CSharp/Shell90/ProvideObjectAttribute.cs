//------------------------------------------------------------------------------
// <copyright file="ProvideObjectAttribute.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {

    using System;
    using System.Globalization;

    /// <include file='doc\ProvideObjectAttribute.uex' path='docs/doc[@for="ProvideObjectAttribute"]' />
    /// <devdoc>
    ///     This attribute declares a class as creatable through Visual Studio.  
    ///     A creatable class will be given an entry in Visual Studio's local 
    ///     registry at install time.  The objectType parameter specifies the
    ///     data type of the object that will be created.
    /// </devdoc>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=true, Inherited=true)]
    public sealed class ProvideObjectAttribute : RegistrationAttribute {

        private Type _objectType;
        private RegistrationMethod registrationMethod = RegistrationMethod.Default;
    
        /// <include file='doc\ProvideObjectAttribute.uex' path='docs/doc[@for="ProvideObjectAttribute.ProvideObjectAttribute"]' />
        /// <devdoc>
        ///     Creates a new ProvideObjectAttribute.
        /// </devdoc>
        public ProvideObjectAttribute (Type objectType) {
            if (objectType == null) {
                throw new ArgumentNullException("objectType");
            }
            _objectType = objectType;
        }
        
        /// <include file='doc\ProvideObjectAttribute.uex' path='docs/doc[@for="ProvideObjectAttribute.ObjectType"]' />
        /// <devdoc>
        ///     The type of object that can be created from this package.
        /// </devdoc>
        public Type ObjectType {
            get {
                return _objectType;
            }
        }

        /// <summary>
        /// Select between specifying the Codebase entry or the Assembly entry in the registry.
        /// This can be overriden during registration
        /// </summary>
        public RegistrationMethod RegisterUsing
        {
            get
            {
                return registrationMethod;
            }
            set
            {
                registrationMethod = value;
            }
        }

        private string CLSIDRegKey
        {
            get { return string.Format(CultureInfo.InvariantCulture, "CLSID\\{0}", ObjectType.GUID.ToString("B")); }
        }

        /// <include file='doc\ProvideObjectAttribute.uex' path='docs/doc[@for="Register"]' />
        /// <devdoc>
        ///     Called to register this attribute with the given context.  The context
        ///     contains the location where the registration inforomation should be placed.
        ///     it also contains such as the type being registered, and path information.
        ///
        ///     This method is called both for registration and unregistration.  The difference is
        ///     that unregistering just uses a hive that reverses the changes applied to it.
        /// </devdoc>
        public override void Register(RegistrationContext context) {
            context.Log.WriteLine(string.Format(Resources.Culture, Resources.Reg_NotifyCreateObject, ObjectType.Name));

            using (Key childKey = context.CreateKey(CLSIDRegKey))
            {
                childKey.SetValue(string.Empty, ObjectType.FullName);
                childKey.SetValue("InprocServer32", context.InprocServerPath);
                childKey.SetValue("Class", ObjectType.FullName);

                // If specified on the command line, let the command line option override
                if (context.RegistrationMethod != RegistrationMethod.Default) {
                    registrationMethod = context.RegistrationMethod;
                }

            switch(registrationMethod) {
                case RegistrationMethod.Default:
                case RegistrationMethod.Assembly:
                    childKey.SetValue("Assembly", ObjectType.Assembly.FullName);
                    break;
                
                    case RegistrationMethod.CodeBase:
                        childKey.SetValue("CodeBase", context.CodeBase);
                        break;
                }

                childKey.SetValue("ThreadingModel", "Both");
            }
        }
        /// <summary>
        /// Unregisters this attribute.
        /// </summary>
        /// <param name="context">
        ///     Contains the location from where the registration inforomation should be removed.
        ///     It also contains other informations as the type being unregistered and path information.
        /// </param>
        public override void Unregister(RegistrationContext context)
        {
            context.RemoveKey(CLSIDRegKey);
        }
    }
}

