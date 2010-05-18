//------------------------------------------------------------------------------
// <copyright file="RegisterLanguageExtensionAttribute.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {

    using System;
    using System.Globalization;

    /// <include file='doc\RegisterLanguageExtensionAttribute.uex' path='docs/doc[@for="RegisterLanguageExtensionAttribute"]' />
    /// <devdoc>
    ///     This attribute associates a file extension to a given editor factory.  
    ///     The editor factory may be specified as either a GUID or a type and 
    ///     is placed on a package.
    /// </devdoc>
    [Obsolete("RegisterLanguageExtensionAttribute has been deprecated. Please use ProvideLanguageExtensionAttribute instead.")]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=true, Inherited=true)]
    public sealed class RegisterLanguageExtensionAttribute : RegistrationAttribute {

        private Guid languageService;
        private string extension;
        
        /// <include file='doc\RegisterLanguageExtensionAttribute.uex' path='docs/doc[@for="RegisterLanguageExtensionAttribute.RegisterLanguageExtensionAttribute"]' />
        /// <devdoc>
        ///     Creates a new attribute.
        /// </devdoc>
        public RegisterLanguageExtensionAttribute (string languageServiceGuid, string extension) {

            if (!extension.StartsWith(".", StringComparison.OrdinalIgnoreCase)) {
                throw new ArgumentException(SR.GetString(SR.Attributes_ExtensionNeedsDot, extension));
            }

            this.languageService = new Guid(languageServiceGuid);
            this.extension = extension;
        }
        
        /// <include file='doc\RegisterLanguageExtensionAttribute.uex' path='docs/doc[@for="RegisterLanguageExtensionAttribute.RegisterLanguageExtensionAttribute1"]' />
        /// <devdoc>
        ///     Creates a new attribute.
        /// </devdoc>
        public RegisterLanguageExtensionAttribute (Type languageService, string extension) {

            if (!extension.StartsWith(".", StringComparison.OrdinalIgnoreCase)) {
                throw new ArgumentException(SR.GetString(SR.Attributes_ExtensionNeedsDot, extension));
            }

            this.languageService = languageService.GUID;
            this.extension = extension;
        }
        
        /// <include file='doc\RegisterLanguageExtensionAttribute.uex' path='docs/doc[@for="RegisterLanguageExtensionAttribute.Extension"]' />
        /// <devdoc>
        ///     The file extension of the file.
        /// </devdoc>
        public string Extension {
            get {
                return extension;
            }
        }
        
        /// <include file='doc\RegisterLanguageExtensionAttribute.uex' path='docs/doc[@for="RegisterLanguageExtensionAttribute.LanguageService"]' />
        /// <devdoc>
        ///     The language service SID.
        /// </devdoc>
        public Guid LanguageService {
            get {
                return languageService;
            }
        }

        private string ExtensionsRegKey
        {
            get { return string.Format(CultureInfo.InvariantCulture, "Languages\\File Extensions\\{0}", Extension); }
        }

        /// <include file='doc\RegisterLanguageExtensionAttribute.uex' path='docs/doc[@for="Register"]' />
        /// <devdoc>
        ///     Called to register this attribute with the given context.  The context
        ///     contains the location where the registration inforomation should be placed.
        ///     it also contains such as the type being registered, and path information.
        ///
        ///     This method is called both for registration and unregistration.  The difference is
        ///     that unregistering just uses a hive that reverses the changes applied to it.
        /// </devdoc>
        public override void Register(RegistrationContext context) {
            context.Log.WriteLine(SR.GetString(SR.Reg_NotifyLanguageExtension, Extension, LanguageService.ToString("B")));

            using (Key childKey = context.CreateKey(ExtensionsRegKey))
            {
                childKey.SetValue(string.Empty, LanguageService.ToString("B"));
            }
        }

        /// <include file='doc\RegisterLanguageExtensionAttribute.uex' path='docs/doc[@for="Unregister"]' />
        /// <devdoc>
        /// Called to remove this attribute from the given context.
        /// </devdoc>
        public override void Unregister(RegistrationContext context) {
            context.RemoveKey(ExtensionsRegKey);
        }
    }
}

