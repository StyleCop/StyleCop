/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using System;
using System.Drawing;
namespace PropertyPageBase
{
	public interface IPageView : System.IDisposable
	{
		void Initialize(System.Windows.Forms.Control parentControl, System.Drawing.Rectangle rectangle);
		void MoveView(System.Drawing.Rectangle rectangle);
		void ShowView();
		void HideView();

		int ProcessAccelerator(ref System.Windows.Forms.Message message);

		void RefreshPropertyValues();
	
		Size ViewSize { get; }
	}
}
