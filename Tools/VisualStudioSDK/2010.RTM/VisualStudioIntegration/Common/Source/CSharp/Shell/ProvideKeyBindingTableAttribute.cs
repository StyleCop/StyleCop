//------------------------------------------------------------------------------
// <copyright file="ProvideKeyBindingTableAttribute.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {

    using System;
    using System.Globalization;

    /// <include file='doc\ProvideKeyBindingTableAttribute.uex' path='docs/doc[@for="ProvideKeyBindingTableAttribute"]' />
    /// <devdoc>
    ///     This attribute declares that a package has a key binding table declared within its 
    ///     CTO file.  This attribute is only used for registration purposes.
    /// </devdoc>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=true, Inherited=true)]
    public sealed class ProvideKeyBindingTableAttribute : RegistrationAttribute {
        
        private short   _nameResourceID;
        private Guid    _tableGuid;
        private bool    _allowNavKeys = false;
    
        /// <include file='doc\ProvideKeyBindingTableAttribute.uex' path='docs/doc[@for="ProvideKeyBindingTableAttribute.ProvideKeyBindingTableAttribute"]' />
        /// <devdoc>
        ///     Creates a new ProvideKeyBindingTableAttribute.
        /// </devdoc>
        public ProvideKeyBindingTableAttribute (string tableGuid, short nameResourceID) {
            if (tableGuid == null) {
                throw new ArgumentNullException("tableGuid");
            }
            _tableGuid = new Guid(tableGuid);
            _nameResourceID = nameResourceID;
        }
        
        /// <include file='doc\ProvideKeyBindingTableAttribute.uex' path='docs/doc[@for="ProvideKeyBindingTableAttribute.NameResourceID"]' />
        /// <devdoc>
        ///     Returns the key binding table's name resource ID.
        /// </devdoc>
        public short NameResourceID {
            get {
                return _nameResourceID;
            }
        }

        /// <include file='doc\ProvideKeyBindingTableAttribute.uex' path='docs/doc[@for="ProvideKeyBindingTableAttribute.TableGuid"]' />
        /// <devdoc>
        ///     Returns the key binding table guid.
        /// </devdoc>
        public Guid TableGuid {
            get {
                return _tableGuid;
            }
        }

        /// <include file='doc\ProvideKeyBindingTableAttribute.uex' path='docs/doc[@for="ProvideKeyBindingTableAttribute.AllowNavKeyBinding"]/*' />
        /// <summary>
        /// Set to true if the user can bind new commands of the nagivation keys
        /// </summary>
        public bool AllowNavKeyBinding
        {
            get { return _allowNavKeys; }
            set { _allowNavKeys = value; }
        }

        private string KeyBindingRegKey
        {
            get { return string.Format(CultureInfo.InvariantCulture, "KeyBindingTables\\{0}", TableGuid.ToString("B")); }
        }

        /// <include file='doc\ProvideKeyBindingTableAttribute.uex' path='docs/doc[@for="Register"]' />
        /// <devdoc>
        ///     Called to register this attribute with the given context.  The context
        ///     contains the location where the registration inforomation should be placed.
        ///     it also contains such as the type being registered, and path information.
        ///
        ///     This method is called both for registration and unregistration.  The difference is
        ///     that unregistering just uses a hive that reverses the changes applied to it.
        /// </devdoc>
        public override void Register(RegistrationContext context) {
            context.Log.WriteLine(SR.GetString(SR.Reg_NotifyKeyBinding, TableGuid.ToString("B"), NameResourceID));

            using (Key childKey = context.CreateKey(KeyBindingRegKey))
            {
                childKey.SetValue(string.Empty, string.Format(CultureInfo.InvariantCulture, "#{0}", NameResourceID));
                childKey.SetValue("Package", context.ComponentType.GUID.ToString("B"));
                childKey.SetValue("AllowNavKeyBinding", _allowNavKeys ? 1 : 0);
            }
        }

        /// <include file='doc\ProvideKeyBindingTableAttribute.uex' path='docs/doc[@for="ProvideKeyBindingTableAttribute.Unregister"]/*' />
        public override void Unregister(RegistrationContext context) {
            context.RemoveKey(KeyBindingRegKey);
        }
    }
}

