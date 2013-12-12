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
using System.Diagnostics.CodeAnalysis;

using VSConstants = Microsoft.VisualStudio.VSConstants;

namespace Microsoft.VsSDK.UnitTestLibrary
{
	[CLSCompliant(false)]
	[SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly")]
	public class OutputWindowPane : IVsOutputWindowPane
	{
		private string name = String.Empty;
		public OutputWindowPane(string paneName)
		{
			name = paneName;
		}

		#region IVsOutputWindowPane Members

		public int Activate()
		{
			return VSConstants.S_OK;
		}

		public int Clear()
		{
			return VSConstants.S_OK;
		}

		public int FlushToTaskList()
		{
			return VSConstants.S_OK;
		}

		public int GetName(ref string pbstrPaneName)
		{
			pbstrPaneName = name;
			return VSConstants.S_OK;
		}

		public int Hide()
		{
			return VSConstants.S_OK;
		}

		public int OutputString(string pszOutputString)
		{
			// We should setup this class and the OutputWindowService class such
			// that the test can listen to calls to ouput strings (including what
			// pane it is sent to), but in my current scenario this is not needed.
			return VSConstants.S_OK;
		}

		public int OutputStringThreadSafe(string pszOutputString)
		{
			return VSConstants.S_OK;
		}

		public int OutputTaskItemString(string pszOutputString, VSTASKPRIORITY nPriority, VSTASKCATEGORY nCategory, string pszSubcategory, int nBitmap, string pszFilename, uint nLineNum, string pszTaskItemText)
		{
			return VSConstants.S_OK;
		}

		public int OutputTaskItemStringEx(string pszOutputString, VSTASKPRIORITY nPriority, VSTASKCATEGORY nCategory, string pszSubcategory, int nBitmap, string pszFilename, uint nLineNum, string pszTaskItemText, string pszLookupKwd)
		{
			return VSConstants.S_OK;
		}

		public int SetName(string pszPaneName)
		{
			name = pszPaneName;
			return VSConstants.S_OK;
		}

		#endregion
	}
}
