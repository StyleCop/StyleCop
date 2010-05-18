/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using System;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Shell;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Reflection;
using IServiceProvider = System.IServiceProvider;
using Microsoft.VisualStudio.OLE.Interop;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.VisualStudio.Package.Automation
{
	[SuppressMessage("Microsoft.Interoperability", "CA1405:ComVisibleTypeBaseTypesShouldBeComVisible")]
	[ComVisible(true), CLSCompliant(false)]
	public class OANestedProjectItem : OAProjectItem<NestedProjectNode>
	{
		#region fields
		EnvDTE.Project nestedProject = null;
		#endregion

		#region ctors
		public OANestedProjectItem(OAProject project, NestedProjectNode node)
			: base(project, node)
		{
			object nestedproject = null;
			if (ErrorHandler.Succeeded(node.NestedHierarchy.GetProperty(VSConstants.VSITEMID_ROOT, (int)__VSHPROPID.VSHPROPID_ExtObject, out nestedproject)))
			{
				this.nestedProject = nestedproject as EnvDTE.Project;
			}
		}

		#endregion

		#region overridden methods
		/// <summary>
		/// Returns the collection of project items defined in the nested project
		/// </summary>
		public override EnvDTE.ProjectItems ProjectItems
		{
			get
			{
				if (this.nestedProject != null)
				{
					return this.nestedProject.ProjectItems;
				}
				return null;
			}
		}

		/// <summary>
		/// Returns the nested project.
		/// </summary>
		public override EnvDTE.Project SubProject
		{
			get
			{
				return this.nestedProject;
			}
		}
		#endregion
	}
}
