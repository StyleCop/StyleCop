//------------------------------------------------------------------------------
// <copyright file="ProvideServiceAttribute.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {

    using System;
    using System.Globalization;

    /// <include file='doc\ProvideServiceAttribute.uex' path='docs/doc[@for="ProvideServiceAttribute"]' />
    /// <devdoc>
    ///     This attribute declares that a package provides a particular service.  The attributes on a 
    ///     package do not control the behavior of the package, but they can be used by registration 
    ///     tools to register the proper information with Visual Studio.
    /// </devdoc>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=true, Inherited=true)]
    public sealed class ProvideServiceAttribute : RegistrationAttribute {

        private string _name;
        private Guid _serviceGuid;
        private Type _serviceType;

        /// <param name="serviceType"></param>
        public ProvideServiceAttribute(object serviceType)
        {
            _serviceType = null;
            // figure out what type of object they passed in and get the GUID from it
            if (serviceType is string)
                _serviceGuid = new Guid((string)serviceType);
            else if (serviceType is Type)
            {
                _serviceType = (Type)serviceType;
                _serviceGuid = _serviceType.GUID;
                _name = _serviceType.Name;
            }
            else if (serviceType is Guid)
                _serviceGuid = (Guid)serviceType;
            else
                throw new ArgumentException(string.Format(Resources.Culture, Resources.Attributes_InvalidFactoryType, serviceType));
        }

        /// <summary>
        /// Name of the service
        /// </summary>
        public string ServiceName
        {
            get {return _name;}
            set {_name = value;}
        }

        /// <summary>
        /// Type of the service.
        /// </summary>
        public Type Service
        {
            get { return _serviceType; }
        }

        /// <include file='doc\ProvideServiceAttribute.uex' path='docs/doc[@for="ProvideServiceAttribute.ServiceType"]' />
        /// <devdoc>
        ///     Returns the service's Guid declared in this attribute.
        /// </devdoc>
        public Guid ServiceType {
            get {
                return _serviceGuid;
            }
        }

        private string ServiceRegKey
        {
            get { return string.Format(CultureInfo.InvariantCulture, "Services\\{0}", ServiceType.ToString("B")); }
        }

        /// <include file='doc\ProvideServiceAttribute.uex' path='docs/doc[@for="Register"]' />
        /// <devdoc>
        ///     Called to register this attribute with the given context.  The context
        ///     contains the location where the registration inforomation should be placed.
        ///     it also contains such as the type being registered, and path information.
        ///
        ///     This method is called both for registration and unregistration.  The difference is
        ///     that unregistering just uses a hive that reverses the changes applied to it.
        /// </devdoc>
        public override void Register(RegistrationContext context) {
            context.Log.WriteLine(string.Format(Resources.Culture, Resources.Reg_NotifyService, ServiceName));

            using (Key serviceKey = context.CreateKey(ServiceRegKey))
            {
                serviceKey.SetValue(string.Empty, context.ComponentType.GUID.ToString("B"));
                serviceKey.SetValue("Name", ServiceName);
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
            context.RemoveKey(ServiceRegKey);
        }
    }
}

