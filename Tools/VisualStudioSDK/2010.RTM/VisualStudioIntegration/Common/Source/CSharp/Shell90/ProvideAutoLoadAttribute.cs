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
    public sealed class ProvideAutoLoadAttribute : RegistrationAttribute {

		private Guid loadGuid = Guid.Empty;

		/// <summary>
		///     Specify that the package should get loaded when this context is active.
		/// </summary>
		/// <param name="cmdUiContextGuid">Context which should trigger the loading of your package.</param>
		public ProvideAutoLoadAttribute(string cmdUiContextGuid) 
		{
			loadGuid = new Guid(cmdUiContextGuid);
		}

		/// <summary>
		/// Context Guid which triggers the loading of the package.
		/// </summary>
		public Guid LoadGuid
		{
			get
			{
				return loadGuid;
			}
		}

		/// <summary>
		///		The reg key name of this AutoLoad.
		/// </summary>
		private string RegKeyName 
		{
			get 
			{
				return string.Format(CultureInfo.InvariantCulture, "AutoLoadPackages\\{0}", loadGuid.ToString("B"));
			}
		}

		/// <summary>
		///     Called to register this attribute with the given context.  The context
		///     contains the location where the registration information should be placed.
		///     it also contains such as the type being registered, and path information.
		/// </summary>
		public override void Register(RegistrationContext context) 
		{
			context.Log.WriteLine(string.Format(Resources.Culture, Resources.Reg_NotifyAutoLoad, loadGuid.ToString("B")));

			using (Key childKey = context.CreateKey(RegKeyName))
                        {
			    childKey.SetValue(context.ComponentType.GUID.ToString("B"), 0);
			}
		}

		/// <summary>
		/// Unregister this AutoLoad specification.
		/// </summary>
		public override void Unregister(RegistrationContext context)
		{
			context.RemoveValue(RegKeyName, context.ComponentType.GUID.ToString("B"));
		}
	}
}

