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
using System.Text;
using Microsoft.VisualStudio.Shell.Interop;

using VSConstants = Microsoft.VisualStudio.VSConstants;

namespace Microsoft.VsSDK.UnitTestLibrary
{
	[CLSCompliant(false)]
	public class OutputWindowService : IVsOutputWindow
	{
		private Dictionary<Guid, string> paneList = new Dictionary<Guid, string>();

		#region IVsOutputWindow Members

		public int CreatePane(ref Guid rguidPane, string pszPaneName, int fInitVisible, int fClearWithSolution)
		{
			// Keep track of the created pane
			paneList.Add(rguidPane, pszPaneName);
			return VSConstants.S_OK;
		}

		public int DeletePane(ref Guid rguidPane)
		{
			paneList.Remove(rguidPane);
			return VSConstants.S_OK;
		}

		public int GetPane(ref Guid rguidPane, out IVsOutputWindowPane ppPane)
		{
			// First make sure the pane was created (we may need to add standard ones in the constructor)
			if (!paneList.ContainsKey(rguidPane))
				throw new ArgumentException("Could not find the requested pane, make sure you call CreatePane first");

			// Create a pane with the correct name
			ppPane = new OutputWindowPane(paneList[rguidPane]);
			return VSConstants.S_OK;
		}

		#endregion
	}
}
