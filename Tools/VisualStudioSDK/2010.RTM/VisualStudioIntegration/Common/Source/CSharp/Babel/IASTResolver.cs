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
	interface IASTResolver
	{
		IList<Declaration> FindCompletions(object result, int line, int col);
		IList<Declaration> FindMembers(object result, int line, int col);
		string FindQuickInfo(object result, int line, int col);
		IList<Method> FindMethods(object result, int line, int col, string name);
	}
}