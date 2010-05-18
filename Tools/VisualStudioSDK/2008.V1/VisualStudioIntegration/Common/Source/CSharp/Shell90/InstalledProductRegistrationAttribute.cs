//------------------------------------------------------------------------------
// <copyright from='2003' to='2004' company='Microsoft Corporation'>           
//  Copyright (c) Microsoft Corporation, All rights reserved.             
//  This code sample is provided "AS IS" without warranty of any kind, 
//  it is not recommended for use in a production environment.
// </copyright>                                                                
//------------------------------------------------------------------------------

using System;
using System.Globalization;

namespace Microsoft.VisualStudio.Shell 
{

    /// <summary>
    ///     This attribute registers an 'installed product' for your package.  
    ///     This enables your package to present information on the VS
    ///     Splash Screen or Help About.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited=false)]
    public sealed class InstalledProductRegistrationAttribute : RegistrationAttribute 
    {

        private string _productName;
        private string _name;
        private string _productId;
        private string _productDetails;
        private string _iconResourceId;
        private bool _useInterface = false;
        private bool _usePackage = false;
    
        /// <summary>
        /// Creates a new InstalledProductRegistrationAttribute to register your package with  
        /// Help/About and enables it to present informations on the VS Splash Screen.
        /// </summary>
        public InstalledProductRegistrationAttribute (bool useInterface, string productName, string productDetails, string productId) 
        {
            _usePackage = false;
            _useInterface = useInterface;
            if (_useInterface)
            {
                // If the object uses the interface in order to expose its informations to the
                // Help/About page, then the registration must use the package, otherwise there
                // is no way to know where to find such interface.
                _usePackage = true;
            }
            else
            {
                // We are not using the interface, so we need the other parameters.
                // Let's check that they are not null or empty.
                if ((null == productName) || (productName.Trim().Length == 0))
                    throw new ArgumentNullException("productName");
                productName = productName.Trim();

                if ((null == productDetails) || (productDetails.Trim().Length == 0))
                    throw new ArgumentNullException("productDetails");
                productDetails = productDetails.Trim();

                if ((null == productId) || (productId.Trim().Length == 0))
                    throw new ArgumentNullException("productId");
                productId = productId.Trim();

                // Assign the values to the member variables
                _productName = productName;
                _productDetails = productDetails;
                _productId = productId;

                // Now that we know that the parameters are not empty, let's do a final
                // validation: the Help/About code assumes that if a registration is made
                // using a package, then both the product name and the product details are
                // id of resources (so they are supposed to be in the form "#nnn"), but if 
                // they are strings, then they both must be string.
                if (((ProductNameResourceID != 0) && (ProductDetailsResourceID == 0)) ||
                    ((ProductNameResourceID == 0) && (ProductDetailsResourceID != 0)))
                {
                    // If we are here we have the resource id for only one entry and,
                    // according with the Help/About code, this is bad, so we have to
                    // throw an exception.
                    string errorMessage = string.Format(Resources.Culture, Resources.Reg_ErrorIncompatibleParametersTypes, "productName", "productDetails");
                    throw new ArgumentException(errorMessage);
                }

                // Now check if the name and details are resource id because in this case
                // we have to use the package to register. Actually we check only the name
                // because of the previous test.
                _usePackage = (ProductNameResourceID != 0) ;
            }
        }

