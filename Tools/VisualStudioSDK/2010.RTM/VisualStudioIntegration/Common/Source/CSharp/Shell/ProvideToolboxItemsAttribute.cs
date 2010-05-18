//------------------------------------------------------------------------------
// <copyright file="ProvideToolboxItemsAttribute.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {

    using System;
    using System.Globalization;

    /// <include file='doc\ProvideToolboxItemsAttribute.uex' path='docs/doc[@for="ProvideToolboxItemsAttribute"]' />
    /// <devdoc>
    ///     This attribute declares that a package offers toolbox items and should be provided time 
    ///     during setup to install these items.  The attributes on a package do not control the 
    ///     behavior of the package, but they can be used by registration tools to register the 
    ///     proper information with Visual Studio.
    /// </devdoc>
    [AttributeUsage(AttributeTargets.Class, Inherited=true)]
    public class ProvideToolboxItemsAttribute : RegistrationAttribute {

        private int   _version;
        private bool  _needsCallbackAfterReset = false;
    
        /// <include file='doc\ProvideToolboxItemsAttribute.uex' path='docs/doc[@for="ProvideToolboxItemsAttribute.ProvideToolboxItemsAttribute"]' />
        /// <devdoc>
        ///     Creates a new ProvideToolboxItemsAttribute.
        /// </devdoc>
        public ProvideToolboxItemsAttribute(int version) {
            _version = version;
            _needsCallbackAfterReset = false;
        }

        /// <include file='doc\ProvideToolboxItemsAttribute.uex' path='docs/doc[@for="ProvideToolboxItemsAttribute.ProvideToolboxItemsAttribute"]' />
        /// <devdoc>
        ///     Creates a new ProvideToolboxItemsAttribute.
        ///     If needsCallbackAfterReset is true, then it will write out the "needsCallbackAfterReset" regkey which
        ///     tells the shell we have transient items to add and need to be called after resetdefaults is complete.
        /// </devdoc>
        public ProvideToolboxItemsAttribute(int version, bool needsCallbackAfterReset) {
            _version = version;
            _needsCallbackAfterReset = needsCallbackAfterReset;
        }

        /// <include file='doc\ProvideToolboxItemsAttribute.uex' path='docs/doc[@for="ProvideToolboxItemsAttribute.Version"]' />
        /// <devdoc>
        ///     Returns the version of items on the toolbox.
        ///     The first time a package get loaded after this version change,
        ///     the ToolboxInitialized event will be generated.
        /// </devdoc>
        public int Version {
            get {
                return _version;
            }
        }

        /// <summary>
        /// Setting this to true will force a ToolboxInitialized event after each
        /// toolbox reset.
        /// This can be used when developing your package to force the toolbox to
        /// ask the list of items to the package everytime (in case it has changed).
        /// For shipped products, it is best to leave it to false so that the cache can
        /// be used for better performances. Some scenario (such as item list that cannot
        /// cannot be persisted to the cache) may need to have this flag set to true
        /// </summary>
        public bool NeedsCallBackAfterReset
        {
            get { return _needsCallbackAfterReset; }
            set { _needsCallbackAfterReset = value; }
        }

        private string GetPackageRegKey(Guid packageGuid)
        {
            return string.Format(CultureInfo.InvariantCulture, "Packages\\{0}", packageGuid.ToString("B"));
        }

        /// <include file='doc\ProvideToolboxItemsAttribute.uex' path='docs/doc[@for="Register"]' />
        /// <devdoc>
        ///     Called to register this attribute with the given context.  The context
        ///     contains the location where the registration inforomation should be placed.
        ///     it also contains such as the type being registered, and path information.
        /// </devdoc>
        public override void Register(RegistrationContext context) {

            using (Key packageKey = context.CreateKey(GetPackageRegKey(context.ComponentType.GUID)))
            {
                using (Key childKey = packageKey.CreateSubkey("Toolbox"))
                {
                    childKey.SetValue("Default Items", Version);

                    // Search the package for the AllowToolboxFormat attribute.
                    //
                    string format = string.Empty;
                    foreach(ProvideToolboxFormatAttribute pfa in context.ComponentType.GetCustomAttributes(typeof(ProvideToolboxFormatAttribute), true)) {
                        if (format.Length == 0) {
                            format = pfa.Format;
                        }
                        else {
                            format = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", format, pfa.Format);
                        }
                    }

                    if (format.Length > 0) {
                        childKey.SetValue("Formats", format);
                    }

                    if (_needsCallbackAfterReset) {
                        childKey.SetValue("NeedsCallbackAfterReset", (int)1);
                    }

                    context.Log.WriteLine(SR.GetString(SR.Reg_NotifyToolboxItem, Version, format));
                }
            }
        }

        /// <include file='doc\ProvideToolboxItemsAttribute.uex' path='docs/doc[@for="Unregister"]' />
        /// <devdoc>
        /// Removes the registration data.
        /// </devdoc>
        public override void Unregister(RegistrationContext context)
        {
            context.RemoveKey(GetPackageRegKey(context.ComponentType.GUID));
        }
    }
}

