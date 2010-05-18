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

namespace Babel
{
	public struct Method
	{
		public string Name;
		public string Description;
		public string Type;
		public IList<Parameter> Parameters;
	}

	public struct Parameter
	{
		public string Name;
		public string Display;
		public string Description;
	}
}