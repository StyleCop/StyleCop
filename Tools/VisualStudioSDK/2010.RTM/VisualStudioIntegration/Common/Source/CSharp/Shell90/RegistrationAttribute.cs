//------------------------------------------------------------------------------
// <copyright file="RegistrationAttribute.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {

    using System;
    using System.IO;

    /// <include file='doc\RegistrationAttribute.uex' path='docs/doc[@for="RegistrationMethod"]/*' />
    /// <summary>
    /// How should the assembly be registered/located
    /// </summary>
    public enum RegistrationMethod {
        /// <include file='doc\RegistrationAttribute.uex' path='docs/doc[@for="RegistrationMethod.Default"]/*' />
        /// <summary>
        /// Default should only be used by tools
        /// </summary>
        Default = 0, 
        /// <include file='doc\RegistrationAttribute.uex' path='docs/doc[@for="RegistrationMethod.CodeBase"]/*' />
        /// <summary>
        /// The path to the assembly should be stored in the registry and used to locate the assembly at runtime
        /// </summary>
        CodeBase,
        /// <summary>
        /// The assembly should be in the GAC or in PrivateAssemblies
        /// </summary>
        Assembly};

    /// <include file='doc\RegistrationAttribute.uex' path='docs/doc[@for="RegistrationAttribute"]' />
    /// <devdoc>
    ///     This attribute is the basis for all other attributes that can be registered by RegPkg.
    /// </devdoc>
    [AttributeUsage(AttributeTargets.Class)]
    public abstract class RegistrationAttribute : Attribute {

        /// <summary>
        /// Override the TypeID property in order to let the RegistrationAttribute derived
        /// classes to work with System.ComponentModel.TypeDescriptor.GetAttributes(...).
        /// An attribute derived from this one will have to override this property only if
        /// it needs a better control on the instances that can be applied to a class.
        /// </summary>
        public override object TypeId
        {
            get
            {
                Type t = this.GetType();
                // Only one AttributeUsage attribute can be applyed to an attribute and the default
                // value is AllowMultiple = false. If both a base and derived attribute have an
                // AttributeUsage, only the one of the derived one will be returned by GetCustomAttributes.
                // We use a foreach because it will protect us from an empty collection
                // (it should never happen, but it is better to be safe) and because it will do
                // all the casts.
                bool isMultiple = false;
                foreach (AttributeUsageAttribute au in t.GetCustomAttributes(typeof(AttributeUsageAttribute), true))
                {
                    isMultiple = au.AllowMultiple;
                    // It should not be possible to have more than one AttributeUsageAttribute, but just in case...
                    break;
                }
                if (isMultiple)
                    return this;
                return t;
            }
        }

        /// <include file='doc\RegistrationAttribute.uex' path='docs/doc[@for="Register"]' />
        /// <devdoc>
        ///     Called to register this attribute with the given context.  The context
        ///     contains the location where the registration information should be placed.
        ///     It also contains such as the type being registered, and path information.
        ///
        ///     This method is called both for registration and unregistration.  The difference is
        ///     that unregistering just uses a hive that reverses the changes applied to it.
        /// </devdoc>
        public abstract void Register(RegistrationContext context);

        /// <include file='doc\RegistrationAttribute.uex' path='docs/doc[@for="Unregister"]' />
        /// <devdoc>
        ///     Called to unregister this attribute with the given context.  The context
        ///     contains the location where the registration information should be removed.
        ///     It also contains things such as the type being unregistered, and path information.
        /// </devdoc>
        public abstract void Unregister(RegistrationContext context);
        
        /// <include file='doc\RegistrationAttribute.uex' path='docs/doc[@for="Key"]' />
        /// <devdoc>
        ///     Abstraction around a registry key.  This may or may not actually
        ///     point to a real registry key.  It could point to a file.
        /// </devdoc>
        public abstract class Key : IDisposable {
            
            /// <include file='doc\RegistrationAttribute.uex' path='docs/doc[@for="Key.Close"]' />
            /// <devdoc>
            ///     Called to close this key.  Alternately, you may use the C# "using"
            ///     syntax on keys, since they are IDisposable. Always close keys when you
            ///     are done with them.
            /// </devdoc>
            public abstract void Close();

            /// <include file='doc\RegistrationAttribute.uex' path='docs/doc[@for="Key.CreateSubkey"]' />
            /// <devdoc>
            ///     Creates a subkey of the given name.
            /// </devdoc>
            public abstract Key CreateSubkey(string name);

            /// <include file='doc\RegistrationAttribute.uex' path='docs/doc[@for="Key.SetValue"]' />
            /// <devdoc>
            ///     Sets the name to the given value. Pass an empty string or null into this to
            ///     set the default value for a key.
            /// </devdoc>
            public abstract void SetValue(string valueName, object value);

            /// <include file='doc\RegistrationAttribute.uex' path='docs/doc[@for="Key.IDisposable.Dispose"]/*' />
            /// <internalonly/>
            /// <devdoc>
            /// Closes the key.
            /// </devdoc>
            void IDisposable.Dispose() {
                Close();
            }
        }

        /// <include file='doc\RegistrationAttribute.uex' path='docs/doc[@for="RegistrationContext"]' />
        /// <devdoc>
        ///     Abstraction around the registry itself.
        /// </devdoc>
        public abstract class RegistrationContext {
            
            /// <include file='doc\RegistrationAttribute.uex' path='docs/doc[@for="RegistrationContext.ComponentPath"]' />
            /// <devdoc>
            ///     The path to the compnent that is being registered.  You should always use this rather than the 
            ///     codebase of the component type, and you should never assume that this is a physical path on
            ///     disk.  It may be a token that identifies the path at install time.  The "component"
            ///     is the type that the registration attribute was found on.
            /// </devdoc>
            public abstract string ComponentPath { get; }

            /// <include file='doc\RegistrationAttribute.uex' path='docs/doc[@for="RegistrationContext.RegisteringType"]' />
            /// <devdoc>
            ///     The type of the component that is being registered.
            /// </devdoc>
            public abstract Type ComponentType { get; }

            /// <include file='doc\RegistrationAttribute.uex' path='docs/doc[@for="RegistrationContext.InprocServerPath"]' />
            /// <devdoc>
            ///     The path to the COM object supplying the class factory.
            /// </devdoc>
            public abstract string InprocServerPath { get;}

            /// <include file='doc\RegistrationAttribute.uex' path='docs/doc[@for="RegistrationContext.CodeBase"]' />
            /// <devdoc>
            ///     The path to the object being registered (including filename).
            /// </devdoc>
            public abstract string CodeBase { get;}

            /// <include file='doc\RegistrationAttribute.uex' path='docs/doc[@for="RegistrationContext.RootFolder"]' />
            /// <devdoc>
            ///     The path to the installation for the host application (e.g. Visual Studio "C:\Program Files\Microsoft Visual Studio <version>\").
            /// </devdoc>
            public abstract string RootFolder { get; }

            /// <include file='doc\RegistrationAttribute.uex' path='docs/doc[@for="RegistrationContext.RegistrationMethod"]' />
            /// <devdoc>
            /// Specify if the assembly should be located using CodeBase or Assembly
            /// </devdoc>
            public abstract RegistrationMethod RegistrationMethod{get;}

            /// <include file='doc\RegistrationAttribute.uex' path='docs/doc[@for="RegistrationContext.Log"]' />
            /// <devdoc>
            ///     Returns a text writer that can be used to log registration information.  This should 
            ///     be a human readable (and ideally localized) bit of text that describes the
            ///     current registration process.
            /// </devdoc>
            public abstract TextWriter Log { get; }

            /// <include file='doc\RegistrationAttribute.uex' path='docs/doc[@for="RegistrationContext.CreateKey"]' />
            /// <devdoc>
            ///     Creates a new key of the given name.  The key is created at the appropriate registration
            ///     point in the registry.  Always close or dispose this key when finished with it.
            /// </devdoc>
            public abstract Key CreateKey(string name);

            /// <include file='doc\RegistrationAttribute.uex' path='docs/doc[@for="RegistrationContext.RemoveKey"]' />
            /// <devdoc>
            /// Removes the key of the given name.
            /// </devdoc>
            public abstract void RemoveKey(string name);

            /// <include file='doc\RegistrationAttribute.uex' path='docs/doc[@for="RegistrationContext.RemoveValue"]' />
            /// <devdoc>
            /// Removes the value of the given name under the key of the given keyname
            /// </devdoc>
            public abstract void RemoveValue(string keyname, string valuename);

            /// <include file='doc\RegistrationAttribute.uex' path='docs/doc[@for="RegistrationContext.RemoveKey"]' />
            /// <devdoc>
            /// Removes the key of the given name if it has no child key and
            /// no value.
            /// </devdoc>
            public abstract void RemoveKeyIfEmpty(string name);

            /// <include file='doc\RegistrationAttribute.uex' path='docs/doc[@for="RegistrationContext.EscapePath"]' />
            /// <devdoc>
            /// Escape the string if needed
            /// This is used by the implementation of the Register method on attributes so that paths be escaped when
            /// needed. The attribute itself does not know if we are writting to a .reg file or directly to the registry.
            /// </devdoc>
            public abstract string EscapePath(string str);
        }
    }
}

