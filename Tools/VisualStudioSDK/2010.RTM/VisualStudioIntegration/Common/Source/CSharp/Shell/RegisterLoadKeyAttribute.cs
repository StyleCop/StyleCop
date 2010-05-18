//------------------------------------------------------------------------------
// <copyright file="RegisterLoadKeyAttribute.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {

    using System;
    using System.Globalization;

    /// <include file='doc\RegisterLoadKeyAttribute.uex' path='docs/doc[@for="RegisterLoadKeyAttribute"]' />
    /// <devdoc>
    ///     This attribute registers a package load key for your package.  
    ///     Package load keys are used by Visual Studio to validate that 
    ///     a package can be loaded.    
    /// </devdoc>
    [Obsolete("RegisterLoadKeyAttribute has been deprecated. Please use ProvideLoadKeyAttribute instead.")]
    [AttributeUsage(AttributeTargets.Class, Inherited=false, AllowMultiple=false)]
    public sealed class RegisterLoadKeyAttribute : RegistrationAttribute {

        private string _minimumEdition;
        private string _productVersion;
        private string _productName;
        private string _companyName;
        private short  _resourceId;
    
        /// <include file='doc\RegisterLoadKeyAttribute.uex' path='docs/doc[@for="RegisterLoadKeyAttribute.RegisterLoadKeyAttribute"]/*' />
        public RegisterLoadKeyAttribute (string minimumEdition, string productVersion, string productName, string companyName, short resourceId) {
            if (minimumEdition == null) {
                throw new ArgumentNullException("minimumEdition");
            }
            if (productVersion == null) {
                throw new ArgumentNullException("productVersion");
            }
            if (productName == null) {
                throw new ArgumentNullException("productName");
            }
            if (companyName == null) {
                throw new ArgumentNullException("companyName");
            }
            
            _minimumEdition = minimumEdition;
            _productVersion = productVersion;
            _productName = productName;
            _companyName = companyName;
            _resourceId = resourceId;
        }
        
        /// <include file='doc\RegisterLoadKeyAttribute.uex' path='docs/doc[@for="RegisterLoadKeyAttribute.MinEdition"]' />
        /// <devdoc>
        ///     Minimum edition of Visual Studio on which
        ///     VSPackage is loaded. This must be the literal 
        ///     edition value provided by Microsoft when 
        ///     obtaining your PLK.
        /// </devdoc>
        public string MinimumEdition {
            get {
                return _minimumEdition;
            }
        }

        /// <include file='doc\RegisterLoadKeyAttribute.uex' path='docs/doc[@for="RegisterLoadKeyAttribute.ProductVersion"]' />
        /// <devdoc>
        ///     Version of the product that this VSPackage
        ///     implements.
        /// </devdoc>
        public string ProductVersion {
            get {
                return _productVersion;
            }
        }
        
        /// <include file='doc\RegisterLoadKeyAttribute.uex' path='docs/doc[@for="RegisterLoadKeyAttribute.ProductName"]' />
        /// <devdoc>
        ///     Name of the product that this VSPackage 
        ///     delivers. Note that one product might be
        ///     comprised of multiple VSPackages, in which 
        ///     case each will need its own PLK.
        /// </devdoc>
        public string ProductName {
            get {
                return _productName;
            }
        }

        /// <include file='doc\RegisterLoadKeyAttribute.uex' path='docs/doc[@for="RegisterLoadKeyAttribute.CompanyName"]' />
        /// <devdoc>
        ///     VSIP Partner/creator of the VSPackage. 
        ///     The literal name (case-sensitive) provided 
        ///     to Microsoft when registering for a PLK.
        /// </devdoc>
        public string CompanyName {
            get {
                return _companyName;
            }
        }
        
        /// <include file='doc\RegisterLoadKeyAttribute.uex' path='docs/doc[@for="RegisterLoadKeyAttribute.ResourceId"]' />
        /// <devdoc>
        ///     Resource ID for VSPackage load key.
        /// </devdoc>
        public short ResourceId {
            get {
                return _resourceId;
            }
        }

        /// <summary>
        /// Registry Key name for this package's load key information.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string RegKeyName (RegistrationContext context)
        {
            return string.Format(CultureInfo.InvariantCulture, "Packages\\{0}", context.ComponentType.GUID.ToString("B"));
        }

        /// <include file='doc\RegisterLoadKeyAttribute.uex' path='docs/doc[@for="Register"]' />
        /// <devdoc>
        ///     Called to register this attribute with the given context.  The context
        ///     contains the location where the registration inforomation should be placed.
        ///     it also contains such as the type being registered, and path information.
        ///
        ///     This method is called both for registration and unregistration.  The difference is
        ///     that unregistering just uses a hive that reverses the changes applied to it.
        /// </devdoc>
        public override void Register(RegistrationContext context) {
            context.Log.WriteLine(SR.GetString(SR.Reg_NotifyLoadKey, CompanyName, ProductName, ProductVersion, MinimumEdition));

            using (Key packageKey = context.CreateKey(RegKeyName(context)))
            {
                packageKey.SetValue("ID", ResourceId);
                packageKey.SetValue("MinEdition", MinimumEdition);
                packageKey.SetValue("ProductVersion", ProductVersion);
                packageKey.SetValue("ProductName", ProductName);
                packageKey.SetValue("CompanyName", CompanyName);
            }
        }

        /// <summary>
        /// Unregisters this package's load key information
        /// </summary>
        /// <param name="context"></param>
        public override void Unregister(RegistrationContext context)
        {
            context.RemoveKey(RegKeyName(context));
        }

    }
}

