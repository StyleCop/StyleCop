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
	/// <summary>
	/// Contains OAReferenceItem objects 
	/// </summary>
	[SuppressMessage("Microsoft.Interoperability", "CA1405:ComVisibleTypeBaseTypesShouldBeComVisible")]
	[ComVisible(true), CLSCompliant(false)]
	public class OAReferenceFolderItem : OAProjectItem<ReferenceContainerNode>
	{
		#region ctors
		public OAReferenceFolderItem(OAProject project, ReferenceContainerNode node)
			: base(project, node)
		{
		}

		#endregion

		#region overridden methods
		/// <summary>
		/// Returns the project items collection of all the references defined for this project.
		/// </summary>
		public override EnvDTE.ProjectItems ProjectItems
		{
			get
			{
				return new OANavigableProjectItems(this.Project, this.GetListOfProjectItems(), this.Node);
			}
		}


		#endregion

		#region Helper methods
		private List<EnvDTE.ProjectItem> GetListOfProjectItems()
		{
			List<EnvDTE.ProjectItem> list = new List<EnvDTE.ProjectItem>();
			for (HierarchyNode child = this.Node.FirstChild; child != null; child = child.NextSibling)
			{
				if (child is ReferenceNode)
				{
					list.Add(new OAReferenceItem(this.Project, child as ReferenceNode));
				}
			}

			return list;
		}
		#endregion
	}
}