        #region Properties
        /// <summary>
        /// Resource ID corresponding to the product name.
        /// </summary>
        public int ProductNameResourceID
        {
            get
            {
                if (_productName == null || _productName.Length < 2 || _productName[0]!='#' || !char.IsDigit(_productName[1]))
                    return 0;
                return int.Parse( _productName.Substring(1), CultureInfo.InvariantCulture);
            }
        }
        /// <summary>
        /// Resource ID for the details.
        /// </summary>
        public int ProductDetailsResourceID
        {
            get
            {
                if (_productDetails == null || _productDetails.Length < 2 || _productDetails[0]!='#' || !char.IsDigit(_productDetails[1]))
                    return 0;
                return int.Parse( _productDetails.Substring(1), CultureInfo.InvariantCulture);
            }
        }
        /// <summary>
        /// Resource ID of the icon.
        /// </summary>
        public int IconResourceID
        {
            get
            {
                if (String.IsNullOrEmpty(_iconResourceId) || _iconResourceId.Length < 2)
                    return 0;
                return int.Parse( _iconResourceId.Substring(1), CultureInfo.InvariantCulture);
            }
            set
            {
                _iconResourceId = @"#" + value.ToString(CultureInfo.InvariantCulture);
            }
        }
        /// <summary>
        /// Your product ID.
        /// </summary>
        public string ProductId
        {
            get {return _productId;}
        }
        /// <summary>
        /// The name of your product.
        /// </summary>
        public string ProductName
        {
            get { return _productName; }
        }

        /// <summary>
        /// The name of your product.
        /// </summary>
        public string LanguageIndependentName
        {
            get { return _name; }
            set { _name = value; }
        }

        private string GetNonEmptyName(RegistrationContext context)
        {
            string product = LanguageIndependentName;
            if (product != null)
                product = product.Trim();
            if (String.IsNullOrEmpty(product))
                product = context.ComponentType.Name;
            return product;
        }
        /// <summary>
        /// Detailed description of your product.
        /// </summary>
        public string ProductDetails
        {
            get {return _productDetails;}
        }
        /// <summary>
        /// Use IVsInstalledProduct to fill in the Help about dialog.
        /// The package must implement IVsInstalledProduct.
        /// </summary>
        public bool UseInterface
        {
            get {return _useInterface;}
        }
        /// <summary>
        /// True is the product installation will use the package ID
        /// </summary>
        public bool UsePackage {
            get 
            {
                return _usePackage;
            }
        }
        #endregion

        private string RegKeyName (RegistrationContext context)
        {
            return string.Format(CultureInfo.InvariantCulture, "InstalledProducts\\{0}", GetNonEmptyName(context));
        }



        /// <summary>
        ///     Called to register this attribute with the given context.
        /// </summary>
        /// <param name="context">
        ///     Contains the location where the registration information should be placed.
        ///     It also contains other information such as the type being registered and path information.
        /// </param>
        public override void Register(RegistrationContext context) 
        {
            if (UseInterface)
            {
                context.Log.WriteLine(Resources.Reg_NotifyInstalledProductInterface);
            }
            else
            {
                context.Log.WriteLine(Resources.Reg_NotifyInstalledProduct, GetNonEmptyName(context), ProductId);
            }

            using (Key packageKey = context.CreateKey(RegKeyName(context)))
            {

                // Set the 'Package' value if necessary
                if (UsePackage)
                {
                    packageKey.SetValue("Package", context.ComponentType.GUID.ToString("B"));
                }

                // Set the 'UseRegNameAsSplashName' flag if the user provided a short name that should be used on the splash screen
                if (!String.IsNullOrEmpty(_name))
                {
                    packageKey.SetValue("UseRegNameAsSplashName", 1);
                }

                // Set the 'UseInterface' value if necessary
                if (UseInterface)
                {
                    packageKey.SetValue("UseInterface", 1);
                }
                else
                {
                    // If UseInterface is 0, then the following are required for HelpAbout
                    packageKey.SetValue("", ProductName);
                    packageKey.SetValue("ProductDetails", ProductDetails);
                    packageKey.SetValue("PID", ProductId);

                    // The icon resource id reg entry is only valid if there 
                    // is a package satellite and not using the interface
                    if (UsePackage && !String.IsNullOrEmpty(_iconResourceId))
                    {
                        packageKey.SetValue("LogoID", _iconResourceId);
                    }
                }
            }
        }

        /// <summary>
        /// Unregister this InstalledProducts entry.
        /// </summary>
        /// <param name="context"></param>
        public override void Unregister(RegistrationContext context) 
        {
            context.RemoveKey(RegKeyName(context));
        }
    }
}

