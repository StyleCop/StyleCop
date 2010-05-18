/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using System;
namespace PropertyPageBase
{
	public delegate void StoreChangedDelegate();

	public interface IPropertyStore
	{
		void Dispose();
		void Initialize(object[] dataObject);
		void Persist(string propertyName, string propertyValue);
		string PropertyValue(string propertyName);

		event StoreChangedDelegate StoreChanged;
	}
}
