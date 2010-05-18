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

using MSBuild = Microsoft.Build.Framework;

namespace Microsoft.VsSDK.UnitTestLibrary
{
	public class MockBuildEngine : MSBuild.IBuildEngine
	{
		#region IBuildEngine Members

		public bool BuildProjectFile(string projectFileName, string[] targetNames, System.Collections.IDictionary globalProperties, System.Collections.IDictionary targetOutputs)
		{
			throw new NotImplementedException();
		}

		public void LogCustomEvent(Microsoft.Build.Framework.CustomBuildEventArgs e)
		{
			throw new NotImplementedException();
		}

		public void LogErrorEvent(Microsoft.Build.Framework.BuildErrorEventArgs e)
		{
		}

		public void LogMessageEvent(Microsoft.Build.Framework.BuildMessageEventArgs e)
		{
		}

		public void LogWarningEvent(Microsoft.Build.Framework.BuildWarningEventArgs e)
		{
		}

		public int ColumnNumberOfTaskNode
		{
			get {return 1;}
		}

		public bool ContinueOnError
		{
			get {return false;}
		}

		public int LineNumberOfTaskNode
		{
			get {return 1;}
		}

		public string ProjectFileOfTaskNode
		{
			get { return String.Empty; }
		}

		#endregion
	}
}
