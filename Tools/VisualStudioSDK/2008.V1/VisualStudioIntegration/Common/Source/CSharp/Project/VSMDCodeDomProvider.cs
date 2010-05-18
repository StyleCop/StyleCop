/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.CodeDom.Compiler;
using Microsoft.VisualStudio.Designer.Interfaces;
using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;
using IServiceProvider = System.IServiceProvider;

namespace Microsoft.VisualStudio.Package
{
	internal class VSMDCodeDomProvider : IVSMDCodeDomProvider
	{
		private CodeDomProvider provider;
		public VSMDCodeDomProvider(CodeDomProvider provider)
		{
			if (provider == null)
				throw new ArgumentNullException("provider");
			this.provider = provider;
		}

		#region IVSMDCodeDomProvider Members
		object IVSMDCodeDomProvider.CodeDomProvider
		{
			get { return provider; }
		}
		#endregion
	}
}
