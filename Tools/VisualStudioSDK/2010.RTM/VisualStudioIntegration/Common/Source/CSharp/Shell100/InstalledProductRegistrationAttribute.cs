//------------------------------------------------------------------------------
// <copyright from='2003' to='2004' company='Microsoft Corporation'>           
//  Copyright (c) Microsoft Corporation, All rights reserved.             
//  This code sample is provided "AS IS" without warranty of any kind, 
//  it is not recommended for use in a production environment.
// </copyright>                                                                
//------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.ComponentModel;

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
        private bool _useVsProductId = false;

        /// <summary>
        /// Creates a new InstalledProductRegistrationAttribute to register your package with Help/About dialog.
        /// This is the simplest registration information necessary for 3rd party packages. 
        /// Providing product details is not a requirement, but is recommended.
        /// </summary>
        public InstalledProductRegistrationAttribute (string productName, string productDetails, string productId) 
             : this(productName, productDetails, productId, false)
        {
        }

        /// <summary>
        /// Creates a new InstalledProductRegistrationAttribute to register your package with Help/About dialog.
        /// </summary>
        /// <param name="useVsProductId">
        ///     Reserved for Microsoft internal use.
        /// </param>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InstalledProductRegistrationAttribute (string productName, string productDetails, string productId, bool useVsProductId) 
        {
            _useVsProductId = useVsProductId;

            Initialize(productName, productDetails, productId);
        }
    
        /// <summary>
        /// Creates a new InstalledProductRegistrationAttribute to register your package with Help/About dialog.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This InstalledProductRegistrationAttribute constructor has been deprecated. Please use other constructor instead.")]    
        public InstalledProductRegistrationAttribute (bool useInterface, string productName, string productDetails, string productId) 
        {
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
                Initialize(productName, productDetails, productId);
            }
         }
                
        private void Initialize (string productName, string productDetails, string productId) 
        {   
            // This function should not be called if the product registration info is provided via interface
            if (UseInterface)
            {
                string errorMessage = string.Format(Resources.Culture, Resources.Reg_ErrorIncompatibleParametersValues, "useInterface", "productName");
                throw new ArgumentException(errorMessage);
            }
        
            // We are not using the interface, so we need the other parameters.
            // Let's check that they are not null or empty.
            if ((null == productName) || (productName.Trim().Length == 0))
                throw new ArgumentNullException("productName");
            productName = productName.Trim();

            // ProductDetails is not mandatory, but is recommended.
            if (null != productDetails)
                productDetails = productDetails.Trim();

            // If not using the same product ID as the rest of VS, then productId is required
            // When using the VS product ID, then PID should not be specified
            if (!UseVsProductId)
            {
                if ((null == productId) || (productId.Trim().Length == 0))
                    throw new ArgumentNullException("productId");
                productId = productId.Trim();
            }
            else
            {
                if (null != productId)
                {
                    string errorMessage = string.Format(Resources.Culture, Resources.Reg_ErrorIncompatibleParametersValues, "productId", "useVsProductId");
                    throw new ArgumentException(errorMessage);
                }
            }
            
            // Assign the values to the member variables
            _productName = productName;
            _productDetails = productDetails;
            _productId = productId;

            // Now that we know that the parameters are not empty, let's do a final
            // validation: the Help/About code assumes that if a registration is made
            // using a package, then both the product name and the product details are
            // id of resources (so they are supposed to be in the form "#nnn"), but if 
            // they are strings, then they both must be string (when product details are provided).
            if (!String.IsNullOrEmpty(ProductDetails))
            {
                if (((ProductNameResourceID != 0) && (ProductDetailsResourceID == 0)) ||
                    ((ProductNameResourceID == 0) && (ProductDetailsResourceID != 0)))
                {
                    // If we are here we have the resource id for only one entry and,
                    // according with the Help/About code, this is bad, so we have to
                    // throw an exception.
                    string errorMessage = string.Format(Resources.Culture, Resources.Reg_ErrorIncompatibleParametersTypes, "productName", "productDetails");
                    throw new ArgumentException(errorMessage);
                }
            }

            // Now check if the name and details are resource id because in this case
            // we have to use the package to register. Actually we check only the name
            // because of the previous test.
            _usePackage = (ProductNameResourceID != 0) ;
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
        
        /// <summary>
        /// True is the product ID is the same as VisualStudio ID
        /// This is reserved for Microsoft internal use. 3rd party packages should provide their own product ID when the class is constructed.
        /// </summary>
        public bool UseVsProductId 
        {
            get { return _useVsProductId; }
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
                context.Log.WriteLine(Resources.Reg_NotifyInstalledProduct, GetNonEmptyName(context), ProductId ?? ProductName);
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
                    if (UseVsProductId)
                    {
                        packageKey.SetValue("UseVsProductID", 1);
                    }
                    else
                    {
                        packageKey.SetValue("PID", ProductId);
                    }

                    // Product details are optional
                    if (!String.IsNullOrEmpty(ProductDetails))
                    {
                        packageKey.SetValue("ProductDetails", ProductDetails);
                    }

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

