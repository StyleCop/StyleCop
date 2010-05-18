/***************************************************************************
Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using System;
using System.Windows.Forms;

namespace PropertyPageBase
{
	public interface IPropertyPageUI
	{
		event UserEditCompleteHandler UserEditComplete;

		string GetControlValue(Control control);
		void SetControlValue(Control control, string value);
	}
}
