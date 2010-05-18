//------------------------------------------------------------------------------
// <copyright from='2003' to='2004' company='Microsoft Corporation'>           
//  Copyright (c) Microsoft Corporation, All rights reserved.             
//  This code sample is provided "AS IS" without warranty of any kind, 
//  it is not recommended for use in a production environment.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {

    using System;

    /// <summary>
    ///     This attribute defines the MSI component ID that is used by the 
    ///     MSI installer. This component ID is used to indicate the install
    ///     path to this component.  This must be placed on a package class
    ///     if the package is to be installed by MSI.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=false, Inherited=false)]
    public sealed class MsiComponentIdAttribute : Attribute {

        private string _id;
    
        /// <summary>
        ///     Creates a new MsiComponentIdAttribute.
        /// </summary>
        public MsiComponentIdAttribute (string id) {
            if (id == null) {
                throw new ArgumentNullException("id");
            }
            _id = id;
        }
        
        /// <summary>
        ///     Returns the component registration ID.
        /// </summary>
        public string Id {
            get {
                return _id;
            }
        }
    }
}

