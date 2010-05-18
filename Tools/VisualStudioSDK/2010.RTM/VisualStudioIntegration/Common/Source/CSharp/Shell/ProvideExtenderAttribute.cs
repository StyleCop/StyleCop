//------------------------------------------------------------------------------
// <copyright from='2003' to='2004' company='Microsoft Corporation'>           
//  Copyright (c) Microsoft Corporation, All rights reserved.             
//  This code sample is provided "AS IS" without warranty of any kind, 
//  it is not recommended for use in a production environment.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {

    using System;
    using System.Globalization;

    /// <summary>
    ///     This attribute registers the package as an extender.  The GUID passed in determines
    ///     what is being extended. The attributes on a package do not control the behavior of
    ///     the package, but they can be used by registration tools to register the proper
    ///     information with Visual Studio.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=true, Inherited=true)]
    public sealed class ProvideExtenderAttribute : RegistrationAttribute {

		private Guid CATID = Guid.Empty;
		private Guid extender = Guid.Empty;
		private string name;

		/// <summary>
		///     Creates a new ProvideExtenderAttribute.
		/// </summary>
		/// <param name="extendeeCatId">CatId of the element you want to extend.</param>
		/// <param name="extenderGuid">GUID of the extender.</param>
		/// <param name="extenderName">Name of the element you want to extend.</param>
		public ProvideExtenderAttribute(string extendeeCatId, string extenderGuid, string extenderName) 
		{
			CATID = new Guid(extendeeCatId);
			extender = new Guid(extenderGuid);
			name = extenderName;
		}

		/// <summary>
		/// The CatID of the element being extended.
		/// </summary>
		public Guid ExtendeeCatId {
			get {
				return CATID;
			}
		}

		/// <summary>
		/// The Guid of the extender.
		/// </summary>
		public Guid Extender {
			get {
				return extender;
			}
		}

		/// <summary>
		/// The name of the extender.
		/// </summary>
		public string ExtenderName {
			get {
				return name ;
			}
		}

		/// <summary>
		///		The reg key name of this Extender.
		/// </summary>
		private string RegKeyName 
		{
			get 
			{
				return string.Format(CultureInfo.InvariantCulture, "Extenders\\{0}\\{1}", CATID.ToString("B"), name);
			}
		}

		/// <summary>
		///     Called to register this attribute with the given context.  The context
		///     contains the location where the registration information should be placed.
		///     it also contains such as the type being registered, and path information.
		/// </summary>
		public override void Register(RegistrationContext context) 
		{
			context.Log.WriteLine(SR.GetString(SR.Reg_NotifyExtender, name, CATID.ToString("B")));

			using (Key childKey = context.CreateKey(RegKeyName))
			{
				// Set default value for the Key = Extender GUID
				childKey.SetValue(string.Empty, extender.ToString("B"));
			}
		}

		/// <summary>
		/// Unregister this Extender specification.
		/// </summary>
		public override void Unregister(RegistrationContext context)
		{
			context.RemoveKey(RegKeyName);
		}
	}
}

